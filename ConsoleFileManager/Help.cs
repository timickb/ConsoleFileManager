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
            output += "as with command line interface using commands from list below:\n\n";
            output += "ls [dir_path] : print the content of directory (current directory by default)\n";
            output += "cd <dir_path> : move to another directory\n";
            output += "cat <file_path> : print the content of the file to the console\n";
            output += "edit <file_path> : text editor\n";
            output += "mv <src_path> <dest_path> : move file to another location\n";
            output += "cp <src_path> <dest_path> : copy file\n";

            Console.ForegroundColor = ConsoleColor.Yellow;
            return output;
        }
    }
}
