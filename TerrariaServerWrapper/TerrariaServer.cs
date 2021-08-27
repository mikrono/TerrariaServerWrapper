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
using TerrariaServerWrapper.Config;

namespace TerrariaServerWrapper
{
    public partial class TerrariaServer : Form
    {
        private ConsoleWrapper Server;
        private string ServerPath;
        public TerrariaServer()
        {
            InitializeComponent();
            Server = null;
            EnvVar.TSWconfig = (TSWConfig)new TSWConfig().GetConfig();
            TerrariaServerController controller = new TerrariaServerController(this);
        }
        public void StartServer()
        {
            Invoke((MethodInvoker)delegate
            {
                if (!(Server != null) || (Server.State == 0))
                {
                    if (Server != null)
                    {
                        Server.Start();
                    }
                    else
                    {
                        Server = new ConsoleWrapper(ServerPath, 200, 10, "");
                        Server.Start();
                        Task.Run(() => ReadOutPut(Server.STDOUT, Encoding.UTF8));
                    }
                }
            });
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
                    ServerPath = openFileDialog.FileName;
                    startToolStripMenuItem.Enabled = true;
                }
            });
        }

        private void commandBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                WriteConsole(commandBox.Text);
                commandBox.Text = "";
            }
        }
        private void commandbutton_Click(object sender, EventArgs e)
        {
            WriteConsole(commandBox.Text);
            commandBox.Text = "";
        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        #region notyetused

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ServerConsole_TextChanged(object sender, EventArgs e)
        {

        }

        private void TerrariaServer_Load(object sender, EventArgs e)
        {

        }

        private void PlayerList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void serverToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region ConsoleIO
        public void AddConsoleLine(string text, Color color, bool displayTime = false)
        {
            Invoke((MethodInvoker)delegate
            {
                ServerConsole.SuspendLayout();
                ServerConsole.SelectionColor = color;
                ServerConsole.AppendText(displayTime ? $"{text}{Environment.NewLine}" : $"{DateTime.Now:[HH:mm:ss]} {text}{System.Environment.NewLine}");
                ServerConsole.ScrollToCaret();
                ServerConsole.ResumeLayout();
            });
        }
        public void WriteConsole(string command)
        {
            Invoke((MethodInvoker)delegate
            {
                if (Server == null) return;
                AddConsoleLine(command, Color.DarkCyan);
                Server.WriteConsole(command, Encoding.UTF8);
            });
        }

        public void ReadOutPut(Stream stream, Encoding encoding)
        {
            using (StreamReader reader = new StreamReader(stream, encoding))
            {
                StringBuilder buffer = new StringBuilder(1024);

                int iChar = reader.Read();
                if (iChar < 0)
                {
                    return;
                }

                var c = (char)iChar;

                while (true)
                {
                    buffer.Append(c);

                    if (reader.Peek() < 0)
                        InvokeParser();

                    iChar = reader.Read();
                    c = (char)iChar;
                }

                void InvokeParser()
                {
                    if (buffer.Length > 0) 
                    {
                        Parser(buffer.ToString().Trim());
                        buffer.Clear();
                    }
                }
            }
        }
        #endregion

        #region Parser
        private void Parser(string dataString)
        {
            string text = Regex.Replace(dataString, "\x1B(?:[@-Z\\-_]|[[0-?]*[ -/]*[@-~])", "");
            if (text.Contains("has joined"))
            {
                string pattern = @"(.+) has joined";
                string joinedPlayer = Regex.Match(text, pattern).Groups[1].Value;
                updatePlayerList(joinedPlayer, true);
            }
            if (text.Contains("has left"))
            {
                string pattern = @"(.+) has left";
                string leftPlayer = Regex.Match(text, pattern).Groups[1].Value;
                updatePlayerList(leftPlayer, false);
            }
            AddConsoleLine(text, Color.Black);
        }

        #endregion

        #region PlayerMethods
        private void updatePlayerList(string PlayerName, bool direction)
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

        private void BanPlayer(string PlayerName)
        {
            WriteConsole($"ban {PlayerName}");
        }

        private void KickPlayer(string PlayerName)
        {
            WriteConsole($"kick {PlayerName}");
        }
        #endregion

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
            KickPlayer(PlayerList.SelectedItem.ToString());
        }

        private void BanSelectedPlayer_Click(object sender, EventArgs e)
        {
            if (PlayerList.SelectedIndex < 0) return;
            BanPlayer(PlayerList.SelectedItem.ToString());
        }

        private void DiscordSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiscordModule.Discord discord = new DiscordModule.Discord();
            discord.Owner = this;
            discord.Show();
        }
    }
}
