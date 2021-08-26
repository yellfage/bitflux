using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Yellfage.Wst
{
    public interface IInvocationContext<TMarker>
    {
        IHub<TMarker> Hub { get; }
        IClient<TMarker> Client { get; }
        IServiceProvider ServiceProvider { get; }
        string HandlerName { get; }
        IList<object?> Arguments { get; }

        Task ReplyAsync(object? value, CancellationToken cancellationToken = default);
        Task ReplyErrorAsync(string error, CancellationToken cancellationToken = default);

        async Task NotifyOthersAsync(string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { }, cancellationToken);
        }

        async Task NotifyOthersAsync<TArgument1>(string handlerName, TArgument1 argument1, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { argument1 }, cancellationToken);
        }

        async Task NotifyOthersAsync<TArgument1, TArgument2>(string handlerName, TArgument1 argument1, TArgument2 argument2, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { argument1, argument2 }, cancellationToken);
        }

        async Task NotifyOthersAsync<TArgument1, TArgument2, TArgument3>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { argument1, argument2, argument3 }, cancellationToken);
        }

        async Task NotifyOthersAsync<TArgument1, TArgument2, TArgument3, TArgument4>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { argument1, argument2, argument3, argument4 }, cancellationToken);
        }

        async Task NotifyOthersAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5 }, cancellationToken);
        }

        async Task NotifyOthersAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6 }, cancellationToken);
        }

        async Task NotifyOthersAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7 }, cancellationToken);
        }

        async Task NotifyOthersAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8 }, cancellationToken);
        }

        async Task NotifyOthersAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9 }, cancellationToken);
        }

        async Task NotifyOthersAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10 }, cancellationToken);
        }

        async Task NotifyOthersAsync(string handlerName, object?[] arguments, CancellationToken cancellationToken = default)
        {
            await Hub.Clients.NotifyAllExceptAsync(Client, handlerName, arguments, cancellationToken);
        }

        async Task NotifyOthersInGroupAsync(string groupName, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, Array.Empty<object>(), cancellationToken);
        }

        async Task NotifyOthersInGroupAsync<TArgument1>(string groupName, string handlerName, TArgument1 argument1, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { argument1 }, cancellationToken);
        }

        async Task NotifyOthersInGroupAsync<TArgument1, TArgument2>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { argument1, argument2 }, cancellationToken);
        }

        async Task NotifyOthersInGroupAsync<TArgument1, TArgument2, TArgument3>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { argument1, argument2, argument3 }, cancellationToken);
        }

        async Task NotifyOthersInGroupAsync<TArgument1, TArgument2, TArgument3, TArgument4>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { argument1, argument2, argument3, argument4 }, cancellationToken);
        }

        async Task NotifyOthersInGroupAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5 }, cancellationToken);
        }

        async Task NotifyOthersInGroupAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6 }, cancellationToken);
        }

        async Task NotifyOthersInGroupAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7 }, cancellationToken);
        }

        async Task NotifyOthersInGroupAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8 }, cancellationToken);
        }

        async Task NotifyOthersInGroupAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9 }, cancellationToken);
        }

        async Task NotifyOthersInGroupAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10 }, cancellationToken);
        }

        async Task NotifyOthersInGroupAsync(string groupName, string handlerName, object?[] arguments, CancellationToken cancellationToken = default)
        {
            if (groupName is null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            await NotifyOthersInManyGroupsAsync(new[] { groupName }, handlerName, arguments, cancellationToken);
        }

        async Task NotifyOthersInManyGroupsAsync(IEnumerable<string> groupNames, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInManyGroupsAsync(groupNames, handlerName, new object?[] { }, cancellationToken);
        }

        async Task NotifyOthersInManyGroupsAsync<TArgument1>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInManyGroupsAsync(groupNames, handlerName, new object?[] { argument1 }, cancellationToken);
        }

        async Task NotifyOthersInManyGroupsAsync<TArgument1, TArgument2>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInManyGroupsAsync(groupNames, handlerName, new object?[] { argument1, argument2 }, cancellationToken);
        }

        async Task NotifyOthersInManyGroupsAsync<TArgument1, TArgument2, TArgument3>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInManyGroupsAsync(groupNames, handlerName, new object?[] { argument1, argument2, argument3 }, cancellationToken);
        }

        async Task NotifyOthersInManyGroupsAsync<TArgument1, TArgument2, TArgument3, TArgument4>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInManyGroupsAsync(groupNames, handlerName, new object?[] { argument1, argument2, argument3, argument4 }, cancellationToken);
        }

        async Task NotifyOthersInManyGroupsAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInManyGroupsAsync(groupNames, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5 }, cancellationToken);
        }

        async Task NotifyOthersInManyGroupsAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInManyGroupsAsync(groupNames, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6 }, cancellationToken);
        }

        async Task NotifyOthersInManyGroupsAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInManyGroupsAsync(groupNames, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7 }, cancellationToken);
        }

        async Task NotifyOthersInManyGroupsAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInManyGroupsAsync(groupNames, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8 }, cancellationToken);
        }

        async Task NotifyOthersInManyGroupsAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInManyGroupsAsync(groupNames, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9 }, cancellationToken);
        }

        async Task NotifyOthersInManyGroupsAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInManyGroupsAsync(groupNames, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10 }, cancellationToken);
        }

        async Task NotifyOthersInManyGroupsAsync(IEnumerable<string> groupNames, string handlerName, object?[] arguments, CancellationToken cancellationToken = default)
        {
            if (groupNames is null)
            {
                throw new ArgumentNullException(nameof(groupNames));
            }

            await Hub.Groups.NotifyManyExceptAsync(groupNames, Client, handlerName, arguments, cancellationToken);
        }
    }
}
