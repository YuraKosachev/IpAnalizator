using System;
namespace IpLogAnalizator.Core.Exceptions
{
    public class DataNullOrEmptyException : Exception
    {
        public DataNullOrEmptyException(string message) : base(message) { }
    }
}
