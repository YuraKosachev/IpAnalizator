using IpLogAnalizator.Implementation.Enums;
using IpLogAnalizator.Implementation.Handlers;
using IpLogAnalizator.Interfaces;

namespace IpLogAnalizator.Implementation.Factories
{
    public class HandlerFactory : IHandlerFactory
    {
        public IHandler CreateHandler(HandlerType type, IAppFactory appFactory)
        {
            switch (type)
            {
                case HandlerType.ReadData: return new ParseDataHandler(appFactory);
                case HandlerType.Setup: return new SettingHandler(appFactory);
                case HandlerType.DataPreparation: return new DataPreparationHandler(appFactory);
                case HandlerType.Save: return new SaveDataHandler(appFactory);
                default:
                    throw new ArgumentException("Such type of handler didn't implement");
            }
        }
    }
}
