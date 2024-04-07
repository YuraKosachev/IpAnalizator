using IpLogAnalizator.Implementation.Factories;
using IpLogAnalizator.Implementation.Logger;
using IpLogAnalizator.Interfaces;

namespace IpLogAnalizator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IApp application = new App(new AppFactory(), new HandlerFactory());
            application.RunAsync().GetAwaiter().GetResult();
        }
    }
}