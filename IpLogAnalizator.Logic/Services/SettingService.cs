using CommandLine;
using System.Text.Json;
using IpLogAnalizator.Core.Interfaces;
using IpLogAnalizator.Core.Constants;
using IpLogAnalizator.Core.Models;

namespace IpLogAnalizator.Logic.Services
{
    public class SettingService : ISettingService
    {
        private readonly ILogger _logger;
        public SettingService(ILogger logger)
        {
            _logger = logger;
        }
        public Setting? GetAppConfigSetting()
        {
            var file = Path.Combine(Environment.CurrentDirectory, AppConstants.AppConfigFile);
            if (!File.Exists(file))
                return null;

            using FileStream stream = File.OpenRead(file);
            try
            {
                return JsonSerializer.Deserialize<Setting>(stream);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public Setting? GetConsoleArgSetting()
        {
            var args = Environment.GetCommandLineArgs();

            var parser = new Parser(option => option.IgnoreUnknownArguments = true);
            var result = parser.ParseArguments<Setting>(args);

            return result?.Value;
        }

        public Setting GetEnvironmentSetting()
        {
            var fileLog = Environment.GetEnvironmentVariable("file-log");
            var fileOutput = Environment.GetEnvironmentVariable("file-output");
            var addressStart = Environment.GetEnvironmentVariable("address-start");

            var addressMaskFormat = Environment.GetEnvironmentVariable("address-mask");
            var timeStart = Environment.GetEnvironmentVariable("time-start");
            var timeEnd = Environment.GetEnvironmentVariable("time-end");

            return new Setting
            {
                FileLog = fileLog,
                AddressStartFormat = addressStart,
                AddressMaskFormat = addressMaskFormat,
                FileOutput = fileOutput,
                StartDateFormat = timeStart,
                EndDateFormat = timeEnd
            };
        }
    }
}
