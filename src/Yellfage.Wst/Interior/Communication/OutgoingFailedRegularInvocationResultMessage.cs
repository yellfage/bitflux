using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class OutgoingFailedRegularInvocationResultMessage : OutgoingRegularInvocationResultMessage
    {
        public string Error { get; }

        public OutgoingFailedRegularInvocationResultMessage(
            string invocationId,
            string error) : base(
                OutgoingMessageType.FailedRegularInvocationResult,
                invocationId)
        {
            Error = error;
        }
    }
}
