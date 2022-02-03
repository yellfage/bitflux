using Yellfage.Bitflux.Interior.Bussing;
using Yellfage.Bitflux.Interior.Caching;

namespace Yellfage.Bitflux.Interior
{
    internal static class IBitfluxHubConfiguratorExtensions
    {
        public static IBitfluxHubConfigurator<TMarker> AddDefaultBus<TMarker>(
            this IBitfluxHubConfigurator<TMarker> configurator)
        {
            configurator.AddBus<Bus<TMarker>>();

            return configurator;
        }

        public static IBitfluxHubConfigurator<TMarker> AddDefaultCache<TMarker>(
            this IBitfluxHubConfigurator<TMarker> configurator)
        {
            configurator.AddCache<HubCache<TMarker>>();

            return configurator;
        }

        public static IBitfluxHubConfigurator<TMarker> AddDefaultClientCache<TMarker>(
            this IBitfluxHubConfigurator<TMarker> configurator)
        {
            configurator.AddClientCache<ClientCacheFactory<TMarker>>();

            return configurator;
        }
    }
}
