using Yellfage.Bitflux.Interior.Communication;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal class RegularInvocationResponderFactory<TMarker> : IRegularInvocationResponderFactory<TMarker>
    {
        public IRegularInvocationResponder<TMarker> Create(
            IMessageTransmitter<TMarker> messageTransmitter)
        {
            return new RegularInvocationResponder<TMarker>(messageTransmitter);
        }
    }
}
