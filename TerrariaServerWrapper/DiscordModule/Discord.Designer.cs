
namespace TerrariaServerWrapper.DiscordModule
{
    partial class Discord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Discord));
            this.DiscordBotToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DiscordConnect = new System.Windows.Forms.Button();
            this.DiscordForm1SizeControl = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DiscordChannelID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DiscordBotToken
            // 
            this.DiscordBotToken.Location = new System.Drawing.Point(74, 12);
            this.DiscordBotToken.Name = "DiscordBotToken";
            this.DiscordBotToken.Size = new System.Drawing.Size(478, 21);
            this.DiscordBotToken.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Token";
            // 
            // DiscordConnect
            // 
            this.DiscordConnect.Location = new System.Drawing.Point(477, 66);
            this.DiscordConnect.Name = "DiscordConnect";
            this.DiscordConnect.Size = new System.Drawing.Size(75, 23);
            this.DiscordConnect.TabIndex = 4;
            this.DiscordConnect.Text = "Connect";
            this.DiscordConnect.UseVisualStyleBackColor = true;
            this.DiscordConnect.Click += new System.EventHandler(this.DiscordConnect_Click);
            // 
            // DiscordForm1SizeControl
            // 
            this.DiscordForm1SizeControl.Enabled = false;
            this.DiscordForm1SizeControl.Location = new System.Drawing.Point(9, 69);
            this.DiscordForm1SizeControl.Margin = new System.Windows.Forms.Padding(0);
            this.DiscordForm1SizeControl.Name = "DiscordForm1SizeControl";
            this.DiscordForm1SizeControl.Size = new System.Drawing.Size(20, 20);
            this.DiscordForm1SizeControl.TabIndex = 5;
            this.DiscordForm1SizeControl.Text = "▼";
            this.DiscordForm1SizeControl.UseVisualStyleBackColor = true;
            this.DiscordForm1SizeControl.Click += new System.EventHandler(this.DiscordForm1SizeControl_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "ChannelID";
            // 
            // DiscordChannelID
            // 
            this.DiscordChannelID.Enabled = false;
            this.DiscordChannelID.Location = new System.Drawing.Point(74, 39);
            this.DiscordChannelID.Name = "DiscordChannelID";
            this.DiscordChannelID.Size = new System.Drawing.Size(478, 21);
            this.DiscordChannelID.TabIndex = 3;
            // 
            // Discord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 96);
            this.Controls.Add(this.DiscordForm1SizeControl);
            this.Controls.Add(this.DiscordConnect);
            this.Controls.Add(this.DiscordChannelID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DiscordBotToken);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Discord";
            this.Text = "DiscordSettings";
            this.Load += new System.EventHandler(this.Discord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DiscordBotToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DiscordConnect;
        private System.Windows.Forms.Button DiscordForm1SizeControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DiscordChannelID;
    }
}