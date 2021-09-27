using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

using Yellfage.Wst.Interior.Mapping;

namespace Yellfage.Wst.Interior
{
    internal class WstHubBuilder<TMarker> : IWstHubBuilder<TMarker>
    {
        public IServiceProvider ServiceProvider => ApplicationBuilder.ApplicationServices;

        private string Pattern { get; }
        private IApplicationBuilder ApplicationBuilder { get; }
        private IEndpointRouteBuilder EndpointRouteBuilder { get; }

        public WstHubBuilder(
            string pattern,
            IApplicationBuilder applicationBuilder,
            IEndpointRouteBuilder endpointRouteBuilder)
        {
            Pattern = pattern;
            ApplicationBuilder = applicationBuilder;
            EndpointRouteBuilder = endpointRouteBuilder;
        }

        public IWstHubBuilder<TMarker> AddWorker<TWorker>() where TWorker : Worker<TMarker>
        {
            ServiceProvider.GetRequiredService<IWorkerMapper>().Map(typeof(TWorker));

            return this;
        }

        public WstHubEndpointConventionBuilder Build()
        {
            return new(EndpointRouteBuilder.Map(Pattern, ApplicationBuilder.Build()));
        }
    }
}
