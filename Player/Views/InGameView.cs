using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Player.Interfaces;
using Common.Lib.Interfaces;

namespace Player
{
    public partial class InGameView : Form, IInGameView
    {

        IInGameModel model;

        // Cards to draw on the screen
        List<PictureBox> boxes = new List<PictureBox>();

        // Players total amount to bet
        int credits = 0;

        // Card Constants
        const int CARD_BACK_IMAGE_ID = 52;
        const int CARD_X_OFFSET = 15;

        public IInGamePresenter InGamePresenter { get; set; }

        public InGameView(IInGameModel model)
        {
            this.model = model;
            InitializeComponent();
            this.CenterToScreen();
        }

        // On load, syncs the game board with the server to update
        public void InGame_Load(object sender, EventArgs e)
        {
            InGamePresenter.SyncClient(Common.Lib.Models.Command.Sync);
        }

        // Enables the Hit/Stand Buttons
        public void EnableHitStandButtons()
        {
            this.Invoke((MethodInvoker)delegate
            {
                // Enable Hit-Stand Buttons
                hitBtn.Enabled = true;
                standBtn.Enabled = true;

                // Disable Betting Buttons
                credit1Btn.Enabled = false;
                credit5Btn.Enabled = false;
                credit10Btn.Enabled = false;
                creditAllBet.Enabled = false;
                submitBetBtn.Enabled = false;
            });
        }

        // Enables the Bet Buttons
        public void EnableBetButtons()
        {
            this.Invoke((MethodInvoker)delegate
            {
                // Enable Betting Buttons
                credit1Btn.Enabled = true;
                credit5Btn.Enabled = true;
                credit10Btn.Enabled = true;
                creditAllBet.Enabled = true;
                submitBetBtn.Enabled = true;

                // Disable Hit-Stand Buttons
                hitBtn.Enabled = false;
                standBtn.Enabled = false;
            });
        }

        // Disables bet buttons
        public void DisableBetButtons()
        {
            this.Invoke((MethodInvoker)delegate
            {
                // Disable Betting Buttons
                credit1Btn.Enabled = false;
                credit5Btn.Enabled = false;
                credit10Btn.Enabled = false;
                creditAllBet.Enabled = false;
                submitBetBtn.Enabled = false;
            });
        }

        // Disables all buttons
        public void DisableAllButtons()
        {
            this.Invoke((MethodInvoker)delegate
            {
                // Disable Hit-Stand Buttons
                hitBtn.Enabled = false;
                standBtn.Enabled = false;

                // Disable Betting Buttons
                credit1Btn.Enabled = false;
                credit5Btn.Enabled = false;
                credit10Btn.Enabled = false;
                creditAllBet.Enabled = false;
                submitBetBtn.Enabled = false;
            });
        }

        // Updates player #1 on the screen
        public void UpdatePlayer1()
        {
            this.Invoke((MethodInvoker)delegate
            {
                int playerID = 1;
                IPlayer player = model.players[playerID];

                p1CardValue.Text = "Count: " + player.scoreHand().ToString();
                p1Name.Text = player.Name;
                p1TotalMoney.Text = "$" + player.getCreditBalance().ToString();
                p1BetAmount.Text = "Bet: $" + player.getWagerAmount().ToString();

                // Check for focus, change background color of name label if true, remove if false
                if (player.hasFocus == true) { p1Name.BackColor = Color.DarkGreen; }
                else { p1Name.BackColor = Color.Transparent; DisableAllButtons(); }
            });
        }

        // Updates player #2 on the screen
        public void UpdatePlayer2()
        {
            this.Invoke((MethodInvoker)delegate
            {
                int playerID = 2;
                IPlayer player = model.players[playerID];

                p2CardValue.Text = "Count: " + player.scoreHand().ToString();
                p2Name.Text = player.Name;
                p2TotalMoney.Text = "$" + player.getCreditBalance().ToString();
                p2BetAmount.Text = "Bet: $" + player.getWagerAmount().ToString();

                // Check for focus, change background color of name label if true, remove if false
                if (player.hasFocus == true) { p2Name.BackColor = Color.DarkGreen; }
                else { p2Name.BackColor = Color.Transparent; }
            });
        }

        // Updates player #3 on the screen
        public void UpdatePlayer3()
        {
            this.Invoke((MethodInvoker)delegate
            {
                int playerID = 3;
                IPlayer player = model.players[playerID];

                p3CardValue.Text = "Count: " + player.scoreHand().ToString();
                p3Name.Text = player.Name;
                p3TotalMoney.Text = "$" + player.getCreditBalance().ToString();
                p3BetAmount.Text = "Bet: $" + player.getWagerAmount().ToString();

                // Check for focus, change background color of name label if true, remove if false
                if (player.hasFocus == true) { p3Name.BackColor = Color.DarkGreen; }
                else { p3Name.BackColor = Color.Transparent; }
            });
        }

        // Updates player #4 on the screen
        public void UpdatePlayer4()
        {
            this.Invoke((MethodInvoker)delegate
            {
                int playerID = 4;
                IPlayer player = model.players[playerID];

                p4CardValue.Text = "Count: " + player.scoreHand().ToString();
                p4Name.Text = player.Name;
                p4TotalMoney.Text = "$" + player.getCreditBalance().ToString();
                p4BetAmount.Text = "Bet: $" + player.getWagerAmount().ToString();

                // Check for focus, change background color of name label if true, remove if false
                if (player.hasFocus == true) { p4Name.BackColor = Color.DarkGreen; }
                else { p4Name.BackColor = Color.Transparent; }
            });
        }

        // Updates the dealer's card value count
        public void UpdateDealerCount()
        {
            this.Invoke((MethodInvoker)delegate
            {
                // Retrieve updated dealer card count from model
                String text = model.dealerCardCount;

                this.dealerCardValue.Text = text;
            });
        }

        // Pulls game status label from model and updates view label
        public void UpdateGameStatusLabel()
        {
            this.Invoke((MethodInvoker)delegate
            {
                // Get Label from Model
                String text = model.gameStatusLabel;

                // Update Label
                gameStatusLabel.Text = text;
            });
        }
        

        // Deals the dealer's cards
        public void DealDealerCards()
        {
            this.Invoke((MethodInvoker)delegate
            {
                int playerID = 0;
                IPlayer player = model.players[playerID];

                Size CARD_SIZE = new Size(73, 104);
                int CARD_LOCATION_X = 310;
                int CARD_LOCATION_Y = 120;

                // Loops through the cards and creates pictureboxes
                if (player.myHand.hand.Count > 0)
                {
                    for (int i = 0; i < player.myHand.hand.Count; i++)
                    {
                        PictureBox box = new PictureBox();
                        int cardID = GetCardGraphic(player.myHand.getCard(i));

                        if (i == 0 && player.getGameStatus() != 9)
                        {
                            box.Image = imageList1.Images[CARD_BACK_IMAGE_ID];
                        }
                        else
                        {
                            box.Image = imageList1.Images[cardID];
                        }

                        box.Size = CARD_SIZE;
                        box.Location = new Point(CARD_LOCATION_X, CARD_LOCATION_Y);
                        this.Controls.Add(box);

                        box.BringToFront();
                        boxes.Add(box);
                        CARD_LOCATION_X += CARD_X_OFFSET;
                    }
                }
            });
        }

        // Deals cards for player depending on player ID
        public void DealCards(int playerID)
        {
            this.Invoke((MethodInvoker)delegate
            {
                IPlayer player = model.players[playerID];

                Size CARD_SIZE = new Size(73, 104);

                // X, Y Coordinate starting points for drawing cards
                int CARD_LOCATION_X = 0;
                int CARD_LOCATION_Y = 417;

                // Sets the X,Y Coordinate for each Player including the Dealer
                if (playerID == 0) { CARD_LOCATION_X = 310; CARD_LOCATION_Y = 120; }
                else if (playerID == 1) { CARD_LOCATION_X = 85; }
                else if (playerID == 2) { CARD_LOCATION_X = 235; }
                else if (playerID == 3) { CARD_LOCATION_X = 385; }
                else if (playerID == 4) { CARD_LOCATION_X = 535; }

                // Loops through the cards and creates pictureboxes
                if (player.myHand.hand.Count > 0)
                {
                    for (int i = 0; i < player.myHand.hand.Count; i++)
                    {
                        PictureBox box = new PictureBox();
                        int cardID = GetCardGraphic(player.myHand.getCard(i));
                        box.Image = imageList1.Images[cardID];
                        box.Size = CARD_SIZE;
                        box.Location = new Point(CARD_LOCATION_X, CARD_LOCATION_Y);
                        this.Controls.Add(box);

                        box.BringToFront();
                        boxes.Add(box);
                        CARD_LOCATION_X += CARD_X_OFFSET;
                    }
                }
            });
        }

        // Converts ICard into Card index to access from Imagelist
        private int GetCardGraphic(ICard card)
        {
            if (card.Suit == Suit.Clubs)
            {
                return card.NumericValue - 2;
            }
            else if (card.Suit == Suit.Diamonds)
            {
                return card.NumericValue + 11;
            }
            else if (card.Suit == Suit.Hearts)
            {
                return card.NumericValue + 24;
            }
            else if (card.Suit == Suit.Spades)
            {
                return card.NumericValue + 37;
            }
            else
            {
                return 0;
            }
        }

        // Updates bet amount on the sidebar
        private void UpdateBetAmount()
        {
            this.Invoke((MethodInvoker)delegate
            {
                sidebarBetAmount.Text = "$" + credits.ToString();
            });
        }

        // Increments bet amount by 1 credits
        private void credit1Btn_Click(object sender, EventArgs e)
        {
            this.credits += 1;
            UpdateBetAmount();
        }

        // Increments bet amount by 5 credits
        private void credit5Btn_Click(object sender, EventArgs e)
        {
            this.credits += 5;
            UpdateBetAmount();
        }

        // Increments bet amount by 10
        private void credit10Btn_Click(object sender, EventArgs e)
        {
            this.credits += 10;
            UpdateBetAmount();
        }

        // Increments bet by adding all available credits
        private void creditAllBet_Click(object sender, EventArgs e)
        {
            this.credits = 0;
            credits = model.player.getCreditBalance();
            UpdateBetAmount();
        }

        // Submits the bet to Presenter
        private void submitBetBtn_Click(object sender, EventArgs e)
        {
            if (credits != 0 && credits <= model.player.getCreditBalance())
            {
                InGamePresenter.SubmitBet(credits);
                DisableBetButtons();
                credits = 0; // Reset the amount of credits the user wants to bet, since it is submitted
                UpdateBetAmount();
            }
            else
            {
                gameStatusLabel.Text = "Bet cannot exceed balance";
                credits = 0; // Reset the amount of credits the user wants to bet, since it is submitted
                UpdateBetAmount();
            }
        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {
            Point startPoint = pictureBox1.Location;
            Point endPoint = p2CardPanel.Location;
            endPoint.Y += 8;
            pictureBox1.Visible = true;
            pictureBox1.Refresh();
            Animate(pictureBox1, startPoint, endPoint);
            pictureBox2.Image = imageList1.Images[26];
            pictureBox2.Visible = true;
            this.Refresh();
            System.Threading.Thread.Sleep(100);
            endPoint.X += 15;
            Animate(pictureBox2, startPoint, endPoint);
        }

        public void Animate(PictureBox card, Point startPoint, Point endPoint)
        {
            int totalSteps = 200;

            card.BringToFront();

            for (int i = 0; i < totalSteps; i++)
            {
                int x = startPoint.X + i * (endPoint.X - startPoint.X) / totalSteps;

                // Get m in y = mx + c
                double m = (double)(endPoint.Y - startPoint.Y) / (endPoint.X - startPoint.X);

                // Get c in y = mx + c
                double c = startPoint.Y - m * startPoint.X;

                int y = (int)Math.Round(m * x + c);

                card.Location = new Point(x, y);
                cardShoe.Refresh();
                blackjackText.Refresh();
                blackjackRulesText.Refresh();
            }

            card.Location = endPoint;
        }

        // Sends hit command to presenter
        private void hitBtn_Click(object sender, EventArgs e)
        {
            InGamePresenter.HitCard();
        }

        // Sends stand command to presenter
        private void standBtn_Click(object sender, EventArgs e)
        {
            InGamePresenter.Stand();
        }

        // Resets each player box to empty
        private void ResetPlayerBoxes()
        {
            p1Name.Text = "Empty";
            p2Name.Text = "Empty";
            p3Name.Text = "Empty";
            p4Name.Text = "Empty";

            p1Name.BackColor = Color.Transparent;
            p2Name.BackColor = Color.Transparent;
            p3Name.BackColor = Color.Transparent;
            p4Name.BackColor = Color.Transparent;

            p1BetAmount.Text = "Bet: $0";
            p2BetAmount.Text = "Bet: $0";
            p3BetAmount.Text = "Bet: $0";
            p4BetAmount.Text = "Bet: $0";

            p1CardValue.Text = "Count: ";
            p2CardValue.Text = "Count: ";
            p3CardValue.Text = "Count: ";
            p4CardValue.Text = "Count: ";

            p1TotalMoney.Text = "Total Money";
            p2TotalMoney.Text = "Total Money";
            p3TotalMoney.Text = "Total Money";
            p4TotalMoney.Text = "Total Money";
        }

        // Called at the end of the game round
        public void GameOver()
        {
            this.Invoke((MethodInvoker)delegate
            {
                foreach (PictureBox box in boxes)
                {
                    this.Controls.Remove(box);
                }
                boxes.Clear();
                ResetPlayerBoxes();
                InGamePresenter.SyncClient(Common.Lib.Models.Command.Sync);
            });
        }

        private void InGameView_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
