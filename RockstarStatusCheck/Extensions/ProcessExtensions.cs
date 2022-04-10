using System;
using System.Diagnostics;

namespace RockstarStatusCheck.Extensions
{
    public static class ProcessExtensions
    {
        public static bool IsRunning(this string process)
        {
            if (process == null)
            {
                throw new ArgumentNullException(nameof(process));
            }

            try
            {
                Process.GetProcessesByName(process.RemoveFileExtension());
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }
    }
}