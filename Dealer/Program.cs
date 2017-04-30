using Common.Lib.Models;
using Common.Lib.Interfaces;
using Common.Lib.Utility;
using System;
using System.Collections.Generic;
using System.Timers;
using XMLDB;
using System.Data;

namespace Dealer
{
    // Used by Program to advance gameplay
    enum GameState
    {
        WaitingForBet,
        CollectingBets,
        DealingCards,
        PlayerHits,
        PlayerStands,
        WaitingForPlayer,
        Calculating,
        GameOver
    }
    public class Program2
    {
        private Server server;
        private Timer gameTimer;
        public List<IPlayer> players;
        public List<IPlayer> addPlayers = new List<IPlayer>();
        public List<IPlayer> removePlayers = new List<IPlayer>();
        private GameState gameState;
        private int elapsedTime = 0;
        private int timeout = 0;
        public Boolean timeoutSignal = false;
        private IDbPersistence db;

        // Use to show Console lines with GameLoop progress
        private Boolean showDebug = true;

        static void Main(string[] args)
        {
            // Creates an instance of our program and runs it
            Program2 program2 = new Program2();
            program2.run();
        }

        private void run()
        {
            // Setup game timer
            gameTimer = new System.Timers.Timer(1000);
            gameTimer.AutoReset = true;
            gameTimer.Elapsed += OnTimedEvent;

            db = new XmlDbPersistence();

            if (!db.load())
            {
                db.initialize();
                db.save();
            }

            // Create players list
            players = new List<IPlayer>();

            // Create Dealer
            Player dealer = new Common.Lib.Models.Player();
            dealer.Name = "Dealer";
            players.Add(dealer);

            // This code sets up and starts the game server.
            server = new Server();
            server.OnDataReceived += Server_OnDataReceived;
            server.Start();

            // Start discovery server, allows players to find server and connect
            DiscoveryServer discoveryServer = new DiscoveryServer("Blackjack", server.GetPort());
            discoveryServer.Start();

            do
            {
                // Keep executing the GameLoop until all players are gone
                GameLoop();

            } while (players.Count > 1);
        }

        // Sync all players
        private void SyncPlayers()
        {
            CommandObject cmdObj = new CommandObject();
            cmdObj.Command = Command.Sync;
            cmdObj.Players = players;

            server.SendAll(cmdObj);
            System.Threading.Thread.Sleep(250);
        }
        
       // Persist a single player's balance
       private void PersistPlayerBalance(IPlayer player)
        {
            DataRow[] rows = db.query("Players", "Name = '" + player.Name + "'");
            if(rows.Length > 0)
            {
                db.update("Players", "Name ='" + player.Name + "'", "Balance=" + player.getCreditBalance());
                db.save();
            }
            else
            {
                DataRow row = db.ds.Tables["Players"].NewRow();
                row["Name"] = player.Name;
                row["Balance"] = player.getCreditBalance();
                db.insert("Players", row);
                db.save();
            }
        }

        // Retrieves the player's balance from data persistence
        private int GetPlayerBalance(IPlayer player)
        {
            DataRow[] rows = db.query("Players", "Name = '" + player.Name + "'");
            if(rows.Length > 0)
            {
                if((int)rows[0]["Balance"] < 1) return 100;
                return (int)rows[0]["Balance"];
            }
            return 100;
        }

        // When data is received from the clients this is where it will end up
        private void Server_OnDataReceived(object sender, DataReceivedEventArgs recEvent)
        {
            switch (recEvent.CmdObject.Command)
            {
                case Command.Bet:
                    if (gameState == GameState.WaitingForBet) gameState = GameState.CollectingBets;
                    players.Find(x => x.Name == ((Player)recEvent.CmdObject.Players[0]).Name).setWagerAmount(((Player)recEvent.CmdObject.Players[0]).WagerAmount);
                    players.Find(x => x.Name == ((Player)recEvent.CmdObject.Players[0]).Name).debitCreditBalance(((Player)recEvent.CmdObject.Players[0]).WagerAmount);
                    players.Find(x => x.Name == ((Player)recEvent.CmdObject.Players[0]).Name).advanceGameStatus();
                    if (showDebug) { Console.WriteLine("Bet Received from " + ((Player)recEvent.CmdObject.Players[0]).Name + " for " + ((Player)recEvent.CmdObject.Players[0]).WagerAmount.ToString() + " credits"); }
                    PersistPlayerBalance(players.Find(x => x.Name == ((Player)recEvent.CmdObject.Players[0]).Name));
                    SyncPlayers();
                    break;
                case Command.Exit:
                    removePlayers.Add(recEvent.CmdObject.Players[0]);
                    break;
                case Command.Hit:
                    gameState = GameState.PlayerHits;
                    break;
                case Command.Sync:
                    SyncPlayers();
                    break;
                case Command.Join:
                    if (recEvent.CmdObject.Response == Response.Accepted)
                    {
                        recEvent.CmdObject.Players[0].creditBalance = GetPlayerBalance(recEvent.CmdObject.Players[0]);

                        if (gameState != GameState.WaitingForBet && gameState != GameState.CollectingBets)
                        {
                            addPlayers.Add(recEvent.CmdObject.Players[0]);
                        }
                        else
                        {
                            players.Add((Player)recEvent.CmdObject.Players[0]);
                            SyncPlayers();
                        }
                    }
                    Console.WriteLine("Player (" + ((Player)recEvent.CmdObject.Players[0]).Name + ") joined");
                    break;
                case Command.Stand:
                    gameState = GameState.PlayerStands;
                    if (showDebug) { Console.WriteLine("Player " + ((Player)recEvent.CmdObject.Players[0]).Name + " stand"); }
                    timeoutSignal = true;
                    break;
            }
        }

        // Starts the GameTimer
        private void StartGameTimer(int timeout)
        {
            this.timeoutSignal = false;
            this.timeout = timeout;
            gameTimer.Enabled = true;
        }


        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            elapsedTime++;

            if (elapsedTime == timeout)
            {
                gameTimer.Stop();
                elapsedTime = 0;
                timeoutSignal = true;
            }
        }

        public void SetPlayerFocus(IPlayer focusPlayer)
        {
            foreach (Player player in players)
            {
                if (player.Equals(focusPlayer))
                {
                    player.setFocus(true);
                }
                else
                {
                    player.setFocus(false);
                }
            }
        }

        public void SetAllPlayersFocus(bool focus)
        {
            foreach (Player player in players)
            {
                player.setFocus(focus);
            }
        }

        public void AdvanceAllPlayers()
        {
            foreach (IPlayer player in players)
            {
                player.advanceGameStatus();
            }
        }

        private void TestGameOver()
        {
            foreach (IPlayer player in players)
            {
                if (player.Name != "Dealer")
                    PersistPlayerBalance(player);
            }

            SyncPlayers();

            Console.WriteLine("Before timer");
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("After timer");

            // Game Over
            gameState = GameState.GameOver;

            if (showDebug) { Console.WriteLine("Removing players..."); }
            foreach (Player player in removePlayers)
            {
                players.Remove(players.Find(x => x.Name == player.Name));
            }

            if (showDebug) { Console.WriteLine("Adding players..."); }
            foreach (Player player in addPlayers)
            {
                players.Add(player);
            }

            if (showDebug) { Console.WriteLine("Resetting players..."); }
            foreach (Player player in players)
            {
                player.WagerAmount = 0;
                player.gameStatus = 0;
                player.hasFocus = true;
                player.myHand = new Hand();
            }

            SyncPlayers();

            if (showDebug) { Console.WriteLine("Game Over"); }
            CommandObject cmdObj = new CommandObject();
            cmdObj.Command = Command.Message;
            cmdObj.Message = "GameOver";
            cmdObj.Players = players;
            server.SendAll(cmdObj);

            gameState = GameState.WaitingForBet;
        }

        // Checks players to see if everyone has bet
        public void CheckBets()
        {
            if (players.Count == 2) // 1 player
            {
                timeoutSignal = true;
            }
            else if (players.Count == 3) // 2 players
            {
                if (players[1].WagerAmount > 0 && players[2].WagerAmount > 0)
                {
                    timeoutSignal = true;
                }
            }
            else if (players.Count == 4) // 3 players
            {
                if (players[1].WagerAmount > 0 && players[2].WagerAmount > 0 && players[3].WagerAmount > 0)
                {
                    timeoutSignal = true;
                }
            }
            else if (players.Count == 5) // 4 players
            {
                if (players[1].WagerAmount > 0 && players[2].WagerAmount > 0 && players[3].WagerAmount > 0 && players[4].WagerAmount > 0)
                {
                    timeoutSignal = true;
                }
            }
        }

        // Checks for inactive players and disables them for round if inactive
        public void CheckForInactivePlayers()
        {
            foreach (Player player in players)
            {
                if (player.Name != "Dealer" && player.WagerAmount == 0)
                {
                    player.setGameStatus(8);
                    player.setFocus(false);
                }
            }
        }
    
        // Deals the first round of cards
        public void DealFirstRoundCards(IDeck deck)
        {
            foreach (Player player in players)
            {
                if (player.getGameStatus() != 8)
                {
                    player.dealCard(deck, false);
                    try
                    {
                        SyncPlayers();
                    }
                    catch (NullReferenceException e)
                    {
                        // Catch for Testing
                        Console.WriteLine("Testing catch for SyncPlayers");
                    }
                }
            }
        }

        // Deals the second round of cards
        public void DealSecondRoundCards(IDeck deck)
        {
            foreach (Player player in players)
            {
                if (player.getGameStatus() != 8)
                {
                    // If the player is the dealer then deal this card face down, else deal the card face up
                    if (player.Name.Equals("Dealer"))
                    {
                        player.dealCard(deck, true);
                    }
                    else
                    {
                        player.dealCard(deck, false);
                    }
                    try
                    {
                        SyncPlayers();
                    }
                    catch (NullReferenceException e)
                    {
                        // Catch for Testing
                        Console.WriteLine("Testing catch for SyncPlayers");
                    }
                }
            }
        }

        // Individual Hit/Stand
        private void IndividualHitStand(IDeck deck)
        {
            foreach (Player player in players)
            {
                if (!player.Name.Equals("Dealer") && player.WagerAmount > 0)
                {
                    if (showDebug) { Console.WriteLine(player.Name + "'s turn"); }
                    SetPlayerFocus(player);
                    player.advanceGameStatus();
                    SyncPlayers();

                    gameState = GameState.WaitingForPlayer;

                    StartGameTimer(25); //set to 25 for testing

                    // Loop while the player is hitting for 125 seconds
                    while (gameState != GameState.PlayerStands && !timeoutSignal)
                    {
                        if (gameState == GameState.PlayerHits)
                        {
                            if (showDebug) { Console.WriteLine(player.Name + " requested hit"); }

                            player.dealCard(deck, false);

                            if (player.scoreHand() > 21)
                            {
                                if (showDebug) { Console.WriteLine(player.Name + " bust"); }
                                player.setFocus(false);
                                timeoutSignal = true;
                                player.setGameStatus(4);
                            }

                            SyncPlayers();
                            gameState = GameState.WaitingForPlayer;
                        }
                    }

                }
            }
        }

        // Dealer's turn to hit/stand
        private void DealerHitStand(IDeck deck, IPlayer dealer)
        {
            while (dealer.scoreHand() < 17 && dealer.myHand.hand.Count < 5)
            {
                if (showDebug) { Console.WriteLine("Dealer requested hit"); }
                dealer.dealCard(deck, false);

                if (dealer.scoreHand() > 21)
                {
                    if (showDebug) { Console.WriteLine("Dealer bust"); }
                }
            }
        }

        // Determine how many credits to credit/debit
        private void DeterminePlayerScores(IPlayer dealer)
        {
            foreach (Player player in players)
            {

                if (player.Name != dealer.Name && player.WagerAmount > 0)
                {
                    if (player.scoreHand() == 99) // Player blackjack
                    {
                        if (showDebug) { Console.WriteLine(player.Name + " got a blackjack"); }
                        player.setGameStatus(7);
                        player.creditCreditBalance(player.WagerAmount * 3);
                    }

                    else if (player.scoreHand() > 21) // Player busts
                    {
                        if (showDebug) { Console.WriteLine(player.Name + " bust"); }
                        player.setGameStatus(4);

                    }

                    else if (player.scoreHand() <= 21) // Compare against dealer
                    {
                        if (dealer.scoreHand() > 21) //dealer busted, player wins
                        {
                            if (showDebug) { Console.WriteLine(player.Name + " wins"); }
                            player.setGameStatus(6);
                            player.creditCreditBalance(player.WagerAmount * 2);
                        }
                        else if (dealer.scoreHand() == player.scoreHand())  //push
                        {
                            if (showDebug) { Console.WriteLine(player.Name + " push"); }
                            player.setGameStatus(5);
                            player.creditCreditBalance(player.WagerAmount);
                        }
                        else if (player.scoreHand() > dealer.scoreHand()) //win
                        {
                            if (showDebug) { Console.WriteLine(player.Name + " wins"); }
                            player.setGameStatus(6);
                            player.creditCreditBalance(player.WagerAmount * 2);
                        }
                        else //loss
                        {
                            if (showDebug) { Console.WriteLine(player.Name + " loses"); }
                            player.setGameStatus(3);
                        }
                    }
                }
            }
        }

        // Persist All Player Balances at end of round
        private void PersistAllBalances() {
            foreach (IPlayer player in players)
            {
                if (player.Name != "Dealer")
                PersistPlayerBalance(player);
            }
            SyncPlayers();
        }

        // Remove players that have left
        public void RemovePlayers()
        {
            if (showDebug) { Console.WriteLine("Removing players..."); }
            foreach (Player player in removePlayers)
            {
                players.Remove(players.Find(x => x.Name == player.Name));
            }

            removePlayers.Clear();
        }

        // Add players that have joined
        public void AddPlayers()
        {
            if (showDebug) { Console.WriteLine("Adding players..."); }
            foreach (Player player in addPlayers)
            {
                players.Add(player);
            }

            addPlayers.Clear();
        }

        // Reset players at the end of the round
        public void ResetPlayers()
        {
            if (showDebug) { Console.WriteLine("Resetting players..."); }
            foreach (Player player in players)
            {
                player.WagerAmount = 0;
                player.gameStatus = 0;
                player.hasFocus = true;
                player.myHand = new Hand();
            }
        }

        // Sends the game over signal to clients
        private void SendGameOverSignal()
        {
            if (showDebug) { Console.WriteLine("Game Over"); }
            CommandObject cmdObj = new CommandObject();
            cmdObj.Command = Command.Message;
            cmdObj.Message = "GameOver";
            cmdObj.Players = players;
            server.SendAll(cmdObj);
        }

        // Game over method
        private void GameOver()
        {
            // Game Over
            gameState = GameState.GameOver;

            // Remove, Add, Reset Players
            RemovePlayers();
            AddPlayers();
            ResetPlayers();

            SyncPlayers();

            // Send Game Over Signal
            SendGameOverSignal();

            gameState = GameState.WaitingForBet;
        }

        private void GameLoop()
        {
            // Create card deck and shuffle, assign dealer
            IPlayer dealer = players[0];
            IDeck deck = new Deck();

            // Wait for first player to bet 
            if (showDebug) { Console.WriteLine("Waiting for first bet..."); }

            while (gameState == GameState.WaitingForBet)
            {
                // Wait for any player to place a bet
            }

            if (showDebug) { Console.WriteLine("Waiting for other bets..."); }

            // Start game timer and wait for betting to complete
            gameState = GameState.CollectingBets;
            StartGameTimer(25);

            while (!timeoutSignal)
            {
                // Wait for betting period to timeout, ends betting if everyone has placed a bet
                CheckBets();
            }

            // Betting is over so disable all players
            SetAllPlayersFocus(false);
            SyncPlayers();

            // Loop through players to see if active or not
            CheckForInactivePlayers();

            SyncPlayers();

            // Initial deal round 1
            if (showDebug) { Console.WriteLine("Dealing first round of cards"); }
            DealFirstRoundCards(deck);

            // Initial deal round 2
            if (showDebug) { Console.WriteLine("Dealing second round of cards"); }
            DealSecondRoundCards(deck);

            // Check for natural blackjack
            if (showDebug) { Console.WriteLine("Checking to see if Dealer has Natural Blackjack"); }

            // Check to see if dealer has Natural Blackjack (Face card and Ace = 21)
            if (players[0].scoreHand() == 99)
            {
                for (int i = 1; i < players.Count - 1; i++)
                {
                    // If player does not also have a Natural Blackjack then player loses wager
                    if (players[i].scoreHand() != 99)
                    {
                        if (showDebug) { Console.WriteLine("Player " + players[i].Name + " does not have natural blackjack to match dealer, player loses"); }
                        players[i].debitCreditBalance(players[i].getWagerAmount());
                        players[i].setWagerAmount(0);
                        players[i].setGameStatus(3);
                    }
                }

                SyncPlayers();
                PersistAllBalances();

                if (showDebug) { Console.WriteLine("Dealer got natural blackjack"); }

                // Game over so exit GameLoop
                if (showDebug) { Console.WriteLine("Showing results..."); }

                // Pause to show results on GUI
                System.Threading.Thread.Sleep(5000);

                GameOver();

                return;
            }

            // Loop through each player
            if (showDebug) { Console.WriteLine("Starting individual hit/stand"); }
            IndividualHitStand(deck);

            //set dealer game status to reveal hold card
            dealer.setGameStatus(9);

            if (showDebug) { Console.WriteLine("Dealer turn to hit/stand"); }

            // Remove focus from all players, and then allow dealer to hit/stand
            SetAllPlayersFocus(false);
            dealer.getCard(1).IsFaceDown = false;
            SyncPlayers();

            // Dealer Hit/Stand
            DealerHitStand(deck, dealer);

            gameState = GameState.Calculating;

            /* Loop through players */
            if (showDebug) { Console.WriteLine("Determining scores..."); }

            // Determine Score for Plays
            DeterminePlayerScores(dealer);

            // Persist Player Balances
            PersistAllBalances();

            if (showDebug) { Console.WriteLine("Showing results..."); }
            System.Threading.Thread.Sleep(5000);

            // Game Over
            GameOver();
        }
    }
}
