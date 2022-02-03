using System;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal class ArgumentBindingException : Exception
    {
        public ArgumentBindingException(string message) : base(message)
        {
        }

        public ArgumentBindingException(string message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
