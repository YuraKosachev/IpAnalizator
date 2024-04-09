using IpLogAnalizator.Core.Models;

namespace IpLogAnalizator.Core.Interfaces
{
    public interface IFileService
    {
        Task<IList<ParseResult>> GetLogFromFileAsync(string path);

        Task SaveDataAsync(string path, string[] lines);
    }
}