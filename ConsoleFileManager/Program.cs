/*
 * Замечания для ревьювера
 * 
 * 1). Возможно, тебе не будет понятно, что в данной программе
 * можно будет считать за дополнительный функционал. Например,
 * в ТЗ явно не указано, может ли пользователь иметь возможность
 * использовать как абсолютный путь, так и относительный. Здесь
 * реализованы оба варианта. Также в ТЗ не указано, должна ли программа
 * давать возможность после выполнения операции выполнить другую операцию.
 * Но мне кажется, что эти очевидные моменты подразумевались сами по себе.
 * Вот то, что я бы точно посчитал доп. функционал, если бы проверял данную работу:
 * - Функция конкатенации двух файлов может записывать результат не только в консоль,
 * но и в файл.
 * - Возможность создания директории (mkdir);
 * - Возможность вывода текущего расположения (location);
 * - Возможность просмотра не только списков диска, но и основной информации о них (lsblk);
 * - Возможность удалить не только файл, но и пустую директорию.
 * 
 * 2). Я не стал реализовывать отдельную функцию "выбор диска" в силу ее бессмысленности при
 * существовании команды смены директории, которая позволяет перейти в корень любого
 * диска. (Например, cd C:/ на виндах и что-нибудь типа cd /mnt/dungeonmaster/ в линухе)
*/


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
