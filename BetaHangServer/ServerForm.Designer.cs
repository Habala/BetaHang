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
            this.SuspendLayout();
            // 
            // serverDisplayBox
            // 
            this.HiddenWordBox.Location = new System.Drawing.Point(128, 146);
            this.HiddenWordBox.Name = "serverDisplayBox";
            this.HiddenWordBox.Size = new System.Drawing.Size(385, 22);
            this.HiddenWordBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server IP";
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(137, 42);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(145, 22);
            this.textBoxServerIP.TabIndex = 3;
            // 
            // textBoxServerPW
            // 
            this.textBoxServerPW.Location = new System.Drawing.Point(137, 72);
            this.textBoxServerPW.Name = "textBoxServerPW";
            this.textBoxServerPW.Size = new System.Drawing.Size(100, 22);
            this.textBoxServerPW.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server Password";
            // 
            // listBoxSentMessages
            // 
            this.listBoxSentMessages.FormattingEnabled = true;
            this.listBoxSentMessages.ItemHeight = 16;
            this.listBoxSentMessages.Location = new System.Drawing.Point(68, 242);
            this.listBoxSentMessages.Name = "listBoxSentMessages";
            this.listBoxSentMessages.Size = new System.Drawing.Size(256, 372);
            this.listBoxSentMessages.TabIndex = 6;
            // 
            // listBoxReceivedMessages
            // 
            this.listBoxReceivedMessages.FormattingEnabled = true;
            this.listBoxReceivedMessages.ItemHeight = 16;
            this.listBoxReceivedMessages.Location = new System.Drawing.Point(351, 242);
            this.listBoxReceivedMessages.Name = "listBoxReceivedMessages";
            this.listBoxReceivedMessages.Size = new System.Drawing.Size(260, 372);
            this.listBoxReceivedMessages.TabIndex = 7;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 642);
            this.Controls.Add(this.listBoxReceivedMessages);
            this.Controls.Add(this.listBoxSentMessages);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxServerPW);
            this.Controls.Add(this.textBoxServerIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HiddenWordBox);
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
    }
}

