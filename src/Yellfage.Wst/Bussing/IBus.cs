using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Yellfage.Wst.Bussing
{
    public interface IBus<TMarker>
    {
        Task AddClientAsync(IClient<TMarker> client, CancellationToken cancellationToken = default);
        Task RemoveClientAsync(IClient<TMarker> client, CancellationToken cancellationToken = default);

        Task AddClientToGroupAsync(string groupName, IClient<TMarker> client, CancellationToken cancellationToken = default);
        Task RemoveClientFromGroupAsync(string groupName, IClient<TMarker> client, CancellationToken cancellationToken = default);

        Task NotifyAllAsync(string handlerName, object?[] arguments, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync(IClient<TMarker> excluded, string handlerName, object?[] arguments, CancellationToken cancellationToken = default);

        Task NotifyGroupAsync(string groupName, string handlerName, object?[] arguments, CancellationToken cancellationToken = default);
        Task NotifyGroupExceptAsync(string groupName, IClient<TMarker> excluded, string handlerName, object?[] arguments, CancellationToken cancellationToken = default);

        Task NotifyManyGroupsAsync(IEnumerable<string> groupNames, string handlerName, object?[] arguments, CancellationToken cancellationToken = default);
        Task NotifyManyGroupsExceptAsync(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, object?[] arguments, CancellationToken cancellationToken = default);
    }
}
