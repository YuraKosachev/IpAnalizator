namespace IpLogAnalizator.Core.Interfaces
{
    public interface ILogger
    {
        void Information(string message);

        void Error(string message);
    }
}