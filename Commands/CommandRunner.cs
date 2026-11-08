
using System;
using System.Threading.Tasks;
using ErrorHandelling;
using GTL.ProcessRunner;
using GTL.AiCommandRunner;

namespace GTL.CommandRunner
{
    public class CommandRunner
    {
        private GTL.ProcessRunner.ProcessRunner _processRunner;
        private GTL.AiCommandRunner.AiCommandRunner _aiCommandRunner;
        private ConnectionRunner _connectionRunner;

        public CommandRunner(
            GTL.ProcessRunner.ProcessRunner processRunner,
            GTL.AiCommandRunner.AiCommandRunner aiCommandRunner,
            ConnectionRunner connectionRunner)
        {
            _processRunner = processRunner;
            _aiCommandRunner = aiCommandRunner;
            _connectionRunner = connectionRunner;
        }

        public async Task Execute(string commandName)
        {
            if (!commandName.StartsWith(
                "GTL ", StringComparison.OrdinalIgnoreCase))
            {
                ErrorHandler.Load_Error("404, Perhaps GTL?");
                return;
            }

            string action = commandName[4..].Trim();

            if (action.Equals("start", StringComparison.OrdinalIgnoreCase))
            {
                _connectionRunner.Start();
            }
            else if (action.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                await _processRunner.Shutdown();
            }
            else if (action.StartsWith("AI ", StringComparison.OrdinalIgnoreCase))
            {
                string aiAction = action[3..].Trim();

                await _aiCommandRunner.ExecuteAI(aiAction);
            }
            else
            {
                ErrorHandler.Load_Error(
                    $"404, Command {action} Not Found");
            }
        }
    }
}
