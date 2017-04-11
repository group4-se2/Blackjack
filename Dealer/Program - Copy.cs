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
        private List<Player> players;
        private GameState gameState;
        private int elapsedTime = 0;
        private int timeout = 0;
        private Boolean timeoutSignal = false;

        static void Main(string[] args)
        {
            // Creates an instance of our program and runs it
            Program2 program2 = new Program2();
            program2.run();

            //temporary for testing
            Console.ReadLine();
        }

        private void run()
        {
            // Setup game timer
            gameTimer = new System.Timers.Timer(1000);
            gameTimer.AutoReset = true;
            gameTimer.Elapsed += OnTimedEvent;

            // Create players list
            players = new List<Player>();

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

            // Start executing the game logic
            GameLoop();

            //temporary for testing
            /*Console.ReadLine();
            Player player = new Player();
            player.Name = "Tim";
            
            players.Add(player);

            Player player2 = new Player();
            player2.Name = "Julian";

            players.Add(player2);

            SyncPlayers();
            */
            /*CommandObject cmdObj = new CommandObject();
            cmdObj.Command = Command.Sync;
            cmdObj.Payload = player;
            server.Send("Tim", cmdObj); */

        }

        //
        private void SyncPlayers()
        {
            CommandObject cmdObj = new CommandObject();
            cmdObj.Command = Command.Sync;
            cmdObj.Payload = players;

            Console.WriteLine(players[1].Name + " credits are " + players[1].getCreditBalance().ToString());
            server.SendAll(cmdObj);

        }

        /// <summary>
        /// When data is received from the clients this is where it will end up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="recEvent"></param>
        private void Server_OnDataReceived(object sender, DataReceivedEventArgs recEvent)
        {
            switch (recEvent.CmdObject.Command)
            {
                case Command.Bet:
                    if (gameState == GameState.WaitingForBet) gameState = GameState.CollectingBets;
                    players.Find(x => x.Name == ((Player)recEvent.CmdObject.Payload).Name).setWagerAmount(((Player)recEvent.CmdObject.Payload).WagerAmount);
                    players.Find(x => x.Name == ((Player)recEvent.CmdObject.Payload).Name).debitCreditBalance(((Player)recEvent.CmdObject.Payload).WagerAmount);
                    Console.WriteLine("Bet Received from " + ((Player)recEvent.CmdObject.Payload).Name + " for " + ((Player)recEvent.CmdObject.Payload).WagerAmount.ToString() + " credits");
                    Console.WriteLine("Credits are " + players.Find(x => x.Name == ((Player)recEvent.CmdObject.Payload).Name).getCreditBalance().ToString());
                    SyncPlayers();
                    break;
                case Command.Exit:
                    players.Remove(players.Find(x => x.Name == ((Player)recEvent.CmdObject.Payload).Name));
                    SyncPlayers();
                    break;
                case Command.Hit:
                    gameState = GameState.PlayerHits;
                    break;
                case Command.Sync:
                    // Used for first load of UI for players to sync data
                    //Console.WriteLine("Trying to sync...");
                    SyncPlayers();
                    break;
                case Command.Join:
                    if (recEvent.CmdObject.Response == Response.Accepted)
                    {
                        players.Add((Player)recEvent.CmdObject.Payload);
                        SyncPlayers();
                    }
                    Console.WriteLine("Player (" + ((Player)recEvent.CmdObject.Payload).Name + ") joined");
                    break;
                case Command.Stand:
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

        private void GameLoop()
        {
            Player dealer = players[0];
            // Create card deck and shuffle
            IDeck deck = new Deck();

            // Wait for first player to bet 
            //      start countdown timer, 30 seconds
            //      Collect bets from player until timer hits 0

            Console.WriteLine("Waiting for bet...");

            while (gameState == GameState.WaitingForBet)
            {
                // Wait for any player to place a bet
                
            }

            gameState = GameState.CollectingBets;

            // Start game timer and wait for betting to complete
            StartGameTimer(10);

            while (!timeoutSignal)
            {
                // Wait for betting period to timeout
            }

            // Betting is over so disable all players
            SetAllPlayersFocus(false);
            SyncPlayers();

            // Loop through players and dealer twice
            //      Deal cards starting with player one:
            //      The dealer gives one card face up to each player in rotation, and then 
            //      one card face up to himself. 
            //      Another round of cards is then dealt
            //      face up to each player, but the dealer takes his second card face down.
            // End loop

            // Initial deal round 1
            foreach (Player player in players)
            {
                player.dealCard(deck, false);
                Console.WriteLine("Card delt to " + player.Name);
                SyncPlayers();
            }

            // Initial deal round 2
            foreach (Player player in players)
            {
                // If the player is the dealer then deal this card face down
                // Else deal the card face up
                if (player.Name.Equals("Dealer"))
                {
                    player.dealCard(deck, true);
                }
                else
                {
                    player.dealCard(deck, false);
                }
                SyncPlayers();
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

            // Check to see if dealer has Natural Blackjack (Face card and Ace = 21)
            if (players[0].scoreHand() == 99)
            {
                for (int i = 1; i < players.Count - 1; i++)
                {
                    // If player does not also have a Natural Blackjack then player loses wager
                    if (players[i].scoreHand() != 99)
                    {
                        players[i].debitCreditBalance(players[i].getWagerAmount());
                        players[i].setWagerAmount(0);
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

            foreach (Player player in players)
            {
                if (!player.Name.Equals("Dealer"))
                {
                    SetPlayerFocus(player);
                    SyncPlayers();

                    gameState = GameState.WaitingForPlayer;
                    StartGameTimer(60);

                    // Loop while the player is hitting
                    // If player does not hit within one minute then they automatically stand
                    // and the game will continue.
                    while (gameState != GameState.PlayerStands && !timeoutSignal)
                    {
                        if(gameState == GameState.PlayerHits)
                        {
                            player.dealCard(deck, false);
                            SyncPlayers();
                            gameState = GameState.WaitingForPlayer;
                        }
                    }
                    gameTimer.Stop();
                }
            }

            // Dealer play
            // Turn face down card face up
            // While hand score is less than 17
            //      Dealer must hit until 17 or more
            // End While

            SetAllPlayersFocus(false);
            dealer.getCard(1).IsFaceDown = false;
            SyncPlayers();
            while(dealer.scoreHand() < 17)
            {
                dealer.dealCard(deck, false);
            }

            gameState = GameState.Calculating;

            // Loop through players
            //      If score is push then return bet to player
            //      If score beats dealer payout
            //      If score does not beat dealer then dealer collects bet
            // End loop

            foreach(Player player in players)
            {
                if (player.scoreHand() < 22)
                {
                    if (dealer.scoreHand() < player.scoreHand())
                    {
                        player.creditCreditBalance(player.getWagerAmount() * 2);
                        player.setWagerAmount(0);
                    }
                    if (dealer.scoreHand() > player.scoreHand())
                    {
                        player.debitCreditBalance(player.getWagerAmount());
                        player.setWagerAmount(0);
                    }
                }
            }
            SyncPlayers();

            // Game Over
            gameState = GameState.GameOver;
        }
    }
}
