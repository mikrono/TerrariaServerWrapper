using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TerrariaServerWrapper.Configs;
using TerrariaServerWrapper.Model;
using TerrariaServerWrapper.DiscordModule;
using System.Threading;

namespace TerrariaServerWrapper.MainServices
{
    class MainService
    {
        private static MainService _instance = null;

        private  ConsoleWrapper Server;
        public  TerrariaServer MainForm = null;
        private  DiscordMain discordMain;
        CancellationTokenSource cts = new CancellationTokenSource();
        private MainService()
        {
            Server = null;
            discordMain = new DiscordMain();
        }

        public static MainService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainService();
                }
                return _instance;
            }
        }

        /// <summary>
        /// If there is no serverwrapper instance, make it and run. If the instance is exist, then, just run
        /// </summary>
        public void StartServer()
        {
            if (!(Server != null) || (Server.State == 0))
            {
                if (Server != null)
                {
                    Server.Start();
                    cts = new CancellationTokenSource();
                    Task.Run(() => ReadOutPut(Server.STDOUT, Encoding.UTF8, cts.Token));
                }
                else
                {
                    Server = new ConsoleWrapper(EnvVar.ServerPath, 200, 10, "");
                    Server.Start();
                    cts = new CancellationTokenSource();
                    Task.Run(() => ReadOutPut(Server.STDOUT, Encoding.UTF8, cts.Token));
                }
            }
        }

        public void RunDiscord()
        {
            discordMain.RunAsync();
        }


        public void WriteConsole(string command)
        {
            if (Server == null) return;
            MainForm.AddConsoleLine(command, Color.DarkCyan);
            Server.SendCommand(command, Encoding.UTF8);
        }

        private void ReadOutPut(Stream stream, Encoding encoding, CancellationToken token)
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
                    {
                        try
                        {
                        token.ThrowIfCancellationRequested();
                        }
                        catch (OperationCanceledException)
                        {
                            break;
                        }
                        InvokeParser();
                    }
                    iChar = reader.Read();
                    c = (char)iChar;
                }

                void InvokeParser()
                {
                    if (buffer.Length > 0)
                    {
                        ParsedMessageReader(Parser.ConsoleParser(buffer.ToString().Trim()));
                        buffer.Clear();
                    }
                }
            }
        }

        private void ParsedMessageReader(ConsoleMessage consoleMessage)
        {
            switch (consoleMessage.messageType)
            {
                case ConsoleMessage.MessageType.Default:
                    {
                        MainForm.AddConsoleLine(consoleMessage.Data, Color.Black);
                        break;
                    }
                case ConsoleMessage.MessageType.PlayerState:
                    {
                        MainForm.AddConsoleLine((consoleMessage.sender + " has " + consoleMessage.Data + Environment.NewLine), Color.Black);
                        if (consoleMessage.Data == "joined")
                        {
                            updatePlayerList(consoleMessage.sender, true);
                        }
                        else
                        {
                            updatePlayerList(consoleMessage.sender, false);
                        }
                        break;
                    }
            }
        }
        
        public void updatePlayerList(string PlayerName, bool direction)
        {
            MainForm.updatePlayerList(PlayerName, direction);
        }

        public void BanPlayer(string PlayerName)
        {
            WriteConsole($"ban {PlayerName}");
        }

        public void KickPlayer(string PlayerName)
        {
            WriteConsole($"kick {PlayerName}");
        }
        public void Restart()
        {
            WriteConsole("exit");
            while (Server.IsRun())
            {

            }
            cts.Cancel();
            StartServer();
        }
        public void GetDiscordSendCommand(string command)
        {
            WriteConsole(command);
        }
    }
}
