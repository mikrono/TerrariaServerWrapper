using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TerrariaServerWrapper.Configs;
using TerrariaServerWrapper.MainServices;

namespace TerrariaServerWrapper
{
    public partial class TerrariaServer : Form
    {
        private MainService controller;
        public DiscordModule.Discord discord;

        public TerrariaServer()
        {
            InitializeComponent();
            EnvVar.TSWconfig = (TSWConfig)new TSWConfig().GetConfig();

            controller = MainService.Instance;
            controller.MainForm = this;

            discord = new DiscordModule.Discord();
            discord.Owner = this;
        }
        private void TerrariaServer_Load(object sender, EventArgs e)
        {
        }
        private void pathToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "Terraria Server (*.exe)|*.exe"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    EnvVar.ServerPath = openFileDialog.FileName;
                    startToolStripMenuItem.Enabled = true;
                }
            });
        }

        private void commandBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MainService.Instance.WriteConsole(commandBox.Text);
                commandBox.Text = "";
            }
        }
        private void commandbutton_Click(object sender, EventArgs e)
        {
            controller.WriteConsole(commandBox.Text);
            commandBox.Text = "";
        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.StartServer();
        }

        #region notyetused

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ServerConsole_TextChanged(object sender, EventArgs e)
        {

        }


        private void PlayerList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void serverToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        public void AddConsoleLine(string text, Color color, bool displayTime = false)
        {
            Invoke((MethodInvoker)delegate
            {
                ServerConsole.SuspendLayout();
                ServerConsole.SelectionColor = color;
                ServerConsole.AppendText(displayTime ? $"{DateTime.Now:[HH:mm:ss]} {text}" : $"{text}");
                ServerConsole.ScrollToCaret();
                ServerConsole.ResumeLayout();
            });
        }

        public void updatePlayerList(string PlayerName, bool direction)
        {
            Invoke((MethodInvoker)delegate
            {
                if (direction) // 0 : left, 1 : joined
                {
                    PlayerList.Items.Add(PlayerName);
                }
                else
                {
                    PlayerList.Items.Remove(PlayerName);
                }
            });
        }

        private void PlayerListUp_Click(object sender, EventArgs e)
        {
            if (PlayerList.Items.Count < 1) return;
            if (PlayerList.SelectedIndex < 0)
            {
                PlayerList.SetSelected(0, true);
            }
            int index = PlayerList.SelectedIndex;
            if (index > 1)
            {
                PlayerList.SetSelected(index, false);
                PlayerList.SetSelected(index - 1, true);
            }
        }
        private void PlayerListDown_Click(object sender, EventArgs e)
        {
            if (PlayerList.Items.Count < 1) return;
            if (PlayerList.SelectedIndex < 0)
            {
                PlayerList.SetSelected(0, true);
            }
            int index = PlayerList.SelectedIndex;
            if (index < PlayerList.Items.Count - 1)
            {
                PlayerList.SetSelected(index, false);
                PlayerList.SetSelected(index + 1, true);
            }
        }

        private void KickSelectedPlayer_Click(object sender, EventArgs e)
        {
            if (PlayerList.SelectedIndex < 0) return;
            controller.KickPlayer(PlayerList.SelectedItem.ToString());
        }

        private void BanSelectedPlayer_Click(object sender, EventArgs e)
        {
            if (PlayerList.SelectedIndex < 0) return;
            controller.BanPlayer(PlayerList.SelectedItem.ToString());
        }

        private void DiscordSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            discord.Show();
        }
    }
}
