namespace ConsoleFileManager
{
    interface IApplication
    {
        // Application name to call it from command line.
        string Name { get; set; }

        string Run(string[] args);

        // Unused in this project, but may be useful in the future.
        void Interrupt();
    }
}
