using Common.Lib.Models;
using Common.Lib.Interfaces;
using System;
using System.Collections.Generic;

namespace Dealer
{
    class Program
    {
        Server server;
        private List<Player> players;
        static void Main(string[] args)
        {
            // Creates an instance of our program and runs it
            Program program = new Program();
            program.run();

            // Demonstration of drawing a card from the deck and displaying it

            //char[] face = new char[3] { 'J', 'Q', 'K' };
            //Deck deck = new Deck();
            //for (int i = 0; i < 52; i++)
            //{
            //    ICard card = deck.drawCard();
            //    if (card.CardType == CardType.Pip)
            //        Console.WriteLine((i + 1) + " " + card.Value.ToString() + " " + card.Suit.ToString());
            //    else if(card.CardType == CardType.Face)
            //        Console.WriteLine((i + 1) + " " + face[card.Value - 11] + " " + card.Suit.ToString());
            //    else if (card.CardType == CardType.Ace)
            //        Console.WriteLine((i + 1) + " " + "A " + card.Suit.ToString());
            //}
            //Console.WriteLine(deck.Cards.Count);

            Console.ReadLine();
        }

        private void run()
        {
            // Create players list
            players = new List<Player>();
            // This code sets up and starts the game server.
            server = new Server();
            server.OnDataReceived += Server_OnDataReceived;
            server.Start();

            // This code sets up and starts the discovery server.
            // The discovery server allows the player application to find our server and connect to it.
            DiscoveryServer discoveryServer = new DiscoveryServer("Blackjack", server.GetPort());
            discoveryServer.Start();

            // Start executing the game logic
            GameLoop();
        }

        /// <summary>
        /// When data is received from the clients this is where it will end up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Server_OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            CommandObject cmdObj = new CommandObject();
            //Player player = (Player)e.CmdObject.Payload;
            //Console.WriteLine(player.Name);
            switch(e.CmdObject.Command)
            {
                case Command.Bet:
                    break;
                case Command.Exit:
                        players.Remove(players.Find(x => x.Name == ((Player)e.CmdObject.Payload).Name));
                        cmdObj.Command = Command.Sync;
                        cmdObj.Payload = players;
                        server.SendAll(cmdObj);
                    break;
                case Command.Hit:
                    break;
                case Command.Join:
                    if (e.CmdObject.Response == Response.Accepted)
                    {
                        players.Add((Player)e.CmdObject.Payload);
                        cmdObj.Command = Command.Sync;
                        cmdObj.Payload = players;
                        server.SendAll(cmdObj);
                    }
                    break;
                case Command.Stand:
                    break;
            }
        }

        /// <summary>
        /// This is where the logic for the game will reside
        /// </summary>
        private void GameLoop()
        {
            private int timeLeft;
            private string timeLabel;
            private void BetTimer;
            private int getWagerAmount;


        // Get Focus for Player 1
        // Player 1 places bet....if/else statement
        // Start Timer
        // Get Focus for Player 2
        // Player 2 places bet
        // Get Focus for Player 3
        // Player 3 places bet
        // Get Focus for Player 4
        // Player 4 places bet
        // End Timer if Timer reaches zero, any player that does not bet does not play the game.
        
        for (getWagerAmount = 0; getWagerAmount <= 4; getWagerAmount++)
                return getWageramount();


        private void BetTimer(object sender, EventArgs e)
        {

            Label timeLabel = new Label();

            // Start the timer
            timeLeft = 30;
            timeLabel.Text = timeLeft + "s"; ;
            BetTimer.Start();


            // Timer counts down from 30 and displays the time left.
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + "s";
            }
            // Counter reaches zero, it will stop and display out of time message.
            else
            {
                BetTimer.Stop();
                timeLabel.Text = "Your time is up!";
            }
        }

        // Wait for first player to bet 
        //      start countdown timer, 30 seconds
        //      Collect bets from player until timer hits 0



        private void dealCardUp();
        
            for(dealCardUp = 0; dealCardUp <= 4; dealCardUp++)
            return dealCard();


        // Loop through players and dealer twice
        //      Deal cards starting with player one:
        //      The dealer gives one card face up to each player in rotation, and then 
        //      one card face up to himself. 
        //      Another round of cards is then dealt
        //      face up to each player, but the dealer takes his second card face down.
        // End loop

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

        // Loop through each player
        //      Loop until player stands
        //          Deal card on hit
        //          Check hand score to see if it is a blackjack or bust
        //          If hand is a blackjack payout and exit loop
        //          If hand is a bust then exit loop
        //      End loop
        // End loop

        // Dealer play
        // Turn face down card face up
        // While hand score is less than 17
        //      Dealer must hit until 17 or more
        // End While

        // Loop through players
        //      If score is push then return bet to player
        //      If score beats dealer payout
        //      If score does not beat dealer then dealer collects bet
        // End loop

        // Game Over
    }
}
}
