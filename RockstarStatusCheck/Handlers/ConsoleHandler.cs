using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RockstarStatusCheck.Classes;
using RockstarStatusCheck.Enums;
using RockstarStatusCheck.Interfaces;
using RockstarStatusCheck.Logging;

namespace RockstarStatusCheck.Handlers
{
    public class ConsoleHandler
    {
        public static void PrintStatus(IPayload status)
        {
            switch (status.Status)
            {
                case Status.Up:
                    WriteWithColor(status.ToString(), ConsoleColor.Green, LogLevel.Info);
                    break;
                case Status.Down:
                    WriteWithColor(status.ToString(), ConsoleColor.Red, LogLevel.Error);
                    break;
                case Status.Limited:
                    WriteWithColor(status.ToString(), ConsoleColor.Yellow, LogLevel.Warning);
                    break;
                case Status.NA:
                    WriteWithColor(Status.NA.ToString(), ConsoleColor.Cyan, LogLevel.Warning);
                    break;
                default:
                    WriteWithColor(Status.NA.ToString(), ConsoleColor.Cyan, LogLevel.Info);
                    break;
            }
        }

        public static void PrintPlatformStatus(IPlaformPayload status)
        {
            switch (status.PlatformStatus.Status)
            {
                case Status.Up:
                    WriteWithColor(status.ToString(), ConsoleColor.Green, LogLevel.Info);
                    break;
                case Status.Down:
                    WriteWithColor(status.ToString(), ConsoleColor.Red, LogLevel.Error);
                    break;
                case Status.Limited:
                    WriteWithColor(status.ToString(), ConsoleColor.Yellow, LogLevel.Warning);
                    break;
                case Status.NA:
                    WriteWithColor(Status.NA.ToString(), ConsoleColor.Cyan, LogLevel.Warning);
                    break;
                default:
                    WriteWithColor(Status.NA.ToString(), ConsoleColor.Cyan, LogLevel.Info);
                    break;
            }
        }

        /// <summary>
        /// Write to the Console with a specified color
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="color">Console Color</param>
        public static void WriteWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }


        /// <summary>
        /// Write to the Console with a specified color and add a log entry to the log file
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="color">Console Color</param>
        /// <param name="logLevel">Log Level - Default is Info</param>
        public static void WriteWithColor(string message, ConsoleColor color, LogLevel logLevel = LogLevel.Info)
        {
            WriteWithColor(message, color);
            LogFileHelper.AddEntry(message, logLevel);
        }

        public static void PrintAllServices(IEnumerable<ServicesPayload> statuses)
        {
            foreach (ServicesPayload status in statuses)
            {
                PrintStatus(status);
            }
        }

        public static void PrintAllPlaforms(IEnumerable<StatusesPayload> statuses)
        {
            foreach (var plaform in statuses.Select(s => s))
            {
                WriteWithColor(plaform.Name, ConsoleColor.Cyan, LogLevel.Info);
                foreach (Platform ps in plaform.Platforms)
                {
                    PrintPlatformStatus(ps);
                }
            }
        }

        /// <summary>
        /// Start a new Task for Console.ReadLine with specified timeout (TimeSpan).<br />
        /// If no user input is detected after the specified timeout then the Task ends.
        /// </summary>
        /// <param name="timeout">Timeout</param>
        public static string ConsoleReadLineWithTimeout(TimeSpan timeout)
        {
            Task<string> task = Task.Factory.StartNew(Console.ReadLine);
            return Task.WaitAny(new Task[] { task }, timeout) == 0
                ? task.Result
                : "no input";
        }
    }
}