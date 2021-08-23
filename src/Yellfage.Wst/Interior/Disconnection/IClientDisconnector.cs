using System.Threading;
using System.Threading.Tasks;

namespace Yellfage.Wst.Interior.Disconnection
{
    internal interface IClientDisconnector
    {
        Task DisconnectAsync(string reason, CancellationToken cancellationToken = default);
    }
}
