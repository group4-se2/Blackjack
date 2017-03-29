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

            Console.ReadLine();

            Player player = new Player();
            player.Name = "Tim";
            CommandObject cmdObj = new CommandObject();
            cmdObj.Command = Command.Sync;
            cmdObj.Payload = player;
            server.Send("Tim",cmdObj);
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
        private Boolean Winner = true;

        private void GameLoop()
        {
            do
            {
        private void placeFirstBet()
        {
            do
            {
                if (player1 === hasFocus)
                {
                    placeBets(); //CREATE METHOD
                    calcBank();
                }
                else if (player2 === hasFocus)
                {
                    placeBets();
                    calcBank();
                }
                else if (player3 === hasFocus)
                {
                    placeBets();
                    calcBank();
                }
                else (dealer === hasFocus)
                    {
                    placeBets();
                    calcBank();
                }
                while (BetTimer != 0) ;
            }
            if (placeBets === 0 && BetTimer === 0)
            {
                disable Player();  //CREATE METHOD
            }
            else
                return FirstDeal{);
            }
        // Wait for first player to bet 
        //      start countdown timer, 30 seconds
        //      Collect bets from player until timer hits 0
        private void FirstDeal();
         {
         for (player = 0; player <= 4; player++)
            {
                for (dealCardUp = 0; dealCardUp <=8; dealCardUp++)
            }
                if (dealCardUp === ArrayElement8)
                    {
                        return dealCardDown;          //CREATE METHOD
                    }
                else 
                    {
                        return checkDealerHand();
                    }  
            }
        // Loop through players and dealer twice
        //      Deal cards starting with player one:
        //      The dealer gives one card face up to each player in rotation, and then 
        //      one card face up to himself. 
        //      Another round of cards is then dealt
        //      face up to each player, but the dealer takes his second card face down.
        // End loop
        private void checkDealerHand();
            {
                if (dealerUpCard === 10 || ‘Ace’) 
                {
                    return checkNaturalBJ;
                    dealerSumHand = dealerUpCard + dealerDownCard;
                    return dealerSumHand;
                }  
                else (dealerUpCard != 10 || ‘Ace’)
                {
                    return playerTurn;
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
            private void checkNaturalBJ();
                {
                    if(dealerSumHand === 21)
                    {
                        return SumofBets; 
                        return UpdateDealerBank; 
                    }
                    else if (dealerSumHand && playerSumHand === 21)
                    {
                        return SumofBets2; 
                        return UpdateDealerBank2; 
                        return UpdatePlayerBank;
                    }
                    else
                    {
                        return playerTurn;
                    }
                }
    
        // Loop through each player
        //      Loop until player stands
        //          Deal card on hit
        //          Check hand score to see if it is a blackjack or bust
        //          If hand is a blackjack payout and exit loop
        //          If hand is a bust then exit loop
        //      End loop
        // End loop
       private void playerTurn();
        {
        do
            {
                for (player = 0; player <= 3; player++)
                    {
                        if (playerHand === 21)
                            {
                             return SumofBets;
                             return ExitGame;                   //Create Method
                            }
                        else if (playerHand <= 21)
                            {
                             return HitOption;                    //Create Method
                            }
                        else if (playerHand > 21)
                            {
                             return BustOption;                   //Create Method
                            }
                        else if (playerHand <=21 && != HitOption)
                            {
                             return StandOption;                  //Create Method
                            }
                        else 
                        {
                        return dealerTurn();
                        }                
                    }
            }
        while (PlayerHand != BustOption);
        }

        // Dealer play
        // Turn face down card face up
        // While hand score is less than 17
        //      Dealer must hit until 17 or more
        // End While
        private void dealerTurn();
        {
        do 
          {
            if (dealerHand <= 17)
            {
                dealerSumHand = dealerUpCard + dealerDownCard;
                return dealerSumHand;
                return HitOption;
            }
        while
            {
            (dealerSumHand< 17);
            }
        }



        // Loop through players
        //      If score is push then return bet to player
        //      If score beats dealer payout
        //      If score does not beat dealer then dealer collects bet
        // End loop

        // Game Over
    }
    while
    {
        (Winner === false);
    }
}
   
}


//CREATED METHODS


private int calcBank();
{
   newBalance = Bet – Balance;
   return newBalance;
}


 private void BetTimer(object sender, EventArgs e)
{

    Label timeLabel = new Label();

    // Start the timer
    timeLeft = 30;
    timeLabel.Text = timeLeft + "s";
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

private int SumofBets();
{
  collectAllBets = player1Bet + player2Bet + player3Bet + DealerBet;
  return collectAllBets;
}


private int UpdateDealerBank();
{
  UpdateDealerCash = DealerBank + collectAllBets;
  return UpdateDealerCash;  
}

private int SumofBets2();
{
  if (player1Hand === 21)
    {
    collectBets1 = player2Bet + player3Bet;
    return collectBets1;
    }
  else if (player2Hand === 21)
    {
    collectBets2 = player1Bet + player3Bet;
    return collectBets2;
    }
  else (player3Hand === 21)
    {
    collectBets1 = player1Bet + player2Bet;
    return collectBets3;
    }
}

collectAllBets = player1Bet + player2Bet + player3Bet;
  return collectAllBets;
}


private int UpdateDealerBank2();
{
  if (SumofBets2 === collectBets1)
     {
     UpdateDealerCash = DealerBank + collectBets1;
     return UpdateDealerCash2;  
     }
  else if(SumofBets2 === collectBets2)
     {
     UpdateDealerCash = DealerBank + collectBets2;
     return UpdateDealerCash2;  
     }
  else (SumofBets2 === collectBets3)
     {
     UpdateDealerCash = DealerBank + collectBets3; 
     return UpdateDealerCash2;  
     }
}


private int UpdatePlayerBank();
{
  if (collectBets1)
     {
       UpdatePlayerCash1 = PlayerBank + collectBets1;
       return UpdatePlayerCash1;
     }
  else if (collectBets2)
     {
       UpdatePlayerCash2 = PlayerBank + collectBets2;
       return UpdatePlayerCash2;
     }
  else (collectBets1)
     {
       UpdatePlayerCash3 = PlayerBank + collectBets3;
       return UpdatePlayerCash3;
     }
}
