
using System;
using System.IO;
using System.Threading.Tasks;

namespace GTL.ProcessRunner
{
    public class ProcessRunner
    {
        private bool _isShuttingDown = false;

        public ProcessRunner()
        {
            Console.CancelKeyPress += OnCancelKeyPress;
        }

        // Handle CTRL+C
        private void OnCancelKeyPress(object? sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;

            Console.WriteLine("\n[GTL] Interrupt detected!");

            Shutdown().GetAwaiter().GetResult();
        }

        // Central shutdown method
        public async Task Shutdown()
        {
            if (_isShuttingDown)
                return;

            _isShuttingDown = true;

            Console.WriteLine("[GTL] Shutting down...");

            await ExitConnection();
            await ExitSession();

            Console.WriteLine("[GTL] Shutdown complete.");

            Environment.Exit(0);
        }

        // Connection cleanup
        private Task ExitConnection()
        {
            if (File.Exists(".con"))
                File.Delete(".con");

            return Task.CompletedTask;
        }

        // Session cleanup
        private Task ExitSession()
        {
            if (File.Exists("./Server/.server"))
                File.Delete("./Server/.server");

            return Task.CompletedTask;
        }
    }
}
