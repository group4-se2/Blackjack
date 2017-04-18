using Player.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Player
{
    public partial class StartGameView : Form, IStartGameView
    {
        public IStartGamePresenter StartGamePresenter { get; set; }
        public IStartGameModel StartGameModel { get; set; }


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

  
        public void EnableStartGame()
        {
            startGameBtn.Enabled = true;
        }

        public void DisableStartGame()
        {
            this.Invoke((MethodInvoker)delegate
            {
                startGameBtn.Enabled = false;
            });
        }

        public void EnableJoinGame()
        {
            this.Invoke((MethodInvoker)delegate
            {
                joinGameBtn.Enabled = true;
            });
        }

        public void EnableUserNamePanel()
        {
            this.Invoke((MethodInvoker)delegate
            {
                usernamePanel.Visible = true;
                goBtn.Visible = true;
                startGameBtn.Visible = false;
                joinGameBtn.Visible = false;
            });
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

            if (usernameTextField.Text.Length == 0  || usernameTextField.Text == placeholder1 || usernameTextField.Text == placeholder2 || usernameTextField.Text.Length >= 11)
            {
                // Don't allow, username is empty
                if (usernameTextField.Text.Length >= 11)
                {
                    usernameTextField.Text = "Username can't be that long...";
                }
                else
                {
                    usernameTextField.Text = "Try again. Enter username...";
                }
            }
            else
            {
                // Hide UI Elements for Username
                usernamePanel.Visible = false;
                goBtn.Visible = false;

                // Enable UI Elements for Starting or Joining Game
                startGameBtn.Visible = true;
                joinGameBtn.Visible = true;

                // Add user name to model player object
                StartGameModel.player.Name = usernameTextField.Text;

                // Call presenter to join this player to the game server
                StartGamePresenter.goButtonClick();
            }
        }

        // Fix the name of this button, later
        private void button1_Click(object sender, EventArgs e)
        {
            StartGamePresenter.OnButton1Click();
        }

        private void joinGameBtn_Click(object sender, EventArgs e)
        {
            StartGamePresenter.OnButton1Click();
        }
    }
}
