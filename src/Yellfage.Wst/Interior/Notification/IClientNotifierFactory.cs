using Yellfage.Wst.Interior.Communication;

namespace Yellfage.Wst.Interior.Notification
{
    internal interface IClientNotifierFactory<TMarker>
    {
        IClientNotifier<TMarker> Create(IMessageTransmitter<TMarker> messageTransmitter);
    }
}
