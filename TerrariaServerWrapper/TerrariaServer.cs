using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
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
                        Server.Start();
                    }
                    else
                    {
                        Server = new ConsoleWrapper(ServerPath, 100, 60, "");
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
            Invoke((MethodInvoker)delegate
            {
                ServerConsole.SuspendLayout();
                ServerConsole.SelectionColor = color;
                ServerConsole.AppendText($"{DateTime.Now:[HH:mm:ss]} {text}{Environment.NewLine}");
                ServerConsole.ScrollToCaret();
                ServerConsole.ResumeLayout();
            });
        }
        public void WriteConsole(string command)
        {
            Invoke((MethodInvoker)delegate
            {
                if (Server == null) return;
                AddConsoleLine(command, Color.Red);
                Server.WriteConsole(command, Encoding.UTF8);
            });
        }

        public void GetConsoleOutPut(object sender, string e)
        {
            Invoke((MethodInvoker)delegate
            {
                AddConsoleLine(e, Color.Black);
            });
        }

        public void ReadOutPut(Stream stream, Encoding encoding)
        {
            using (var reader = new StreamReader(stream, encoding ,true))
            {
                var buffer = new StringBuilder(1024);

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
                        FlushBuffer();

                    iChar = reader.Read();
                    c = (char)iChar;
                }

                void FlushBuffer()
                {
                    if (buffer.Length > 0)
                        AddConsoleLine(buffer.ToString(), Color.Black);
                        buffer.Clear();
                }
            }
        }
        private static string DecodeFromStream(Stream dataStream, Encoding encoding, int bufferSize)
        {
            Decoder decoder = encoding.GetDecoder();
            StringBuilder sb = new StringBuilder();
            int inputByteCount;
            byte[] inputBuffer = new byte[bufferSize];
            char[] charBuffer = new char[encoding.GetMaxCharCount(inputBuffer.Length)];

            while ((inputByteCount = dataStream.Read(inputBuffer, 0, inputBuffer.Length)) > 0)
            {
                int readChars = decoder.GetChars(inputBuffer, 0, inputByteCount, charBuffer, 0);
                if (readChars > 0)
                    sb.Append(charBuffer, 0, readChars);
            }
            return sb.ToString();
        }
        #endregion
    }
}
