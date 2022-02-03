namespace Yellfage.Bitflux.Communication
{
    public abstract class OutgoingMessage
    {
        public OutgoingMessageType Type { get; }

        public OutgoingMessage(OutgoingMessageType type)
        {
            Type = type;
        }
    }
}
