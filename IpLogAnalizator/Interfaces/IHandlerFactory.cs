using IpLogAnalizator.Implementation.Enums;

namespace IpLogAnalizator.Interfaces
{
    public interface IHandlerFactory
    {
        IHandler CreateHandler(HandlerType type, IAppFactory appFactory);
    }
}
