using System;
using System.Reflection;

namespace ConsoleFileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Title.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"CFM version {Assembly.GetExecutingAssembly().GetName().Version.ToString()}\n");

            // Instruction.
            Console.WriteLine((new Help(null)).Run(null));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Type \"help\" to print this list again; type \"exit\" for exit.\n");
            CommandExecutor executor = new CommandExecutor();

            // Main loop.
            string userInput;
            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("> ");
                userInput = Console.ReadLine();
                Console.WriteLine(executor.Execute(userInput));
            }
            while (userInput != CommandExecutor.EXIT_COMMAND);
            
        }
    }
}
