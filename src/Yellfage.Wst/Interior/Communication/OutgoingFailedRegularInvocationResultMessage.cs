using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class OutgoingFailedRegularInvocationResultMessage : OutgoingRegularInvocationResultMessage
    {
        public string Error { get; }

        public OutgoingFailedRegularInvocationResultMessage(
            string id,
            string error) : base(
                OutgoingMessageType.FailedRegularInvocationResult,
                id)
        {
            Error = error;
        }
    }
}
