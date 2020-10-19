using System.Collections.Generic;
using System.IO;

namespace ConsoleFileManager
{
    class CommandExecutor
    {
        public const string EXIT_COMMAND = "exit";
        public static string CurrentUserPath = Directory.GetCurrentDirectory();

        private List<IApplication> apps;

        public CommandExecutor()
        {
            apps = new List<IApplication>();

            // Initialize all available applications.
            apps.Add(new Help("help"));
            apps.Add(new CurrentPath("location"));
            apps.Add(new FileContentViewer("cat"));
            apps.Add(new ListDirectory("ls"));
            apps.Add(new ChangeDirectory("cd"));
            apps.Add(new DiskInfo("lsblk"));
            apps.Add(new FileCopy("cp"));
            apps.Add(new FileJoin("concat"));
            apps.Add(new FileCreate("create"));
            apps.Add(new FileMove("mv"));
            apps.Add(new FileRemove("rm"));
            apps.Add(new MakeDirectory("mkdir"));
        }
        public string Execute(string input)
        {
            string[] args = input.Split(' ');
            string appName = args[0];

            // Find an application with this name in the list and run it.
            foreach (var app in apps)
            {
                if (app.Name == appName)
                {
                    return app.Run(args);
                }
            }
            if (args[0] == EXIT_COMMAND)
            {
                return "Bye!\n";
            }
            return "Unknown command. Type \"help\" to get a list of available commands.";
        }
    }
}
