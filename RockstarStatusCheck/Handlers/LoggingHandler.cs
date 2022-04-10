using RockstarStatusCheck.Logging;
using RockstarStatusCheck.Tools;

namespace RockstarStatusCheck.Handlers
{
    public class LoggingHandler
    {
        public static void RunDelay(int delay = 2000) => ProcessTools.RunDelay(delay);

        public static void StartLogging()
        {
            LogFileHelper.AddInfoEntry($"Logging to: {LogFileInfo.LogFileName}...", true);
            LogFileHelper.AddInfoEntry("Starting RockStar Services Status Check...", true);
        }

        public static void ExitLogging()
        {
            LogFileHelper.AddInfoEntry($"Exiting {ProcessTools.CurrentProcessName}.exe...", true);
            RunDelay();
        }
    }
}
