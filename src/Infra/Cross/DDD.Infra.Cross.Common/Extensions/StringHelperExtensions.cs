using System.Text.RegularExpressions;

namespace DDD.Infra.Cross.Common.Extensions
{
    public static class StringHelperExtensions
    {
        public static string ApenasNumeros(this string obj)
        {
            if (!string.IsNullOrEmpty(obj))
                return Regex.Replace(obj, "[^0-9,]", "");
            return obj;
        }
    }
}
