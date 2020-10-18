using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace ConsoleFileManager
{
    /// <summary>
    /// Different useful methods. All methods suppose
    /// that input data is correct; they don't handle
    /// any incorrect cases and don't throw any exceptions.
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
        // It is assumed that the path satisfies the format <DISK_LETTER>:\<dir0>\<dir1>\...\<dirN>
        public static string RemoveLastPartFromPath(string path)
        {
            if(path.EndsWith(Path.PathSeparator))
            {
                path = path.Substring(0, path.Length - 1);
            }
            int endIndex = 0;
            // Let's find last "\" symbol in the path
            for(int i = path.Length - 1; i > 0; i--)
            {
                if(path[i] == Path.PathSeparator)
                {
                    endIndex = i;
                    break;
                }
            }
            return path.Substring(0, endIndex + 1);
        }
    }
}
