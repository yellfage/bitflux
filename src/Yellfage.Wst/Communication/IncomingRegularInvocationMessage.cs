#pragma warning disable CS8618

namespace Yellfage.Wst.Communication
{
    public class IncomingRegularInvocationMessage : IncomingInvocationMessage
    {
        public string InvocationId { get; set; }

        public override bool IsValid()
        {
            return HandlerName is not null && Args is not null && InvocationId is not null;
        }
    }
}
