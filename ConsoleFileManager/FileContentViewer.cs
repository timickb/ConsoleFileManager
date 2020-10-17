using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            if(args.Length == 1)
            {
                return "Usage: cat <filename>";
            }
            string[] fileContent;
            string filePath = CommandExecutor.CurrentUserPath + "\\" + args[1];
            try
            {
                fileContent = File.ReadAllLines(filePath);
            } catch(IOException)
            {
                return $"File {filePath} not found";
            }

            return String.Join('\n', fileContent);
        }
    }
}
