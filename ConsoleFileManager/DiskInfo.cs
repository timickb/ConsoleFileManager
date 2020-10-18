using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleFileManager
{
    class DiskInfo : IApplication
    {
        public string Name { get; set; }
        public string[] Arguments { get; set; }

        public DiskInfo(string name)
        {
            Name = name;
        }

        public void Interrupt()
        {
            throw new NotImplementedException();
        }

        public string Run(string[] args)
        {
            DriveInfo[] driveInfo = System.IO.DriveInfo.GetDrives();
            List<string> drives = new List<string>();
            foreach(var drive in driveInfo) {
                string block = $"Drive: {drive.Name}, Type: {drive.DriveType}{Environment.NewLine}";
                if(drive.IsReady) {
                    block += $"Volume label: {drive.VolumeLabel}{Environment.NewLine}";
                    block += $"File system: {drive.DriveFormat}{Environment.NewLine}";
                    block += $"Free space: {drive.TotalFreeSpace}{Environment.NewLine}";
                    block += $"Size of drive: {drive.TotalSize}{Environment.NewLine}";
                    block += $"{Environment.NewLine}";
                }
                drives.Add(block);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            return String.Join(Environment.NewLine, drives);
        }
    }
}
