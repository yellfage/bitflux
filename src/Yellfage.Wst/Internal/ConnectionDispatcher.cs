using System;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Collections.Generic;

using Yellfage.Wst.Communication;
using Yellfage.Wst.Filters;
using Yellfage.Wst.Filters.Internal;

namespace Yellfage.Wst.Internal
{
    internal class ConnectionDispatcher<T> : IConnectionDispatcher
    {
        private IHub<T> Hub { get; }
        private IFilterProvider FilterProvider { get; }
        private IFilterExecutor FilterExecutor { get; }
        private IMessageDispatcher<T> MessageDispatcher { get; }
        private IServiceProvider ServiceProvider { get; }

        public ConnectionDispatcher(
            IHub<T> hub,
            IFilterProvider filterProvider,
            IFilterExecutor filterExecutor,
            IMessageDispatcher<T> messageDispatcher,
            IServiceProvider serviceProvider)
        {
            Hub = hub;
            FilterProvider = filterProvider;
            FilterExecutor = filterExecutor;
            MessageDispatcher = messageDispatcher;
            ServiceProvider = serviceProvider;
        }

        public async Task AcceptAsync(IProtocol protocol, WebSocket webSocket)
        {
            var messageTransmitter = new MessageTransmitter(webSocket, protocol);
            var clientDisconnector = new ClientDisconnector(webSocket);

            var client = new Client<T>(messageTransmitter, clientDisconnector);

            Hub.Clients.All.Add(client);

            await ApplyConnectionFiltersAsync(client);

            /*
             * We need to check the connection state because
             * a connection filter could kick the client out
             */
            if (webSocket.State == WebSocketState.Open)
            {
                await MessageDispatcher.StartAcceptingAsync(webSocket, protocol, client);
            }

            await ApplyDisconnectionFiltersAsync(client, webSocket.CloseStatusDescription ?? "");

            Hub.Clients.All.Remove(client);
        }

        private async Task ApplyConnectionFiltersAsync(IClient<T> client)
        {
            IList<IConnectionFilter> filters = FilterProvider
                .GetConnectionFilters()
                .ToList();

            var context = new ConnectionContext<T>(
                Hub,
                ServiceProvider,
                client);

            await FilterExecutor.ExecuteConnectionFiltersAsync(
                filters,
                context,
                () => Task.CompletedTask);
        }

        private async Task ApplyDisconnectionFiltersAsync(
            IClient<T> client,
            string reason)
        {
            IList<IDisconnectionFilter> filters = FilterProvider
                .GetDisconnectionFilters()
                .ToList();

            var context = new DisconnectionContext<T>(
                Hub,
                ServiceProvider,
                client,
                reason);

            await FilterExecutor.ExecuteDisconnectionFiltersAsync(
                filters,
                context,
                () => Task.CompletedTask);
        }
    }
}
