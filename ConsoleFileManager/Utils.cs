using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleFileManager
{
    /// <summary>
    /// Different useful methods. All methods suppose
    /// that input data is correct; they don't handle
    /// any incorrect cases and don't throw any exceptions.
    /// </summary>
    static class Utils
    {
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
