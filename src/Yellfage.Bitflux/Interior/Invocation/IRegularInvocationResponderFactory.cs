using Yellfage.Bitflux.Interior.Communication;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal interface IRegularInvocationResponderFactory<TMarker>
    {
        IRegularInvocationResponder<TMarker> Create(IMessageTransmitter<TMarker> messageTransmitter);
    }
}
