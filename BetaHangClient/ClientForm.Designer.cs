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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.player1Label = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            this.player3Label = new System.Windows.Forms.Label();
            this.player4Label = new System.Windows.Forms.Label();
            this.readyButton = new System.Windows.Forms.Button();
            this.listBoxDebug = new System.Windows.Forms.ListBox();
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
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(430, 31);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(56, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Location = new System.Drawing.Point(47, 328);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(67, 13);
            this.player1Label.TabIndex = 2;
            this.player1Label.Text = "player1Label";
            this.player1Label.Click += new System.EventHandler(this.label1_Click);
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = true;
            this.player2Label.Location = new System.Drawing.Point(156, 328);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(67, 13);
            this.player2Label.TabIndex = 3;
            this.player2Label.Text = "player2Label";
            // 
            // player3Label
            // 
            this.player3Label.AutoSize = true;
            this.player3Label.Location = new System.Drawing.Point(295, 328);
            this.player3Label.Name = "player3Label";
            this.player3Label.Size = new System.Drawing.Size(67, 13);
            this.player3Label.TabIndex = 4;
            this.player3Label.Text = "player3Label";
            // 
            // player4Label
            // 
            this.player4Label.AutoSize = true;
            this.player4Label.Location = new System.Drawing.Point(415, 328);
            this.player4Label.Name = "player4Label";
            this.player4Label.Size = new System.Drawing.Size(67, 13);
            this.player4Label.TabIndex = 5;
            this.player4Label.Text = "player4Label";
            // 
            // readyButton
            // 
            this.readyButton.Location = new System.Drawing.Point(22, 31);
            this.readyButton.Name = "readyButton";
            this.readyButton.Size = new System.Drawing.Size(75, 23);
            this.readyButton.TabIndex = 6;
            this.readyButton.Text = "Ready!";
            this.readyButton.UseVisualStyleBackColor = true;
            this.readyButton.Click += new System.EventHandler(this.readyButton_Click);
            // 
            // listBoxDebug
            // 
            this.listBoxDebug.FormattingEnabled = true;
            this.listBoxDebug.Location = new System.Drawing.Point(11, 479);
            this.listBoxDebug.Name = "listBoxDebug";
            this.listBoxDebug.Size = new System.Drawing.Size(217, 160);
            this.listBoxDebug.TabIndex = 7;
            // 
            // textBoxGuess
            // 
            this.textBoxGuess.Location = new System.Drawing.Point(116, 414);
            this.textBoxGuess.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxGuess.Name = "textBoxGuess";
            this.textBoxGuess.Size = new System.Drawing.Size(154, 20);
            this.textBoxGuess.TabIndex = 8;
            this.textBoxGuess.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxGuess_KeyPress);
            // 
            // buttonSubmitGuess
            // 
            this.buttonSubmitGuess.Location = new System.Drawing.Point(316, 415);
            this.buttonSubmitGuess.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSubmitGuess.Name = "buttonSubmitGuess";
            this.buttonSubmitGuess.Size = new System.Drawing.Size(88, 19);
            this.buttonSubmitGuess.TabIndex = 9;
            this.buttonSubmitGuess.Text = "submit guess";
            this.buttonSubmitGuess.UseVisualStyleBackColor = true;
            this.buttonSubmitGuess.Click += new System.EventHandler(this.buttonSubmitGuess_Click);
            // 
            // lblPlayerOneGuess
            // 
            this.lblPlayerOneGuess.AutoSize = true;
            this.lblPlayerOneGuess.Location = new System.Drawing.Point(47, 290);
            this.lblPlayerOneGuess.Name = "lblPlayerOneGuess";
            this.lblPlayerOneGuess.Size = new System.Drawing.Size(72, 13);
            this.lblPlayerOneGuess.TabIndex = 10;
            this.lblPlayerOneGuess.Text = "Player1Guess";
            // 
            // lblPlayerTwoGuess
            // 
            this.lblPlayerTwoGuess.AutoSize = true;
            this.lblPlayerTwoGuess.Location = new System.Drawing.Point(156, 290);
            this.lblPlayerTwoGuess.Name = "lblPlayerTwoGuess";
            this.lblPlayerTwoGuess.Size = new System.Drawing.Size(72, 13);
            this.lblPlayerTwoGuess.TabIndex = 11;
            this.lblPlayerTwoGuess.Text = "Player2Guess";
            // 
            // lblPlayerThreeGuess
            // 
            this.lblPlayerThreeGuess.AutoSize = true;
            this.lblPlayerThreeGuess.Location = new System.Drawing.Point(290, 290);
            this.lblPlayerThreeGuess.Name = "lblPlayerThreeGuess";
            this.lblPlayerThreeGuess.Size = new System.Drawing.Size(72, 13);
            this.lblPlayerThreeGuess.TabIndex = 12;
            this.lblPlayerThreeGuess.Text = "Player3Guess";
            // 
            // LblPlayerFourGuess
            // 
            this.LblPlayerFourGuess.AutoSize = true;
            this.LblPlayerFourGuess.Location = new System.Drawing.Point(414, 290);
            this.LblPlayerFourGuess.Name = "LblPlayerFourGuess";
            this.LblPlayerFourGuess.Size = new System.Drawing.Size(72, 13);
            this.LblPlayerFourGuess.TabIndex = 13;
            this.LblPlayerFourGuess.Text = "Player4Guess";
            // 
            // lblPlayerOnePoints
            // 
            this.lblPlayerOnePoints.AutoSize = true;
            this.lblPlayerOnePoints.Location = new System.Drawing.Point(43, 362);
            this.lblPlayerOnePoints.Name = "lblPlayerOnePoints";
            this.lblPlayerOnePoints.Size = new System.Drawing.Size(71, 13);
            this.lblPlayerOnePoints.TabIndex = 14;
            this.lblPlayerOnePoints.Text = "Player1Points";
            // 
            // lblPlayerTwoPoints
            // 
            this.lblPlayerTwoPoints.AutoSize = true;
            this.lblPlayerTwoPoints.Location = new System.Drawing.Point(157, 362);
            this.lblPlayerTwoPoints.Name = "lblPlayerTwoPoints";
            this.lblPlayerTwoPoints.Size = new System.Drawing.Size(71, 13);
            this.lblPlayerTwoPoints.TabIndex = 15;
            this.lblPlayerTwoPoints.Text = "Player2Points";
            // 
            // lblPlayerThreePoints
            // 
            this.lblPlayerThreePoints.AutoSize = true;
            this.lblPlayerThreePoints.Location = new System.Drawing.Point(295, 362);
            this.lblPlayerThreePoints.Name = "lblPlayerThreePoints";
            this.lblPlayerThreePoints.Size = new System.Drawing.Size(71, 13);
            this.lblPlayerThreePoints.TabIndex = 16;
            this.lblPlayerThreePoints.Text = "Player3Points";
            // 
            // lblPlayerFourPoints
            // 
            this.lblPlayerFourPoints.AutoSize = true;
            this.lblPlayerFourPoints.Location = new System.Drawing.Point(414, 362);
            this.lblPlayerFourPoints.Name = "lblPlayerFourPoints";
            this.lblPlayerFourPoints.Size = new System.Drawing.Size(71, 13);
            this.lblPlayerFourPoints.TabIndex = 17;
            this.lblPlayerFourPoints.Text = "Player4Points";
            // 
            // LblDisplayWord
            // 
            this.LblDisplayWord.AutoSize = true;
            this.LblDisplayWord.Font = new System.Drawing.Font("Gill Sans Nova Cond Ultra Bold", 24F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRound.Location = new System.Drawing.Point(212, 31);
            this.lblRound.MinimumSize = new System.Drawing.Size(80, 30);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(80, 30);
            this.lblRound.TabIndex = 19;
            this.lblRound.Text = "ROUND: X";
            // 
            // ClientForm
            // 
            this.AcceptButton = this.buttonSubmitGuess;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 523);
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
            this.Controls.Add(this.listBoxDebug);
            this.Controls.Add(this.readyButton);
            this.Controls.Add(this.player4Label);
            this.Controls.Add(this.player3Label);
            this.Controls.Add(this.player2Label);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.Label player2Label;
        private System.Windows.Forms.Label player3Label;
        private System.Windows.Forms.Label player4Label;
        private System.Windows.Forms.Button readyButton;
        private System.Windows.Forms.ListBox listBoxDebug;
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
    }
}

