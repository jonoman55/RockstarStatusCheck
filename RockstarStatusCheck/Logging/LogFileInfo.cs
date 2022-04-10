using RockstarStatusCheck.Tools;
using System.IO;

namespace RockstarStatusCheck.Logging
{
    public class LogFileInfo
    {
        // Application Data
        public static readonly string LogName = "GTA5RSC";
        public static readonly string ExeName = $"{LogName}.exe";
        public static readonly string LogExt = ".log";

        // App Log File Data
        /// <summary>
        /// Returns the File Path. 
        /// </summary>
        public static string LogFilePath => Path.Combine(OSTools.DesktopPath, "GTA");

        /// <summary>
        /// Returns the Full Log File Name including the Log File Extension and File Path. 
        /// </summary>
        public static string LogFileFullPath => Path.Combine(LogFilePath, LogFileName);


        /// <summary>
        /// Returns the Log File Name
        /// </summary>
        public static string LogFileName => $"{LogName}{LogExt}";
    }
}