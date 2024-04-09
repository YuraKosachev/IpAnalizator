namespace IpLogAnalizator.Interfaces
{
    public interface IApp
    {
        Task RunAsync();

        IApp Configure();
    }
}