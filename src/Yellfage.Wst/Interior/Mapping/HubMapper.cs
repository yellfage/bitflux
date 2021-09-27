using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using Yellfage.Wst.Filtration;
using Yellfage.Wst.Interior.Filtration;

namespace Yellfage.Wst.Interior.Mapping
{
    internal class HubMapper : Mapper, IHubMapper
    {
        private IServiceProvider ServiceProvider { get; }
        private IHubFilterStore HubFilterStore { get; }

        public HubMapper(
            IFilterScreener filterScreener,
            IFilterExplorer filterExplorer,
            IServiceProvider serviceProvider,
            IHubFilterStore hubFilterStore) : base(
                filterScreener,
                filterExplorer)
        {
            ServiceProvider = serviceProvider;
            HubFilterStore = hubFilterStore;
        }

        public void Map<TMarker>()
        {
            IHub<TMarker> hub = ResolveHub<TMarker>();

            IEnumerable<IFilter> filters = ResolveFilters(hub.GetType());

            HubFilterStore.AddRange(filters);
        }

        private IHub<TMarker> ResolveHub<TMarker>()
        {
            return ServiceProvider.GetRequiredService<IHub<TMarker>>();
        }
    }
}
