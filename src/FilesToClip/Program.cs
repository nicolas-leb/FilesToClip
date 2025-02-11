using FilesToClip;
using System.CommandLine;
using System.IO.Abstractions;

var extensionsOption = new Option<string>(
        "--extension",
        "The file extension to search for (e.g., .txt)")
{
    IsRequired = true,
};
extensionsOption.AddAlias("-e");

var scanFolderOption = new Option<string>(
        "--folder",
        "The folder to scan for files.")
{
    IsRequired = true,
};
scanFolderOption.AddAlias("-sf");

var rootCommand = new RootCommand("CLI tool to concatenate files by extension into the system clipboard.");
rootCommand.AddOption(extensionsOption);
rootCommand.AddOption(scanFolderOption);

rootCommand.SetHandler(async (extensionsOptionValue, scanFolderValue) =>
{
    Console.WriteLine($"Scanning {scanFolderValue} for {extensionsOptionValue} files!");
    var fileContatenator = new FileContatenator(new FileSystem());
    await fileContatenator.ConcatenateFilesAsync(extensionsOptionValue, scanFolderValue);
},
    extensionsOption, scanFolderOption);

return await rootCommand.InvokeAsync(args);