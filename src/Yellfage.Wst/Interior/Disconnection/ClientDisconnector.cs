using System.Threading;
using System.Threading.Tasks;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Disconnection
{
    internal class ClientDisconnector<TMarker> : IClientDisconnector<TMarker>
    {
        private ITransport<TMarker> Transport { get; }

        public ClientDisconnector(ITransport<TMarker> transport)
        {
            Transport = transport;
        }

        public async Task DisconnectAsync(
            string reason,
            CancellationToken cancellationToken = default)
        {
            await Transport.StopAsync(reason, cancellationToken);
        }
    }
}
