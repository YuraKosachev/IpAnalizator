﻿using IpLogAnalizator.Core.Interfaces;
using IpLogAnalizator.Core.Models;

namespace IpLogAnalizator.Logic.Handlers
{
    public class SettingHandler : BaseHandler, IHandler
    {
        private readonly ISettingService _settingService;

        public SettingHandler(ISettingService settingService, ILogger logger) : base(logger)
        {
            _settingService = settingService;
        }

        public override async Task ModuleExecuteAsync(HandlerContext context)
        {
            var consoleArgsSetting = _settingService.GetConsoleArgSetting();
            var enviromentSetting = _settingService.GetEnvironmentSetting();
            var appSetting = _settingService.GetAppConfigSetting();

            context.Setting = new();
            context.Setting.FileOutput = consoleArgsSetting?.FileOutput ?? enviromentSetting?.FileOutput ?? appSetting?.FileOutput;
            context.Setting.FileLog = consoleArgsSetting?.FileLog ?? enviromentSetting?.FileLog ?? appSetting?.FileLog;
            context.Setting.AddressMaskFormat = consoleArgsSetting?.AddressMaskFormat ?? enviromentSetting?.AddressMaskFormat ?? appSetting?.AddressMaskFormat;
            context.Setting.AddressStartFormat = consoleArgsSetting?.AddressStartFormat ?? enviromentSetting?.AddressStartFormat ?? appSetting?.AddressStartFormat;
            context.Setting.StartDateFormat = consoleArgsSetting?.StartDateFormat ?? enviromentSetting?.StartDateFormat ?? appSetting?.StartDateFormat;
            context.Setting.EndDateFormat = consoleArgsSetting?.EndDateFormat ?? enviromentSetting?.EndDateFormat ?? appSetting?.EndDateFormat;

            ArgumentNullException.ThrowIfNull(context.Setting.FileOutput, nameof(context.Setting.FileOutput));
            ArgumentNullException.ThrowIfNull(context.Setting.FileLog, nameof(context.Setting.FileLog));

            await Task.CompletedTask;
        }
    }
}