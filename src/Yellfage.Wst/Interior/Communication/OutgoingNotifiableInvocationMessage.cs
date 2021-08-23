using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
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
