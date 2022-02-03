using System;

namespace Yellfage.Bitflux.Communication
{
    public class ReceptionException : Exception
    {
        public ReceptionException()
        {
        }

        public ReceptionException(string message) : base(message)
        {
        }

        public ReceptionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
