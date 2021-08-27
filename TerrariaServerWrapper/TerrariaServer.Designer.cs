
namespace TerrariaServerWrapper
{
    partial class TerrariaServer
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TerrariaServer));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PlayerList = new System.Windows.Forms.ListBox();
            this.ServerConsole = new System.Windows.Forms.RichTextBox();
            this.commandBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serverToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DiscordSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverOfflineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandbutton = new System.Windows.Forms.Button();
            this.PlayerListUp = new System.Windows.Forms.Button();
            this.PlayerListDown = new System.Windows.Forms.Button();
            this.KickSelectedPlayer = new System.Windows.Forms.Button();
            this.BanSelectedPlayer = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(3, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Players";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(262, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Console";
            // 
            // PlayerList
            // 
            this.PlayerList.BackColor = System.Drawing.Color.LightGray;
            this.PlayerList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PlayerList.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PlayerList.ForeColor = System.Drawing.SystemColors.InfoText;
            this.PlayerList.FormattingEnabled = true;
            this.PlayerList.ItemHeight = 20;
            this.PlayerList.Location = new System.Drawing.Point(8, 67);
            this.PlayerList.Name = "PlayerList";
            this.PlayerList.Size = new System.Drawing.Size(253, 500);
            this.PlayerList.TabIndex = 2;
            this.PlayerList.SelectedIndexChanged += new System.EventHandler(this.PlayerList_SelectedIndexChanged);
            // 
            // ServerConsole
            // 
            this.ServerConsole.BackColor = System.Drawing.Color.LightGray;
            this.ServerConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServerConsole.Location = new System.Drawing.Point(267, 67);
            this.ServerConsole.Name = "ServerConsole";
            this.ServerConsole.ReadOnly = true;
            this.ServerConsole.Size = new System.Drawing.Size(882, 500);
            this.ServerConsole.TabIndex = 3;
            this.ServerConsole.Text = "";
            this.ServerConsole.TextChanged += new System.EventHandler(this.ServerConsole_TextChanged);
            // 
            // commandBox
            // 
            this.commandBox.BackColor = System.Drawing.Color.LightGray;
            this.commandBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.commandBox.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.commandBox.Location = new System.Drawing.Point(267, 571);
            this.commandBox.Name = "commandBox";
            this.commandBox.Size = new System.Drawing.Size(814, 22);
            this.commandBox.TabIndex = 4;
            this.commandBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.commandBox_KeyUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem1,
            this.discordToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1158, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // serverToolStripMenuItem1
            // 
            this.serverToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pathToolStripMenuItem,
            this.startToolStripMenuItem});
            this.serverToolStripMenuItem1.Name = "serverToolStripMenuItem1";
            this.serverToolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.serverToolStripMenuItem1.Text = "Server";
            this.serverToolStripMenuItem1.Click += new System.EventHandler(this.serverToolStripMenuItem1_Click);
            // 
            // pathToolStripMenuItem
            // 
            this.pathToolStripMenuItem.Name = "pathToolStripMenuItem";
            this.pathToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pathToolStripMenuItem.Text = "ServerPath";
            this.pathToolStripMenuItem.Click += new System.EventHandler(this.pathToolStripMenuItem_Click_1);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Enabled = false;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // discordToolStripMenuItem
            // 
            this.discordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DiscordSettingsToolStripMenuItem});
            this.discordToolStripMenuItem.Name = "discordToolStripMenuItem";
            this.discordToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.discordToolStripMenuItem.Text = "Discord";
            // 
            // DiscordSettingsToolStripMenuItem
            // 
            this.DiscordSettingsToolStripMenuItem.Name = "DiscordSettingsToolStripMenuItem";
            this.DiscordSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DiscordSettingsToolStripMenuItem.Text = "Settings";
            this.DiscordSettingsToolStripMenuItem.Click += new System.EventHandler(this.DiscordSettingsToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // serverOfflineToolStripMenuItem
            // 
            this.serverOfflineToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.serverOfflineToolStripMenuItem.Name = "serverOfflineToolStripMenuItem";
            this.serverOfflineToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.serverOfflineToolStripMenuItem.Text = "Server Offline";
            // 
            // commandbutton
            // 
            this.commandbutton.FlatAppearance.BorderSize = 0;
            this.commandbutton.Location = new System.Drawing.Point(1087, 571);
            this.commandbutton.Name = "commandbutton";
            this.commandbutton.Size = new System.Drawing.Size(62, 22);
            this.commandbutton.TabIndex = 6;
            this.commandbutton.Text = "Send";
            this.commandbutton.UseVisualStyleBackColor = true;
            this.commandbutton.Click += new System.EventHandler(this.commandbutton_Click);
            // 
            // PlayerListUp
            // 
            this.PlayerListUp.Location = new System.Drawing.Point(8, 571);
            this.PlayerListUp.Name = "PlayerListUp";
            this.PlayerListUp.Size = new System.Drawing.Size(25, 23);
            this.PlayerListUp.TabIndex = 7;
            this.PlayerListUp.Text = "▲";
            this.PlayerListUp.UseVisualStyleBackColor = true;
            this.PlayerListUp.Click += new System.EventHandler(this.PlayerListUp_Click);
            // 
            // PlayerListDown
            // 
            this.PlayerListDown.Location = new System.Drawing.Point(39, 571);
            this.PlayerListDown.Name = "PlayerListDown";
            this.PlayerListDown.Size = new System.Drawing.Size(25, 23);
            this.PlayerListDown.TabIndex = 8;
            this.PlayerListDown.Text = "▼";
            this.PlayerListDown.UseVisualStyleBackColor = true;
            this.PlayerListDown.Click += new System.EventHandler(this.PlayerListDown_Click);
            // 
            // KickSelectedPlayer
            // 
            this.KickSelectedPlayer.Location = new System.Drawing.Point(70, 571);
            this.KickSelectedPlayer.Name = "KickSelectedPlayer";
            this.KickSelectedPlayer.Size = new System.Drawing.Size(75, 23);
            this.KickSelectedPlayer.TabIndex = 9;
            this.KickSelectedPlayer.Text = "Kick";
            this.KickSelectedPlayer.UseVisualStyleBackColor = true;
            this.KickSelectedPlayer.Click += new System.EventHandler(this.KickSelectedPlayer_Click);
            // 
            // BanSelectedPlayer
            // 
            this.BanSelectedPlayer.Location = new System.Drawing.Point(151, 571);
            this.BanSelectedPlayer.Name = "BanSelectedPlayer";
            this.BanSelectedPlayer.Size = new System.Drawing.Size(75, 23);
            this.BanSelectedPlayer.TabIndex = 10;
            this.BanSelectedPlayer.Text = "Ban";
            this.BanSelectedPlayer.UseVisualStyleBackColor = true;
            this.BanSelectedPlayer.Click += new System.EventHandler(this.BanSelectedPlayer_Click);
            // 
            // TerrariaServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1158, 603);
            this.Controls.Add(this.BanSelectedPlayer);
            this.Controls.Add(this.KickSelectedPlayer);
            this.Controls.Add(this.PlayerListDown);
            this.Controls.Add(this.PlayerListUp);
            this.Controls.Add(this.commandbutton);
            this.Controls.Add(this.commandBox);
            this.Controls.Add(this.ServerConsole);
            this.Controls.Add(this.PlayerList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TerrariaServer";
            this.Text = "TerrariaServerWrapper";
            this.Load += new System.EventHandler(this.TerrariaServer_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox PlayerList;
        private System.Windows.Forms.RichTextBox ServerConsole;
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverOfflineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pathToolStripMenuItem;
        private System.Windows.Forms.Button commandbutton;
        private System.Windows.Forms.Button PlayerListUp;
        private System.Windows.Forms.Button PlayerListDown;
        private System.Windows.Forms.Button KickSelectedPlayer;
        private System.Windows.Forms.Button BanSelectedPlayer;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DiscordSettingsToolStripMenuItem;
    }
}

