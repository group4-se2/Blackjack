namespace Player
{
    partial class InGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InGame));
            this.DealerTitleLabel = new System.Windows.Forms.Label();
            this.BlackjackTitleLabel = new System.Windows.Forms.Label();
            this.DealerInfoTitleLabel = new System.Windows.Forms.Label();
            this.PotAmountLabel = new System.Windows.Forms.Label();
            this.PotContainerPanel = new System.Windows.Forms.Panel();
            this.Player4CardPanel = new System.Windows.Forms.Panel();
            this.Player3CardPanel = new System.Windows.Forms.Panel();
            this.Player2CardPanel = new System.Windows.Forms.Panel();
            this.Player1CardPanel = new System.Windows.Forms.Panel();
            this.PokerChipsImage = new System.Windows.Forms.PictureBox();
            this.SidebarPanel = new System.Windows.Forms.Panel();
            this.GameStatusLabel = new System.Windows.Forms.Label();
            this.TotalMoneyAvailableLabel = new System.Windows.Forms.Label();
            this.TotalMoneyAvailableTitleLabel = new System.Windows.Forms.Label();
            this.Player1NameLabel = new System.Windows.Forms.Label();
            this.Player2NameLabel = new System.Windows.Forms.Label();
            this.Player3NameLabel = new System.Windows.Forms.Label();
            this.Player4NameLabel = new System.Windows.Forms.Label();
            this.Player1CardValueLabel = new System.Windows.Forms.Label();
            this.Player2CardValueLabel = new System.Windows.Forms.Label();
            this.Player3CardValueLabel = new System.Windows.Forms.Label();
            this.Player4CardValueLabel = new System.Windows.Forms.Label();
            this.Player1BetAmountLabel = new System.Windows.Forms.Label();
            this.Player2BetAmountLabel = new System.Windows.Forms.Label();
            this.Player3BetAmountLabel = new System.Windows.Forms.Label();
            this.Player4BetAmountLabel = new System.Windows.Forms.Label();
            this.Player1TotalMoneyLabel = new System.Windows.Forms.Label();
            this.Player2TotalMoneyLabel = new System.Windows.Forms.Label();
            this.Player3TotalMoneyLabel = new System.Windows.Forms.Label();
            this.Player4TotalMoneyLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PotContainerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PokerChipsImage)).BeginInit();
            this.SidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // DealerTitleLabel
            // 
            this.DealerTitleLabel.AutoSize = true;
            this.DealerTitleLabel.Font = new System.Drawing.Font("Baskerville Old Face", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DealerTitleLabel.ForeColor = System.Drawing.Color.White;
            this.DealerTitleLabel.Location = new System.Drawing.Point(600, 320);
            this.DealerTitleLabel.Name = "DealerTitleLabel";
            this.DealerTitleLabel.Size = new System.Drawing.Size(87, 31);
            this.DealerTitleLabel.TabIndex = 4;
            this.DealerTitleLabel.Text = "Dealer";
            // 
            // BlackjackTitleLabel
            // 
            this.BlackjackTitleLabel.AutoSize = true;
            this.BlackjackTitleLabel.Font = new System.Drawing.Font("Baskerville Old Face", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlackjackTitleLabel.ForeColor = System.Drawing.Color.Yellow;
            this.BlackjackTitleLabel.Location = new System.Drawing.Point(390, 390);
            this.BlackjackTitleLabel.Name = "BlackjackTitleLabel";
            this.BlackjackTitleLabel.Size = new System.Drawing.Size(487, 45);
            this.BlackjackTitleLabel.TabIndex = 6;
            this.BlackjackTitleLabel.Text = "BLACKJACK PAYS 3 TO 2";
            // 
            // DealerInfoTitleLabel
            // 
            this.DealerInfoTitleLabel.AutoSize = true;
            this.DealerInfoTitleLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DealerInfoTitleLabel.ForeColor = System.Drawing.Color.White;
            this.DealerInfoTitleLabel.Location = new System.Drawing.Point(350, 450);
            this.DealerInfoTitleLabel.Name = "DealerInfoTitleLabel";
            this.DealerInfoTitleLabel.Size = new System.Drawing.Size(559, 25);
            this.DealerInfoTitleLabel.TabIndex = 7;
            this.DealerInfoTitleLabel.Text = "DEALER MUST DRAW TO 16 and STAND ON ALL 17\'S";
            // 
            // PotAmountLabel
            // 
            this.PotAmountLabel.AutoSize = true;
            this.PotAmountLabel.Font = new System.Drawing.Font("Baskerville Old Face", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PotAmountLabel.ForeColor = System.Drawing.Color.Yellow;
            this.PotAmountLabel.Location = new System.Drawing.Point(430, 30);
            this.PotAmountLabel.Name = "PotAmountLabel";
            this.PotAmountLabel.Size = new System.Drawing.Size(80, 27);
            this.PotAmountLabel.TabIndex = 9;
            this.PotAmountLabel.Text = "Pot: $0";
            // 
            // PotContainerPanel
            // 
            this.PotContainerPanel.BackgroundImage = global::Player.Properties.Resources.rounded_rectangle_pot;
            this.PotContainerPanel.Controls.Add(this.PotAmountLabel);
            this.PotContainerPanel.Location = new System.Drawing.Point(170, 500);
            this.PotContainerPanel.Name = "PotContainerPanel";
            this.PotContainerPanel.Size = new System.Drawing.Size(940, 92);
            this.PotContainerPanel.TabIndex = 10;
            // 
            // Player4CardPanel
            // 
            this.Player4CardPanel.BackgroundImage = global::Player.Properties.Resources.player_panel_background;
            this.Player4CardPanel.Location = new System.Drawing.Point(990, 680);
            this.Player4CardPanel.Name = "Player4CardPanel";
            this.Player4CardPanel.Size = new System.Drawing.Size(120, 162);
            this.Player4CardPanel.TabIndex = 9;
            // 
            // Player3CardPanel
            // 
            this.Player3CardPanel.BackgroundImage = global::Player.Properties.Resources.player_panel_background;
            this.Player3CardPanel.Location = new System.Drawing.Point(710, 680);
            this.Player3CardPanel.Name = "Player3CardPanel";
            this.Player3CardPanel.Size = new System.Drawing.Size(120, 162);
            this.Player3CardPanel.TabIndex = 9;
            // 
            // Player2CardPanel
            // 
            this.Player2CardPanel.BackgroundImage = global::Player.Properties.Resources.player_panel_background;
            this.Player2CardPanel.Location = new System.Drawing.Point(440, 680);
            this.Player2CardPanel.Name = "Player2CardPanel";
            this.Player2CardPanel.Size = new System.Drawing.Size(120, 162);
            this.Player2CardPanel.TabIndex = 9;
            // 
            // Player1CardPanel
            // 
            this.Player1CardPanel.BackgroundImage = global::Player.Properties.Resources.player_panel_background;
            this.Player1CardPanel.Location = new System.Drawing.Point(170, 680);
            this.Player1CardPanel.Name = "Player1CardPanel";
            this.Player1CardPanel.Size = new System.Drawing.Size(120, 162);
            this.Player1CardPanel.TabIndex = 8;
            // 
            // PokerChipsImage
            // 
            this.PokerChipsImage.Image = ((System.Drawing.Image)(resources.GetObject("PokerChipsImage.Image")));
            this.PokerChipsImage.Location = new System.Drawing.Point(580, 25);
            this.PokerChipsImage.Name = "PokerChipsImage";
            this.PokerChipsImage.Size = new System.Drawing.Size(125, 89);
            this.PokerChipsImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PokerChipsImage.TabIndex = 1;
            this.PokerChipsImage.TabStop = false;
            // 
            // SidebarPanel
            // 
            this.SidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(105)))), ((int)(((byte)(39)))));
            this.SidebarPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SidebarPanel.BackgroundImage")));
            this.SidebarPanel.Controls.Add(this.GameStatusLabel);
            this.SidebarPanel.Controls.Add(this.TotalMoneyAvailableLabel);
            this.SidebarPanel.Controls.Add(this.TotalMoneyAvailableTitleLabel);
            this.SidebarPanel.Location = new System.Drawing.Point(1364, 0);
            this.SidebarPanel.Name = "SidebarPanel";
            this.SidebarPanel.Size = new System.Drawing.Size(370, 1000);
            this.SidebarPanel.TabIndex = 0;
            // 
            // GameStatusLabel
            // 
            this.GameStatusLabel.AutoSize = true;
            this.GameStatusLabel.Font = new System.Drawing.Font("Baskerville Old Face", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameStatusLabel.ForeColor = System.Drawing.Color.White;
            this.GameStatusLabel.Location = new System.Drawing.Point(160, 270);
            this.GameStatusLabel.Name = "GameStatusLabel";
            this.GameStatusLabel.Size = new System.Drawing.Size(68, 31);
            this.GameStatusLabel.TabIndex = 2;
            this.GameStatusLabel.Text = "BET";
            // 
            // TotalMoneyAvailableLabel
            // 
            this.TotalMoneyAvailableLabel.AutoSize = true;
            this.TotalMoneyAvailableLabel.Font = new System.Drawing.Font("Baskerville Old Face", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalMoneyAvailableLabel.ForeColor = System.Drawing.Color.White;
            this.TotalMoneyAvailableLabel.Location = new System.Drawing.Point(160, 130);
            this.TotalMoneyAvailableLabel.Name = "TotalMoneyAvailableLabel";
            this.TotalMoneyAvailableLabel.Size = new System.Drawing.Size(75, 34);
            this.TotalMoneyAvailableLabel.TabIndex = 1;
            this.TotalMoneyAvailableLabel.Text = "$250";
            // 
            // TotalMoneyAvailableTitleLabel
            // 
            this.TotalMoneyAvailableTitleLabel.AutoSize = true;
            this.TotalMoneyAvailableTitleLabel.Font = new System.Drawing.Font("Baskerville Old Face", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalMoneyAvailableTitleLabel.ForeColor = System.Drawing.Color.White;
            this.TotalMoneyAvailableTitleLabel.Location = new System.Drawing.Point(110, 90);
            this.TotalMoneyAvailableTitleLabel.Name = "TotalMoneyAvailableTitleLabel";
            this.TotalMoneyAvailableTitleLabel.Size = new System.Drawing.Size(181, 34);
            this.TotalMoneyAvailableTitleLabel.TabIndex = 0;
            this.TotalMoneyAvailableTitleLabel.Text = "Total Money:";
            // 
            // Player1NameLabel
            // 
            this.Player1NameLabel.AutoSize = true;
            this.Player1NameLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1NameLabel.ForeColor = System.Drawing.Color.White;
            this.Player1NameLabel.Location = new System.Drawing.Point(185, 650);
            this.Player1NameLabel.Name = "Player1NameLabel";
            this.Player1NameLabel.Size = new System.Drawing.Size(96, 25);
            this.Player1NameLabel.TabIndex = 11;
            this.Player1NameLabel.Text = "P1 Name";
            // 
            // Player2NameLabel
            // 
            this.Player2NameLabel.AutoSize = true;
            this.Player2NameLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2NameLabel.ForeColor = System.Drawing.Color.White;
            this.Player2NameLabel.Location = new System.Drawing.Point(455, 650);
            this.Player2NameLabel.Name = "Player2NameLabel";
            this.Player2NameLabel.Size = new System.Drawing.Size(96, 25);
            this.Player2NameLabel.TabIndex = 12;
            this.Player2NameLabel.Text = "P2 Name";
            // 
            // Player3NameLabel
            // 
            this.Player3NameLabel.AutoSize = true;
            this.Player3NameLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player3NameLabel.ForeColor = System.Drawing.Color.White;
            this.Player3NameLabel.Location = new System.Drawing.Point(725, 650);
            this.Player3NameLabel.Name = "Player3NameLabel";
            this.Player3NameLabel.Size = new System.Drawing.Size(96, 25);
            this.Player3NameLabel.TabIndex = 13;
            this.Player3NameLabel.Text = "P3 Name";
            // 
            // Player4NameLabel
            // 
            this.Player4NameLabel.AutoSize = true;
            this.Player4NameLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player4NameLabel.ForeColor = System.Drawing.Color.White;
            this.Player4NameLabel.Location = new System.Drawing.Point(1005, 650);
            this.Player4NameLabel.Name = "Player4NameLabel";
            this.Player4NameLabel.Size = new System.Drawing.Size(96, 25);
            this.Player4NameLabel.TabIndex = 14;
            this.Player4NameLabel.Text = "P4 Name";
            // 
            // Player1CardValueLabel
            // 
            this.Player1CardValueLabel.AutoSize = true;
            this.Player1CardValueLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1CardValueLabel.ForeColor = System.Drawing.Color.Yellow;
            this.Player1CardValueLabel.Location = new System.Drawing.Point(220, 620);
            this.Player1CardValueLabel.Name = "Player1CardValueLabel";
            this.Player1CardValueLabel.Size = new System.Drawing.Size(34, 25);
            this.Player1CardValueLabel.TabIndex = 15;
            this.Player1CardValueLabel.Text = "21";
            // 
            // Player2CardValueLabel
            // 
            this.Player2CardValueLabel.AutoSize = true;
            this.Player2CardValueLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2CardValueLabel.ForeColor = System.Drawing.Color.Yellow;
            this.Player2CardValueLabel.Location = new System.Drawing.Point(490, 620);
            this.Player2CardValueLabel.Name = "Player2CardValueLabel";
            this.Player2CardValueLabel.Size = new System.Drawing.Size(34, 25);
            this.Player2CardValueLabel.TabIndex = 16;
            this.Player2CardValueLabel.Text = "21";
            // 
            // Player3CardValueLabel
            // 
            this.Player3CardValueLabel.AutoSize = true;
            this.Player3CardValueLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player3CardValueLabel.ForeColor = System.Drawing.Color.Yellow;
            this.Player3CardValueLabel.Location = new System.Drawing.Point(755, 620);
            this.Player3CardValueLabel.Name = "Player3CardValueLabel";
            this.Player3CardValueLabel.Size = new System.Drawing.Size(34, 25);
            this.Player3CardValueLabel.TabIndex = 17;
            this.Player3CardValueLabel.Text = "21";
            // 
            // Player4CardValueLabel
            // 
            this.Player4CardValueLabel.AutoSize = true;
            this.Player4CardValueLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player4CardValueLabel.ForeColor = System.Drawing.Color.Yellow;
            this.Player4CardValueLabel.Location = new System.Drawing.Point(1035, 620);
            this.Player4CardValueLabel.Name = "Player4CardValueLabel";
            this.Player4CardValueLabel.Size = new System.Drawing.Size(34, 25);
            this.Player4CardValueLabel.TabIndex = 18;
            this.Player4CardValueLabel.Text = "21";
            // 
            // Player1BetAmountLabel
            // 
            this.Player1BetAmountLabel.AutoSize = true;
            this.Player1BetAmountLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1BetAmountLabel.ForeColor = System.Drawing.Color.White;
            this.Player1BetAmountLabel.Location = new System.Drawing.Point(190, 850);
            this.Player1BetAmountLabel.Name = "Player1BetAmountLabel";
            this.Player1BetAmountLabel.Size = new System.Drawing.Size(76, 25);
            this.Player1BetAmountLabel.TabIndex = 19;
            this.Player1BetAmountLabel.Text = "Bet: $0";
            // 
            // Player2BetAmountLabel
            // 
            this.Player2BetAmountLabel.AutoSize = true;
            this.Player2BetAmountLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2BetAmountLabel.ForeColor = System.Drawing.Color.White;
            this.Player2BetAmountLabel.Location = new System.Drawing.Point(465, 850);
            this.Player2BetAmountLabel.Name = "Player2BetAmountLabel";
            this.Player2BetAmountLabel.Size = new System.Drawing.Size(76, 25);
            this.Player2BetAmountLabel.TabIndex = 20;
            this.Player2BetAmountLabel.Text = "Bet: $0";
            // 
            // Player3BetAmountLabel
            // 
            this.Player3BetAmountLabel.AutoSize = true;
            this.Player3BetAmountLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player3BetAmountLabel.ForeColor = System.Drawing.Color.White;
            this.Player3BetAmountLabel.Location = new System.Drawing.Point(735, 850);
            this.Player3BetAmountLabel.Name = "Player3BetAmountLabel";
            this.Player3BetAmountLabel.Size = new System.Drawing.Size(76, 25);
            this.Player3BetAmountLabel.TabIndex = 21;
            this.Player3BetAmountLabel.Text = "Bet: $0";
            // 
            // Player4BetAmountLabel
            // 
            this.Player4BetAmountLabel.AutoSize = true;
            this.Player4BetAmountLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player4BetAmountLabel.ForeColor = System.Drawing.Color.White;
            this.Player4BetAmountLabel.Location = new System.Drawing.Point(1015, 850);
            this.Player4BetAmountLabel.Name = "Player4BetAmountLabel";
            this.Player4BetAmountLabel.Size = new System.Drawing.Size(76, 25);
            this.Player4BetAmountLabel.TabIndex = 22;
            this.Player4BetAmountLabel.Text = "Bet: $0";
            // 
            // Player1TotalMoneyLabel
            // 
            this.Player1TotalMoneyLabel.AutoSize = true;
            this.Player1TotalMoneyLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1TotalMoneyLabel.ForeColor = System.Drawing.Color.Silver;
            this.Player1TotalMoneyLabel.Location = new System.Drawing.Point(200, 900);
            this.Player1TotalMoneyLabel.Name = "Player1TotalMoneyLabel";
            this.Player1TotalMoneyLabel.Size = new System.Drawing.Size(60, 25);
            this.Player1TotalMoneyLabel.TabIndex = 23;
            this.Player1TotalMoneyLabel.Text = "$250";
            // 
            // Player2TotalMoneyLabel
            // 
            this.Player2TotalMoneyLabel.AutoSize = true;
            this.Player2TotalMoneyLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2TotalMoneyLabel.ForeColor = System.Drawing.Color.Silver;
            this.Player2TotalMoneyLabel.Location = new System.Drawing.Point(475, 900);
            this.Player2TotalMoneyLabel.Name = "Player2TotalMoneyLabel";
            this.Player2TotalMoneyLabel.Size = new System.Drawing.Size(60, 25);
            this.Player2TotalMoneyLabel.TabIndex = 24;
            this.Player2TotalMoneyLabel.Text = "$250";
            // 
            // Player3TotalMoneyLabel
            // 
            this.Player3TotalMoneyLabel.AutoSize = true;
            this.Player3TotalMoneyLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player3TotalMoneyLabel.ForeColor = System.Drawing.Color.Silver;
            this.Player3TotalMoneyLabel.Location = new System.Drawing.Point(740, 900);
            this.Player3TotalMoneyLabel.Name = "Player3TotalMoneyLabel";
            this.Player3TotalMoneyLabel.Size = new System.Drawing.Size(60, 25);
            this.Player3TotalMoneyLabel.TabIndex = 25;
            this.Player3TotalMoneyLabel.Text = "$250";
            // 
            // Player4TotalMoneyLabel
            // 
            this.Player4TotalMoneyLabel.AutoSize = true;
            this.Player4TotalMoneyLabel.Font = new System.Drawing.Font("Baskerville Old Face", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player4TotalMoneyLabel.ForeColor = System.Drawing.Color.Silver;
            this.Player4TotalMoneyLabel.Location = new System.Drawing.Point(1025, 895);
            this.Player4TotalMoneyLabel.Name = "Player4TotalMoneyLabel";
            this.Player4TotalMoneyLabel.Size = new System.Drawing.Size(60, 25);
            this.Player4TotalMoneyLabel.TabIndex = 26;
            this.Player4TotalMoneyLabel.Text = "$250";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(135, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1060, 95);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(112, 208);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // InGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(162)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1734, 961);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Player4TotalMoneyLabel);
            this.Controls.Add(this.Player3TotalMoneyLabel);
            this.Controls.Add(this.Player2TotalMoneyLabel);
            this.Controls.Add(this.Player1TotalMoneyLabel);
            this.Controls.Add(this.Player4BetAmountLabel);
            this.Controls.Add(this.Player3BetAmountLabel);
            this.Controls.Add(this.Player2BetAmountLabel);
            this.Controls.Add(this.Player1BetAmountLabel);
            this.Controls.Add(this.Player4CardValueLabel);
            this.Controls.Add(this.Player3CardValueLabel);
            this.Controls.Add(this.Player2CardValueLabel);
            this.Controls.Add(this.Player1CardValueLabel);
            this.Controls.Add(this.Player4NameLabel);
            this.Controls.Add(this.Player3NameLabel);
            this.Controls.Add(this.Player2NameLabel);
            this.Controls.Add(this.Player1NameLabel);
            this.Controls.Add(this.PotContainerPanel);
            this.Controls.Add(this.Player4CardPanel);
            this.Controls.Add(this.Player3CardPanel);
            this.Controls.Add(this.Player2CardPanel);
            this.Controls.Add(this.Player1CardPanel);
            this.Controls.Add(this.DealerInfoTitleLabel);
            this.Controls.Add(this.BlackjackTitleLabel);
            this.Controls.Add(this.DealerTitleLabel);
            this.Controls.Add(this.PokerChipsImage);
            this.Controls.Add(this.SidebarPanel);
            this.Name = "InGame";
            this.Text = "Blackjack";
            this.Load += new System.EventHandler(this.InGame_Load);
            this.PotContainerPanel.ResumeLayout(false);
            this.PotContainerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PokerChipsImage)).EndInit();
            this.SidebarPanel.ResumeLayout(false);
            this.SidebarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel SidebarPanel;
        private System.Windows.Forms.PictureBox PokerChipsImage;
        private System.Windows.Forms.Label DealerTitleLabel;
        private System.Windows.Forms.Label BlackjackTitleLabel;
        private System.Windows.Forms.Label DealerInfoTitleLabel;
        private System.Windows.Forms.Panel Player1CardPanel;
        private System.Windows.Forms.Label TotalMoneyAvailableLabel;
        private System.Windows.Forms.Label TotalMoneyAvailableTitleLabel;
        private System.Windows.Forms.Label GameStatusLabel;
        private System.Windows.Forms.Label PotAmountLabel;
        private System.Windows.Forms.Panel Player2CardPanel;
        private System.Windows.Forms.Panel Player3CardPanel;
        private System.Windows.Forms.Panel Player4CardPanel;
        private System.Windows.Forms.Panel PotContainerPanel;
        private System.Windows.Forms.Label Player1NameLabel;
        private System.Windows.Forms.Label Player2NameLabel;
        private System.Windows.Forms.Label Player3NameLabel;
        private System.Windows.Forms.Label Player4NameLabel;
        private System.Windows.Forms.Label Player1CardValueLabel;
        private System.Windows.Forms.Label Player2CardValueLabel;
        private System.Windows.Forms.Label Player3CardValueLabel;
        private System.Windows.Forms.Label Player4CardValueLabel;
        private System.Windows.Forms.Label Player1BetAmountLabel;
        private System.Windows.Forms.Label Player2BetAmountLabel;
        private System.Windows.Forms.Label Player3BetAmountLabel;
        private System.Windows.Forms.Label Player4BetAmountLabel;
        private System.Windows.Forms.Label Player1TotalMoneyLabel;
        private System.Windows.Forms.Label Player2TotalMoneyLabel;
        private System.Windows.Forms.Label Player3TotalMoneyLabel;
        private System.Windows.Forms.Label Player4TotalMoneyLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}