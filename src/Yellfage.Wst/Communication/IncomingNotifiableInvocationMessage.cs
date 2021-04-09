namespace Yellfage.Wst.Communication
{
    public class IncomingNotifiableInvocationMessage : IncomingInvocationMessage
    {
        public override bool IsValid()
        {
            return HandlerName is not null && Args is not null;
        }
    }
}
