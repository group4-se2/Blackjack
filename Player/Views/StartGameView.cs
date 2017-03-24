using Player.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Player
{
    public partial class StartGameView : Form, IStartGameView
    {
        public IStartGamePresenter StartGamePresenter { get; set; }
        private String playerUsername;

        public StartGameView()
        {
            InitializeComponent();
            this.CenterToScreen();
            pictureBox2.BackColor = Color.Transparent;
            startGameBtn.FlatAppearance.BorderSize = 0;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Get focus off of the username text field
            joinGameBtn.Focus();
        }

  
        private void button1_Click(object sender, EventArgs e)
        {
            StartGamePresenter.OnButton1Click();
        }

        public void UpdateView()
        {
            throw new NotImplementedException();
        }

        private void usernamePanel_Click(object sender, EventArgs e)
        {
            // Clears placeholder text on panel click
            usernameTextField.Text = "";
            usernameTextField.Focus();
        }

        private void usernameTextField_Click(object sender, EventArgs e)
        {
            // Clears placeholder text on text field click
            usernameTextField.Text = "";
        }

        private void goBtn_Click(object sender, EventArgs e)
        {

            String placeholder1 = "Enter username...";
            String placeholder2 = "Try again. Enter username...";

            if (usernameTextField.Text.Length == 0  || usernameTextField.Text == placeholder1 || usernameTextField.Text == placeholder2)
            {
                // Don't allow, username is empty
                usernameTextField.Text = "Try again. Enter username...";
            }
            else
            {
                // Store username
                playerUsername = usernameTextField.Text;

                // Hide UI Elements for Username
                usernamePanel.Visible = false;
                goBtn.Visible = false;

                // Enable UI Elements for Starting or Joining Game
                startGameBtn.Visible = true;
                joinGameBtn.Visible = true;
            }
        }
    }
}
