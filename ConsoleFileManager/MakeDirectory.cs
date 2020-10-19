using System;
using System.IO;

namespace ConsoleFileManager
{
    class MakeDirectory : IApplication
    {
        public string Name { get; set; }

        public void Interrupt()
        {
            throw new NotImplementedException();
        }

        public MakeDirectory(string name)
        {
            Name = name;
        }

        public string Run(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    return "Usage: mkdir <base_dir_path>";
                }
                string parentPath = Utils.HandleDirectoryPath(args[1]);
                if (parentPath == String.Empty)
                {
                    return "Parent directory doesn't exist.";
                }
                Console.Write("Specify the new directory name: ");
                string dirName = Console.ReadLine();
                try
                {
                    Directory.CreateDirectory(Path.Combine(parentPath, dirName));
                }
                catch (IOException)
                {
                    return "Cannot create directory. Maybe, you used incorrect characters in directory name.";
                }
                catch (UnauthorizedAccessException)
                {
                    return $"Permission denied for creating something in {parentPath}";
                }
                return "Directory successfully created.";
            }
            catch (Exception)
            {
                return "pizdec";
            }
        }
    }
}
