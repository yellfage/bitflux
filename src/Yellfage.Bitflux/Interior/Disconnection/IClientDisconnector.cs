using System.Threading;
using System.Threading.Tasks;

namespace Yellfage.Bitflux.Interior.Disconnection
{
    internal interface IClientDisconnector<TMarker>
    {
        Task DisconnectAsync(string reason, CancellationToken cancellationToken = default);
    }
}
