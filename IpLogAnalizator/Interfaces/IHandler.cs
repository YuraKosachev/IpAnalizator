using IpLogAnalizator.Models;

namespace IpLogAnalizator.Interfaces
{
    public interface IHandler
    {
        Task ExcecuteAsync(HandlerContext context);
        IHandler SetNextHandler(IHandler handler);
    }
}
