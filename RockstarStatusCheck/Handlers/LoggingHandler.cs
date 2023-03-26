using RockstarStatusCheck.Logging;
using RockstarStatusCheck.Tools;
using System;

namespace RockstarStatusCheck.Handlers
{
    public class LoggingHandler
    {
        public static void StartLogging()
        {
            LogFileHelper.AddInfoEntry($"Logging to: {LogFileInfo.LogFileName}...", true);
            LogFileHelper.AddInfoEntry("Starting RockStar Services Status Check...", true);
        }

        public static void ExitLogging(int timout = 5)
        {
            Console.WriteLine("Press the Enter key to exit...");
            string result = ConsoleHandler.ConsoleReadLineWithTimeout(TimeSpan.FromSeconds(timout));
            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine("\nNo user input detected - Now exiting...\n");
            }
            LogFileHelper.AddInfoEntry($"Exiting {ProcessTools.CurrentProcessName}.exe...", true);
            ProcessTools.RunDelay(2000);
        }
    }
}
