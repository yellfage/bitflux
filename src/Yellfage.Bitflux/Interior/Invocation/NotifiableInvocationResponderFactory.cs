namespace Yellfage.Bitflux.Interior.Invocation
{
    internal class NotifiableInvocationResponderFactory<TMarker> : INotifiableInvocationResponderFactory<TMarker>
    {
        public INotifiableInvocationResponder<TMarker> Create()
        {
            return new NotifiableInvocationResponder<TMarker>();
        }
    }
}
