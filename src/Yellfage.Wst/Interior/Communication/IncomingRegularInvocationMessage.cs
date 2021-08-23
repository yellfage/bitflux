namespace Yellfage.Wst.Interior.Communication
{
    internal class IncomingRegularInvocationMessage : IncomingInvocationMessage
    {
        public string InvocationId { get; set; }

        internal override bool IsValid()
        {
            return IsInvocationMessageValid() && InvocationId is not null;
        }
    }
}
