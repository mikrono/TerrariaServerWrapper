using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TerrariaServerWrapper.PseudoTerminal;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace TerrariaWrapper
{
    public partial class TerrariaServer : Form
    {
        private ConsoleWrapper Server;
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
                if (!(Server != null) || (Server.State == 0))
                {
                    if (Server != null)
                    {
                        Task.Run(() => Server.Start());
                    }
                    else
                    {
                        Server = new ConsoleWrapper(ServerPath, 100, 60);
                        Task.Run(() => Server.Start());
                        Server.OutputReady += Terminal_OutputReady;
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
        public void StreamConsoleLine(string text, Color color)
        {
            ServerConsole.SuspendLayout();
            ServerConsole.SelectionColor = color;
            ServerConsole.AppendText($"{text}");
            ServerConsole.ResumeLayout();
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
        private void Terminal_OutputReady(object sender, EventArgs e)
        {
            // Start a long-lived thread for the "read console" task, so that we don't use a standard thread pool thread.
            Task.Factory.StartNew(() => CopyConsoleToWindow(), TaskCreationOptions.LongRunning);
        }
        private void CopyConsoleToWindow()
        {
            using (StreamReader reader = new StreamReader(Server.ConsoleOutStream))
            {
                // Read the console's output 1 character at a time
                int bytesRead;
                char[] buf = new char[1];
                while ((bytesRead = reader.ReadBlock(buf, 0, 1)) != 0)
                {
                    // This is where you'd parse and tokenize the incoming VT100 text, most likely.
                    Invoke((MethodInvoker)delegate
                    {
                        // ...and then you'd do something to render it.
                        // For now, just emit raw VT100 to the primary TextBlock.
                        StreamConsoleLine( new string(buf.Take(bytesRead).ToArray()), Color.Black);
                    });
                }
            }
        }
        #endregion
    }
}
