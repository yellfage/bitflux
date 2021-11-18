using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
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
