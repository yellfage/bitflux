using System;

namespace Yellfage.Wst
{
    public interface IWstHubBuilder<TMarker>
    {
        IServiceProvider ServiceProvider { get; }

        IWstHubBuilder<TMarker> AddWorker<TWorker>() where TWorker : Worker<TMarker>;

        WstHubEndpointConventionBuilder Build();
    }
}
