using Yellfage.Bitflux.Interior.Communication;

namespace Yellfage.Bitflux.Interior.Notification
{
    internal interface IClientNotifierFactory<TMarker>
    {
        IClientNotifier<TMarker> Create(IMessageTransmitter<TMarker> messageTransmitter);
    }
}
