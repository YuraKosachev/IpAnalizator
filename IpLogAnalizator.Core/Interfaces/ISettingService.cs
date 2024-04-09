using IpLogAnalizator.Core.Models;

namespace IpLogAnalizator.Core.Interfaces
{
    public interface ISettingService
    {
        Setting? GetAppConfigSetting();

        Setting? GetEnvironmentSetting();

        Setting? GetConsoleArgSetting();
    }
}