using System;

namespace ConsoleFileManager
{
    class CurrentPath : IApplication
    {
        public string Name { get; set; }

        public CurrentPath(string name)
        {
            Name = name;
        }

        public void Interrupt()
        {
            throw new NotImplementedException();
        }

        public string Run(string[] args)
        {
            return $"You're at {CommandExecutor.CurrentUserPath}";
        }
    }
}
