using Common.Lib.Models;
using Common.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Timers;

namespace Dealer
{
    //used by Program to advance gameplay
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
    class Program2
    {
        private Server server;
        private Timer gameTimer;
        private List<IPlayer> players;
        private List<IPlayer> addPlayers = new List<IPlayer>();
        private List<IPlayer> removePlayers = new List<IPlayer>();
        private GameState gameState;
        private int elapsedTime = 0;
        private int timeout = 0;
        private Boolean timeoutSignal = false;
       
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

            /* This code sets up and starts the discovery server.
             * The discovery server allows the player application to find our 
             * server and connect to it.
             */
            DiscoveryServer discoveryServer = new DiscoveryServer("Blackjack", server.GetPort());
            discoveryServer.Start();

            do
            {
                // Start executing the game logic
                GameLoop();

            } while (players.Count > 1);
        }


        private void SyncPlayers()
        {
            CommandObject cmdObj = new CommandObject();
            cmdObj.Command = Command.Sync;
            cmdObj.Players = players;

            server.SendAll(cmdObj);
            System.Threading.Thread.Sleep(100);
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
                    //Console.WriteLine("Credits are " + players.Find(x => x.Name == ((Player)recEvent.CmdObject.Payload).Name).getCreditBalance().ToString());
                    SyncPlayers();
                    break;
                case Command.Exit:
                    removePlayers.Add(recEvent.CmdObject.Players[0]);
                    break;
                case Command.Hit:
                    gameState = GameState.PlayerHits;
                    break;
                case Command.Sync:
                    //Used for first load of UI for players to sync data
                    //Console.WriteLine("Trying to sync...");
                    SyncPlayers();
                    break;
                case Command.Join:
                    if (recEvent.CmdObject.Response == Response.Accepted)
                    {
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
                    //gameTimer.Stop();
                    timeoutSignal = true;
                    break;
            }
        }

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

        /// <summary>
        /// This is where the logic for the game will reside
        /// </summary>
        private Boolean Winner = true;

        private void SetPlayerFocus(Player focusPlayer)
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

        private void SetAllPlayersFocus(bool focus)
        {
            foreach (Player player in players)
            {
                player.setFocus(focus);
            }
        }

        private void AdvanceAllPlayers()
        {
            foreach (IPlayer player in players)
            {
                player.advanceGameStatus();
            }
        }
        private void GameLoop()
        {

            IPlayer dealer = players[0];
            // Create card deck and shuffle
            IDeck deck = new Deck();

            // Wait for first player to bet 
            //      start countdown timer, 30 seconds
            //      Collect bets from player until timer hits 0

            if (showDebug) { Console.WriteLine("Waiting for first bet...    GS: " + gameState); }

            while (gameState == GameState.WaitingForBet)
            {
                // Wait for any player to place a bet

            }

            if (showDebug) { Console.WriteLine("Waiting for other bets...    GS: " + gameState); }

            gameState = GameState.CollectingBets;

            // Start game timer and wait for betting to complete
            StartGameTimer(15);

            while (!timeoutSignal)
            {
                // Wait for betting period to timeout

                // Ends betting if everyone has placed a bet
                if (players.Count == 2)
                {
                    // Continue on
                    //gameTimer.Stop();
                    timeoutSignal = true;
                }
                else if (players.Count == 3)
                {
                    if (players[1].WagerAmount > 0 && players[2].WagerAmount > 0)
                    {
                        //gameTimer.Stop();
                        timeoutSignal = true;
                    }
                }
                else if (players.Count == 4)
                {
                    if (players[1].WagerAmount > 0 && players[2].WagerAmount > 0 && players[3].WagerAmount > 0)
                    {
                        //gameTimer.Stop();
                        timeoutSignal = true;
                    }
                }
                else if (players.Count == 5)
                {
                    if (players[1].WagerAmount > 0 && players[2].WagerAmount > 0 && players[3].WagerAmount > 0 && players[4].WagerAmount > 0)
                    {
                        //gameTimer.Stop();
                        timeoutSignal = true;
                    }
                }

            }

            // Betting is over so disable all players
            SetAllPlayersFocus(false);
            //AdvanceAllPlayers();
            SyncPlayers();

            // Loop through players to see if active or not
            foreach (Player player in players)
            {
                if (player.Name != "Dealer" && player.WagerAmount == 0)
                {
                    // Inactive
                    player.setGameStatus(8);
                    player.setFocus(false);
                }
            }
            SyncPlayers();

            // Loop through players and dealer twice
            //      Deal cards starting with player one:
            //      The dealer gives one card face up to each player in rotation, and then 
            //      one card face up to himself. 
            //      Another round of cards is then dealt
            //      face up to each player, but the dealer takes his second card face down.
            // End loop

            if (showDebug) { Console.WriteLine("Dealing first round of cards"); }

            // Initial deal round 1
            foreach (Player player in players)
            {
                if (player.getGameStatus() != 8)
                {
                    player.dealCard(deck, false);
                    //Console.WriteLine(player.myHand.getCard(0).Description + " card delt to " + player.Name);
                    SyncPlayers();
                }
            }

            if (showDebug) { Console.WriteLine("Dealing second round of cards"); }

            // Initial deal round 2
            foreach (Player player in players)
            {
                if (player.getGameStatus() != 8)
                {
                    // If the player is the dealer then deal this card face down
                    // Else deal the card face up
                    if (player.Name.Equals("Dealer"))
                    {
                        player.dealCard(deck, true);
                        //Console.WriteLine(player.myHand.getCard(1).Description + " card delt to " + player.Name);
                    }
                    else
                    {
                        player.dealCard(deck, false);
                        //Console.WriteLine(player.myHand.getCard(1).Description + " card delt to " + player.Name);
                    }
                    SyncPlayers();
                }
            }

            // Check for natural blackjack
            //      If the dealer has a natural, he immediately collects the bets of all players 
            //      who do not have naturals, (but no additional amount). If the dealer and another 
            //      player both have naturals, the bet of that player is a push (a tie), and 
            //      the player takes back his chips.

            //      If the dealer's face-up card is a ten-card or an ace, he looks at his face-down 
            //      card to see if the two cards make a natural. If the face-up card is not a 
            //      ten -card or an ace, he does not look at the face-down card until it is 
            //      the dealer's turn to play.
            // End Check

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

                // Game over so exit GameLoop
                return;
            }

            // Loop through each player
            //      Loop until player stands
            //          Deal card on hit
            //          Check hand score to see if it is a blackjack or bust
            //          If hand is a blackjack payout and exit loop
            //          If hand is a bust then exit loop
            //      End loop
            // End loop

            if (showDebug) { Console.WriteLine("Starting individual hit/stand"); }
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

                    /* Loop while the player is hitting
                     * If player does not hit within one minute then they automatically stand
                     * and the game will continue.
                    */
                    
                    while (gameState != GameState.PlayerStands && !timeoutSignal)
                    {
                        if (gameState == GameState.PlayerHits)
                        {
                            if (showDebug) { Console.WriteLine(player.Name + " requested hit"); }

                            player.dealCard(deck, false);

                            if (player.scoreHand() > 21)
                            {
                                player.setFocus(false);
                                //gameTimer.Stop();
                                timeoutSignal = true;
                                if (showDebug) { Console.WriteLine(player.Name + " bust"); }
                                player.setGameStatus(4);
                            }

                            SyncPlayers();
                            gameState = GameState.WaitingForPlayer;
                        }
                    }

                }
            }

            /* Dealer play
             * Turn face down card face up
             * While hand score is less than 17
             * Dealer must hit until 17 or more
             * End While
            */

            //set dealer game status to reveal hold card
            dealer.setGameStatus(9);


            if (showDebug) { Console.WriteLine("Dealer turn to hit/stand"); }

            SetAllPlayersFocus(false);
            dealer.getCard(1).IsFaceDown = false;
            SyncPlayers();

            while (dealer.scoreHand() < 17 && dealer.myHand.hand.Count < 5)
            {
                if (showDebug) { Console.WriteLine("Dealer requested hit"); }
                dealer.dealCard(deck, false);

                if (dealer.scoreHand() > 21)
                {
                    if (showDebug) { Console.WriteLine("Dealer bust"); }
                }
            }

            gameState = GameState.Calculating;



            /* Loop through players
             * If score is push then return bet to player
             * If score beats dealer payout
             * If score does not beat dealer then dealer collects bet
             * End loop
            */

            if (showDebug) { Console.WriteLine("Determining scores..."); }

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
                            player.debitCreditBalance(player.WagerAmount);
                        }
                    }
                }
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
    }
}
