using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ConsoleFileManager
{
    class FileContentViewer : IApplication
    {
        public string Name { get; set; }
        public string[] Arguments { get; set; }

        public FileContentViewer(string name)
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
                return "Usage: cat <filename>";
            }
            string fullPath = Utils.HandleFilePath(args[1]);
            if(fullPath == String.Empty) {
                return "This file doesn't exist.";
            }
            string[] fileContent = File.ReadAllLines(fullPath);
            return String.Join(Environment.NewLine, fileContent);
        }
    }
}
