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
            string[] fileList, subdirList;
            string dirPath = CommandExecutor.CurrentUserPath;
            // If it mentioned in command, append a relative path argument.
            if(args.Length > 1)
            {
                dirPath = Path.Combine(dirPath, args[1]);
            }
            try
            {
                fileList = Directory.GetFiles(dirPath);
                subdirList = Directory.GetDirectories(dirPath);
            } catch(DirectoryNotFoundException)
            {
                return $"Directory {dirPath} not found.";
            } catch(IOException)
            {
                return $"Cannot access {dirPath}.";
            }

            // We need only file names and dir names => remove path tail.
            for(int i = 0; i < fileList.Length; i++)
            {
                fileList[i] = Path.GetFileName(fileList[i]);
            }
            for(int i = 0; i < subdirList.Length; i++)
            {
                subdirList[i] = Path.GetFileName(subdirList[i]) + " [directory]";
            }

            Console.ForegroundColor = ConsoleColor.Green;
            return $"Content of {dirPath}:\n\n" + String.Join('\n', fileList) + '\n' + String.Join('\n', subdirList);
        }
    }
}
