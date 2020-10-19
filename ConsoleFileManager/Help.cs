using System;

namespace ConsoleFileManager
{
    class Help : IApplication
    {
        public string Name { get; set; }

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
            output += "cat <file_path> [encoding] : print the content of the file to the console (optional with specified encoding, utf-8 by default)" + sep;
            output += "create <dir_path> : create new file in specified directory. This tool will request the filename and its encoding." + sep;
            output += "mkdir <base_dir_path> : create new directory in existing base_dir_path directory. This tool will request the name for new directory." + sep;
            output += "mv <src_file_path> <dest_dir_path> : move file to directory <dest_path>" + sep;
            output += "cp <src_file_path> <dest_dir_path> : copy file to directory <dest_path>" + sep;
            output += "rm <object_path> : remove file or EMPTY directory" + sep;
            output += "concat <file1_path> <file2_path> [output_dir_path]: concatenate the content of two files." +
            "If output directory is not specified, the result of operation will be printed to the console." +
            "The name of new file is also a concatenation of two old names with the first's file extension." + sep;
            output += "help : print this text again" + sep + sep;
            output += "Note 1: paths may be either absolute or relative. \"..\" = parent dir, \".\" = current dir." + sep;
            output += "Note 2: params in square brackets [] are optional, params in curve brackets <> are required." + sep;

            Console.ForegroundColor = ConsoleColor.Yellow;
            return output;
        }
    }
}
