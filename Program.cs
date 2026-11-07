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
Directory.CreateDirectory("./AI");
foreach (string FilePath in Directory.GetFiles("./AI", "*.bot"))
{
    string BotName = Path.GetFileNameWithoutExtension(FilePath);
    GTLState.BotList.Add(BotName);
}

await MainLoop();
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

                string FilePath = $"./AI/{BotName}.bot";

                File.AppendAllText(
                    FilePath,
                    Prompt + Environment.NewLine
                );

                Console.WriteLine($"Prompt added to {BotName}.");
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
