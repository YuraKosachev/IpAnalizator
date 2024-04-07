using System.Globalization;

namespace IpLogAnalizator.Implementation.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime? TryToParse(this string src, string format)
        {
            if (src == null)
                return null;

            var isSuccess = DateTime.TryParseExact(src, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result);

            return isSuccess ? result : null;
        }
    }
}