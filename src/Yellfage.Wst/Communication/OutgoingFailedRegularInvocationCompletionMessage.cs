namespace Yellfage.Wst.Communication
{
    public class OutgoingFailedRegularInvocationCompletionMessage : OutgoingRegularInvocationCompletionMessage
    {
        public string? Error { get; }

        public OutgoingFailedRegularInvocationCompletionMessage(
            string invocationId, string? error) : base(
                OutgoingMessageType.FailedRegularInvocationCompletion, invocationId)
        {
            Error = error;
        }
    }
}
