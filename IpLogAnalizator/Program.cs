using IpLogAnalizator.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IpLogAnalizator
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            try
            {
                IApp application = new App(new ServiceCollection());
                await application.Configure().RunAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}