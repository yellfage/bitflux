using System.Threading;
using System.Threading.Tasks;

namespace Yellfage.Wst.Internal
{
    internal interface IClientDisconnector
    {
        Task DisconnectAsync(string reason, CancellationToken cancellationToken = default);
    }
}
