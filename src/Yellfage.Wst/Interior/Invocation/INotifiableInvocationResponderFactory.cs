namespace Yellfage.Wst.Interior.Invocation
{
    internal interface INotifiableInvocationResponderFactory<TMarker>
    {
        INotifiableInvocationResponder<TMarker> Create();
    }
}
