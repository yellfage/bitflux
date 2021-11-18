using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Yellfage.Wst.Bussing;

namespace Yellfage.Wst.Interior
{
    internal class GroupManager<TMarker> : IGroupManager<TMarker>
    {
        public event ClientAddedToGroupEventHandler<TMarker> Added = (_) => Task.CompletedTask;
        public event ClientRemovedFromGroupEventHandler<TMarker> Removed = (_) => Task.CompletedTask;

        private IBus<TMarker> Bus { get; }

        public GroupManager(IBus<TMarker> bus)
        {
            Bus = bus;
        }

        public async Task AddAsync(string groupName, IClient<TMarker> client, CancellationToken cancellationToken = default)
        {
            await Bus.AddClientToGroupAsync(groupName, client, cancellationToken);

            foreach (ClientAddedToGroupEventHandler<TMarker> handler in Added.GetInvocationList())
            {
                await handler.Invoke(new(this, groupName, client));
            }
        }

        public async Task AddManyAsync(IEnumerable<string> groupNames, IClient<TMarker> client, CancellationToken cancellationToken = default)
        {
            await AddManyAsync("", groupNames, client, cancellationToken);
        }

        public async Task AddManyAsync(string groupNamePrefix, IEnumerable<string> groupNames, IClient<TMarker> client, CancellationToken cancellationToken = default)
        {
            await Task.WhenAll(
                groupNames.Select(name => AddAsync(groupNamePrefix + name, client, cancellationToken)));
        }

        public async Task RemoveAsync(string groupName, IClient<TMarker> client, CancellationToken cancellationToken = default)
        {
            await Bus.RemoveClientFromGroupAsync(groupName, client, cancellationToken);

            foreach (ClientRemovedFromGroupEventHandler<TMarker> handler in Removed.GetInvocationList())
            {
                await handler.Invoke(new(this, groupName, client));
            }
        }

        public async Task RemoveManyAsync(IEnumerable<string> groupNames, IClient<TMarker> client, CancellationToken cancellationToken = default)
        {
            await RemoveManyAsync("", groupNames, client, cancellationToken);
        }

        public async Task RemoveManyAsync(string groupNamePrefix, IEnumerable<string> groupNames, IClient<TMarker> client, CancellationToken cancellationToken = default)
        {
            await Task.WhenAll(
                groupNames.Select(name => RemoveAsync(groupNamePrefix + name, client, cancellationToken)));
        }

        public async Task RemoveAll(IClient<TMarker> client, CancellationToken cancellationToken = default)
        {
            await Bus.RemoveClientFromAllGroupsAsync(client, cancellationToken);
        }

        public async Task NotifyAsync(string groupName, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { }, cancellationToken);
        }

        public async Task NotifyAsync<TArgument1>(string groupName, string handlerName, TArgument1 argument1, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { argument1 }, cancellationToken);
        }

        public async Task NotifyAsync<TArgument1, TArgument2>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { argument1, argument2 }, cancellationToken);
        }

        public async Task NotifyAsync<TArgument1, TArgument2, TArgument3>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { argument1, argument2, argument3 }, cancellationToken);
        }

        public async Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { argument1, argument2, argument3, argument4 }, cancellationToken);
        }

        public async Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5 }, cancellationToken);
        }

        public async Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6 }, cancellationToken);
        }

        public async Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7 }, cancellationToken);
        }

        public async Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8 }, cancellationToken);
        }

        public async Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9 }, cancellationToken);
        }

        public async Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(string groupName, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10 }, cancellationToken);
        }

        public async Task NotifyAsync(string groupName, string handlerName, object?[] arguments, CancellationToken cancellationToken = default)
        {
            if (groupName is null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            await NotifyManyAsync(new[] { groupName }, handlerName, arguments, cancellationToken);
        }

        public async Task NotifyExceptAsync(string groupName, IClient<TMarker> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArgument1>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { argument1 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArgument1, TArgument2>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { argument1, argument2 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArgument1, TArgument2, TArgument3>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { argument1, argument2, argument3 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(string groupName, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10 }, cancellationToken);
        }

        public async Task NotifyExceptAsync(string groupName, IClient<TMarker> excluded, string handlerName, object?[] arguments, CancellationToken cancellationToken = default)
        {
            if (groupName is null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            await NotifyManyExceptAsync(new[] { groupName }, excluded, handlerName, arguments, cancellationToken);
        }

        public async Task NotifyManyAsync(IEnumerable<string> groupNames, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(groupNames, handlerName, new object?[] { }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArgument1>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(groupNames, handlerName, new object?[] { argument1 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArgument1, TArgument2>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(groupNames, handlerName, new object?[] { argument1, argument2 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArgument1, TArgument2, TArgument3>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(groupNames, handlerName, new object?[] { argument1, argument2, argument3 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArgument1, TArgument2, TArgument3, TArgument4>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(groupNames, handlerName, new object?[] { argument1, argument2, argument3, argument4 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(groupNames, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(groupNames, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(groupNames, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(groupNames, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(groupNames, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(IEnumerable<string> groupNames, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(groupNames, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10 }, cancellationToken);
        }

        public async Task NotifyManyAsync(IEnumerable<string> groupNames, string handlerName, object?[] arguments, CancellationToken cancellationToken = default)
        {
            if (groupNames is null)
            {
                throw new ArgumentNullException(nameof(groupNames));
            }

            await Bus.NotifyManyGroupsAsync(groupNames, handlerName, arguments, cancellationToken);
        }

        public async Task NotifyManyExceptAsync(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(groupNames, excluded, handlerName, new object?[] { }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArgument1>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(groupNames, excluded, handlerName, new object?[] { argument1 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArgument1, TArgument2>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(groupNames, excluded, handlerName, new object?[] { argument1, argument2 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArgument1, TArgument2, TArgument3>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(groupNames, excluded, handlerName, new object?[] { argument1, argument2, argument3 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(groupNames, excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(groupNames, excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(groupNames, excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(groupNames, excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(groupNames, excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(groupNames, excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(groupNames, excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync(IEnumerable<string> groupNames, IClient<TMarker> excluded, string handlerName, object?[] arguments, CancellationToken cancellationToken = default)
        {
            if (groupNames is null)
            {
                throw new ArgumentNullException(nameof(groupNames));
            }

            if (excluded is null)
            {
                throw new ArgumentNullException(nameof(excluded));
            }

            await Bus.NotifyManyGroupsExceptAsync(groupNames, excluded, handlerName, arguments, cancellationToken);
        }
    }
}
