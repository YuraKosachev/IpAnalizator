using IpLogAnalizator.Core.Constants;
using IpLogAnalizator.Core.Enums;
using IpLogAnalizator.Core.Interfaces;
using IpLogAnalizator.Core.Models;

namespace IpLogAnalizator.Logic.Handlers
{
    public class SaveDataHandler : BaseHandler, IHandler
    {
        private readonly IFileService _fileService;
        private string _path;

        public SaveDataHandler(IFileService fileService, ILogger logger) : base(logger)
        {
            _fileService = fileService;
        }

        public override async Task ModuleExecuteAsync(HandlerContext context)
        {
            if (context.Setting?.FileOutput == null)
                throw new ArgumentNullException($"result log file path is not found");

            _path = context.Setting.FileOutput;

            if (!Path.HasExtension(_path))
            {
                var fileName = $"{DateTime.Now.ToString(FormatConstants.FileNameFormat)}.txt";
                _path = Path.Combine(_path, fileName);
            }

            var list = (string[])context.Data[Key.Result];
            await _fileService.SaveDataAsync(_path, list);
        }

        protected override async Task EndExecuteAsync()
        {
            _logger.Information($"result file succesfully saved. Path - {_path}");
            await Task.CompletedTask;
        }
    }
}