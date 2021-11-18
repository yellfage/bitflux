using System.Threading;
using System.Threading.Tasks;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class MessageTransmitter<TMarker> : IMessageTransmitter<TMarker>
    {
        private ITransport<TMarker> Transport { get; }
        private IProtocol<TMarker> Protocol { get; }

        public MessageTransmitter(ITransport<TMarker> transport, IProtocol<TMarker> protocol)
        {
            Transport = transport;
            Protocol = protocol;
        }

        public async Task TransmitAsync(
            OutgoingMessage message,
            CancellationToken cancellationToken = default)
        {
            await Transport.SendAsync(
                Protocol.Serialize(message),
                Protocol.TransferFormat,
                cancellationToken);
        }
    }
}
