// init
using System.ComponentModel;
using System.IO;
using ErrorHandelling;

// GTL architecture
// GTL start to start a first connection and auto connect a session.
// GTL session status
// GTL connection status
// GTL STATUS
// GTL load
// GTL parse

// Main frame
using System.Net;
using System.Net.Mime;

// init load
MainLoop();

static void MainLoop()
{
    Console.Write("GTL ~> ");
    string Command = Console.ReadLine() ?? "";
    run_check(Command);
}

static void run_check(string CommandName)
{
    if (CommandName.Contains("GTL") || CommandName.Contains("gtl"))
    {
        if (CommandName.Contains("start"))
        {
            // first lets check if all necessery files are created.
            if (exists(".con") != "False") 
            {
                if (exists(".server") != "False")
                {
                    if (exists(".local") != "False")
                    {
                        // succesnode
                    } else return;
                } else return;      
                ErrorHandler.Load_Error("Error FileNames notfound");
                MainLoop();
            } else {MainLoop();}
        }
        else
        {
            // check if Perhaps misspelled
            ErrorHandler.Load_Error($"Error 404, Command {CommandName[4..]} Not Found");
            MainLoop();
        }
    } else
    {
        ErrorHandler.Load_Error("Error 404, Perhaps GTL?");
        MainLoop();
    }
}

static void establish_connection()
{
    

}

static void establish_session()
{
    

}

// small controls and checks
static string exists(string FileNameCheck)
{
    string FileContent;
    try
    {
        FileContent = File.ReadAllText(FileNameCheck);
        return FileContent;
    }
    catch
    {
        ErrorHandler.Load_Error("Error ALL");
        return "False";
    }
}
