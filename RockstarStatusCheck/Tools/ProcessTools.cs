using RockstarStatusCheck.Extensions;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace RockstarStatusCheck.Tools
{
    public class ProcessTools
    {
        public static void RunDelay(int milliseconds) => Thread.Sleep(milliseconds);

        public static int GetProcessId(string procName)
        {
            foreach (Process process in from Process process in Process.GetProcesses()
                                        where process.ProcessName == procName
                                        select process)
            {
                return process.Id;
            }
            return 0;
        }

        public static bool CheckForProcessByName(string procName)
        {
            foreach (Process p in Process.GetProcessesByName(procName.RemoveFileExtension()))
            {
                if (!procName.Contains(p.ProcessName))
                {
                    continue;
                }
                return true;
            }
            return false;
        }

        public static string CurrentProcessName => Process.GetCurrentProcess().ProcessName;

        public static bool CheckForCurrentProcess() => Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1;
    }
}