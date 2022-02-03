using System;

using Microsoft.AspNetCore.Builder;

namespace Yellfage.Bitflux
{
    public sealed class BitfluxHubEndpointConventionBuilder : IEndpointConventionBuilder
    {
        private IEndpointConventionBuilder EndpointConventionBuilder { get; }

        internal BitfluxHubEndpointConventionBuilder(IEndpointConventionBuilder endpointConventionBuilder)
        {
            EndpointConventionBuilder = endpointConventionBuilder;
        }

        public void Add(Action<EndpointBuilder> convention)
        {
            EndpointConventionBuilder.Add(convention);
        }
    }
}
