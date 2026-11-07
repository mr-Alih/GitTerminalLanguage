// init
using System.ComponentModel;
using System.IO;
using ErrorHandelling;
using GTL.AI;

// GTL architecture
// GTL start to start a first connection and auto connect a session.
// GTL session status
// GTL connection status
// GTL STATUS
// GTL load
// GTL parse
//  GTL AI "answer me this?"

// Main frame
using System.Net;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// init load
await MainLoop();

static async Task MainLoop()
{
    while (true)
    {
        Console.Write("[GTL]@T- :// ");
        string Command = Console.ReadLine() ?? "";
        await run_check(Command);
    }
}

static async Task run_check(string CommandName)
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
            await exit_connection();
            await exit_session();
            Environment.Exit(1);
        }

        if (Action.Equals("AI", StringComparison.OrdinalIgnoreCase))
        {
            string AiAction = CommandName.Substring(3).Trim();
            // Debugging basic filesstack
            if (AiAction.Equals("DEBUG FILE", StringComparison.OrdinalIgnoreCase))
            {
                // hardcode local filepath
                string filePath = ("./Local/" + CommandName["GTL AI Debug File ".Length..]);
                string content = File.ReadAllText(filePath);
                string PromptHelper = $"Please debug this code, make your answer as short as possible. no details until asked";
                string CommandPrompt = $"{PromptHelper}\n\n{content}\nProgram filepath: {filePath}";
                await Ai_Stack(CommandPrompt);
            }

            // Main ai questioneer
            else if (AiAction.Equals("ASK", StringComparison.OrdinalIgnoreCase))
            {
                string CommandPrompt = CommandName["GTL ASK ".Length..];
                await Ai_Stack(CommandPrompt);
            }


            // AI architecture
            /// AI start will create an Ai branche.
            /// AI bot "botname" should create a bot
            /// then if you give it a prompt, it will repeat prompt in set time
            // Start ai 
            else if (AiAction.Equals("start", StringComparison.OrdinalIgnoreCase))
            {
                string FileContent = Convert.ToString("First Started AI Name");
                File.WriteAllText($"./AI/.Ai", FileContent);
            }
            else if (AiAction.EndsWith("bot", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("[GTL]@T- :// BotName? ");
                string BotName = Console.ReadLine() ?? "";
                CreateBot(BotName);

                string FileContent = Convert.ToString(""); // Promptlist
                File.WriteAllText($"./AI/.{BotName}", FileContent);
            }
            // now if you do GTL AI %botname% (prompt) it will add it to its promptlist
            else if (AiAction.Equals($"", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("[GTL]@T- :// BotName? ");
                string BotName = Console.ReadLine() ?? "";

                string FileContent = Convert.ToString(""); // Promptlist
                File.WriteAllText($"./AI/.{BotName}", FileContent);
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

// AI Stack
static async Task Ai_Stack(string prompt)
{
    
    Ollama ai = new Ollama();
    string answer = await ai.Ai_Request(prompt);
    Console.WriteLine(answer);
}
static void CreateBot(string BotName)
{
    if (GTLState.BotList.Contains(BotName))
    {
        Console.WriteLine("Bot already exists.");
        return;
    }

    GTLState.BotList.Add(BotName);

    Directory.CreateDirectory("./AI");

    File.WriteAllText($"./AI/.{BotName}", "");

    Console.WriteLine($"Bot {BotName} created.");
}


// connecting:
static void RunSwitchCheck()
{
    if (!Run_Exists(".con"))
        establish_connection();

    if (!Run_Exists("./Server/.server"))
        establish_session();

    if (!Run_Exists("./Local/.local"))
        establish_local();

    Console.WriteLine("[GTL] Connection established.");
}


// connection making (saved inside the main module)
static void establish_connection()
{
    string FileContent = Convert.ToString(Random.Shared.Next(1111111, 8999999));
    File.WriteAllText(".con", FileContent);
}
/// exiting the connection
static async Task exit_connection()
{
    File.Delete(".con");
}

static void establish_local()
{
    string FileContent = Convert.ToString(Random.Shared.Next(1111111, 8999999));
    File.WriteAllText("./Local/.local", FileContent);
}

// session making (saved inside the server module)
/// making the session
static void establish_session()
{
    string FileContent = Convert.ToString(Random.Shared.Next(1111111, 8999999));
    File.WriteAllText("./Server/.server", FileContent);
}
/// exiting the session
static async Task exit_session()
{
    File.Delete("./Server/.server");
}

// small controls and checks
static bool Run_Exists(string FileNameCheck)
{
    bool Run_Bool;
    try
    {
        Run_Bool = File.Exists(FileNameCheck);
        return Run_Bool;
    }
    catch
    {
        ErrorHandler.Load_Error("Error ALL");
        return false;
    }
}

static class GTLState
{
    public static List<string> BotList = [];
}
