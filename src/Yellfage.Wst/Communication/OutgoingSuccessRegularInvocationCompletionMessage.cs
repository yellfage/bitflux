namespace Yellfage.Wst.Communication
{
    public class OutgoingSuccessRegularInvocationCompletionMessage : OutgoingRegularInvocationCompletionMessage
    {
        public object? Data { get; }

        public OutgoingSuccessRegularInvocationCompletionMessage(
            string invocationId, object? data) :
                base(OutgoingMessageType.SuccessRegularInvocationCompletion, invocationId)
        {
            Data = data;
        }
    }
}
