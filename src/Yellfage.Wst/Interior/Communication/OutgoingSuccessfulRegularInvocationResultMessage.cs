using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class OutgoingSuccessfulRegularInvocationResultMessage : OutgoingRegularInvocationResultMessage
    {
        public object? Value { get; }

        public OutgoingSuccessfulRegularInvocationResultMessage(
            string invocationId,
            object? value) : base(
                OutgoingMessageType.SuccessfulRegularInvocationResult,
                invocationId)
        {
            Value = value;
        }
    }
}
