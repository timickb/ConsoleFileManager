using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleFileManager
{
    class ChangeDirectory : IApplication
    {
        public string Name { get; set; }
        public string[] Arguments { get; set; }

        public ChangeDirectory(string name)
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
                return "Usage: cd <path>";
            }
            string path = args[1];
            // Is it absolute or relative?

            // UNIX case.
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // Absolute path case.
                if(path.StartsWith('/'))
                {
                    if(Directory.Exists(path))
                    {
                        CommandExecutor.CurrentUserPath = Path.GetFullPath(path);
                        return $"Successfully moved to {CommandExecutor.CurrentUserPath}";
                    } else
                    {
                        return "This path doesn't exist.";
                    }
                    
                }
            } 
            else
            // Shindows case.
            {
                // Absolute path case.
                if(path.Contains(':'))
                {
                    if(Directory.Exists(path))
                    {
                        CommandExecutor.CurrentUserPath = Path.GetFullPath(path);
                        return $"Successfully moved to {CommandExecutor.CurrentUserPath}";
                    } else
                    {
                        return "This path doesn't exist.";
                    }
                }
            }

            // Relative path case.
            string newPath = Path.Combine(CommandExecutor.CurrentUserPath, path);
            if(Directory.Exists(newPath))
            {
                CommandExecutor.CurrentUserPath = Path.GetFullPath(newPath);
                return $"Successfully moved to {CommandExecutor.CurrentUserPath}";
            }
            return "This path doesn't exist.";
           
        }
    }
}
