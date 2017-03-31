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

namespace Player
{
    public partial class InGameView : Form, IInGameView
    {

        IInGameModel model;
        IPlayer p1, p2, p3, p4;
        Label[] names;

        double betAmount = 0.00;

        public InGameView(IInGameModel model)
        {

            this.model = model;

            InitializeComponent();
            this.CenterToScreen();
        }

        private void InGame_Load(object sender, EventArgs e)
        {
            Label player1name = new Label();
            player1name.Text = "Julian Loftis";
            player1name.SetBounds(50, 50, 200, 50);
            this.Controls.Add(player1name);

            /*
            List<IPlayer> tempPlayers = new List<IPlayer>();

            Common.Lib.Models.Player player1 = new Common.Lib.Models.Player();
            player1.Name = "Dealer";

            Common.Lib.Models.Player player2 = new Common.Lib.Models.Player();
            player2.Name = "Tim";

            Common.Lib.Models.Player player3 = new Common.Lib.Models.Player();
            player3.Name = "Julian";

            tempPlayers.Add(player1);
            tempPlayers.Add(player2);
            tempPlayers.Add(player3);

            UpdatePlayers(tempPlayers);

            */
        }

        public void UpdatePlayers(List<IPlayer> players)
        {
            int count = 0;

            foreach (IPlayer player in players)
            {
                // Parse out player data

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
                        
                    }
                    else if (count == 2)
                    {
                        // Update Player 2
                        p2Name.Text = player.Name;
                        p2TotalMoney.Text = "$" + player.getCreditBalance().ToString();
                        p2BetAmount.Text = "Bet: $" + player.getWagerAmount().ToString();
                    }
                    else if (count == 3)
                    {
                        // Update Player 3
                        p3Name.Text = player.Name;
                        p3TotalMoney.Text = "$" + player.getCreditBalance().ToString();
                        p3BetAmount.Text = "Bet: $" + player.getWagerAmount().ToString();
                    }
                    else if (count == 4)
                    {
                        // Update Player 4
                        p4Name.Text = player.Name;
                        p4TotalMoney.Text = "$" + player.getCreditBalance().ToString();
                        p4BetAmount.Text = "Bet: $" + player.getWagerAmount().ToString();
                    }

                    count++;
                }
                
            }

        }

        public void UpdateView()
        {

            this.p1 = model.getPlayer(1);

            this.Invoke((MethodInvoker) delegate
            {
                //p1CardValue.Text = p1.scoreHand().ToString();
                p1Name.Text = p1.Name;
                p1BetAmount.Text = "Bet: $" + p1.getWagerAmount().ToString();
                p1TotalMoney.Text = "$" + p1.getCreditBalance().ToString();

                if (p1.getFocus() == true) { p1Name.BackColor = Color.DarkOliveGreen; }
                else { p1Name.BackColor = Color.Transparent; }
            });

           
        }

        private void credit1Btn_Click(object sender, EventArgs e)
        {
            // Increment bet amount by 1
            this.betAmount += 1;
        }

        private void credit5Btn_Click(object sender, EventArgs e)
        {
            // Increment bet amount by 5
            this.betAmount += 5;
        }

        private void credit10Btn_Click(object sender, EventArgs e)
        {
            // Increment bet amount by 10
            this.betAmount += 10;
        }

        private void creditAllBet_Click(object sender, EventArgs e)
        {
            // Increment bet by adding all available money
            this.betAmount = 0;
            this.betAmount = p1.getCreditBalance();
        }

        private void submitBetBtn_Click(object sender, EventArgs e)
        {
            
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
