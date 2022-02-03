using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal abstract class OutgoingRegularInvocationResultMessage : OutgoingMessage
    {
        public string Id { get; }

        public OutgoingRegularInvocationResultMessage(
            OutgoingMessageType type,
            string id) : base(type)
        {
            Id = id;
        }
    }
}
