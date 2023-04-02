using RockstarStatusCheck.Enums;
using RockstarStatusCheck.Interfaces;
using RockstarStatusCheck.Tools;
using System;
using System.IO;

namespace RockstarStatusCheck.Logging
{
    public class LogFile : ILogFile
    {
        private string fileName;
        private string fileLocation;
        private string fileExt;
        private string folderPath;

        public string FileName 
        { 
            get => fileName; 
            set => fileName = value; 
        }
        public string FileLocation 
        { 
            get => fileLocation; 
            set => fileLocation = value; 
        }
        public string FileExt 
        { 
            get => fileExt; 
            set => fileExt = value; 
        }
        public string FolderPath 
        { 
            get => folderPath; 
            set => folderPath = value; 
        }

        /// <summary>
        /// Creates a new instance of a LogFile.<br />
        /// File params can be specified but are optional.<br />
        /// App EXE name is assumed when not provided.
        /// </summary>
        /// <param name="fileName">Log file name</param>
        /// <param name="filePath">Log file path</param>
        /// <param name="fileExt">Log file extension - example: ".log"</param>                                             
        public LogFile(string fileName = "", string fileExt = "", string filePath = "")
        {
            if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(fileExt) && !string.IsNullOrEmpty(filePath)) // check to see if a file params were specified 
            {
                FileName = fileName;
                FileExt = fileExt;
                FileLocation = Path.Combine(filePath, fileName + fileExt);
                FolderPath = filePath;
            }
            else
            {
                FileExt = LogFileInfo.LogExt;
                FileName = LogFileInfo.LogFileName;
                FileLocation = LogFileInfo.LogFileFullPath;
                FolderPath = LogFileInfo.LogFilePath;
            }
            CreateLogFileDir();
        }

        /// <summary>
        /// Call this method to create the log folder and file.
        /// </summary>
        public void CreateLogFileDir()
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath); // Create log directory if it doesn't exist
                if (!File.Exists(FileLocation))
                {
                    CreateLogFile(); // Create log file if it doesn't exist
                }
            }
        }

        /// <summary>
        /// Call this method to create a log file.
        /// </summary>
        public void CreateLogFile()
        {
            if (!Directory.Exists(FolderPath)) // Create the log file and folder if it doesn't exist  
            {
                CreateLogFileDir();      
            }
            else
            {
                if (!File.Exists(FileLocation)) // Create a new log file if it doesn't exist
                {
                    LogFileTools.TextWriterNew(FileLocation, new LogEntry()
                    {
                        Data = $"{LogFileInfo.LogName}.exe initialized", // remove .log file extension from the file name
                        Level = LogLevel.Info
                    }.ToString());
                }
            }
        }

        /// <summary>
        /// Adds an Log Entry to the log file.
        /// </summary>
        /// <param name="entry"></param>
        public void AddEntry(LogEntry entry)
        {
            if (entry is null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            else
            {
                string msg = entry.ToString();
                string file = FileLocation;
                string path = FolderPath;
                if (!Directory.Exists(path))
                {
                    return;
                }
                if (!File.Exists(file))
                {
                    // Initial Log File Creation
                    LogFileTools.TextWriterNew(file, msg);
                }
                else
                {
                    if (!CheckFileSize(file)) // Check the file size to see if it exceeds 10MB
                    {
                        LogFileTools.TextWriterAppend(file, msg); // Create new log file
                    }
                    else
                    {
                        LogFileTools.TextWriterNew(file, msg); // Append to existing log file
                    }
                }
            }
        }

        /// <summary>
        /// Checks the log file size - 10MB is max.
        /// </summary>
        /// <param name="file">Target file</param>
        /// <returns>Boolean</returns>
        public bool CheckFileSize(string file) => LogFileTools.CheckFileSize(file); // File Size limit = 10MB
    }
}