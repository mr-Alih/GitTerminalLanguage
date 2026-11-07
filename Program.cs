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
            await RunSwitchCheck();
        }
        // Exitting the application
        if (Action.Equals("exit", StringComparison.OrdinalIgnoreCase))
        {
            await exit_connection();
            await exit_session();
            Environment.Exit(1);
        }


        // Debugging basic filesstack
        else if (Action.Equals("AI DEBUG FILE", StringComparison.OrdinalIgnoreCase))
        {
            // hardcode local filepath
            string filePath = ("./Local/" + CommandName["GTL AI Debug File ".Length..]);
            string content = File.ReadAllText(filePath);
            string PromptHelper = $"Please debug this code, make your answer as short as possible. no details until asked";
            string CommandPrompt = $"{PromptHelper}\n\n{content}\nProgram filepath: {filePath}";
            await Ai_Stack(CommandPrompt);
        }

        // Main ai questioneer
        else if (Action.Equals("AI", StringComparison.OrdinalIgnoreCase))
        {
            string CommandPrompt = CommandName["GTL AI ".Length..];
            await Ai_Stack(CommandPrompt);
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

// connecting:
static async Task RunSwitchCheck()
{
    int state = 1;
    while (state <= 3)
    {
        switch (state)
        {
            case 1:
                if (Run_Exists(".con"))
                {
                    state = 2;
                }
                else
                {
                    establish_connection();
                }
                break;

            case 2:
                if (Run_Exists(".server"))
                {
                    state = 3;
                }
                else
                {
                    establish_session();
                }
                break;

            case 3:
                if (Run_Exists(".local"))
                {
                    state = 4;
                    // approve
                    continue;
                }
                else
                {
                    establish_local();
                }
                break;
        }
    }
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
