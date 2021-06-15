namespace Yellfage.Wst.Communication
{
    public class IncomingRegularInvocationMessage : IncomingInvocationMessage
    {
        public override bool IsValid()
        {
            return InvocationId is not null && HandlerName is not null && Args is not null;
        }
    }
}
