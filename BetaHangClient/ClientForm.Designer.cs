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
            this.button1 = new System.Windows.Forms.Button();
            this.player1Label = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            this.player3Label = new System.Windows.Forms.Label();
            this.player4Label = new System.Windows.Forms.Label();
            this.readyButton = new System.Windows.Forms.Button();
            this.listBoxDebug = new System.Windows.Forms.ListBox();
            this.textBoxGuess = new System.Windows.Forms.TextBox();
            this.buttonSubmitGuess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(35, 129);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(351, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(219, 159);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Location = new System.Drawing.Point(31, 476);
            this.player1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(90, 17);
            this.player1Label.TabIndex = 2;
            this.player1Label.Text = "player1Label";
            this.player1Label.Click += new System.EventHandler(this.label1_Click);
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = true;
            this.player2Label.Location = new System.Drawing.Point(215, 476);
            this.player2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(90, 17);
            this.player2Label.TabIndex = 3;
            this.player2Label.Text = "player2Label";
            // 
            // player3Label
            // 
            this.player3Label.AutoSize = true;
            this.player3Label.Location = new System.Drawing.Point(381, 476);
            this.player3Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player3Label.Name = "player3Label";
            this.player3Label.Size = new System.Drawing.Size(90, 17);
            this.player3Label.TabIndex = 4;
            this.player3Label.Text = "player3Label";
            // 
            // player4Label
            // 
            this.player4Label.AutoSize = true;
            this.player4Label.Location = new System.Drawing.Point(559, 476);
            this.player4Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player4Label.Name = "player4Label";
            this.player4Label.Size = new System.Drawing.Size(90, 17);
            this.player4Label.TabIndex = 5;
            this.player4Label.Text = "player4Label";
            // 
            // readyButton
            // 
            this.readyButton.Location = new System.Drawing.Point(548, 129);
            this.readyButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.readyButton.Name = "readyButton";
            this.readyButton.Size = new System.Drawing.Size(100, 28);
            this.readyButton.TabIndex = 6;
            this.readyButton.Text = "Ready!";
            this.readyButton.UseVisualStyleBackColor = true;
            this.readyButton.Click += new System.EventHandler(this.readyButton_Click);
            // 
            // listBoxDebug
            // 
            this.listBoxDebug.FormattingEnabled = true;
            this.listBoxDebug.ItemHeight = 16;
            this.listBoxDebug.Location = new System.Drawing.Point(35, 228);
            this.listBoxDebug.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxDebug.Name = "listBoxDebug";
            this.listBoxDebug.Size = new System.Drawing.Size(288, 196);
            this.listBoxDebug.TabIndex = 7;
            // 
            // textBoxGuess
            // 
            this.textBoxGuess.Location = new System.Drawing.Point(424, 290);
            this.textBoxGuess.Name = "textBoxGuess";
            this.textBoxGuess.Size = new System.Drawing.Size(100, 22);
            this.textBoxGuess.TabIndex = 8;
            // 
            // buttonSubmitGuess
            // 
            this.buttonSubmitGuess.Location = new System.Drawing.Point(531, 290);
            this.buttonSubmitGuess.Name = "buttonSubmitGuess";
            this.buttonSubmitGuess.Size = new System.Drawing.Size(118, 23);
            this.buttonSubmitGuess.TabIndex = 9;
            this.buttonSubmitGuess.Text = "submit guess";
            this.buttonSubmitGuess.UseVisualStyleBackColor = true;
            this.buttonSubmitGuess.Click += new System.EventHandler(this.buttonSubmitGuess_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 644);
            this.Controls.Add(this.buttonSubmitGuess);
            this.Controls.Add(this.textBoxGuess);
            this.Controls.Add(this.listBoxDebug);
            this.Controls.Add(this.readyButton);
            this.Controls.Add(this.player4Label);
            this.Controls.Add(this.player3Label);
            this.Controls.Add(this.player2Label);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.Label player2Label;
        private System.Windows.Forms.Label player3Label;
        private System.Windows.Forms.Label player4Label;
        private System.Windows.Forms.Button readyButton;
        private System.Windows.Forms.ListBox listBoxDebug;
        private System.Windows.Forms.TextBox textBoxGuess;
        private System.Windows.Forms.Button buttonSubmitGuess;
    }
}

