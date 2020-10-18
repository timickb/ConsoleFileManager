using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace ConsoleFileManager
{
    /// <summary>
    /// Different useful methods.
    /// </summary>
    static class Utils
    {

        /// <summary>
        /// Path can be relative or absolute; function will detect it
        /// <returns>If path not found: emptry string; else correct path</returns>
        /// <summary>
        public static string HandleFilePath(string path) {
            // UNIX case.
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // Absolute path case.
                if(path.StartsWith('/'))
                {
                    if(File.Exists(path))
                    {
                        return Path.GetFullPath(path);
                    }
                    return String.Empty;
                }
            } 
            else
            // Shindows case.
            {
                // Absolute path case.
                if(path.Contains(':'))
                {
                    if(File.Exists(path))
                    {
                        return Path.GetFullPath(path);
                    }
                    return String.Empty;
                }
            }

            // Relative path case.
            string newPath = Path.Combine(CommandExecutor.CurrentUserPath, path);
            if(File.Exists(newPath))
            {
                return Path.GetFullPath(newPath);
            }
            return String.Empty;
        }

        /// <summary>
        /// Path can be relative or absolute; function will detect it
        /// <returns>If path not found: emptry string; else correct path</returns>
        /// <summary>
        public static string HandleDirectoryPath(string path) {
            // UNIX case.
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // Absolute path case.
                if(path.StartsWith('/'))
                {
                    if(Directory.Exists(path))
                    {
                        return Path.GetFullPath(path);
                    }
                    return String.Empty;
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
                        return Path.GetFullPath(path);
                    }
                    return String.Empty;
                }
            }

            // Relative path case.
            string newPath = Path.Combine(CommandExecutor.CurrentUserPath, path);
            if(Directory.Exists(newPath))
            {
                return Path.GetFullPath(newPath);
            }
            return String.Empty;
        }

        public static Encoding GetEncodingOrReturnNullIfNotFound(string enc) {
            enc = enc.ToLower();
            switch(enc)
            {
                case "utf-8":
                    return Encoding.UTF8;
                case "unicode":
                    return Encoding.Unicode;
                case "utf-32":
                    return Encoding.UTF32;
                case "ascii":
                    return Encoding.ASCII;
                default:
                    return null;
            }
        }
    }
}
