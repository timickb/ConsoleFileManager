using System;
using System.Reflection;

namespace ConsoleFileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"CFM version {Assembly.GetExecutingAssembly().GetName().Version.ToString()}\n");
            Console.WriteLine("Type \"help\" for getting information, type \"exit\" for exit.\n");
            CommandExecutor executor = new CommandExecutor();
            string userInput;
            do
            {
                Console.Write("> ");
                userInput = Console.ReadLine();
                Console.WriteLine(executor.Execute(userInput));
            } while (userInput != CommandExecutor.EXIT_COMMAND);
            
        }
    }
}
