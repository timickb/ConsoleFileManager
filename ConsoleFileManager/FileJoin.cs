using System;
using System.IO;
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
            if(args.Length < 2)
            {
                return "Usage: concat <file1_path> <file2_path> [output_dir_path]" + Environment.NewLine +
                    "If output_dir_path is not specified or incorrect, result of operation will be just" +
                    "printed to the console.";
            }
            string file1 = Utils.HandleFilePath(args[1]);
            string file2 = Utils.HandleFilePath(args[2]);
            string outputDir = String.Empty;
            // If output_dir_path is not specified, the result of this operation will be just printed to the console.
            try
            {
                outputDir = Utils.HandleDirectoryPath(args[3]);
            }
            catch(IndexOutOfRangeException) {}

            if(file1 == String.Empty)
            {
                return "First file doesn't exist.";
            }
            if(file2 == String.Empty)
            {
                return "Second file doesn't exist.";
            }

            string firstFileContent, secondFileContent;
            try
            {
                firstFileContent = String.Join(Environment.NewLine, File.ReadAllLines(file1));
                secondFileContent = String.Join(Environment.NewLine, File.ReadAllLines(file2));
            }
            catch(IOException)
            {
                return "Cannot get access to the one of files.";
            }

            string file1Name = Path.GetFileName(file1);
            string file2Name = Path.GetFileName(file2);

            string newFileContent = firstFileContent + secondFileContent;
            // By default new file name is a concatenation of two previous.
            string newFileName = 
                Path.GetFileNameWithoutExtension(file1Name) + 
                Path.GetFileNameWithoutExtension(file2Name);

            // If arg3 wasn't specified just return the content of file for printing.
            if(outputDir == String.Empty) {
                return newFileContent;
            }

            try
            {
                Console.WriteLine(
                    $"Trying to write file to {Path.Combine(outputDir, newFileName)}"
                );
                StreamWriter sw = new StreamWriter(File.Open(
                    Path.Combine(outputDir, newFileName), FileMode.Create),
                    Encoding.UTF8);
                sw.WriteLine(newFileContent);
                sw.Close();
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
                return "Cannot get access to the target directory.";
            }

            return $"New file is in {Path.Combine(outputDir, newFileName)}";
        }
    }
}
