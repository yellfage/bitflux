using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Yellfage.Wst
{
    public interface IGroupManager<TMarker>
    {
        Task AddAsync(string groupName, IClient<TMarker> client, CancellationToken cancellationToken = default);
        Task AddManyAsync(IEnumerable<string> groupNames, IClient<TMarker> client, CancellationToken cancellationToken = default);

        Task RemoveAsync(string groupNames, IClient<TMarker> client, CancellationToken cancellationToken = default);
        Task RemoveManyAsync(IEnumerable<string> groupNames, IClient<TMarker> client, CancellationToken cancellationToken = default);

        Task NotifyAsync(string groupName, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1>(string groupName, string handlerName, TArgument1 argument1, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2, TArgument3>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10, CancellationToken cancellationToken = default);
        Task NotifyAsync(string groupName, string handlerName, object?[] arguments, CancellationToken cancellationToken = default);

        Task NotifyExceptAsync(string groupName, IClient<TMarker> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArgument1>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArgument1, TArgument2>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArgument1, TArgument2, TArgument3>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync(string groupName, IClient<TMarker> excluded, string handlerName, object?[] arguments, CancellationToken cancellationToken = default);

        Task NotifyManyAsync(IEnumerable<string> groupNames, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArgument1>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArgument1, TArgument2>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArgument1, TArgument2, TArgument3>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArgument1, TArgument2, TArgument3, TArgument4>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10, CancellationToken cancellationToken = default);
        Task NotifyManyAsync(IEnumerable<string> groupNames, string handlerName, object?[] arguments, CancellationToken cancellationToken = default);

        Task NotifyManyExceptAsync(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArgument1>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArgument1, TArgument2>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArgument1, TArgument2, TArgument3>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, object?[] arguments, CancellationToken cancellationToken = default);
    }
}
