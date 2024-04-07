using IpLogAnalizator.Interfaces;

namespace IpLogAnalizator.Implementation.Logger
{
    public class AppLogger : ILogger
    {
        private static ILogger _logger;

        private AppLogger()
        {
        }

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Information(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static ILogger Instance()
        {
            if (_logger == null)
            {
                _logger = new AppLogger();
            }
            return _logger;
        }
    }
}