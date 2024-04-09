using IpLogAnalizator.Implementation.Enums;
using IpLogAnalizator.Implementation.Handlers;
using IpLogAnalizator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IpLogAnalizator.Implementation.Factories
{
    public class HandlerFactory : IHandlerFactory
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public HandlerFactory(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public IHandler CreateHandler(HandlerType type)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var setting = scope.ServiceProvider.GetService<SettingHandler>();
            switch (type)
            {
                case HandlerType.ReadData: return scope.ServiceProvider.GetService<ParseDataHandler>();
                case HandlerType.Setup: return scope.ServiceProvider.GetService<SettingHandler>();
                case HandlerType.DataPreparation: return scope.ServiceProvider.GetService<DataPreparationHandler>();
                case HandlerType.Save: return scope.ServiceProvider.GetService<SaveDataHandler>();
                default:
                    throw new ArgumentException("Such type of handler didn't implement");
            }
        }
    }
}
