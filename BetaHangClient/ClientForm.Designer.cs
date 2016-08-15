namespace BetaHangClient
{
    partial class ClientForm
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
            this.player1Label = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            this.player3Label = new System.Windows.Forms.Label();
            this.player4Label = new System.Windows.Forms.Label();
            this.textBoxGuess = new System.Windows.Forms.TextBox();
            this.buttonSubmitGuess = new System.Windows.Forms.Button();
            this.lblPlayerOneGuess = new System.Windows.Forms.Label();
            this.lblPlayerTwoGuess = new System.Windows.Forms.Label();
            this.lblPlayerThreeGuess = new System.Windows.Forms.Label();
            this.LblPlayerFourGuess = new System.Windows.Forms.Label();
            this.lblPlayerOnePoints = new System.Windows.Forms.Label();
            this.lblPlayerTwoPoints = new System.Windows.Forms.Label();
            this.lblPlayerThreePoints = new System.Windows.Forms.Label();
            this.lblPlayerFourPoints = new System.Windows.Forms.Label();
            this.LblDisplayWord = new System.Windows.Forms.Label();
            this.lblRound = new System.Windows.Forms.Label();
            this.PanelGameStart = new System.Windows.Forms.Panel();
            this.lbPlayerOverLB = new System.Windows.Forms.Label();
            this.btnReadyForGame = new System.Windows.Forms.Button();
            this.PlayerListBox = new System.Windows.Forms.ListBox();
            this.buttonJoin = new System.Windows.Forms.Button();
            this.Logo = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbServer = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.tBPassword = new System.Windows.Forms.TextBox();
            this.tBUserName = new System.Windows.Forms.TextBox();
            this.tBServerIP = new System.Windows.Forms.TextBox();
            this.lblCountDown = new System.Windows.Forms.Label();
            this.PanelGameStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Label.Location = new System.Drawing.Point(43, 328);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(91, 17);
            this.player1Label.TabIndex = 2;
            this.player1Label.Text = "Player1Label";
            this.player1Label.Click += new System.EventHandler(this.label1_Click);
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = true;
            this.player2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2Label.Location = new System.Drawing.Point(156, 328);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(91, 17);
            this.player2Label.TabIndex = 3;
            this.player2Label.Text = "Player2Label";
            // 
            // player3Label
            // 
            this.player3Label.AutoSize = true;
            this.player3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player3Label.Location = new System.Drawing.Point(290, 328);
            this.player3Label.Name = "player3Label";
            this.player3Label.Size = new System.Drawing.Size(91, 17);
            this.player3Label.TabIndex = 4;
            this.player3Label.Text = "Player3Label";
            // 
            // player4Label
            // 
            this.player4Label.AutoSize = true;
            this.player4Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player4Label.Location = new System.Drawing.Point(415, 328);
            this.player4Label.Name = "player4Label";
            this.player4Label.Size = new System.Drawing.Size(91, 17);
            this.player4Label.TabIndex = 5;
            this.player4Label.Text = "Player4Label";
            // 
            // textBoxGuess
            // 
            this.textBoxGuess.Location = new System.Drawing.Point(134, 414);
            this.textBoxGuess.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxGuess.Name = "textBoxGuess";
            this.textBoxGuess.Size = new System.Drawing.Size(154, 20);
            this.textBoxGuess.TabIndex = 8;
            // 
            // buttonSubmitGuess
            // 
            this.buttonSubmitGuess.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonSubmitGuess.Location = new System.Drawing.Point(306, 406);
            this.buttonSubmitGuess.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSubmitGuess.Name = "buttonSubmitGuess";
            this.buttonSubmitGuess.Size = new System.Drawing.Size(88, 36);
            this.buttonSubmitGuess.TabIndex = 9;
            this.buttonSubmitGuess.Text = "Guess!";
            this.buttonSubmitGuess.UseVisualStyleBackColor = false;
            this.buttonSubmitGuess.Click += new System.EventHandler(this.buttonSubmitGuess_Click);
            // 
            // lblPlayerOneGuess
            // 
            this.lblPlayerOneGuess.AutoSize = true;
            this.lblPlayerOneGuess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerOneGuess.Location = new System.Drawing.Point(42, 290);
            this.lblPlayerOneGuess.Name = "lblPlayerOneGuess";
            this.lblPlayerOneGuess.Size = new System.Drawing.Size(108, 20);
            this.lblPlayerOneGuess.TabIndex = 10;
            this.lblPlayerOneGuess.Text = "Player1Guess";
            // 
            // lblPlayerTwoGuess
            // 
            this.lblPlayerTwoGuess.AutoSize = true;
            this.lblPlayerTwoGuess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerTwoGuess.Location = new System.Drawing.Point(156, 290);
            this.lblPlayerTwoGuess.Name = "lblPlayerTwoGuess";
            this.lblPlayerTwoGuess.Size = new System.Drawing.Size(108, 20);
            this.lblPlayerTwoGuess.TabIndex = 11;
            this.lblPlayerTwoGuess.Text = "Player2Guess";
            // 
            // lblPlayerThreeGuess
            // 
            this.lblPlayerThreeGuess.AutoSize = true;
            this.lblPlayerThreeGuess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerThreeGuess.Location = new System.Drawing.Point(290, 290);
            this.lblPlayerThreeGuess.Name = "lblPlayerThreeGuess";
            this.lblPlayerThreeGuess.Size = new System.Drawing.Size(108, 20);
            this.lblPlayerThreeGuess.TabIndex = 12;
            this.lblPlayerThreeGuess.Text = "Player3Guess";
            // 
            // LblPlayerFourGuess
            // 
            this.LblPlayerFourGuess.AutoSize = true;
            this.LblPlayerFourGuess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPlayerFourGuess.Location = new System.Drawing.Point(414, 290);
            this.LblPlayerFourGuess.Name = "LblPlayerFourGuess";
            this.LblPlayerFourGuess.Size = new System.Drawing.Size(108, 20);
            this.LblPlayerFourGuess.TabIndex = 13;
            this.LblPlayerFourGuess.Text = "Player4Guess";
            // 
            // lblPlayerOnePoints
            // 
            this.lblPlayerOnePoints.AutoSize = true;
            this.lblPlayerOnePoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerOnePoints.Location = new System.Drawing.Point(43, 362);
            this.lblPlayerOnePoints.Name = "lblPlayerOnePoints";
            this.lblPlayerOnePoints.Size = new System.Drawing.Size(105, 20);
            this.lblPlayerOnePoints.TabIndex = 14;
            this.lblPlayerOnePoints.Text = "Player1Points";
            // 
            // lblPlayerTwoPoints
            // 
            this.lblPlayerTwoPoints.AutoSize = true;
            this.lblPlayerTwoPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerTwoPoints.Location = new System.Drawing.Point(156, 362);
            this.lblPlayerTwoPoints.Name = "lblPlayerTwoPoints";
            this.lblPlayerTwoPoints.Size = new System.Drawing.Size(105, 20);
            this.lblPlayerTwoPoints.TabIndex = 15;
            this.lblPlayerTwoPoints.Text = "Player2Points";
            // 
            // lblPlayerThreePoints
            // 
            this.lblPlayerThreePoints.AutoSize = true;
            this.lblPlayerThreePoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerThreePoints.Location = new System.Drawing.Point(290, 362);
            this.lblPlayerThreePoints.Name = "lblPlayerThreePoints";
            this.lblPlayerThreePoints.Size = new System.Drawing.Size(105, 20);
            this.lblPlayerThreePoints.TabIndex = 16;
            this.lblPlayerThreePoints.Text = "Player3Points";
            // 
            // lblPlayerFourPoints
            // 
            this.lblPlayerFourPoints.AutoSize = true;
            this.lblPlayerFourPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerFourPoints.Location = new System.Drawing.Point(414, 362);
            this.lblPlayerFourPoints.Name = "lblPlayerFourPoints";
            this.lblPlayerFourPoints.Size = new System.Drawing.Size(105, 20);
            this.lblPlayerFourPoints.TabIndex = 17;
            this.lblPlayerFourPoints.Text = "Player4Points";
            // 
            // LblDisplayWord
            // 
            this.LblDisplayWord.AutoSize = true;
            this.LblDisplayWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDisplayWord.Location = new System.Drawing.Point(47, 125);
            this.LblDisplayWord.MinimumSize = new System.Drawing.Size(435, 100);
            this.LblDisplayWord.Name = "LblDisplayWord";
            this.LblDisplayWord.Size = new System.Drawing.Size(435, 100);
            this.LblDisplayWord.TabIndex = 18;
            this.LblDisplayWord.Text = "DISPLAYWORD";
            this.LblDisplayWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRound.Location = new System.Drawing.Point(212, 31);
            this.lblRound.MinimumSize = new System.Drawing.Size(80, 30);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(110, 30);
            this.lblRound.TabIndex = 19;
            this.lblRound.Text = "ROUND: X";
            // 
            // PanelGameStart
            // 
            this.PanelGameStart.Controls.Add(this.lbPlayerOverLB);
            this.PanelGameStart.Controls.Add(this.btnReadyForGame);
            this.PanelGameStart.Controls.Add(this.PlayerListBox);
            this.PanelGameStart.Controls.Add(this.buttonJoin);
            this.PanelGameStart.Controls.Add(this.Logo);
            this.PanelGameStart.Controls.Add(this.lbPassword);
            this.PanelGameStart.Controls.Add(this.lbServer);
            this.PanelGameStart.Controls.Add(this.lbUserName);
            this.PanelGameStart.Controls.Add(this.tBPassword);
            this.PanelGameStart.Controls.Add(this.tBUserName);
            this.PanelGameStart.Controls.Add(this.tBServerIP);
            this.PanelGameStart.Location = new System.Drawing.Point(12, 12);
            this.PanelGameStart.Name = "PanelGameStart";
            this.PanelGameStart.Size = new System.Drawing.Size(524, 460);
            this.PanelGameStart.TabIndex = 20;
            // 
            // lbPlayerOverLB
            // 
            this.lbPlayerOverLB.AutoSize = true;
            this.lbPlayerOverLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlayerOverLB.Location = new System.Drawing.Point(35, 261);
            this.lbPlayerOverLB.Name = "lbPlayerOverLB";
            this.lbPlayerOverLB.Size = new System.Drawing.Size(67, 20);
            this.lbPlayerOverLB.TabIndex = 10;
            this.lbPlayerOverLB.Text = "Players";
            // 
            // btnReadyForGame
            // 
            this.btnReadyForGame.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReadyForGame.Location = new System.Drawing.Point(400, 415);
            this.btnReadyForGame.Name = "btnReadyForGame";
            this.btnReadyForGame.Size = new System.Drawing.Size(75, 23);
            this.btnReadyForGame.TabIndex = 9;
            this.btnReadyForGame.Text = "Ready";
            this.btnReadyForGame.UseVisualStyleBackColor = false;
            this.btnReadyForGame.Click += new System.EventHandler(this.btnReadyForGame_Click);
            // 
            // PlayerListBox
            // 
            this.PlayerListBox.FormattingEnabled = true;
            this.PlayerListBox.Location = new System.Drawing.Point(35, 293);
            this.PlayerListBox.Name = "PlayerListBox";
            this.PlayerListBox.Size = new System.Drawing.Size(440, 108);
            this.PlayerListBox.TabIndex = 8;
            // 
            // buttonJoin
            // 
            this.buttonJoin.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonJoin.Location = new System.Drawing.Point(204, 192);
            this.buttonJoin.Name = "buttonJoin";
            this.buttonJoin.Size = new System.Drawing.Size(75, 23);
            this.buttonJoin.TabIndex = 7;
            this.buttonJoin.Text = "Join game";
            this.buttonJoin.UseVisualStyleBackColor = false;
            this.buttonJoin.Click += new System.EventHandler(this.buttonJoin_Click);
            // 
            // Logo
            // 
            this.Logo.AutoSize = true;
            this.Logo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logo.Location = new System.Drawing.Point(175, 18);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(185, 42);
            this.Logo.TabIndex = 6;
            this.Logo.Text = "BetaHang";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.Location = new System.Drawing.Point(35, 120);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(61, 13);
            this.lbPassword.TabIndex = 5;
            this.lbPassword.Text = "Password";
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbServer.Location = new System.Drawing.Point(35, 71);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(44, 13);
            this.lbServer.TabIndex = 4;
            this.lbServer.Text = "Server";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.Location = new System.Drawing.Point(35, 176);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(63, 13);
            this.lbUserName.TabIndex = 3;
            this.lbUserName.Text = "Username";
            // 
            // tBPassword
            // 
            this.tBPassword.Location = new System.Drawing.Point(38, 136);
            this.tBPassword.Name = "tBPassword";
            this.tBPassword.Size = new System.Drawing.Size(147, 20);
            this.tBPassword.TabIndex = 1;
            // 
            // tBUserName
            // 
            this.tBUserName.Location = new System.Drawing.Point(38, 192);
            this.tBUserName.Name = "tBUserName";
            this.tBUserName.Size = new System.Drawing.Size(147, 20);
            this.tBUserName.TabIndex = 2;
            // 
            // tBServerIP
            // 
            this.tBServerIP.Location = new System.Drawing.Point(38, 87);
            this.tBServerIP.Name = "tBServerIP";
            this.tBServerIP.Size = new System.Drawing.Size(147, 20);
            this.tBServerIP.TabIndex = 0;
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDown.Location = new System.Drawing.Point(455, 9);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(80, 55);
            this.lblCountDown.TabIndex = 22;
            this.lblCountDown.Text = "77";
            // 
            // ClientForm
            // 
            this.AcceptButton = this.buttonSubmitGuess;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(536, 523);
            this.Controls.Add(this.PanelGameStart);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.LblDisplayWord);
            this.Controls.Add(this.lblPlayerFourPoints);
            this.Controls.Add(this.lblPlayerThreePoints);
            this.Controls.Add(this.lblPlayerTwoPoints);
            this.Controls.Add(this.lblPlayerOnePoints);
            this.Controls.Add(this.LblPlayerFourGuess);
            this.Controls.Add(this.lblPlayerThreeGuess);
            this.Controls.Add(this.lblPlayerTwoGuess);
            this.Controls.Add(this.lblPlayerOneGuess);
            this.Controls.Add(this.buttonSubmitGuess);
            this.Controls.Add(this.textBoxGuess);
            this.Controls.Add(this.player4Label);
            this.Controls.Add(this.player3Label);
            this.Controls.Add(this.player2Label);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.lblCountDown);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClientForm";
            this.Text = "BetaHang";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.PanelGameStart.ResumeLayout(false);
            this.PanelGameStart.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.Label player2Label;
        private System.Windows.Forms.Label player3Label;
        private System.Windows.Forms.Label player4Label;
        private System.Windows.Forms.TextBox textBoxGuess;
        private System.Windows.Forms.Button buttonSubmitGuess;
        private System.Windows.Forms.Label lblPlayerOneGuess;
        private System.Windows.Forms.Label lblPlayerTwoGuess;
        private System.Windows.Forms.Label lblPlayerThreeGuess;
        private System.Windows.Forms.Label LblPlayerFourGuess;
        private System.Windows.Forms.Label lblPlayerOnePoints;
        private System.Windows.Forms.Label lblPlayerTwoPoints;
        private System.Windows.Forms.Label lblPlayerThreePoints;
        private System.Windows.Forms.Label lblPlayerFourPoints;
        private System.Windows.Forms.Label LblDisplayWord;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Panel PanelGameStart;
        private System.Windows.Forms.Label Logo;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TextBox tBPassword;
        private System.Windows.Forms.TextBox tBUserName;
        private System.Windows.Forms.TextBox tBServerIP;
        private System.Windows.Forms.Label lbPlayerOverLB;
        private System.Windows.Forms.Button btnReadyForGame;
        private System.Windows.Forms.ListBox PlayerListBox;
        private System.Windows.Forms.Button buttonJoin;
        private System.Windows.Forms.Label lblCountDown;
    }
}

