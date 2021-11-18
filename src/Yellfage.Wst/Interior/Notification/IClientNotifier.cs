using System.Threading;
using System.Threading.Tasks;

namespace Yellfage.Wst.Interior.Notification
{
    internal interface IClientNotifier<TMarker>
    {
        Task NotifyAsync(string handlerName, object?[] arguments, CancellationToken cancellationToken = default);
    }
}
