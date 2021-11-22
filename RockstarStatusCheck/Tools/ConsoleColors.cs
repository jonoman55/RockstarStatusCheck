using RockstarStatusCheck.Classes;
using System;

namespace RockstarStatusCheck.Tools
{
    public class ConsoleColors
    {
        public static void WriteWithColor(ServiceStatus status)
        {
            switch (status.Status)
            {
                case Status.Up:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(status.ToString());
                    Console.ResetColor();
                    break;
                case Status.Down:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(status.ToString());
                    Console.ResetColor();
                    break;
                case Status.Limited:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(status.ToString());
                    Console.ResetColor();
                    break;
            }
        }

        public static void WriteWithColor(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        // TODO : test this next time the services are down in the WriteWithColor(ServiceStatus status) function
        public static void WriteWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}