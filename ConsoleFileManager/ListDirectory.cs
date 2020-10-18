using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleFileManager
{
    class ListDirectory : IApplication
    {
        public string Name { get; set; }
        public string[] Arguments { get; set; }

        public ListDirectory(string name)
        {
            Name = name;
        }

        public void Interrupt()
        {
            throw new NotImplementedException();
        }

        public string Run(string[] args)
        {
            string[] files, directories;
            string dirPath;
            if(args.Length == 1) {
                dirPath = CommandExecutor.CurrentUserPath;
            } else {
                dirPath = Utils.HandleDirectoryPath(args[1]);
                if(dirPath == "") {
                    return "This directory doesn't exist.";
                }
            }
            files = Directory.GetFiles(dirPath);
            directories = Directory.GetDirectories(dirPath);
            
            // We need only file names and dir names => remove path tail.
            for(int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileName(files[i]);
            }
            for(int i = 0; i < directories.Length; i++)
            {
                directories[i] = Path.GetFileName(directories[i]) + " [directory]";
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            return $"Content of {dirPath}:\n\n" + String.Join('\n', files) + '\n' + String.Join('\n', directories);
            
        }
    }
}
