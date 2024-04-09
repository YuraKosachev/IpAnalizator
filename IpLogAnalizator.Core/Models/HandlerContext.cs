using IpLogAnalizator.Core.Enums;

namespace IpLogAnalizator.Core.Models
{
    public class HandlerContext
    {
        public Setting? Setting { get; set; }
        public IDictionary<Key, object> Data { get; set; } = new Dictionary<Key, object>();
    }
}