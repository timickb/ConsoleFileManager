using System;
using System.IO;
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
            if(args.Length < 3)
            {
                return "Usage: cp <source_file_path> <destination_dir_path>";
            }
            string srcPath = Utils.HandleFilePath(args[1]);
            string destPath = Utils.HandleDirectoryPath(args[2]);

            if(srcPath == String.Empty)
            {
                return "Source file doesn't exist.";
            }
            if(destPath == String.Empty)
            {
                return "Destination directory doesn't exist.";
            }

            string fileName = Path.GetFileName(srcPath);
            destPath = Path.Combine(destPath, fileName);

            try
            {
                File.Copy(srcPath, destPath);
            }
            catch(IOException)
            {
                return "This file already exists in destination or something else went wrong.";
            }
            catch(UnauthorizedAccessException)
            {
                return "Permission denied.";
            }

            return "Copied!";
        }
    }
}
