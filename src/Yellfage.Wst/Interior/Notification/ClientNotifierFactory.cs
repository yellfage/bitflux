using Yellfage.Wst.Interior.Communication;

namespace Yellfage.Wst.Interior.Notification
{
    internal class ClientNotifierFactory<TMarker> : IClientNotifierFactory<TMarker>
    {
        public IClientNotifier<TMarker> Create(IMessageTransmitter<TMarker> messageTransmitter)
        {
            return new ClientNotifier<TMarker>(messageTransmitter);
        }
    }
}
