using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleFileManager
{
    class FileJoin : IApplication
    {
        public string Name { get; set; }
        public string[] Arguments { get; set; }

        public FileJoin(string name)
        {
            Name = name;
        }

        public void Interrupt()
        {
            throw new NotImplementedException();
        }

        public string Run(string[] args)
        {
            return "";
        }
    }
}
