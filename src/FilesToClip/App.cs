using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesToClip
{
    internal class App(ILogger<App> logger, IFileContatenator fileContatenator)
    {
        public async Task RunAsync(string[] args)
        {
            RootCommand rootCommand = CreateRootCommand();

            await rootCommand.InvokeAsync(args);
        }

        private RootCommand CreateRootCommand()
        {
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
                await fileContatenator.ConcatenateFilesAsync(extensionsOptionValue, scanFolderValue);
            },
                extensionsOption, scanFolderOption);

            logger.LogDebug("Root command created.");

            return rootCommand;
        }
    }
}
