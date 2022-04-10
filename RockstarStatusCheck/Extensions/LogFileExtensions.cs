using System.IO;

namespace RockstarStatusCheck.Extensions
{
    public static class LogFileExtensions
    {
        public static string RemoveValue(this string input, string value)
        {
            if (input.ToLower().Contains(value))
            {
                input = input.Replace(value, string.Empty); // replace specified value with an empty string
            }
            return input;
        }

        public static string RemoveFileExtension(this string exeName) => Path.GetFileNameWithoutExtension(exeName);
    }
}