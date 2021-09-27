using System;

using Microsoft.AspNetCore.Builder;

namespace Yellfage.Wst
{
    public sealed class WstHubEndpointConventionBuilder : IEndpointConventionBuilder
    {
        private IEndpointConventionBuilder EndpointConventionBuilder { get; }

        internal WstHubEndpointConventionBuilder(IEndpointConventionBuilder endpointConventionBuilder)
        {
            EndpointConventionBuilder = endpointConventionBuilder;
        }

        public void Add(Action<EndpointBuilder> convention)
        {
            EndpointConventionBuilder.Add(convention);
        }
    }
}
