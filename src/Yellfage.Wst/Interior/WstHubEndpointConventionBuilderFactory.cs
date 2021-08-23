using Microsoft.AspNetCore.Builder;

using Yellfage.Wst.Interior.Mapping;
using Yellfage.Wst.Interior.Filtration;

namespace Yellfage.Wst.Interior
{
    internal class WstHubEndpointConventionBuilderFactory : IWstHubEndpointConventionBuilderFactory
    {
        private IHubFilterStore HubFilterStore { get; }
        private IWorkerMapper WorkerMapper { get; }

        public WstHubEndpointConventionBuilderFactory(
            IHubFilterStore hubFilterStore,
            IWorkerMapper workerMapper)
        {
            HubFilterStore = hubFilterStore;
            WorkerMapper = workerMapper;
        }

        public IWstHubEndpointConventionBuilder<TMarker> Create<TMarker>(
            IEndpointConventionBuilder endpointConventionBuilder)
        {
            return new WstHubEndpointConventionBuilder<TMarker>(
                endpointConventionBuilder,
                HubFilterStore,
                WorkerMapper);
        }
    }
}
