using System;
using System.IO;
using System.Threading.Tasks;
using ErrorHandelling;
using GTL.AI;
using GTL.BotRunner;
using GTL.ProcessRunner;
using GTL.CommandRunner;
using GTL.AiCommandRunner;

namespace GTL.AiCommandRunner
{
    public class AiCommandRunner
    {
       // AI Stack
        static async Task Ai_Stack(string prompt)
        {
            
            Ollama ai = new Ollama();
            string answer = await ai.Ai_Request(prompt);
            Console.WriteLine(answer);
        }
        // creating the bot
        static void CreateBot(string BotName)
        {
            if (string.IsNullOrWhiteSpace(BotName))
            {
                Console.WriteLine("Invalid bot name.");
                return;
            }

            if (GTLState.BotList.Contains(BotName,
                StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine("Bot already exists.");
                return;
            }

            Directory.CreateDirectory("./AI");

            string FilePath = $"./AI/{BotName}.bot";

            File.WriteAllText(FilePath, "");

            GTLState.BotList.Add(BotName);

            Console.WriteLine($"Bot {BotName} created.");
        }
    }
}