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
using System.Collections;

// init load
MainLoop();

static void MainLoop()
{
    Console.Write("[GTL]@T- :// ");
    string Command = Console.ReadLine() ?? "";
    run_check(Command);
}

static void run_check(string CommandName)
{
    if (CommandName.Contains("GTL") || CommandName.Contains("gtl"))
    {
        if (CommandName.Contains("start"))
        {
            int state = 1;

            while (state <= 3)
            {
                switch (state)
                {
                    case 1:
                        if (Run_Exists(".con"))
                            state = 2;
                        else
                            ErrorHandler.Load_Error("ConError");
                            return;
                        break;

                    case 2:
                        if (Run_Exists(".server"))
                            state = 3;
                        else
                            ErrorHandler.Load_Error("FileError");
                            return;
                        break;

                    case 3:
                        if (Run_Exists(".con"))
                        {
                            // approve
                            establish_connection();
                            establish_session();
                        }
                        else
                            ErrorHandler.Load_Error("FileError");
                            return;
                        break;
                }
            }
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
    string FileContent = Convert.ToString(Random.Shared.Next(1111111, 8999999));
    File.WriteAllText(".con", FileContent);
}

static void establish_session()
{
    

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
