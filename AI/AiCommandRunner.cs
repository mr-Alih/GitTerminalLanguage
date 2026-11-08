
using System;
using System.IO;
using System.Threading.Tasks;
using GTL.AI;
using GTL.BotRunner;
using GTL.Core;

namespace GTL.AiCommandRunner
{
    public class AiCommandRunner
    {
        public async Task ExecuteAI(string action)
        {
            // Create a bot
            if (action.Equals("bot", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("[GTL] BotName? ");
                string newBotName = Console.ReadLine() ?? "";

                CreateBot(newBotName);
                return;
            }

            // Ask the main AI
            if (action.StartsWith("ASK ", StringComparison.OrdinalIgnoreCase))
            {
                string prompt = action[4..].Trim();

                await Ai_Stack(prompt);
                return;
            }

            // Bot-specific commands
            string[] parts = action.Split(
                ' ',
                2,
                StringSplitOptions.RemoveEmptyEntries
            );

            if (parts.Length < 2)
            {
                Console.WriteLine("Invalid AI command.");
                return;
            }

            string botName = parts[0];
            string promptText = parts[1];

            if (!GTLState.BotList.Exists(name =>
                string.Equals(name, botName,
                    StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Bot not found.");
                return;
            }

            if (promptText.StartsWith("Run",
                StringComparison.OrdinalIgnoreCase))
            {
                SystemRunner runner = new SystemRunner();
                await runner.RunBot(botName);
            }
            else
            {
                string filePath = $"./AI/{botName}.bot";

                File.AppendAllText(
                    filePath,
                    promptText + Environment.NewLine
                );

                Console.WriteLine($"Prompt added to {botName}.");
            }
        }

        private async Task Ai_Stack(string prompt)
        {
            Ollama ai = new Ollama();

            string answer = await ai.Ai_Request(prompt);

            Console.WriteLine(answer);
        }

        private void CreateBot(string botName)
        {
            if (string.IsNullOrWhiteSpace(botName))
            {
                Console.WriteLine("Invalid bot name.");
                return;
            }

            if (GTLState.BotList.Contains(
                botName, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine("Bot already exists.");
                return;
            }

            Directory.CreateDirectory("./AI");

            string filePath = $"./AI/{botName}.bot";

            File.WriteAllText(filePath, "");

            GTLState.BotList.Add(botName);

            Console.WriteLine($"Bot {botName} created.");
        }
    }
}
