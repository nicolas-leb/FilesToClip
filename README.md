# FileToClip

**FileToClip** is a simple command-line tool built with .NET 8 that concatenates the contents of files with a given extension and copies the result directly to your system clipboard. This tool is ideal for quickly merging text-based files (e.g., `.txt`, `.log`, etc.) from a directory and making the result easily accessible via the clipboard for further use.

## Features

- Merge all files of a specific extension within a folder.
- Automatically copy the merged content to the system clipboard.
- Supports dependency injection for easier testing and maintenance.
- Built with modern .NET 8 technologies and best practices.

## Tech Stack

- **.NET 8**: The latest version of the .NET framework, providing enhanced performance and features for building cross-platform applications.
- **C#**: The primary programming language used in this project.
- **System.CommandLine**: For parsing command-line arguments and managing user input.
- **TextCopy**: A library to copy the concatenated content directly to the system clipboard.
- **Microsoft.Extensions.Hosting**: Provides a robust dependency injection framework for managing services and logging.
- **System.IO.Abstractions**: Used to abstract file system operations for testability, enabling easier unit testing.

## Requirements

- **.NET 8 SDK** installed.
- Runs on **Windows**, **Linux**, and **macOS** (Clipboard functionality might vary depending on the platform).

## Installation

### Step 1: Clone the Repository

```bash
git clone https://github.com/yourusername/MergeToClip.git
cd MergeToClip
```

### Step 2: Install Dependencies

Before running the application, ensure that all necessary NuGet packages are installed:

```bash
dotnet restore
```

### Step 3: Build the Application

```bash
dotnet build
```

## Usage

Once the project is built, you can run the tool via the command line.

### Command-line Arguments

```bash
dotnet run --extension <file-extension> --folder <folder-path>
```

| Argument      | Description                                                |
|---------------|------------------------------------------------------------|
| `--extension` | The file extension to search for (e.g., `.txt`, `.log`).    |
| `--folder`    | The folder where the files are located.                     |

### Example

```bash
dotnet run --extension ".txt" --folder "C:/InputFolder"
```

In this example, **FileToClip** will concatenate all `.txt` files in the `C:/InputFolder` directory and copy the result to your clipboard.

## How It Works

- The tool scans the specified folder for files with the provided extension.
- It merges the contents of these files.
- The merged content is copied directly to your system clipboard using the [TextCopy](https://github.com/CopyText/TextCopy) library.

## Testing

The project has been designed with **dependency injection** to allow easy testing of file I/O operations by mocking the `System.IO.Abstractions` library.

## Dependencies

This project uses the following libraries:

- [System.CommandLine](https://github.com/dotnet/command-line-api) for handling command-line arguments.
- [Microsoft.Extensions.Hosting](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting) for dependency injection and logging.
- [TextCopy](https://github.com/CopyText/TextCopy) for clipboard operations.
- [System.IO.Abstractions](https://github.com/System-IO-Abstractions/System.IO.Abstractions) for testing and file system abstraction.

## Future Enhancements

- **Save to file option**: Add a switch to choose between clipboard output and file output.
- **Multithreading**: Process large sets of files concurrently for better performance.
- **Filters**: Allow more advanced filtering by file name or modification date.

## Contributing

Feel free to submit issues or pull requests. Contributions are welcome!

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/NewFeature`)
3. Commit your changes (`git commit -m 'Add some NewFeature'`)
4. Push to the branch (`git push origin feature/NewFeature`)
5. Open a pull request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
