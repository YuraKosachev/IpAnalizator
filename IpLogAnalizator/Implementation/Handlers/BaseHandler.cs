using IpLogAnalizator.Interfaces;
using IpLogAnalizator.Models;

namespace IpLogAnalizator.Implementation.Handlers
{
    public abstract class BaseHandler
    {
        protected IHandler? _nextHandler;
        protected readonly IAppFactory _appFactory;
        protected readonly ILogger _logger;

        public BaseHandler(IAppFactory appFactory)
        {
            _appFactory = appFactory ?? throw new ArgumentNullException(nameof(appFactory));
            _logger = appFactory.CreateAppLogger();
        }

        public abstract Task ModuleExecuteAsync(HandlerContext context);

        public async Task ExcecuteAsync(HandlerContext context)
        {
            await StartExecuteAsync();

            await ModuleExecuteAsync(context);

            await EndExecuteAsync();

            if (_nextHandler != null)
                await _nextHandler.ExcecuteAsync(context);
        }

        protected virtual async Task StartExecuteAsync()
        {
            _logger.Information($"handler {this.GetType().Name} start execution");
            await Task.CompletedTask;
        }

        protected virtual async Task EndExecuteAsync()
        {
            _logger.Information($"handler {this.GetType().Name} completed");
            await Task.CompletedTask;
        }

        public IHandler SetNextHandler(IHandler handler)
        {
            _nextHandler = handler;
            return _nextHandler;
        }
    }
}