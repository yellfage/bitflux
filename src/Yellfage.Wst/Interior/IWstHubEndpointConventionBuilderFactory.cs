using Microsoft.AspNetCore.Builder;

namespace Yellfage.Wst.Interior
{
    internal interface IWstHubEndpointConventionBuilderFactory
    {
        IWstHubEndpointConventionBuilder<TMarker> Create<TMarker>(IEndpointConventionBuilder endpointConventionBuilder);
    }
}
