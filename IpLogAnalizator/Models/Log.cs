using IpLogAnalizator.Implementation.Extensions;
using System.Net;

namespace IpLogAnalizator.Models
{
    public class Log
    {
        public IPAddress Ip { get; set; }
        public DateTime? Date { get; set; }
        public long? IpInt
        {
            get
            {
                return Ip?.ToInt();
            }
        }

    }
}
