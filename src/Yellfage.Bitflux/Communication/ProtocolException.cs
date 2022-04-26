using System;

namespace Yellfage.Bitflux.Communication
{
    public class ProtocolException : Exception
    {
        public ProtocolException(string? message) : base(message)
        {
        }

        public ProtocolException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
