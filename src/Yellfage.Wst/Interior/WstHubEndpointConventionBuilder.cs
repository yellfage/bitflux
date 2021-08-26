using System;

using Microsoft.AspNetCore.Builder;

using Yellfage.Wst.Interior.Filtration;
using Yellfage.Wst.Interior.Mapping;

namespace Yellfage.Wst.Interior
{
    internal class WstHubEndpointConventionBuilder<TMarker> : IWstHubEndpointConventionBuilder<TMarker>
    {
        private IEndpointConventionBuilder EndpointConventionBuilder { get; }
        private IHubFilterStore HubFilterStore { get; }
        private IWorkerMapper WorkerMapper { get; }

        internal WstHubEndpointConventionBuilder(
            IEndpointConventionBuilder endpointConventionBuilder,
            IHubFilterStore hubFilterStore,
            IWorkerMapper workerMapper)
        {
            EndpointConventionBuilder = endpointConventionBuilder;
            HubFilterStore = hubFilterStore;
            WorkerMapper = workerMapper;
        }

        public void Add(Action<EndpointBuilder> convention)
        {
            EndpointConventionBuilder.Add(convention);
        }

        public IWstHubEndpointConventionBuilder<TMarker> MapWorker<TWorker>()
            where TWorker : Worker<TMarker>
        {
            return MapWorker(typeof(TWorker));
        }

        public IWstHubEndpointConventionBuilder<TMarker> MapWorker(Type type)
        {
            if (!typeof(Worker<TMarker>).IsAssignableFrom(type))
            {
                throw new ArgumentException(
                    $"The '{type.FullName}' type must derive " +
                    $"from '{typeof(Worker<TMarker>)}'");
            }

            WorkerMapper.Map(type, HubFilterStore.GetAll());

            return this;
        }
    }
}
