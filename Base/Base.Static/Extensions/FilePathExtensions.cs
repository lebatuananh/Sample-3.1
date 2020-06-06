using System.Text.RegularExpressions;

namespace Base.Static.Extensions
{
    public static class FilePathExtensions
    {
        public static string GetFileExtension(this string fileName)
        {
            try
            {
                var reg = new Regex(@"\.[0-9a-z]+$");
                var match = reg.Match(fileName);
                if (match.Success) return match.Groups[0].Value;
            }
            catch
            {
                return string.Empty;
            }

            return string.Empty;
        }
    }
}