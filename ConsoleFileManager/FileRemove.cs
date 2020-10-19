using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleFileManager
{
    class FileRemove : IApplication
    {
        public string Name { get; set; }
        public string[] Arguments { get; set; }

        public FileRemove(string name)
        {
            Name = name;
        }

        public void Interrupt()
        {
            throw new NotImplementedException();
        }

        public string Run(string[] args)
        {
            if (args.Length < 2)
            {
                return "Usage: rm <file_path_or_dir_path>";
            }
            string filePath = Utils.HandleFilePath(args[1]);
            string dirPath = Utils.HandleDirectoryPath(args[1]);
            if (filePath != String.Empty)
            {
                try
                {
                    File.Delete(filePath);
                    return "Success";
                }
                catch (IOException)
                {
                    return "Cannot access the file.";
                }
            }
            else if (dirPath != String.Empty)
            {
                try
                {
                    Directory.Delete(dirPath);
                    return "Success";
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    return "Cannot access the directory.";
                }
            }
            return $"Object {args[1]} doesn't exist.";
        }
    }
}
