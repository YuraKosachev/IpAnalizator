using IpLogAnalizator.Core.Extensions;
using System.Net;

namespace IpLogAnalizator.Core.Models
{
    public class Log
    {
        public IPAddress Ip { get; set; }
        public DateTime? Date { get; set; }
        public long? IpInt => Ip?.ToInt();
    }
}