using Yellfage.Wst.Interior.Bussing;
using Yellfage.Wst.Interior.Caching;

namespace Yellfage.Wst.Interior
{
    internal static class IWstHubConfiguratorExtensions
    {
        public static IWstHubConfigurator<TMarker> AddDefaultBus<TMarker>(
            this IWstHubConfigurator<TMarker> configurator)
        {
            configurator.AddBus<Bus<TMarker>>();

            return configurator;
        }

        public static IWstHubConfigurator<TMarker> AddDefaultCache<TMarker>(
            this IWstHubConfigurator<TMarker> configurator)
        {
            configurator.AddCache<HubCache<TMarker>>();

            return configurator;
        }

        public static IWstHubConfigurator<TMarker> AddDefaultClientCache<TMarker>(
            this IWstHubConfigurator<TMarker> configurator)
        {
            configurator.AddClientCache<ClientCacheFactory<TMarker>>();

            return configurator;
        }
    }
}
