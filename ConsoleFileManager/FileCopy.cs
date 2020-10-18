using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleFileManager
{
    class FileCopy : IApplication
    {
        public string Name { get; set; }
        public string[] Arguments { get; set; }

        public FileCopy(string name)
        {
            Name = name;
        }

        public void Interrupt()
        {
            throw new NotImplementedException();
        }

        public string Run(string[] args)
        {
            if(args.Length < 3) {
                return "Usage: cp <source_path> <destination_path>";
            }
            string srcPath = Utils.FileExists(args[1]);
            string destPath = Utils.FileExists(args[2]);
            if(srcPath == String.Empty) {
                return "Source path doesn't exist.";
            }
            if(destPath == String.Empty) {
                return "Destination path doesn't exist.";
            }
            return "";
        }
    }
}
