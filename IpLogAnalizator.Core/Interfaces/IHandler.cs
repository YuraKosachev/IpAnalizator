using IpLogAnalizator.Core.Models;

namespace IpLogAnalizator.Core.Interfaces
{
    public interface IHandler
    {
        Task ExcecuteAsync(HandlerContext context);

        IHandler SetNextHandler(IHandler handler);
    }
}