using System;
using System.Collections.Generic;
using System.Text;

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
        /// Improved version of Path.Combine. It doesn't just append
        /// two strings, it also can handle ".." expression in path.
        /// </summary>
        /// <param name="path">Some absolute path</param>
        /// <param name="ext">Some relative path</param>
        /// <returns></returns>
        public static string CombinePath(string path, string ext)
        {
            path = PrettifyPath(path);
            ext = PrettifyPath(ext);
            string result = path;
            string[] parts = ext.Split('\\');
            foreach(var part in parts)
            {
                if(part == "..")
                {
                    result = RemoveLastPartFromPath(result);
                } else
                {
                    result += ("\\" + part);
                }
            }

            return PrettifyPath(result);
        }
        // It is assumed that the path satisfies the format <DISK_LETTER>:\<dir0>\<dir1>\...\<dirN>
        public static string RemoveLastPartFromPath(string path)
        {
            if(path.EndsWith('\\') || path.EndsWith('/'))
            {
                path = path.Substring(0, path.Length - 1);
            }
            int endIndex = 0;
            // Let's find last "\" symbol in the path
            for(int i = path.Length - 1; i > 0; i--)
            {
                if(path[i] == '\\' || path[i] == '/')
                {
                    endIndex = i;
                    break;
                }
            }
            return path.Substring(0, endIndex + 1);
        }

        // It replaces all "\" to "/", removes "\" from the end
        // ONLY FOR Windows file system.
        public static string PrettifyPath(string path)
        {
            path.Replace('/', '\\');
            if(path[path.Length - 1] == '\\' || path[path.Length - 1] == '/')
            {
                path = path.Substring(0, path.Length - 1);
            }
            return path;
        }

        // This method was copy-pasted from stackoverflow and I don't know why.
        public static bool IsLinux()
        {
            int p = (int)Environment.OSVersion.Platform;
            return (p == 4) || (p == 6) || (p == 128);
        }
        
    }
}
