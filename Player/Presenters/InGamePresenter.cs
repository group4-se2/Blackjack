using System;
using System.Windows.Forms;
using Player.Interfaces;
using Common.Lib.Interfaces;
using System.Collections.Generic;
using Common.Lib.Models;
using System.Diagnostics;

namespace Player.Presenters
{
    public class InGamePresenter : IInGamePresenter
    {
        IInGameModel model;
        IInGameView view;
        public Client client { get; set; }

        public InGamePresenter(IInGameModel model, IInGameView view, Client client)
        {
            this.model = model;
            this.view = view;
            this.client = client;
            
            view.InGamePresenter = this;
        }
        
        public DialogResult ShowDialog()
        {
            return view.ShowDialog();
        }

        //unneeded complexity
        public void OnCardShoeClick()
        {

            
        }

        // Allows player to submit bet
        public void SubmitBet(int credits)
        {
            if (model.player.getCreditBalance() >= credits)
            {
                model.player.setWagerAmount(credits);
                SyncClient(Command.Bet);
            }
            else
            {
                // Update View with Error Dialog Later
                throw new ArgumentOutOfRangeException();
            }
        }
        
        // Allows player to hit for another card
        public void HitCard()
        {
            SyncClient(Command.Hit);
        }

        // Allows player to stand
        public void Stand()
        {
            SyncClient(Command.Stand);
        }

        public void SyncClient(Command c)
        {
            CommandObject cmdObj = new CommandObject();
            cmdObj.Command = c;
            cmdObj.Players = new List<IPlayer>();
            cmdObj.Players.Add(model.player);
            client.Send(cmdObj);
        }

        public void client_OnDataReceived(object sender, ClientDataReceivedEventArgs e)
        {
            if(e.CmdObject.Command == Command.Message)
            {
                if (e.CmdObject.Message.Trim() == "GameOver")
                {
                    GameOver();
                    return;
                }
            }

            // Player object retrieved from server
            model.players = e.CmdObject.Players;
            
            // Iterate and find current player and assign to model player
            foreach (IPlayer player in model.players)
            {
                if (player.Name == model.player.Name)
                {
                    model.player = player;
                }
            }
            
            // Update the View with new Info
            UpdateView();
        }

        public void UpdateSidebar(IPlayer player)
        {
            // Enabling, Disabling buttons in sidebar
            if (player.getGameStatus().ToString() == "0")
            {
                //Console.WriteLine("Game Status: " + player.getGameStatus().ToString() + " - Wager Amount: " + player.WagerAmount);
                model.gameStatusLabel = "Place Bet";

                if (player.WagerAmount == 0)
                {
                    view.EnableBetButtons();
                }
                else
                {
                    view.DisableBetButtons();
                }

            }
            else if (player.getGameStatus() == 1) // Waiting for bets...
            {
                model.gameStatusLabel = "Waiting on bets...";
            }
            else if (player.getGameStatus() == 2) // Hit/Stand
            {
                model.gameStatusLabel = "Hit/Stand";
                view.EnableHitStandButtons();
            }
            else if (player.getGameStatus() == 3) // Loss 
            {
                model.gameStatusLabel = "Loss";
            }
            else if (player.getGameStatus() == 4) // Bust
            {
                model.gameStatusLabel = "Bust";
            }
            else if (player.getGameStatus() == 5) // Push
            {
                model.gameStatusLabel = "Push";
            }
            else if (player.getGameStatus() == 6) // Win
            {
                model.gameStatusLabel = "Win";
            }
            else if (player.getGameStatus() == 7) // Blackjack
            {
                model.gameStatusLabel = "Blackjack";
            }
            else if (player.getGameStatus() == 8)
            {
                model.gameStatusLabel = "Inactive";
                view.DisableAllButtons();
            }
            else
            {
                throw new Exception("Unsupported Game Status");
            }

            view.UpdateGameStatusLabel();
        }

        public void UpdateView()
        {
            // Count is used to increment thru players, 0 - Dealer, 1 - Player #1, 2 - Player #2, 3 - Player #3, 4 - Player #4
            int count = 0;

            IList<Common.Lib.Interfaces.IPlayer> players = model.players;

            // Parse out player data
            foreach (IPlayer player in players)
            {

                // Updates Sidebar for Current Player
                if (player.Name == model.player.Name)
                {
                    UpdateSidebar(player);
                }

                // Updates each player including dealer. Uses count variable to increment through players slots (0 - dealer, 1 - p1, 2 - p2 ...)
                if (player.Name == "Dealer" && count == 0)
                {
                    // Check for Blackjack
                    CheckForDealerBlackjack(player);

                    // Get view to deal dealer's cards
                    view.DealDealerCards();

                    model.cardDealPlayerID = 0;

                    count++;
                }
                else
                {
                    if (count == 1)
                    {
                        // Update Player #1
                        view.UpdatePlayer1();
                        model.cardDealPlayerID = count;
                        view.DealCards();
                    }
                    else if (count == 2)
                    {
                        // Update Player #2
                        view.UpdatePlayer2();
                        model.cardDealPlayerID = count;
                        view.DealCards();
                    }
                    else if (count == 3)
                    {
                        // Update Player #3
                        view.UpdatePlayer3();
                        model.cardDealPlayerID = count;
                        view.DealCards();
                    }
                    else if (count == 4)
                    {
                        // Update Player #4
                        view.UpdatePlayer4();
                        model.cardDealPlayerID = count;
                        view.DealCards();
                    }

                    count++;
                }

            }

        }

        // This Testable version of UpdateView was created because the regular
        // UpdateView() retrieves the player list from the Model. When you run
        // the regular UpdateView() within the test you receive a NullReference
        // Exception. If you pass the list of players from the model into the
        // TestableUpdateView it will work for testing. This version of Update
        // View is similar to the previous one, except no calls to view are made.
        public void TestableUpdateView(IList<Common.Lib.Models.Player> players)
        {
            // Count is used to increment thru players, 0 - Dealer, 1 - Player #1, 2 - Player #2, 3 - Player #3, 4 - Player #4
            int count = 0;
            
            // Parse out player data
            foreach (IPlayer player in players)
            {

                // Updates Sidebar for Current Player
                if (player.Name == model.player.Name)
                {
                    UpdateSidebar(player);
                    model.testMessage += " Player (" + player.Name + ") is current player";
                }

                // Updates each player including dealer. Uses count variable to increment through players slots (0 - dealer, 1 - p1, 2 - p2 ...)
                if (player.Name == "Dealer" && count == 0)
                {
                    // Check for Blackjack
                    //CheckForDealerBlackjack(player);

                    // Get view to deal dealer's cards
                    //view.DealDealerCards();

                    model.cardDealPlayerID = count;
                    model.testMessage += "Dealer requested cards";
                    count++;
                }
                else
                {
                    if (count == 1)
                    {
                        // Update Player #1
                        //view.UpdatePlayer1();
                        model.cardDealPlayerID = count;
                        //view.DealCards();
                    }
                    else if (count == 2)
                    {
                        // Update Player #2
                        //view.UpdatePlayer2();
                        model.cardDealPlayerID = count;
                        //view.DealCards();
                    }
                    else if (count == 3)
                    {
                        // Update Player #3
                        //view.UpdatePlayer3();
                        model.cardDealPlayerID = count;
                        //view.DealCards();
                    }
                    else if (count == 4)
                    {
                        // Update Player #4
                        //view.UpdatePlayer4();
                        model.cardDealPlayerID = count;
                        //view.DealCards();
                    }

                    count++;
                }

            }

        }

        // Checks to see if the dealer has a blackjack, updates view with result
        public void CheckForDealerBlackjack(IPlayer player)
        {
            if (player.getGameStatus() == 9)
            {
                if (player.scoreHand() == 99)
                {
                    model.dealerCardCount = "Count: 21";
                }
                else
                {
                    model.dealerCardCount = "Count: " + player.scoreHand().ToString();
                }
            }
            else
            {
                model.dealerCardCount = "";
            }

            view.UpdateDealerCount();
        }

        public void ExitGame()
        {
            CommandObject cmdObj = new CommandObject();
            cmdObj.Command = Command.Exit;
            cmdObj.Players = new List<IPlayer>();
            cmdObj.Players.Add(model.player);
            client.Send(cmdObj);
        }

        private void GameOver()
        {
            view.GameOver();
        }
    }
}
