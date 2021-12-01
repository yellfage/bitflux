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
        private IFilterResearcher<TMarker> FilterResearcher { get; }
        private IWorkerMapper<TMarker> WorkerMapper { get; }

        public HubMapper(
            IHub<TMarker> hub,
            IFilterResearcher<TMarker> filterResearcher,
            IWorkerMapper<TMarker> workerMapper)
        {
            Hub = hub;
            FilterResearcher = filterResearcher;
            WorkerMapper = workerMapper;
        }

        public void Map()
        {
            IEnumerable<IFilter> filters = FilterResearcher
                .Research(Hub.GetType(), new List<IFilter>());

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
