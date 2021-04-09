using System.Threading;
using System.Threading.Tasks;

namespace Yellfage.Wst.Internal
{
    internal interface IClientNotifier
    {
        Task NotifyAsync(string handlerName, object?[] args, CancellationToken cancellationToken = default);
    }
}
