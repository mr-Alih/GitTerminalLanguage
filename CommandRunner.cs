using System;
using System.IO;
using System.Threading.Tasks;
using ErrorHandelling;
using GTL.AI;
using GTL.BotRunner;
using GTL.ProcessRunner;
using GTL.CommandRunner;
using GTL.AiCommandRunner;

namespace GTL.CommandRunner
{
    public class CommandRunner
    {
        public async Task Execute(string CommandName)
        {
            if (CommandName.StartsWith("GTL ", StringComparison.OrdinalIgnoreCase))
            {
                // forward the action into a string
                string Action = CommandName.Substring(4).Trim();
                if (Action.Equals("start", StringComparison.OrdinalIgnoreCase))
                {
                    RunSwitchCheck();
                }
                // Exitting the application
                if (Action.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    await processRunner.Shutdown();
                    return;
                }

                if (Action.StartsWith("AI ", StringComparison.OrdinalIgnoreCase))
                {
                    string AiAction = Action[3..].Trim();

                    // Create a bot
                    if (AiAction.Equals("bot", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("[GTL] BotName? ");
                        string BotName = Console.ReadLine() ?? "";

                        CreateBot(BotName);
                    }

                    // Ask the main AI
                    else if (AiAction.StartsWith("ASK ", StringComparison.OrdinalIgnoreCase))
                    {
                        string CommandPrompt = AiAction[4..];
                        await Ai_Stack(CommandPrompt);
                    }

                    // Bot-specific commands
                    else
                    {
                        string[] Parts = AiAction.Split(
                            ' ',
                            2,
                            StringSplitOptions.RemoveEmptyEntries
                        );
                        
                        if (Parts.Length < 2)
                        {
                            Console.WriteLine("Invalid AI command.");
                            return;
                        }

                        string BotName = Parts[0];
                        string Prompt = Parts[1];

                        if (!GTLState.BotList.Exists(name =>
                            string.Equals(name, BotName, StringComparison.OrdinalIgnoreCase)))
                        {
                            Console.WriteLine("Bot not found.");
                            return;
                        }

                        if (Prompt.StartsWith("Run", StringComparison.OrdinalIgnoreCase))
                        {
                            SystemRunner Runner = new SystemRunner();
                            await Runner.RunBot(BotName);
                        }
                        // else just assume that its creating an prompt runner inside a bot
                        else
                        {
                            string FilePath = $"./AI/{BotName}.bot";

                            File.AppendAllText(
                                FilePath,
                                Prompt + Environment.NewLine
                            );

                            Console.WriteLine($"Prompt added to {BotName}.");
                        }
                    }
                }
                else
                {
                    // check if Perhaps misspelled
                    ErrorHandler.Load_Error($"404, Command {CommandName[4..]} Not Found");
                    return;
                }
            } else
            {
                ErrorHandler.Load_Error("404, Perhaps GTL?");
                return;
            }
        }
    }
}