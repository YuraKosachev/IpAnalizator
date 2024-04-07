using IpLogAnalizator.Models;


namespace IpLogAnalizator.Interfaces
{
    public interface ISettingService
    {
        Setting? GetAppConfigSetting();

        Setting? GetEnvironmentSetting();

        Setting? GetConsoleArgSetting();
    }
}
