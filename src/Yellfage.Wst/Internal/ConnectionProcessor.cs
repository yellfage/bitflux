using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Yellfage.Wst.Filters;
using Yellfage.Wst.Filters.Internal;

namespace Yellfage.Wst.Internal
{
    internal class ConnectionProcessor<T> : IConnectionProcessor
    {
        private IHub<T> Hub { get; }
        private IClient<T> Client { get; }
        private IFilterProvider FilterProvider { get; }
        private IFilterExecutor FilterExecutor { get; }
        private IMessageDispatcher MessageDispatcher { get; }
        private IServiceProvider ServiceProvider { get; }

        public ConnectionProcessor(
            IHub<T> hub,
            IClient<T> client,
            IFilterProvider filterProvider,
            IFilterExecutor filterExecutor,
            IMessageDispatcher messageDispatcher,
            IServiceProvider serviceProvider)
        {
            Hub = hub;
            Client = client;
            FilterProvider = filterProvider;
            FilterExecutor = filterExecutor;
            MessageDispatcher = messageDispatcher;
            ServiceProvider = serviceProvider;
        }

        public async Task StartProcessingAsync()
        {
            Hub.Clients.All.Add(Client);

            await ApplyConnectionFiltersAsync();

            await MessageDispatcher.StartAcceptingAsync();

            await ApplyDisconnectionFiltersAsync();

            Hub.Clients.All.Remove(Client);
        }

        private async Task ApplyConnectionFiltersAsync()
        {
            IList<IConnectionFilter> filters = FilterProvider
                .GetConnectionFilters()
                .ToList();

            var context = new ConnectionContext<T>(
                Hub,
                ServiceProvider,
                Client);

            await FilterExecutor.ExecuteConnectionFiltersAsync(
                filters,
                context,
                () => Task.CompletedTask);
        }

        private async Task ApplyDisconnectionFiltersAsync()
        {
            IList<IDisconnectionFilter> filters = FilterProvider
                .GetDisconnectionFilters()
                .ToList();

            var context = new DisconnectionContext<T>(
                Hub,
                ServiceProvider,
                Client,
                "");

            await FilterExecutor.ExecuteDisconnectionFiltersAsync(
                filters,
                context,
                () => Task.CompletedTask);
        }
    }
}
