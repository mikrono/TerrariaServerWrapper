using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using static TerrariaServerWrapper.PseudoTerminal.Native.ConsoleApi;
using TerrariaServerWrapper.PseudoTerminal.Processes;
using TerrariaServerWrapper.PseudoTerminal;

namespace TerrariaWrapper
{
    class ConsoleWrapper
    {
        public enum ConsoleState { Off = 0, Running = 1 };
        public ConsoleState State;
        public int ConsoleWidth;
        public int ConsoleHeight;
        public string FilePath;
        private SafeFileHandle _consoleInputPipeWriteHandle;
        private StreamWriter _consoleInputWriter;
        public FileStream ConsoleOutStream { get; private set; }
        public event EventHandler OutputReady;

        public ConsoleWrapper(string filePath, int consoleWidth, int consoleHeight)
        {
            FilePath = filePath;
            State = ConsoleState.Off;
            // Size of pseudo console(by charcter).
            ConsoleWidth = consoleWidth;
            ConsoleHeight = consoleHeight;
        }

        public void Start()
        {
            using (var inputPipe = new PseudoConsolePipe())
            using (var outputPipe = new PseudoConsolePipe())
            using (var pseudoConsole = PseudoConsole.Create(inputPipe.ReadSide, outputPipe.WriteSide, ConsoleWidth, ConsoleHeight))
            using (var process = ProcessFactory.Start(FilePath, PseudoConsole.PseudoConsoleThreadAttribute, pseudoConsole.Handle))
            {
                // copy all pseudoconsole output to a FileStream and expose it to the rest of the app
                ConsoleOutStream = new FileStream(outputPipe.ReadSide, FileAccess.Read);
                OutputReady.Invoke(this, EventArgs.Empty);

                // Store input pipe handle, and a writer for later reuse
                _consoleInputPipeWriteHandle = inputPipe.WriteSide;
                _consoleInputWriter = new StreamWriter(new FileStream(_consoleInputPipeWriteHandle, FileAccess.Write))
                {
                    AutoFlush = true
                };

                // free resources in case the console is ungracefully closed (e.g. by the 'x' in the window titlebar)
                OnClose(() => DisposeResources(process, pseudoConsole, outputPipe, inputPipe, _consoleInputWriter));

                WaitForExit(process).WaitOne(Timeout.Infinite);
            }
        }

        /// <summary>
        /// Write string into console
        /// </summary>
        /// <param name="input"></param>
        public void SendCommand(string input)
        {
            if (_consoleInputWriter == null)
            {
                throw new InvalidOperationException("There is no writer attached to a pseudoconsole. Have you called Start on this instance yet?");
            }
            _consoleInputWriter.Write(input);
        }

        /// <summary>
        /// Set a callback for when the terminal is closed (e.g. via the "X" window decoration button).
        /// Intended for resource cleanup logic.
        /// </summary>
        private static void OnClose(Action handler)
        {
            SetConsoleCtrlHandler(eventType =>
            {
                if (eventType == CtrlTypes.CTRL_CLOSE_EVENT)
                {
                    handler();
                }
                return false;
            }, true);
        }

        private void DisposeResources(params IDisposable[] disposables)
        {
            foreach (var disposable in disposables)
            {
                disposable.Dispose();
            }
        }

        /// <summary>
        /// Get an AutoResetEvent that signals when the process exits
        /// </summary>
        private static AutoResetEvent WaitForExit(Process process) =>
            new AutoResetEvent(false)
            {
                SafeWaitHandle = new SafeWaitHandle(process.ProcessInfo.hProcess, ownsHandle: false)
            };
    }
}
