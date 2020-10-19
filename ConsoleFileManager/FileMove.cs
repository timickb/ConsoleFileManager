using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleFileManager
{
    class FileMove : IApplication
    {
        // We need to know the result of copy operation before removing original file.
        private bool copyStatus;

        public string Name { get; set; }
        public string[] Arguments { get; set; }

        public FileMove(string name)
        {
            Name = name;
        }

        public void Interrupt()
        {
            throw new NotImplementedException();
        }

        private string CreateFileCopy(string fileContent, string fileName, string dirPath, Encoding enc)
        {
            try
            {
                StreamWriter sw = new StreamWriter(
                    File.Open(Path.Combine(dirPath, fileName), FileMode.Create), enc);
                sw.WriteLine(fileContent);
                sw.Close();
            }
            catch(IOException)
            {
                copyStatus = false;
                return $"Cannot create file in {dirPath}";
            }
            catch(UnauthorizedAccessException)
            {
                copyStatus = false;
                return $"Permission to {dirPath} is denied";
            }
            copyStatus = true;
            return $"File moved to {Path.Combine(dirPath, fileName)}";
        }

        public string Run(string[] args)
        {
            copyStatus = false;
            if (args.Length < 3)
            {
                return "Usage: <src_file_path> <dest_dir_path>";
            }
            string filePath = Utils.HandleFilePath(args[1]);
            string dirPath = Utils.HandleDirectoryPath(args[2]);

            if (filePath == String.Empty)
            {
                return "Source file doesn't exist.";
            }
            if (dirPath == String.Empty)
            {
                return "Destination directory doesn't exist.";
            }

            try
            {
                string fileContent = String.Join(Environment.NewLine, File.ReadAllLines(filePath));
                Encoding enc = Utils.GetFileEncoding(filePath);
                string result = CreateFileCopy(fileContent, Path.GetFileName(filePath), dirPath, enc);
                if (copyStatus)
                {
                    // If it was successfully copied, remove the original file.
                    try
                    {
                        File.Delete(filePath);
                    }
                    catch (Exception)
                    {
                        return "(!) File was copied, but the original file is unavailable for removing.";
                    }
                }
                return result;
            }
            catch (IOException)
            {
                return "Cannot access source file.";
            }

        }
    }
}
