using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleFileManager
{
    class FileMove : IApplication
    {
        public string Name { get; set; }
        public string[] Arguments { get; set; }

        public FileMove(string name)
        {
            Name = name;
        }

        public void Interrupt()
        {
            throw new NotImplementedException();
        }

        public string Run(string[] args)
        {
            if(args.Length < 3)
            {
                return "Usage: <src_file_path> <dest_dir_path>";
            }
            string filePath = Utils.HandleFilePath(args[1]);
            string dirPath = Utils.HandleDirectoryPath(args[2]);

            if(filePath == String.Empty)
            {
                return "Source file doesn't exist.";
            }
            if(dirPath == String.Empty)
            {
                return "Destination directory doesn't exist.";
            }

            

            return "";
        }
    }
}
