using IpLogAnalizator.Implementation.Logger;
using IpLogAnalizator.Implementation.Services;
using IpLogAnalizator.Interfaces;


namespace IpLogAnalizator.Implementation.Factories
{
    public class AppFactory : IAppFactory
    {
        public ILogger CreateAppLogger() => AppLogger.Instance();

        public IFileService CreateFileService() => new FileService();

        public ISettingService CreateSettingService() => new SettingService(AppLogger.Instance());
    }
}
