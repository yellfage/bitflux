using Microsoft.AspNetCore.Routing;

namespace Yellfage.Wst.Interior.Mapping
{
    internal interface IHubMapper
    {
        IWstHubEndpointConventionBuilder<TMarker> Map<TMarker>(IEndpointRouteBuilder endpoints, string pattern);
    }
}
