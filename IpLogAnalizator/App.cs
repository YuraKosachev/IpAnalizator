using IpLogAnalizator.Implementation.Enums;
using IpLogAnalizator.Interfaces;
using IpLogAnalizator.Models;

namespace IpLogAnalizator
{
    public class App : IApp
    {
        private readonly IAppFactory _appFactory;
        private readonly IHandlerFactory _handlerFactory;
        public App(IAppFactory appFactory, IHandlerFactory handlerFactory)
        {
            _appFactory = appFactory ?? throw new ArgumentNullException(nameof(appFactory));
            _handlerFactory = handlerFactory ?? throw new ArgumentNullException(nameof(handlerFactory));
        }
        public async Task RunAsync()
        {
            HandlerContext context = new();
            var logger = _appFactory.CreateAppLogger();

            var handler = _handlerFactory.CreateHandler(HandlerType.Setup, _appFactory);

            handler
                .SetNextHandler(_handlerFactory.CreateHandler(HandlerType.ReadData, _appFactory))
                .SetNextHandler(_handlerFactory.CreateHandler(HandlerType.DataPreparation, _appFactory))
                .SetNextHandler(_handlerFactory.CreateHandler(HandlerType.Save, _appFactory));

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
