using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;

using Yellfage.Wst.Filters;
using Yellfage.Wst.Internal;
using Yellfage.Wst.Filters.Internal;

namespace Yellfage.Wst
{
    public class WstHubEndpointConventionBuilder<T> : IEndpointConventionBuilder
    {
        private IFilterExplorer FilterExplorer { get; }
        private IHandlerExplorer HandlerExplorer { get; }
        private IHandlerDescriptorFactory HandlerDescriptorFactory { get; }
        private IEndpointConventionBuilder EndpointConventionBuilder { get; }

        private IEnumerable<IFilter> HubFilters { get; }
        private IList<HandlerDescriptor> HandlerDescriptors { get; }

        internal WstHubEndpointConventionBuilder(
            IFilterExplorer filterExplorer,
            IHandlerExplorer handlerExplorer,
            IHandlerDescriptorFactory handlerDescriptorFactory,
            IEndpointConventionBuilder endpointConventionBuilder,
            IEnumerable<IFilter> hubFilters,
            IList<HandlerDescriptor> handlerDescriptors)
        {
            FilterExplorer = filterExplorer;
            HandlerExplorer = handlerExplorer;
            HandlerDescriptorFactory = handlerDescriptorFactory;
            EndpointConventionBuilder = endpointConventionBuilder;
            HubFilters = hubFilters;
            HandlerDescriptors = handlerDescriptors;
        }

        public void Add(Action<EndpointBuilder> convention)
        {
            EndpointConventionBuilder.Add(convention);
        }

        public WstHubEndpointConventionBuilder<T> MapWorker<TWorker>() where TWorker : Worker<T>
        {
            return MapWorker(typeof(TWorker));
        }

        public WstHubEndpointConventionBuilder<T> MapWorker(Type type)
        {
            if (!typeof(Worker<T>).IsAssignableFrom(type))
            {
                throw new ArgumentException(
                    $"The type '{type.FullName}' must derive " +
                    $"from '{typeof(Worker<T>)}'");
            }

            IEnumerable<IInvocationFilter> localFilters = FilterExplorer.ExploreInvocationFilters(type);

            IEnumerable<IInvocationFilter> filters = HubFilters
                .OfType<IInvocationFilter>()
                .Concat(localFilters);

            IList<HandlerDescriptor> handlerDescriptors = HandlerExplorer
                .ExploreWorker(type)
                .Select(methodInfo => HandlerDescriptorFactory.Create(methodInfo, type, filters))
                .ToList();

            foreach (HandlerDescriptor handlerDescriptor in handlerDescriptors)
            {
                HandlerDescriptors.Add(handlerDescriptor);
            }

            return this;
        }
    }
}
