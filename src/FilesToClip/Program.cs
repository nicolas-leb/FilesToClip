using System.CommandLine;

var extensionsOption = new Option<string>(
        "--extension",
        "The file extension to search for (e.g., .txt)")
{
    IsRequired = true,
};
extensionsOption.AddAlias("-e");

var scanFolderOption = new Option<string>(
        "--folder",
        "The folder to scan for files.");
scanFolderOption.AddAlias("-sf");

var rootCommand = new RootCommand("CLI tool to concatenate files by extension into the system clipboard.");
rootCommand.AddOption(extensionsOption);
rootCommand.AddOption(scanFolderOption);

rootCommand.SetHandler(() =>
{
    Console.WriteLine("Hello, World!");
});

return await rootCommand.InvokeAsync(args);