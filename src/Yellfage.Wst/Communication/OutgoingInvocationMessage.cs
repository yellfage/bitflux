namespace Yellfage.Wst.Communication
{
    public abstract class OutgoingInvocationMessage : OutgoingMessage
    {
        public string HandlerName { get; }
        public object?[] Args { get; }

        public OutgoingInvocationMessage(
            OutgoingMessageType type,
            string handlerName,
            object?[] args) : base(type)
        {
            HandlerName = handlerName;
            Args = args;
        }
    }
}
