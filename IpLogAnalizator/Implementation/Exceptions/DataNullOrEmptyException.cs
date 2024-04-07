using System;
namespace IpLogAnalizator.Implementation.Exceptions
{
    public class DataNullOrEmptyException : Exception
    {
        public DataNullOrEmptyException(string message) : base(message) { }
    }
}
