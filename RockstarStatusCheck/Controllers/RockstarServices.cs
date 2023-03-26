using RockstarStatusCheck.Enums;
using RockstarStatusCheck.Handlers;
using System;
using System.Linq;

namespace RockstarStatusCheck.Controllers
{
    public class RockstarServices
    {
        public static void RunChecks()
        {
            // Start logging
            LoggingHandler.StartLogging();

            // Fetch and Print Services and Statuses
            ServicesCheck();

            // Fetch and Print Platform Statuses
            PlatformsCheck();

            // Exit on user input or 5 second timeout
            LoggingHandler.ExitLogging();
        }

        private static void ServicesCheck()
        {
            Console.WriteLine();
            foreach (var (check, statuses) in EnumHandler.ForEachAll())
            {
                ConsoleHandler.WriteWithColor(check.ToString(), ConsoleColor.Magenta, LogLevel.Info);
                ConsoleHandler.PrintAllServices(statuses);
                if (statuses.All(s => s.Status is Status.Up))
                {
                    ConsoleHandler.WriteWithColor($"All Rockstar {check} Operational", ConsoleColor.Green, LogLevel.Info);
                }
                else
                {
                    ConsoleHandler.WriteWithColor($"Rockstar {check} Outage Detected", ConsoleColor.Red, LogLevel.Error);
                }
                Console.WriteLine();
            }
        }

        private static void PlatformsCheck()
        {
            foreach (var (check, statuses) in EnumHandler.ForEachPlatform())
            {
                ConsoleHandler.WriteWithColor(check.ToString(), ConsoleColor.Magenta, LogLevel.Info);
                ConsoleHandler.PrintAllPlaforms(statuses);
                Console.WriteLine();
            }
        }
    }
}
