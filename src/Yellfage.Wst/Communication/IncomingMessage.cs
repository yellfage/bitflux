using System;

namespace Yellfage.Wst.Communication
{
    public class IncomingMessage
    {
        public IncomingMessageType Type { get; set; }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
