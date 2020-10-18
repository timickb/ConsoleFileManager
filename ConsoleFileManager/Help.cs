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
            string sep = Environment.NewLine;
            output += "Hi! This is simple Console File Manager (CFM). You can interact with it" + sep;
            output += "as with command line interface using commands from list below:" + sep + sep;
            output += "location : print your current location in file system" + sep;
            output += "lsblk : print all available drives and their parameters." + sep;
            output += "ls [dir_path] : print the content of directory (current directory by default)" + sep;
            output += "cd <dir_path> : move to another directory" + sep;
            output += "cat <file_path> [encoding] : print the content of the file to the console (optional with specified encoding)" + sep;
            output += "edit <file_path> [encoding] : text editor" + sep;
            output += "mv <src_path> <dest_path> : move file to another location" + sep;
            output += "cp <src_path> <dest_path> : copy file" + sep;

            Console.ForegroundColor = ConsoleColor.Yellow;
            return output;
        }
    }
}
