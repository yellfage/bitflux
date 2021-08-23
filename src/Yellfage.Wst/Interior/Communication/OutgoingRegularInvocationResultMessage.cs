using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal abstract class OutgoingRegularInvocationResultMessage : OutgoingMessage
    {
        public string InvocationId { get; }

        public OutgoingRegularInvocationResultMessage(
            OutgoingMessageType type,
            string invocationId) : base(type)
        {
            InvocationId = invocationId;
        }
    }
}
