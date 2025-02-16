using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextCopy;

namespace FilesToClip
{
    internal class FileContatenator(ILogger<FileContatenator> logger, IFileSystem fileSystem) : IFileContatenator
    {
        public async Task ConcatenateFilesAsync(string extension, string folderPath)
        {
            logger.LogInformation("Starting file concatenation.");

            if (!fileSystem.Directory.Exists(folderPath))
            {
                logger.LogError("The directory {folderPath} does not exist.", folderPath);
                return;
            }

            var files = fileSystem.Directory.GetFiles(folderPath, $"*{extension}", SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                logger.LogWarning("No files with extension {extension} were found in {folderPath}.", extension, folderPath);
                return;
            }

            var stringBuilder = new StringBuilder();

            foreach (var file in files)
            {
                logger.LogDebug("Processing file: {file}", file);
                using var reader = fileSystem.File.OpenText(file);
                string content = await reader.ReadToEndAsync();

                stringBuilder.AppendLine(content);
            }

            string mergedContent = stringBuilder.ToString();

            // Copy the merged content to the clipboard
            ClipboardService.SetText(mergedContent);

            logger.LogInformation("File concatenation completed. Output saved in clipboard.");
        }
    }
}
