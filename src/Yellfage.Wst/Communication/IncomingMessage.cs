namespace Yellfage.Wst.Communication
{
    public class IncomingMessage
    {
        public IncomingMessageType Type { get; set; }

        internal virtual bool IsValid()
        {
            return false;
        }
    }
}
