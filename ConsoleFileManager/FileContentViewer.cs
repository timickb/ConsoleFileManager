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

        private string GetFileContent(string filePath, Encoding enc)
        {
            if (enc == null)
            {
                enc = Encoding.UTF8;
            }
            List<string> content = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(File.Open(filePath, FileMode.Open), enc))
                {
                    while (sr.Peek() >= 0)
                    {
                        content.Add(sr.ReadLine());
                    }
                }
            }
            catch (IOException)
            {
                return "Cannot access this file. Operation failed.";
            }
            catch (UnauthorizedAccessException)
            {
                return $"Permission denied for {filePath}";
            }
            return String.Join(Environment.NewLine, content);
        }

        public string Run(string[] args)
        {
            if (args.Length < 2)
            {
                return "Usage: cat <filename> [encoding]";
            }
            string fullPath = Utils.HandleFilePath(args[1]);
            if (fullPath == String.Empty)
            {
                return "This file doesn't exist.";
            }
            if (args.Length == 3)
            {
                Encoding enc = Utils.GetEncodingOrReturnNullIfNotFound(args[2]);
                return GetFileContent(fullPath, enc);
            }
            return GetFileContent(fullPath, Encoding.UTF8);
        }
    }
}
