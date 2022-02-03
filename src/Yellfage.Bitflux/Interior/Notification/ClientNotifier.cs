using System.Threading;
using System.Threading.Tasks;

using Yellfage.Bitflux.Interior.Communication;

namespace Yellfage.Bitflux.Interior.Notification
{
    internal class ClientNotifier<TMarker> : IClientNotifier<TMarker>
    {
        private IMessageTransmitter<TMarker> MessageTransmitter { get; }

        public ClientNotifier(IMessageTransmitter<TMarker> messageTransmitter)
        {
            MessageTransmitter = messageTransmitter;
        }

        public async Task NotifyAsync(
            string handlerName,
            object?[] arguments,
            CancellationToken cancellationToken = default)
        {
            var message = new OutgoingNotifiableInvocationMessage(handlerName, arguments);

            await MessageTransmitter.TransmitAsync(message, cancellationToken);
        }
    }
}
