using RockstarStatusCheck.Logging;

namespace RockstarStatusCheck.Interfaces
{
    public interface ILogFile
    {
        void CreateLogFileDir();
        void AddEntry(LogEntry entry);
        void CreateLogFile();
        bool CheckFileSize(string file);
    }
}
