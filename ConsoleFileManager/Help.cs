using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleFileManager
{
    class Help : IApplication
    {
        public string Name { get; set; }
        public string[] Arguments { get; set; }

        public Help(string name)
        {
            Name = name;
        }

        public void Interrupt()
        {
            throw new NotImplementedException();
        }

        public string Run(string[] args)
        {
            string output = "";
            output += "Hi! This is simple Console File Manager (CFM). You can interact with it\n";
            output += "as with command line interface using commands from list below:\n";
            return output;
        }
    }
}
