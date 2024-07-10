# File Renamer Tool

## Overview
The File Renamer Tool is a command-line application written in C# designed to rename files in a specified directory based on a customizable naming format. It allows users to filter files by extension, define a custom file naming format, and specify a starting number for file naming counters. This tool is particularly useful for organizing collections of files, such as photos or documents, by renaming them according to a consistent pattern.

## Features
- **Custom File Naming**: Specify a custom naming format for the files using placeholders.
- **Extension Filtering**: Rename only files of a specific extension within the directory.
- **Counter Start Point**: Begin the naming sequence from a custom starting number.
- **Help Guide**: Access a help guide with usage instructions directly from the command line.

## Usage

### Prerequisites
- .NET Runtime environment
- Command line or terminal access

### Running the Tool
1. Open your command line or terminal.
2. Navigate to the directory where the File Renamer Tool is located.
3. Execute the tool using the following syntax:

```shell
File_Renamer [options]
--help, -h: Show the help message with usage instructions.
path=YourFolderPath: Specify the folder path containing the files you wish to rename.
extension=YourExtension: Specify the file extension of the files you wish to rename (default: .png).
format=YourFormat: Specify the file name format. Use {counter} as a placeholder for the numbering (default: {counter}).
start=YourStartNumber: Specify the starting number for the counter (default: 1).
```

### Examples
Rename .png files in the C:\Users\Example\Pictures directory using the default naming format starting from 100:

```shell
File_Renamer path=C:\Users\Example\Pictures extension=png start=100
```

Rename files in the C:\Documents directory with a custom format and extension:

```shell
File_Renamer path=C:\Documents extension=txt format=Document_{counter} start=1
```

## Contributing
Contributions to the File Renamer Tool are welcome. Please ensure to follow the project's coding standards and submit a pull request for review.

## License
This project is licensed under the MIT License - see the LICENSE file for details