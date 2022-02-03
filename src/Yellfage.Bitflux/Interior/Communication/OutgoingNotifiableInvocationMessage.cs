using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal class OutgoingNotifiableInvocationMessage : OutgoingInvocationMessage
    {
        public OutgoingNotifiableInvocationMessage(
            string handlerName,
            object?[] arguments) : base(
                OutgoingMessageType.NotifiableInvocation,
                handlerName,
                arguments)
        {
        }
    }
}
