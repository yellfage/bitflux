namespace Yellfage.Wst.Interior.Communication
{
    internal class IncomingNotifiableInvocationMessage : IncomingInvocationMessage
    {
        internal override bool IsValid()
        {
            return IsInvocationMessageValid();
        }
    }
}
