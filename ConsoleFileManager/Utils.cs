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
        public static string HandleFilePath(string path)
        {
            // UNIX case.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // Absolute path case.
                if (path.StartsWith('/'))
                {
                    if (File.Exists(path))
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
                if (path.Contains(':'))
                {
                    if (File.Exists(path))
                    {
                        return Path.GetFullPath(path);
                    }
                    return String.Empty;
                }
            }

            // Relative path case.
            string newPath = Path.Combine(CommandExecutor.CurrentUserPath, path);
            if (File.Exists(newPath))
            {
                return Path.GetFullPath(newPath);
            }
            return String.Empty;
        }

        /// <summary>
        /// Path can be relative or absolute; function will detect it
        /// <returns>If path not found: emptry string; else correct path</returns>
        /// <summary>
        public static string HandleDirectoryPath(string path)
        {
            // UNIX case.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // Absolute path case.
                if (path.StartsWith('/'))
                {
                    if (Directory.Exists(path))
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
                if (path.Contains(':'))
                {
                    if (Directory.Exists(path))
                    {
                        return Path.GetFullPath(path);
                    }
                    return String.Empty;
                }
            }

            // Relative path case.
            string newPath = Path.Combine(CommandExecutor.CurrentUserPath, path);
            if (Directory.Exists(newPath))
            {
                return Path.GetFullPath(newPath);
            }
            return String.Empty;
        }

        /// <summary>
        /// Get an Encoding object by a string from user
        /// </summary>
        /// <param name="enc">Some string from set "utf-8", "unicode", "utf-32", "ascii"</param>
        /// <returns>Encoding object</returns>
        public static Encoding GetEncodingOrReturnNullIfNotFound(string enc)
        {
            enc = enc.ToLower();
            switch (enc)
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


        // This method was totally copy-pasted from stackoverflow :)
        /// <summary>
        /// Determines a text file's encoding by analyzing its byte order mark (BOM).
        /// Defaults to ASCII when detection of the text file's endianness fails.
        /// </summary>
        /// <param name="filename">The text file to analyze.</param>
        /// <returns>The detected encoding.</returns>
        public static Encoding GetFileEncoding(string filename)
        {
            // This method was totally copy-pasted from stackoverflow :)
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe && bom[2] == 0 && bom[3] == 0) return Encoding.UTF32; //UTF-32LE
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return new UTF32Encoding(true, true);  //UTF-32BE

            // We actually have no idea what the encoding is if we reach this point, so
            // you may wish to return null instead of defaulting to ASCII
            return Encoding.ASCII;
        }
    }
}
