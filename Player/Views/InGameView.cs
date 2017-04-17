using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;
using Player.Interfaces;
using Common.Lib.Interfaces;
using Player.Presenters;

namespace Player
{
    public partial class InGameView : Form, IInGameView
    {

        IInGameModel model;

        // Players total amount to bet
        int credits = 0;

        public IInGamePresenter InGamePresenter { get; set; }

        public InGameView(IInGameModel model)
        {
            this.model = model;

            InitializeComponent();
            this.CenterToScreen();
        }

        private void InGame_Load(object sender, EventArgs e)
        {
            InGamePresenter.SyncClient(Common.Lib.Models.Command.Sync);
        }

        // Enables the Hit/Stand Buttons
        private void EnableHitStandButtons()
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
        }

        // Enables the Bet Buttons
        private void EnableBetButtons()
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
        }

        // Disables bet buttons
        private void DisableBetButtons()
        {
            // Disable Betting Buttons
            credit1Btn.Enabled = false;
            credit5Btn.Enabled = false;
            credit10Btn.Enabled = false;
            creditAllBet.Enabled = false;
            submitBetBtn.Enabled = false;
        }

        // Disables all buttons
        private void DisableAllButtons()
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
        }

        public void UpdateView()
        {
            int count = 0;

            this.Invoke((MethodInvoker)delegate
           {

               // Parse out player data
               foreach (IPlayer player in model.players)
               {

                   // Updates Sidebar for Current Player
                   if (player.Name == model.player.Name)
                   {
                       UpdateSidebar(player);
                   }

                   // Updates each player including dealer. Uses count variable to increment through players slots (0 - dealer, 1 - p1, 2 - p2 ...)
                   if (player.Name == "Dealer" && count == 0)
                   {
                       // Update Dealer Info

                       // Check for Blackjack
                       CheckForDealerBlackjack(player);

                       // Deal Cards
                       DealCards(player, count);

                       count++;
                   }
                   else
                   {
                       if (count == 1)
                       {
                           // Update Player 1
                           p1CardValue.Text = player.scoreHand().ToString();
                           p1Name.Text = player.Name;
                           p1TotalMoney.Text = "$" + player.getCreditBalance().ToString();
                           p1BetAmount.Text = "Bet: $" + player.getWagerAmount().ToString();

                           // Check for focus, change background color of name label if true, remove if false
                           if (player.hasFocus == true) { p1Name.BackColor = Color.DarkGreen; }
                           else { p1Name.BackColor = Color.Transparent; DisableAllButtons(); }

                           // Deal Cards
                           DealCards(player, count);

                       }
                       else if (count == 2)
                       {
                           // Update Player 2
                           p2CardValue.Text = player.scoreHand().ToString();
                           p2Name.Text = player.Name;
                           p2TotalMoney.Text = "$" + player.getCreditBalance().ToString();
                           p2BetAmount.Text = "Bet: $" + player.getWagerAmount().ToString();

                           // Check for focus, change background color of name label if true, remove if false
                           if (player.hasFocus == true) { p2Name.BackColor = Color.DarkGreen; }
                           else { p2Name.BackColor = Color.Transparent; }

                           // Deal Cards
                           DealCards(player, count);

                       }
                       else if (count == 3)
                       {
                           // Update Player 3
                           p3CardValue.Text = player.scoreHand().ToString();
                           p3Name.Text = player.Name;
                           p3TotalMoney.Text = "$" + player.getCreditBalance().ToString();
                           p3BetAmount.Text = "Bet: $" + player.getWagerAmount().ToString();

                           // Check for focus, change background color of name label if true, remove if false
                           if (player.hasFocus == true) { p3Name.BackColor = Color.DarkGreen; }
                           else { p3Name.BackColor = Color.Transparent; }

                           // Deal Cards
                           DealCards(player, count);
                       }
                       else if (count == 4)
                       {
                           // Update Player 4
                           p4CardValue.Text = player.scoreHand().ToString();
                           p4Name.Text = player.Name;
                           p4TotalMoney.Text = "$" + player.getCreditBalance().ToString();
                           p4BetAmount.Text = "Bet: $" + player.getWagerAmount().ToString();

                           // Check for focus, change background color of name label if true, remove if false
                           if (player.hasFocus == true) { p4Name.BackColor = Color.DarkGreen; }
                           else { p4Name.BackColor = Color.Transparent; }

                           // Deal Cards
                           DealCards(player, count);
                       }

                       count++;
                   }

               }

           });
        }
        private void CheckForDealerBlackjack(IPlayer player)
        {
            if (player.scoreHand() == 99)
            {
                dealerCardValue.Text = "21";
            }
            else
            {
                dealerCardValue.Text = player.scoreHand().ToString();
            }
        }

        private void UpdateSidebar(IPlayer player)
        {
            gameStatusLabel.Text = "$" + player.getCreditBalance().ToString();

            // Enabling, Disabling buttons in sidebar
            if (player.getGameStatus().ToString() == "0")
            {
                EnableBetButtons();
            }
            else if (player.getGameStatus().ToString() == "1")
            {
                EnableHitStandButtons();
            }
        }

        private void DealCards(IPlayer player, int count)
        {
            Size CARD_SIZE = new Size(73, 104);

            int CARD_LOCATION_X = 0;
            int CARD_LOCATION_Y = 417;
            
            // Sets the X,Y Coordinate for each Player
            if (count == 0) { CARD_LOCATION_X = 310; CARD_LOCATION_Y = 120; }
            else if (count == 1) { CARD_LOCATION_X = 85; }
            else if (count == 2) { CARD_LOCATION_X = 235; }
            else if (count == 3) { CARD_LOCATION_X = 385; }
            else if (count == 4) { CARD_LOCATION_X = 535; }
            
            // Loops through the cards and creates pictureboxes
            if (player.myHand.hand.Count > 0)
            {
                PictureBox[] boxes = new PictureBox[player.myHand.hand.Count];
               
                for (int i = 0; i < player.myHand.hand.Count; i++)
                {
                    boxes[i] = new PictureBox();
                    int cardID = GetCardGraphic(player.myHand.getCard(i));
                    boxes[i].Image = imageList1.Images[cardID];
                    boxes[i].Size = CARD_SIZE;
                    boxes[i].Location = new Point(CARD_LOCATION_X, CARD_LOCATION_Y);
                    this.Controls.Add(boxes[i]);
                    boxes[i].BringToFront();
                    CARD_LOCATION_X += 15;
                }
            }

        }

        // Converts ICard into Card index to access from Imagelist
        private int GetCardGraphic(ICard card)
        {
            if (card.Suit == Suit.Clubs) { return card.NumericValue - 2; }
            else if (card.Suit == Suit.Diamonds) { return card.NumericValue + 11; }
            else if (card.Suit == Suit.Hearts) { return card.NumericValue + 24;  }
            else if (card.Suit == Suit.Spades) { return card.NumericValue + 37; }
            else { return 0; }
        }

        // Updates bet amount on the sidebar
        private void UpdateBetAmount()
        {
            this.Invoke((MethodInvoker)delegate
            {
                sidebarBetAmount.Text = "$" + credits.ToString();
            });
        }

        // Increment bet amount by 1
        private void credit1Btn_Click(object sender, EventArgs e)
        {
            this.credits += 1;
            UpdateBetAmount();
        }

        // Increment bet amount by 5
        private void credit5Btn_Click(object sender, EventArgs e)
        {
            this.credits += 5;
            UpdateBetAmount();
        }

        // Increment bet amount by 10
        private void credit10Btn_Click(object sender, EventArgs e)
        {
            this.credits += 10;
            UpdateBetAmount();
        }

        // Increment bet by adding all available money
        private void creditAllBet_Click(object sender, EventArgs e)
        {
            this.credits = 0;
            this.credits = model.player.getCreditBalance();
            UpdateBetAmount();
        }

        // Submits the bet to Presenter
        private void submitBetBtn_Click(object sender, EventArgs e)
        {
            InGamePresenter.SubmitBet(credits);
            DisableBetButtons();
            credits = 0; // Reset the amount of credits the user wants to bet, since it is submitted
            UpdateBetAmount();
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

        // Hit for another card
        private void hitBtn_Click(object sender, EventArgs e)
        {
            InGamePresenter.HitCard();
        }

        // Stand
        private void standBtn_Click(object sender, EventArgs e)
        {
            InGamePresenter.Stand();
        }
    }
}
