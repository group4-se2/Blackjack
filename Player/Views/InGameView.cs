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

        public void UpdateView()
        {
            int count = 0;

            this.Invoke((MethodInvoker)delegate
           {
               
            foreach (IPlayer player in model.players)
            {
                   // Parse out player data

                   // Updates Sidebar for Current Player
                   if (player.Name == model.player.Name)
                   {
                       totalMoneyAvailable.Text = "$" + player.getCreditBalance().ToString();
                       
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

                   if (player.Name == "Dealer" && count == 0)
                   {
                       // Update Dealer Info
                       count++;

                   }
                   else
                   {
                       if (count == 1)
                       {
                           // Update Player 1
                           p1Name.Text = player.Name;
                           p1TotalMoney.Text = "$" + player.getCreditBalance().ToString();
                           p1BetAmount.Text = "Bet: $" + player.getWagerAmount().ToString();

                           // Check for focus, change background color of name label if true, remove if false
                           if (player.hasFocus == true) { p1Name.BackColor = Color.DarkGreen; }
                           else { p1Name.BackColor = Color.Transparent; }


                           if (player.myHand.length > 0)
                           {
                               Console.WriteLine("Cards have been dealt");
                           }
                           else
                           {
                               Console.WriteLine("Cards have not been dealt");
                           }

                       }
                       else if (count == 2)
                       {
                           // Update Player 2
                           p2Name.Text = player.Name;
                           p2TotalMoney.Text = "$" + player.getCreditBalance().ToString();
                           p2BetAmount.Text = "Bet: $" + player.getWagerAmount().ToString();

                           // Check for focus, change background color of name label if true, remove if false
                           if (player.hasFocus == true) { p2Name.BackColor = Color.DarkGreen; }
                           else { p2Name.BackColor = Color.Transparent; }

                       }
                       else if (count == 3)
                       {
                           // Update Player 3
                           p3Name.Text = player.Name;
                           p3TotalMoney.Text = "$" + player.getCreditBalance().ToString();
                           p3BetAmount.Text = "Bet: $" + player.getWagerAmount().ToString();

                           // Check for focus, change background color of name label if true, remove if false
                           if (player.hasFocus == true) { p3Name.BackColor = Color.DarkGreen; }
                           else { p3Name.BackColor = Color.Transparent; }
                       }
                       else if (count == 4)
                       {
                           // Update Player 4
                           p4Name.Text = player.Name;
                           p4TotalMoney.Text = "$" + player.getCreditBalance().ToString();
                           p4BetAmount.Text = "Bet: $" + player.getWagerAmount().ToString();

                           // Check for focus, change background color of name label if true, remove if false
                           if (player.hasFocus == true) { p4Name.BackColor = Color.DarkGreen; }
                           else { p4Name.BackColor = Color.Transparent; }
                       }

                       count++;
                   }

               }

           });
        }


        // Increment bet amount by 1
        private void credit1Btn_Click(object sender, EventArgs e)
        {
            this.credits += 1;
            credit1Btn.Focus();
        }

        // Increment bet amount by 5
        private void credit5Btn_Click(object sender, EventArgs e)
        {
            this.credits += 5;
        }

        // Increment bet amount by 10
        private void credit10Btn_Click(object sender, EventArgs e)
        {
            this.credits += 10;
        }

        // Increment bet by adding all available money
        private void creditAllBet_Click(object sender, EventArgs e)
        {
            this.credits = 0;
            this.credits = model.player.getCreditBalance();
        }

        // Submits the bet to Presenter
        private void submitBetBtn_Click(object sender, EventArgs e)
        {
            InGamePresenter.SubmitBet(credits);
            credits = 0; // Reset the amount of credits the user wants to bet, since it is submitted
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
    }
}
