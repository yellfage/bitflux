using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Yellfage.Wst.Bussing;

namespace Yellfage.Wst.Interior.Bussing
{
    internal class Bus<TMarker> : IBus<TMarker>
    {
        private ConcurrentDictionary<string, IClient<TMarker>> Clients { get; } = new();
        private ConcurrentDictionary<string, IList<IClient<TMarker>>> Groups { get; } = new();

        public async Task AddClientAsync(
            IClient<TMarker> client,
            CancellationToken cancellationToken = default)
        {
            Clients[client.Id] = client;
        }

        public async Task RemoveClientAsync(
            IClient<TMarker> client,
            CancellationToken cancellationToken = default)
        {
            Clients.Remove(client.Id, out IClient<TMarker> _);
        }

        public async Task AddClientToGroupAsync(
            string groupName,
            IClient<TMarker> client,
            CancellationToken cancellationToken = default)
        {
            if (Groups.TryGetValue(groupName, out IList<IClient<TMarker>>? clients))
            {
                clients.Add(client);
            }

            Groups[groupName] = new List<IClient<TMarker>>() { client };
        }

        public async Task RemoveClientFromGroupAsync(
            string groupName,
            IClient<TMarker> client,
            CancellationToken cancellationToken = default)
        {
            if (Groups.TryGetValue(groupName, out IList<IClient<TMarker>>? clients))
            {
                if (!clients.Remove(client))
                {
                    return;
                }

                if (!clients.Any())
                {
                    Groups.Remove(groupName, out IList<IClient<TMarker>> _);
                }
            }
        }

        public async Task RemoveClientFromAllGroupsAsync(
            IClient<TMarker> client,
            CancellationToken cancellationToken = default)
        {
            await Task.WhenAll(
                Groups
                    .Where(pair => pair.Value.Contains(client))
                    .Select(pair => pair.Key)
                    .Select(groupName => RemoveClientFromGroupAsync(groupName, client, cancellationToken)));
        }

        public async Task NotifyAllAsync(
            string handlerName,
            object?[] arguments,
            CancellationToken cancellationToken = default)
        {
            await Task.WhenAll(
                Clients
                    .Values
                    .Select(client => client.NotifyAsync(handlerName, arguments, cancellationToken)));
        }

        public async Task NotifyAllExceptAsync(
            IClient<TMarker> excluded,
            string handlerName,
            object?[] arguments,
            CancellationToken cancellationToken = default)
        {
            await Task.WhenAll(
                Clients
                    .Values
                    .Except(new[] { excluded })
                    .Select(client => client.NotifyAsync(handlerName, arguments, cancellationToken)));
        }

        public async Task NotifyGroupAsync(
            string groupName,
            string handlerName,
            object?[] arguments,
            CancellationToken cancellationToken = default)
        {
            await Task.WhenAll(
                Groups[groupName]
                    .Select(client => client.NotifyAsync(handlerName, arguments, cancellationToken)));
        }

        public async Task NotifyGroupExceptAsync(
            string groupName,
            IClient<TMarker> excluded,
            string handlerName,
            object?[] arguments,
            CancellationToken cancellationToken = default)
        {
            await Task.WhenAll(
                Groups[groupName]
                    .Except(new[] { excluded })
                    .Select(client => client.NotifyAsync(handlerName, arguments, cancellationToken)));
        }

        public async Task NotifyManyGroupsAsync(
            IEnumerable<string> groupNames,
            string handlerName,
            object?[] arguments,
            CancellationToken cancellationToken = default)
        {
            await Task.WhenAll(
                groupNames
                    .Select(name => NotifyGroupAsync(name, handlerName, arguments, cancellationToken)));
        }

        public async Task NotifyManyGroupsExceptAsync(
            IEnumerable<string> groupNames,
            IClient<TMarker> excluded,
            string handlerName,
            object?[] arguments,
            CancellationToken cancellationToken = default)
        {
            await Task.WhenAll(
                groupNames
                    .Select(name => NotifyGroupExceptAsync(name, excluded, handlerName, arguments, cancellationToken)));
        }
    }
}
