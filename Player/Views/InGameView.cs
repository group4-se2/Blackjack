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

        public InGameView()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void InGame_Load(object sender, EventArgs e)
        {
            
        }


        public void UpdateView()
        {

            // Update Players
            this.p1 = model.getPlayer(1);
            this.p2 = model.getPlayer(2);
            this.p3 = model.getPlayer(3);
            this.p4 = model.getPlayer(4);

            this.Invoke((MethodInvoker) delegate
            {
                // P1
                p1CardValue.Text = p1.scoreHand().ToString();
                p1Name.Text = p1.Name;
                p1BetAmount.Text = "Bet: $" + p1.getWagerAmount().ToString();
                p1TotalMoney.Text = "$" + p1.getCreditBalance().ToString();

                if (p1.getFocus() == true) { p1Name.BackColor = Color.DarkOliveGreen; }
                else { p1Name.BackColor = Color.Transparent; }
                
                // P2
                p2CardValue.Text = p2.scoreHand().ToString();
                p2Name.Text = p2.Name;
                p2BetAmount.Text = "Bet: $" + p2.getWagerAmount().ToString();
                p2TotalMoney.Text = "$" + p2.getCreditBalance().ToString();

                if (p2.getFocus() == true) { p2Name.BackColor = Color.DarkOliveGreen; }
                else { p2Name.BackColor = Color.Transparent; }

                // P3
                p3CardValue.Text = p3.scoreHand().ToString();
                p3Name.Text = p3.Name;
                p3BetAmount.Text = "Bet: $" + p3.getWagerAmount().ToString();
                p3TotalMoney.Text = "$" + p3.getCreditBalance().ToString();

                if (p3.getFocus() == true) { p3Name.BackColor = Color.DarkOliveGreen; }
                else { p3Name.BackColor = Color.Transparent; }

                // P4
                p4CardValue.Text = p4.scoreHand().ToString();
                p4Name.Text = p4.Name;
                p4BetAmount.Text = "Bet: $" + p4.getWagerAmount().ToString();
                p4TotalMoney.Text = "$" + p4.getCreditBalance().ToString();

                if (p4.getFocus() == true) { p4Name.BackColor = Color.DarkOliveGreen; }
                else { p4Name.BackColor = Color.Transparent; }

            });


        }

        public void UpdatePlayer(IPlayer player)
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
