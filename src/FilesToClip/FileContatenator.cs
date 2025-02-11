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
        private readonly IFileSystem _fileSystem;

        public FileContatenator(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public async Task ConcatenateFilesAsync(string extension, string folderPath)
        {

            if (!_fileSystem.Directory.Exists(folderPath))
            {
                return;
            }

            var files = _fileSystem.Directory.GetFiles(folderPath, $"*{extension}");
            if (files.Length == 0)
            {
                return;
            }

            var stringBuilder = new StringBuilder();

            foreach (var file in files)
            {
                using var reader = _fileSystem.File.OpenText(file);
                string content = await reader.ReadToEndAsync();

                stringBuilder.AppendLine(content);
            }

            string mergedContent = stringBuilder.ToString();

            // Copy the merged content to the clipboard
            ClipboardService.SetText(mergedContent);

        }
    }
}
