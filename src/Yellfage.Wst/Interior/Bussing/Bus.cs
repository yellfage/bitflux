using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;

using Yellfage.Wst.Bussing;

namespace Yellfage.Wst.Interior.Bussing
{
    internal class Bus<TMarker> : IBus<TMarker>
    {
        private IDictionary<string, IClient<TMarker>> Clients { get; }
        private IDictionary<string, IList<IClient<TMarker>>> Groups { get; }

        public Bus()
        {
            Clients = new ConcurrentDictionary<string, IClient<TMarker>>();
            Groups = new ConcurrentDictionary<string, IList<IClient<TMarker>>>();
        }

        public Task AddClientAsync(
            IClient<TMarker> client,
            CancellationToken cancellationToken = default)
        {
            Clients[client.Id] = client;

            return Task.CompletedTask;
        }

        public Task RemoveClientAsync(
            IClient<TMarker> client,
            CancellationToken cancellationToken = default)
        {
            foreach (IList<IClient<TMarker>> clients in Groups.Values)
            {
                clients.Remove(client);
            }

            Clients.Remove(client.Id);

            return Task.CompletedTask;
        }

        public Task AddClientToGroupAsync(
            string groupName,
            IClient<TMarker> client,
            CancellationToken cancellationToken = default)
        {
            if (Groups.TryGetValue(groupName, out IList<IClient<TMarker>>? clients))
            {
                clients.Add(client);

                return Task.CompletedTask;
            }

            Groups[groupName] = new List<IClient<TMarker>>() { client };

            return Task.CompletedTask;
        }

        public Task RemoveClientFromGroupAsync(
            string groupName,
            IClient<TMarker> client,
            CancellationToken cancellationToken = default)
        {
            if (Groups.TryGetValue(groupName, out IList<IClient<TMarker>>? clients))
            {
                if (!clients.Remove(client) || clients.Any())
                {
                    return Task.CompletedTask;
                }

                Groups.Remove(groupName);
            }

            return Task.CompletedTask;
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
