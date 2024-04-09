using IpLogAnalizator.Implementation.Enums;
using IpLogAnalizator.Implementation.Factories;
using IpLogAnalizator.Implementation.Handlers;
using IpLogAnalizator.Implementation.Logger;
using IpLogAnalizator.Implementation.Services;
using IpLogAnalizator.Interfaces;
using IpLogAnalizator.Models;
using Microsoft.Extensions.DependencyInjection;

namespace IpLogAnalizator
{
    public class App : IApp
    {
        private readonly IServiceCollection _serviceCollection;

        public App(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public IApp Configure()
        {
            _serviceCollection.AddScoped<IFileService, FileService>();
            _serviceCollection.AddScoped<ISettingService, SettingService>();
            _serviceCollection.AddSingleton<ILogger, AppLogger>();
            _serviceCollection.AddScoped<IHandlerFactory, HandlerFactory>();

            _serviceCollection.AddScoped(typeof(ParseDataHandler));
            _serviceCollection.AddScoped(typeof(SettingHandler));
            _serviceCollection.AddScoped(typeof(SaveDataHandler));
            _serviceCollection.AddScoped(typeof(DataPreparationHandler));

            return this;
        }

        public async Task RunAsync()
        {
            HandlerContext context = new();

            using var service = _serviceCollection.BuildServiceProvider();
            var handlerFactory = service.GetService<IHandlerFactory>();
            var logger = service.GetService<ILogger>();

            var handler = handlerFactory.CreateHandler(HandlerType.Setup);

            handler
                .SetNextHandler(handlerFactory.CreateHandler(HandlerType.ReadData))
                .SetNextHandler(handlerFactory.CreateHandler(HandlerType.DataPreparation))
                .SetNextHandler(handlerFactory.CreateHandler(HandlerType.Save));

            try
            {
                await handler.ExcecuteAsync(context);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}