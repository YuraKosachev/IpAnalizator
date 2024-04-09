using IpLogAnalizator.Core.Enums;

namespace IpLogAnalizator.Core.Interfaces
{
    public interface IHandlerFactory
    {
        IHandler CreateHandler(HandlerType type);
    }
}