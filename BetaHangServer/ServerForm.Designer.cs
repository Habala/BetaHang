namespace BetaHangServer
{
    partial class ServerForm
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
            this.HiddenWordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxServerIP = new System.Windows.Forms.TextBox();
            this.textBoxServerPW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxSentMessages = new System.Windows.Forms.ListBox();
            this.listBoxReceivedMessages = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HiddenWordBox
            // 
            this.HiddenWordBox.Location = new System.Drawing.Point(14, 198);
            this.HiddenWordBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.HiddenWordBox.Name = "HiddenWordBox";
            this.HiddenWordBox.Size = new System.Drawing.Size(290, 20);
            this.HiddenWordBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server IP";
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(14, 100);
            this.textBoxServerIP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(110, 20);
            this.textBoxServerIP.TabIndex = 3;
            // 
            // textBoxServerPW
            // 
            this.textBoxServerPW.Location = new System.Drawing.Point(14, 147);
            this.textBoxServerPW.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxServerPW.Name = "textBoxServerPW";
            this.textBoxServerPW.Size = new System.Drawing.Size(110, 20);
            this.textBoxServerPW.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server Password";
            // 
            // listBoxSentMessages
            // 
            this.listBoxSentMessages.FormattingEnabled = true;
            this.listBoxSentMessages.Location = new System.Drawing.Point(11, 260);
            this.listBoxSentMessages.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxSentMessages.Name = "listBoxSentMessages";
            this.listBoxSentMessages.Size = new System.Drawing.Size(193, 251);
            this.listBoxSentMessages.TabIndex = 6;
            // 
            // listBoxReceivedMessages
            // 
            this.listBoxReceivedMessages.FormattingEnabled = true;
            this.listBoxReceivedMessages.Location = new System.Drawing.Point(287, 260);
            this.listBoxReceivedMessages.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxReceivedMessages.Name = "listBoxReceivedMessages";
            this.listBoxReceivedMessages.Size = new System.Drawing.Size(196, 251);
            this.listBoxReceivedMessages.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Secret word";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Messages sent";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(287, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Messages recieved";
            // 
            // Logo
            // 
            this.Logo.AutoSize = true;
            this.Logo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logo.Location = new System.Drawing.Point(150, 18);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(185, 42);
            this.Logo.TabIndex = 11;
            this.Logo.Text = "BetaHang";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 522);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxReceivedMessages);
            this.Controls.Add(this.listBoxSentMessages);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxServerPW);
            this.Controls.Add(this.textBoxServerIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HiddenWordBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox HiddenWordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxServerIP;
        private System.Windows.Forms.TextBox textBoxServerPW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxSentMessages;
        private System.Windows.Forms.ListBox listBoxReceivedMessages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Logo;
    }
}

