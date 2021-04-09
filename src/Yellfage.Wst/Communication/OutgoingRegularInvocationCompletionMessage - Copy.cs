namespace Yellfage.Wst.Communication
{
    public abstract class OutgoingRegularInvocationCompletionMessage : OutgoingMessage
    {
        public string InvocationId { get; }

        public OutgoingRegularInvocationCompletionMessage(
            OutgoingMessageType type, string invocationId) : base(type)
        {
            InvocationId = invocationId;
        }
    }
}
