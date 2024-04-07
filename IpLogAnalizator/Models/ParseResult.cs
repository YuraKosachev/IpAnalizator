
namespace IpLogAnalizator.Models
{
    public class ParseResult
    {
        public Log? Log { get; set; }
        public string? Source { get; set; }
        public string? Error { get; set; }
        public bool IsError { get; set; }

    }
}
