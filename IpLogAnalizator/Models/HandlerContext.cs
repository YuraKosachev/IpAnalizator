using IpLogAnalizator.Implementation.Enums;

namespace IpLogAnalizator.Models
{
    public class HandlerContext
    {
        public Setting? Setting { get; set; }
        public IDictionary<Key, object> Data { get; set; } = new Dictionary<Key, object>();
    }
}
