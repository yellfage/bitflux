using System.Net.WebSockets;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Receptions.WebSockets
{
    internal class Reception<TMarker> : IReception<TMarker>
    {
        public string TransportName { get; } = "web-socket";

        private IProtocolProvider<TMarker> ProtocolProvider { get; }
        private ITransportFactory<TMarker> TransportFactory { get; }
        private IAgreementFactory<TMarker> AgreementFactory { get; }

        public Reception(
            IProtocolProvider<TMarker> protocolProvider,
            ITransportFactory<TMarker> transportFactory,
            IAgreementFactory<TMarker> agreementFactory)
        {
            ProtocolProvider = protocolProvider;
            TransportFactory = transportFactory;
            AgreementFactory = agreementFactory;
        }

        public async Task<IAgreement<TMarker>> AcceptAsync(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                throw new ReceptionException(
                    "Unable to accept the request: " +
                    "it is not a WebSocket establishment request");
            }

            IProtocol<TMarker> protocol = ProtocolProvider
                .Select(context.WebSockets.WebSocketRequestedProtocols);

            WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync(protocol.Name);

            ITransport<TMarker> transport = TransportFactory.Create(webSocket);

            return AgreementFactory.Create(transport, protocol);
        }
    }
}
