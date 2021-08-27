using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static winpty.WinPty;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace TerrariaServerWrapper
{
    class ConsoleWrapper
    {
        public enum ConsoleState { Off = 0, Running = 1 };
        public ConsoleState State;
        private int ConsoleWidth;
        private int ConsoleHeight;
        private string FilePath;
        private string Args;

        private IntPtr hError;
        private IntPtr hPtyConfig;
        private IntPtr hPty;
        private IntPtr hSpawnPtyConfig;
        public Stream STDIN;
        public Stream STDOUT;
        private int ProcessId;

        [DllImport("kernel32.dll")]
        static extern int GetProcessId(IntPtr handle);

        public ConsoleWrapper(string filePath, int consoleWidth, int consoleHeight, string args)
        {
            FilePath = filePath;
            State = ConsoleState.Off;
            // Size of pseudo console(by charcter).
            ConsoleWidth = consoleWidth;
            ConsoleHeight = consoleHeight;
            Args = args;
        }

        public void Start()
        {
            try
            {
                hPtyConfig = winpty_config_new(WINPTY_FLAG_COLOR_ESCAPES, out hError);
                ErrorCheck(hError);
                winpty_config_set_initial_size(hPtyConfig, ConsoleWidth, ConsoleHeight);
                hPty = winpty_open(hPtyConfig, out hError);
                ErrorCheck(hError);
                hSpawnPtyConfig = winpty_spawn_config_new(WINPTY_SPAWN_FLAG_AUTO_SHUTDOWN, FilePath, Args, Path.GetDirectoryName(FilePath), null, out hError);
                ErrorCheck(hError);

                STDIN = CreatePipe(winpty_conin_name(hPty), PipeDirection.Out);
                STDOUT = CreatePipe(winpty_conout_name(hPty), PipeDirection.In);

                if (!winpty_spawn(hPty, hSpawnPtyConfig, out IntPtr hProcess, out IntPtr hThread, out int _, out hError))
                {
                    ErrorCheck(hError);
                }
                ProcessId = GetProcessId(hProcess);
            }
            finally
            {
                winpty_config_free(hPtyConfig);
                winpty_spawn_config_free(hSpawnPtyConfig);
                winpty_error_free(hError);
            }
        }
        public bool IsRun()
        {
            try { Process.GetProcessById(ProcessId); }
            catch (InvalidOperationException) { return false; }
            catch (ArgumentException) { return false; }
            return true;
        }

        /// <summary>
        /// Write string into console
        /// </summary>
        /// <param name="input"></param>
        public void SendCommand(string input, Encoding encoding)
        {
            Encoder encoder = encoding.GetEncoder();
            char[] string1 = $"{input}{System.Environment.NewLine}".ToCharArray();
            byte[] bytes = new byte[1024];
            _ = encoder.GetBytes(string1, 0, string1.Length, bytes, 0, true);
            STDIN.Write(bytes, 0, bytes.Length);
        }

        private void ErrorCheck(IntPtr error)
        {
            if (error == IntPtr.Zero) return;
            throw new Exception($"{winpty_error_code(error)}, {winpty_error_msg(error)}");
        }
        private Stream CreatePipe(string pipeName, PipeDirection direction)
        {
            string serverName = ".";
            if (pipeName.StartsWith("\\"))
            {
                int slash3 = pipeName.IndexOf('\\', 2);
                if (slash3 != -1)
                {
                    serverName = pipeName.Substring(2, slash3 - 2);
                }
                int slash4 = pipeName.IndexOf('\\', slash3 + 1);
                if (slash4 != -1)
                {
                    pipeName = pipeName.Substring(slash4 + 1);
                }
            }

            var pipe = new NamedPipeClientStream(serverName, pipeName, direction);
            pipe.Connect();
            return pipe;
        }
        private void DisposeResources(params IDisposable[] disposables)
        {
            foreach (var disposable in disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
