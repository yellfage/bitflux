using Yellfage.Wst.Caching;

namespace Yellfage.Wst.Interior.Caching
{
    internal class ClientCacheFactory : IClientCacheFactory
    {
        private IClientCacheConverter ClientCacheConverter { get; }

        public ClientCacheFactory(IClientCacheConverter clientCacheConverter)
        {
            ClientCacheConverter = clientCacheConverter;
        }

        public IClientCache<TMarker> Create<TMarker>(IClientClaimsPrincipal user)
        {
            return new ClientCache<TMarker>(ClientCacheConverter);
        }
    }
}
