// init
// Main frame
using System.Net;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.IO;
using ErrorHandelling;
using GTL.AI;
using GTL.BotRunner;
using GTL.ProcessRunner;
using GTL.CommandRunner;
using GTL.AiCommandRunner;

// GTL architecture
// GTL start to start a first connection and auto connect a session.
// GTL session status
// GTL connection status
// GTL STATUS
// GTL load
// GTL parse
//  GTL AI "answer me this?"

// the end proces runner for session:
ProcessRunner processRunner = new ProcessRunner();
CommandRunner commandRunner = new CommandRunner();
AiCommandRunner aiCommandRunner = new AiCommandRunner();
Console.WriteLine("GTL 2026*c CopyRight");

// init load
Directory.CreateDirectory("./AI");
foreach (string FilePath in Directory.GetFiles("./AI", "*.bot"))
{
    string BotName = Path.GetFileNameWithoutExtension(FilePath);
    GTLState.BotList.Add(BotName);
}


await MainLoop();

async Task MainLoop()
{
    while (true)
    {
        Console.Write("[GTL]@T- :// ");
        string Command = Console.ReadLine() ?? "";
        await commandRunner.Execute(Command);
    }
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
