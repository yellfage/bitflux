using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
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
