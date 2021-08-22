using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TerrariaWrapper
{
    public partial class TerrariaServer : Form
    {
        private ServerWrapper Server;
        private string ServerPath;
        public TerrariaServer()
        {
            InitializeComponent();
            Server = null;
        }
        public void StartServer()
        {
            Invoke((MethodInvoker)delegate
            {
                if (!(Server != null) || !Server.Running)
                {
                    if (Server != null)
                    {
                        AddConsoleLine($"{Server.Running}", Color.Black);
                        Server.Start();
                    }
                    else
                    {
                        Server = new ServerWrapper(ServerPath);
                        Server.StandardOutput += Server_stdout_received;
                        Server.StandardError += Server_stdout_received;
                        Server.Start();
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
                SendCommand(commandBox.Text);
                commandBox.Text = "";
            }
        }
        private void commandbutton_Click(object sender, EventArgs e)
        {
            SendCommand(commandBox.Text);
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void serverToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region ConsoleIO
        public void AddConsoleLine(string text, Color color)
        {
            ServerConsole.SuspendLayout();
            ServerConsole.SelectionColor = color;
            ServerConsole.AppendText($"{DateTime.Now:[HH:mm:ss]} {text}{Environment.NewLine}");
            ServerConsole.ScrollToCaret();
            ServerConsole.ResumeLayout();
        }
        private void Server_stdout_received(object sender, DataReceivedEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                if (e.Data == null) return;
                AddConsoleLine(e.Data, Color.Black);
            });
        }
        public void SendCommand(string command)
        {
            Invoke((MethodInvoker)delegate
            {
                if (Server == null) return;
                AddConsoleLine(command, Color.Red);
                Server.SendCommand(command);
            });
        }

        #endregion
    }
}
