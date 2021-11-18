using Yellfage.Wst.Interior.Communication;

namespace Yellfage.Wst.Interior.Invocation
{
    internal interface IRegularInvocationResponderFactory<TMarker>
    {
        IRegularInvocationResponder<TMarker> Create(IMessageTransmitter<TMarker> messageTransmitter);
    }
}
