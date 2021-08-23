using System.Threading;
using System.Threading.Tasks;

namespace Yellfage.Wst
{
    public interface IClientManager<TMarker>
    {
        event ClientAddedEventHandler<TMarker> Added;
        event ClientRemovedEventHandler<TMarker> Removed;

        Task AddAsync(IClient<TMarker> client, CancellationToken cancellationToken = default);
        Task RemoveAsync(IClient<TMarker> client, CancellationToken cancellationToken = default);

        Task NotifyAllAsync(string handlerName, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArgument1>(string handlerName, TArgument1 argument1, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArgument1, TArgument2>(string handlerName, TArgument1 argument1, TArgument2 argument2, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArgument1, TArgument2, TArgument3>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArgument1, TArgument2, TArgument3, TArgument4>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10, CancellationToken cancellationToken = default);
        Task NotifyAllAsync(string handlerName, object?[] arguments, CancellationToken cancellationToken = default);

        Task NotifyAllExceptAsync(IClient<TMarker> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArgument1>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArgument1, TArgument2>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArgument1, TArgument2, TArgument3>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync(IClient<TMarker> excluded, string handlerName, object?[] arguments, CancellationToken cancellationToken = default);
    }
}
