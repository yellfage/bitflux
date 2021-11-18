using System;

namespace Yellfage.Wst
{
    public class InvocationException : Exception
    {
        public InvocationException(string message) : base(message)
        {
        }

        public InvocationException(string message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
