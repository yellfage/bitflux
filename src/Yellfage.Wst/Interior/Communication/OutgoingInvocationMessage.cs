using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal abstract class OutgoingInvocationMessage : OutgoingMessage
    {
        public string HandlerName { get; }
        public object?[] Arguments { get; }

        public OutgoingInvocationMessage(
            OutgoingMessageType type,
            string handlerName,
            object?[] arguments) : base(type)
        {
            HandlerName = handlerName;
            Arguments = arguments;
        }
    }
}
