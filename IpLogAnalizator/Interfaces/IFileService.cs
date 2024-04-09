using IpLogAnalizator.Models;

namespace IpLogAnalizator.Interfaces
{
    public interface IFileService
    {
        Task<IList<ParseResult>> GetLogFromFileAsync(string path);

        Task SaveDataAsync(string path, string[] lines);
    }
}