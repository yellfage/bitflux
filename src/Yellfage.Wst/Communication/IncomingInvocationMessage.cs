#pragma warning disable CS8618
namespace Yellfage.Wst.Communication
{
    public abstract class IncomingInvocationMessage : IncomingMessage
    {
        public string HandlerName { get; set; }
        public object?[] Args { get; set; }
    }
}
