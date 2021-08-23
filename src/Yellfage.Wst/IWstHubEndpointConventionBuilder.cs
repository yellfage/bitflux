using System;
using Microsoft.AspNetCore.Builder;

namespace Yellfage.Wst
{
    public interface IWstHubEndpointConventionBuilder<TMarker> : IEndpointConventionBuilder
    {
        IWstHubEndpointConventionBuilder<TMarker> MapWorker<TWorker>() where TWorker : Worker<TMarker>;
        IWstHubEndpointConventionBuilder<TMarker> MapWorker(Type type);
    }
}
