using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace File_Renamer {

    internal class Program {

        public static void Main(string[] args) {
            if(args.Contains("--help") || args.Contains("-h")) {
                print_help();
                return;
            }

            Dictionary<string, string> arguments = parse_arguments(args);

            if(!arguments.ContainsKey("path")) {
                Console.WriteLine("Please specify the folder path using \"path=YourFolderPath\".");
                return;
            }

            string folder_path = arguments["path"];

            if(!Directory.Exists(folder_path)) {
                Console.WriteLine("The specified folder does not exist.");
                return;
            }

            string file_extension = arguments.ContainsKey("extension") ? arguments["extension"] : ".png";

            if (!file_extension.StartsWith(".")) {
                file_extension = "." + file_extension;
            }

            string file_name_format = arguments.ContainsKey("format") ? arguments["format"] : "{counter}";
            int counter = arguments.ContainsKey("start") ? int.Parse(arguments["start"]) : 1;
            List<string> files = Directory.GetFiles(folder_path, "*" + file_extension).ToList();

            Console.WriteLine(files.Count + $" {file_extension} files found.");

            foreach(var file in files) {
                string formatted_counter = counter.ToString("D3");
                string new_name_format = file_name_format.Contains("{counter}") ? file_name_format.Replace("{counter}", formatted_counter) + file_extension : file_name_format + formatted_counter + file_extension;

                string new_name = Path.Combine(folder_path, new_name_format);

                if(File.Exists(new_name)) {
                    counter ++;
                    continue;
                }

                Console.WriteLine(Path.GetFileName(file) + " -> " + Path.GetFileName(new_name));
                File.Move(file, new_name);
                counter ++;
            }

            Console.WriteLine($"Renaming completed. {counter - 1} files renamed.");
        }

        private static Dictionary<string, string> parse_arguments(string[] args) {
            Dictionary<string, string> arguments = new Dictionary<string, string>();

            foreach (var arg in args) {
                var parts = arg.Split('=');

                if(parts.Length == 2) {
                    arguments[parts[0]] = parts[1];
                }
            }

            return arguments;
        }

        private static void print_help() {
            Console.WriteLine("Usage: File_Renamer [options]");
            Console.WriteLine("Options:");
            Console.WriteLine("  --help, -h\t\tShow this help message");
            Console.WriteLine("  path=YourFolderPath\tSpecify the folder path to rename files in");
            Console.WriteLine("  extension=YourExtension\tSpecify the file extension to filter by (default: .png)");
            Console.WriteLine("  format=YourFormat\tSpecify the file name format (default: {counter})");
            Console.WriteLine("  start=YourStartNumber\tSpecify the starting number for the counter (default: 1)");
            Console.WriteLine("\nExamples:");
            Console.WriteLine("  File_Renamer path=C:\\Users\\Example\\Pictures extension=png format=photo_{counter} start=100");
            Console.WriteLine("  File_Renamer --help");
        }
    }
}