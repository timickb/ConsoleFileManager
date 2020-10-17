using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleFileManager
{
    interface IApplication
    {
        string Name { get; set; }
        string[] Arguments { get; set; }
        string Run(string[] args);
        void Interrupt();
    }
}
