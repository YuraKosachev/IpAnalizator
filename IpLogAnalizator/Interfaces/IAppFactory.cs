

namespace IpLogAnalizator.Interfaces
{
    public interface IAppFactory
    {
        ILogger CreateAppLogger();
        IFileService CreateFileService();

        ISettingService CreateSettingService();
    }
}
