using System;

namespace Yellfage.Wst.Internal
{
    internal class ConnectionContext<T> : IConnectionContext<T>
    {
        public IHub<T> Hub { get; }
        public IServiceProvider ServiceProvider { get; }
        public IClient<T> Client { get; }

        public ConnectionContext(
            IHub<T> hub,
            IServiceProvider serviceProvider,
            IClient<T> client)
        {
            Hub = hub;
            ServiceProvider = serviceProvider;
            Client = client;
        }
    }
}
