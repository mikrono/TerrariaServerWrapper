using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace TerrariaWrapper
{
    class ServerWrapper
    {
        private Process process;
        public string ServerFilePath;
        public event DataReceivedEventHandler StandardOutput;
        public event DataReceivedEventHandler StandardError;

        public bool Running
        {
            get
            {
                if (process == null) return false;
                try { Process.GetProcessById(process.Id); }
                catch (InvalidOperationException) { return false; }
                catch (ArgumentException) { return false; }
                return true;
            }
        }
        
        public ServerWrapper(string serverFilePath)
        {
            ServerFilePath = serverFilePath;
        }

        public void CreateServerProcess(Process existingProcess = null)
        {
            process = existingProcess ?? new Process
            {
                StartInfo =
                {
                    WorkingDirectory = Path.GetDirectoryName(ServerFilePath),
                    FileName = ServerFilePath,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    CreateNoWindow = true
                }
            };
            process.OutputDataReceived += ServerProcess_OutputDataReceived;
            process.ErrorDataReceived += ServerProcess_ErrorDataReceived;
        }
        public void ServerProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            StandardError?.Invoke(this, e);
        }
        public void ServerProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            StandardOutput?.Invoke(this, e);
        }

        public void StartServerProcess()
        {
            if (Running) throw new InvalidOperationException("Can't start the server process when it is already running!");
            process.Start();
            try
            {
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.StandardInput.AutoFlush = true;
            }
            catch (InvalidOperationException) { }
        }
        
        public void Start()
        {
            if (Running) throw new InvalidOperationException("Can't start server, it's already running!");
            CreateServerProcess();
            StartServerProcess();
        }
        public void SendCommand(string text)
        {
            if (!Running) throw new InvalidOperationException("Can't send a command, the process is not running");
            process.StandardInput.WriteLine(text);
        }
    }
}
