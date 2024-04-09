using IpLogAnalizator.Core.Enums;
using IpLogAnalizator.Core.Interfaces;
using IpLogAnalizator.Core.Models;

namespace IpLogAnalizator.Logic.Handlers
{
    public class ParseDataHandler : BaseHandler, IHandler
    {
        private readonly IFileService _fileService;

        public ParseDataHandler(IFileService fileService, ILogger logger): base(logger)
        {
            _fileService = fileService;
        }

        public override async Task ModuleExecuteAsync(HandlerContext context)
        {
            if (!File.Exists(context.Setting?.FileLog))
                throw new FileNotFoundException($"Log file ({context.Setting?.FileLog})  is not found");

            var result = await _fileService.GetLogFromFileAsync(context.Setting.FileLog);

            context.Data[Key.Parse] = result.Where(result => !result.IsError).Select(result => result.Log).ToList();

            var errors = result.Where(result => result.IsError).ToList();

            foreach (var line in errors)
            {
                _logger.Error($"parse error - line:{line.Source} message:{line.Error}");
            }
        }
    }
}