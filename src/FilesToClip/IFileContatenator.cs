
namespace FilesToClip
{
    internal interface IFileContatenator
    {
        Task ConcatenateFilesAsync(string extension, string folderPath);
    }
}