using System.Net.Http;
using System.Text;
using System.Text.Json;
using ErrorHandelling;
using GTL.AI;

namespace GTL.BotRunner
{
    public class SystemRunner
    {
        
        public async Task RunBot(string BotName)
        {
            string BotPrompt = File.ReadAllText($"./AI/{BotName}.bot");
            
            while (true){
                Ollama ai = new Ollama();
                string answer = await ai.Ai_Request(BotPrompt);
                Console.WriteLine(answer);
            }
        }
    }
}