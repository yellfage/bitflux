using System;
using System.Threading;
using System.Threading.Tasks;

using Yellfage.Wst.Bussing;

namespace Yellfage.Wst.Interior
{
    internal class ClientManager<TMarker> : IClientManager<TMarker>
    {
        public event ClientAddedEventHandler<TMarker>? Added;
        public event ClientRemovedEventHandler<TMarker>? Removed;
        private IBus<TMarker> Bus { get; }

        public ClientManager(IBus<TMarker> bus)
        {
            Bus = bus;
        }

        public async Task AddAsync(IClient<TMarker> client, CancellationToken cancellationToken = default)
        {
            await Bus.AddClientAsync(client, cancellationToken);

            if (Added is null)
            {
                return;
            }

            foreach (ClientAddedEventHandler<TMarker> handler in Added.GetInvocationList())
            {
                await handler.Invoke(new(client));
            }
        }

        public async Task RemoveAsync(IClient<TMarker> client, CancellationToken cancellationToken = default)
        {
            await Bus.RemoveClientAsync(client, cancellationToken);

            if (Removed is null)
            {
                return;
            }

            foreach (ClientRemovedEventHandler<TMarker> handler in Removed.GetInvocationList())
            {
                await handler.Invoke(new(client));
            }
        }

        public async Task NotifyAllAsync(string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArgument1>(string handlerName, TArgument1 argument1, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { argument1 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArgument1, TArgument2>(string handlerName, TArgument1 argument1, TArgument2 argument2, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { argument1, argument2 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArgument1, TArgument2, TArgument3>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { argument1, argument2, argument3 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArgument1, TArgument2, TArgument3, TArgument4>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { argument1, argument2, argument3, argument4 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10 }, cancellationToken);
        }

        public async Task NotifyAllAsync(string handlerName, object?[] arguments, CancellationToken cancellationToken = default)
        {
            await Bus.NotifyAllAsync(handlerName, arguments, cancellationToken);
        }

        public async Task NotifyAllExceptAsync(IClient<TMarker> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArgument1>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { argument1 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArgument1, TArgument2>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { argument1, argument2 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArgument1, TArgument2, TArgument3>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { argument1, argument2, argument3 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(IClient<TMarker> excluded, string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync(IClient<TMarker> excluded, string handlerName, object?[] arguments, CancellationToken cancellationToken = default)
        {
            if (excluded is null)
            {
                throw new ArgumentNullException(nameof(excluded));
            }

            await Bus.NotifyAllExceptAsync(excluded, handlerName, arguments, cancellationToken);
        }
    }
}
