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
    internal class FileContatenator : IFileContatenator
    {
        private readonly ILogger<FileContatenator> _logger;
        private readonly IFileSystem _fileSystem;

        public FileContatenator(ILogger<FileContatenator> logger, IFileSystem fileSystem)
        {
            _logger = logger;
            _fileSystem = fileSystem;
        }

        public async Task ConcatenateFilesAsync(string extension, string folderPath)
        {
            _logger.LogInformation("Starting file concatenation.");

            if (!_fileSystem.Directory.Exists(folderPath))
            {
                _logger.LogError($"The directory {folderPath} does not exist.");
                return;
            }

            var files = _fileSystem.Directory.GetFiles(folderPath, $"*{extension}");
            if (files.Length == 0)
            {
                _logger.LogWarning($"No files with extension {extension} were found in {folderPath}.");
                return;
            }

            var stringBuilder = new StringBuilder();

            foreach (var file in files)
            {
                _logger.LogDebug($"Processing file: {file}");
                using var reader = _fileSystem.File.OpenText(file);
                string content = await reader.ReadToEndAsync();

                stringBuilder.AppendLine(content);
            }

            string mergedContent = stringBuilder.ToString();

            // Copy the merged content to the clipboard
            ClipboardService.SetText(mergedContent);

            _logger.LogInformation($"File concatenation completed. Output saved in clipboard.");
        }
    }
}
