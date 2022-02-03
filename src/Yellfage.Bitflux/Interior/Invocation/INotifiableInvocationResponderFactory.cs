namespace Yellfage.Bitflux.Interior.Invocation
{
    internal interface INotifiableInvocationResponderFactory<TMarker>
    {
        INotifiableInvocationResponder<TMarker> Create();
    }
}
