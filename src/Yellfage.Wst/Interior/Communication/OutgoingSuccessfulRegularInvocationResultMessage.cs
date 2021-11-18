using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class OutgoingSuccessfulRegularInvocationResultMessage : OutgoingRegularInvocationResultMessage
    {
        public object? Value { get; }

        public OutgoingSuccessfulRegularInvocationResultMessage(
            string id,
            object? value) : base(
                OutgoingMessageType.SuccessfulRegularInvocationResult,
                id)
        {
            Value = value;
        }
    }
}
