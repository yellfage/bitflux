using System;

namespace Yellfage.Wst.Internal
{
    internal class DisconnectionContext<T> : IDisconnectionContext<T>
    {
        public IHub<T> Hub { get; }
        public IServiceProvider ServiceProvider { get; }
        public IClient<T> Client { get; }
        public string? Reason { get; }

        public DisconnectionContext(
            IHub<T> hub,
            IServiceProvider serviceProvider,
            IClient<T> client,
            string? reason)
        {
            Hub = hub;
            ServiceProvider = serviceProvider;
            Client = client;
            Reason = reason;
        }
    }
}
