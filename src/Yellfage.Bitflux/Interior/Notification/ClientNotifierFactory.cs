using Yellfage.Bitflux.Interior.Communication;

namespace Yellfage.Bitflux.Interior.Notification
{
    internal class ClientNotifierFactory<TMarker> : IClientNotifierFactory<TMarker>
    {
        public IClientNotifier<TMarker> Create(IMessageTransmitter<TMarker> messageTransmitter)
        {
            return new ClientNotifier<TMarker>(messageTransmitter);
        }
    }
}
