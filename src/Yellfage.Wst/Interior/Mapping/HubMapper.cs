using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Yellfage.Wst.Filters;
using Yellfage.Wst.Interior.Filters;

namespace Yellfage.Wst.Interior.Mapping
{
    internal class HubMapper<TMarker> : IHubMapper<TMarker>
    {
        private IHub<TMarker> Hub { get; }
        private IFilterExplorer<TMarker> FilterExplorer { get; }
        private IWorkerMapper<TMarker> WorkerMapper { get; }

        public HubMapper(
            IHub<TMarker> hub,
            IFilterExplorer<TMarker> filterExplorer,
            IWorkerMapper<TMarker> workerMapper)
        {
            Hub = hub;
            FilterExplorer = filterExplorer;
            WorkerMapper = workerMapper;
        }

        public void Map()
        {
            IEnumerable<IFilter> filters = FilterExplorer.Explore(Hub.GetType());

            foreach (Type type in ResolveWorkerTypes())
            {
                WorkerMapper.Map(type, filters);
            }
        }

        private IEnumerable<Type> ResolveWorkerTypes()
        {
            return Assembly
                .GetEntryAssembly()!
                .DefinedTypes
                .Where(type => typeof(IWorker<TMarker>).IsAssignableFrom(type));
        }
    }
}
