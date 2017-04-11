namespace Player
{
    partial class StartGameView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartGameView));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.startGameBtn = new System.Windows.Forms.Button();
            this.joinGameBtn = new System.Windows.Forms.Button();
            this.creditsLabel = new System.Windows.Forms.Label();
            this.usernamePanel = new System.Windows.Forms.Panel();
            this.usernameTextField = new System.Windows.Forms.TextBox();
            this.goBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.usernamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(319, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(210, 231);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(416, 110);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // startGameBtn
            // 
            this.startGameBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(131)))), ((int)(((byte)(51)))));
            this.startGameBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startGameBtn.Enabled = false;
            this.startGameBtn.FlatAppearance.BorderSize = 0;
            this.startGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startGameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startGameBtn.ForeColor = System.Drawing.Color.White;
            this.startGameBtn.Location = new System.Drawing.Point(183, 365);
            this.startGameBtn.Name = "startGameBtn";
            this.startGameBtn.Size = new System.Drawing.Size(220, 69);
            this.startGameBtn.TabIndex = 2;
            this.startGameBtn.Text = "Start Game";
            this.startGameBtn.UseVisualStyleBackColor = false;
            this.startGameBtn.Visible = false;
            this.startGameBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // joinGameBtn
            // 
            this.joinGameBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(131)))), ((int)(((byte)(51)))));
            this.joinGameBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.joinGameBtn.Enabled = false;
            this.joinGameBtn.FlatAppearance.BorderSize = 0;
            this.joinGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.joinGameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.joinGameBtn.ForeColor = System.Drawing.Color.White;
            this.joinGameBtn.Location = new System.Drawing.Point(424, 365);
            this.joinGameBtn.Name = "joinGameBtn";
            this.joinGameBtn.Size = new System.Drawing.Size(220, 69);
            this.joinGameBtn.TabIndex = 3;
            this.joinGameBtn.Text = "Join Game";
            this.joinGameBtn.UseVisualStyleBackColor = false;
            this.joinGameBtn.Visible = false;
            this.joinGameBtn.Click += new System.EventHandler(this.joinGameBtn_Click);
            // 
            // creditsLabel
            // 
            this.creditsLabel.AutoSize = true;
            this.creditsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditsLabel.ForeColor = System.Drawing.Color.White;
            this.creditsLabel.Location = new System.Drawing.Point(197, 470);
            this.creditsLabel.Name = "creditsLabel";
            this.creditsLabel.Size = new System.Drawing.Size(429, 16);
            this.creditsLabel.TabIndex = 4;
            this.creditsLabel.Text = "Created by: Julian Loftis, Tim Sullivan, Fred Lash, Chris Fails, David Kirk";
            // 
            // usernamePanel
            // 
            this.usernamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(131)))), ((int)(((byte)(51)))));
            this.usernamePanel.Controls.Add(this.usernameTextField);
            this.usernamePanel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.usernamePanel.Location = new System.Drawing.Point(183, 365);
            this.usernamePanel.Name = "usernamePanel";
            this.usernamePanel.Size = new System.Drawing.Size(360, 68);
            this.usernamePanel.TabIndex = 5;
            this.usernamePanel.Click += new System.EventHandler(this.usernamePanel_Click);
            // 
            // usernameTextField
            // 
            this.usernameTextField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(131)))), ((int)(((byte)(51)))));
            this.usernameTextField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTextField.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextField.ForeColor = System.Drawing.Color.White;
            this.usernameTextField.Location = new System.Drawing.Point(20, 24);
            this.usernameTextField.Name = "usernameTextField";
            this.usernameTextField.Size = new System.Drawing.Size(319, 22);
            this.usernameTextField.TabIndex = 0;
            this.usernameTextField.TabStop = false;
            this.usernameTextField.Text = "Enter username...";
            this.usernameTextField.Click += new System.EventHandler(this.usernameTextField_Click);
            // 
            // goBtn
            // 
            this.goBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(102)))), ((int)(((byte)(33)))));
            this.goBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goBtn.FlatAppearance.BorderSize = 0;
            this.goBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBtn.ForeColor = System.Drawing.Color.White;
            this.goBtn.Location = new System.Drawing.Point(549, 364);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(95, 69);
            this.goBtn.TabIndex = 6;
            this.goBtn.Text = "Next";
            this.goBtn.UseVisualStyleBackColor = false;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // StartGameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(162)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(824, 521);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.usernamePanel);
            this.Controls.Add(this.creditsLabel);
            this.Controls.Add(this.joinGameBtn);
            this.Controls.Add(this.startGameBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "StartGameView";
            this.Text = "Blackjack";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.usernamePanel.ResumeLayout(false);
            this.usernamePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button startGameBtn;
        private System.Windows.Forms.Button joinGameBtn;
        private System.Windows.Forms.Label creditsLabel;
        private System.Windows.Forms.Panel usernamePanel;
        private System.Windows.Forms.TextBox usernameTextField;
        private System.Windows.Forms.Button goBtn;
    }
}

