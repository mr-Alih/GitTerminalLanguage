using System;
using System.IO;
using GTL.ProcessRunner;
using GTL.CommandRunner;
using GTL.AiCommandRunner;
using GTL.Core;

// Initialize components
ProcessRunner processRunner = new ProcessRunner();

AiCommandRunner aiCommandRunner = new AiCommandRunner();

ConnectionRunner connectionRunner = new ConnectionRunner();

CommandRunner commandRunner = new CommandRunner(
    processRunner,
    aiCommandRunner,
    connectionRunner
);

Console.WriteLine("GTL 2026*c CopyRight");

// Load bots
Directory.CreateDirectory("./AI");

foreach (string filePath in Directory.GetFiles("./AI", "*.bot"))
{
    string botName = Path.GetFileNameWithoutExtension(filePath);
    GTLState.BotList.Add(botName);
}

await MainLoop();

async Task MainLoop()
{
    while (true)
    {
        Console.Write("[GTL]@T- :// ");

        string command = Console.ReadLine() ?? "";

        await commandRunner.Execute(command);
    }
}