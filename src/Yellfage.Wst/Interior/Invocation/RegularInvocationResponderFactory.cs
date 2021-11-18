using Yellfage.Wst.Interior.Communication;

namespace Yellfage.Wst.Interior.Invocation
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
