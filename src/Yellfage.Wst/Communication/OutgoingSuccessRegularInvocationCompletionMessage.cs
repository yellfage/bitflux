namespace Yellfage.Wst.Communication
{
    public class OutgoingSuccessRegularInvocationCompletionMessage : OutgoingRegularInvocationCompletionMessage
    {
        public object? Payload { get; }

        public OutgoingSuccessRegularInvocationCompletionMessage(
            string invocationId, object? payload) : base(
                OutgoingMessageType.SuccessRegularInvocationCompletion, invocationId)
        {
            Payload = payload;
        }
    }
}
