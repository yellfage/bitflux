namespace Yellfage.Wst.Communication
{
    public class OutgoingNotifiableInvocationMessage : OutgoingInvocationMessage
    {
        public OutgoingNotifiableInvocationMessage(
            string handlerName,
            object?[] args) : base(
                OutgoingMessageType.NotifiableInvocation,
                handlerName,
                args)
        {
        }
    }
}
