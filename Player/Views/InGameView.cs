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

namespace Player
{
    public partial class InGameView : Form, IInGameView
    {
        public InGameView()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void InGame_Load(object sender, EventArgs e)
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
