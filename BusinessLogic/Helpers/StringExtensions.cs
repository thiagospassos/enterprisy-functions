using System.Text.RegularExpressions;

namespace Application
{
    public static class StringExtensions
    {
        public static string CleanUp(this string input)
        {
            input = Regex.Replace(input, "[^0-9a-zA-Z]+", "");
            return input.Trim().Replace("  ", " ").Normalize().ToLower();
        }
    }
}
