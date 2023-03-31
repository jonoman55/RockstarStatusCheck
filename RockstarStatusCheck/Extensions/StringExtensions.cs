using System.Text.RegularExpressions;

namespace RockstarStatusCheck.Extensions
{
    public static class StringExtensions
    {
        public static string StripHTML(this string input) =>
            Regex.IsMatch(input, "<(.|\n)*?>")
                ? Regex.Replace(input, "<(.|\n)*?>", string.Empty)
                : input;
    }
}
