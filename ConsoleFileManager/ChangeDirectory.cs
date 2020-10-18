using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleFileManager
{
    class ChangeDirectory : IApplication
    {
        public string Name { get; set; }
        public string[] Arguments { get; set; }

        public ChangeDirectory(string name)
        {
            Name = name;
        }

        public void Interrupt()
        {
            throw new NotImplementedException();
        }

        public string Run(string[] args)
        {
            if(args.Length < 2)
            {
                return "Usage: cd <path>";
            }
            string fullPath = Utils.HandleDirectoryPath(args[1]);
            if(fullPath == String.Empty) {
                return "This directory doesn't exist.";
            }
            CommandExecutor.CurrentUserPath = fullPath;
            return $"Successfully moved to {fullPath}";
           
        }
    }
}
