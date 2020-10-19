using System;
using System.IO;
using System.Text;

namespace ConsoleFileManager
{
    class FileCreate : IApplication
    {
        public string Name { get; set; }
        public string[] Arguments { get; set; }

        public FileCreate(string name)
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
                return "Usage: create <dir_path>";
            }
            string dirPath = Utils.HandleDirectoryPath(args[1]);

            if(dirPath == String.Empty)
            {
                return "This directory doesn't exist.";
            }

            Console.Write("Please specify a name of new file: ");
            string fileName = Console.ReadLine();

            Encoding enc = null;
            do {
                Console.Write("Please specify an encoding for this file: ");
                string encodingInput = Console.ReadLine();
                enc = Utils.GetEncodingOrReturnNullIfNotFound(encodingInput);
                if(enc == null) {
                    Console.WriteLine("Incorrect encoding. Choose one from list: utf-8, utf-32, ascii, unicode.");
                }
            } while(enc == null);
            
            try
            {
                StreamWriter sw = new StreamWriter(File.Open(Path.Combine(dirPath, fileName), FileMode.Create), enc);
                sw.WriteLine("This file was created by CFM.");
                sw.Close();
            }
            catch (IOException)
            {
                return "Something went wrong :(";
            }
            catch (UnauthorizedAccessException)
            {
                return $"Permission denied for {dirPath}";
            }

            return "File successfully created.";
        }
    }
}
