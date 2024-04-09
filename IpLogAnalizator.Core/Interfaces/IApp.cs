namespace IpLogAnalizator.Core.Interfaces
{
    public interface IApp
    {
        Task RunAsync();

        IApp Configure();
    }
}