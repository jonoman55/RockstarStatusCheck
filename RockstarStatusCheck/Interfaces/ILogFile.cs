using RockstarStatusCheck.Logging;

namespace RockstarStatusCheck.Interfaces
{
    public interface ILogFile
    {
        public void CreateLogFileDir();
        public void AddEntry(LogEntry entry);
        public void CreateLogFile();
        public bool CheckFileSize(string file);
    }
}
