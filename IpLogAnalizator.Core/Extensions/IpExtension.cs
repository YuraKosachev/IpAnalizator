using System.Net;

namespace IpLogAnalizator.Core.Extensions
{
    public static class IpExtension
    {
        public static long? ToInt(this IPAddress ip)
        {
            byte[] bytes = ip.GetAddressBytes();

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToUInt32(bytes, 0);
        }

        public static IPAddress? TryToParse(this string src)
        {
            if (src == null)
                return null;

            var isSuccess = IPAddress.TryParse(src, out IPAddress ip);

            return isSuccess ? ip : null;
        }
    }
}