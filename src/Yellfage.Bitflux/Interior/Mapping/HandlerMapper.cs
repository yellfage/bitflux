using System;
using System.Collections.Generic;
using System.Reflection;

using Yellfage.Bitflux.Filters;
using Yellfage.Bitflux.Interior.Filters;
using Yellfage.Bitflux.Interior.Invocation;

namespace Yellfage.Bitflux.Interior.Mapping
{
    internal class HandlerMapper<TMarker> : IHandlerMapper<TMarker>
    {
        private IHandlerStore<TMarker> HandlerStore { get; }
        private IFilterResearcher<TMarker> FilterResearcher { get; }
        private IHandlerFactory<TMarker> HandlerFactory { get; }

        public HandlerMapper(
            IHandlerStore<TMarker> handlerStore,
            IFilterResearcher<TMarker> filterResearcher,
            IHandlerFactory<TMarker> handlerFactory)
        {
            HandlerStore = handlerStore;
            FilterResearcher = filterResearcher;
            HandlerFactory = handlerFactory;
        }

        public void Map(MethodInfo method, IEnumerable<IFilter> outerFilters)
        {
            if (method.IsGenericMethod)
            {
                throw new NotSupportedException(
                    $"Unable to map the '{method.Name}' method: " +
                    $"generic methods are not supported");
            }

            string name = ResolveName(method);

            if (HandlerStore.Contains(name))
            {
                throw new NotSupportedException(
                    $"Unable to map the '{name}' handler: " +
                    "handler name duplication and method overloading are not supported");
            }

            IEnumerable<IFilter> filters = FilterResearcher.Research(method, outerFilters);

            IHandler handler = HandlerFactory.Create(method, filters);

            HandlerStore.Add(name, handler);
        }

        private string ResolveName(MethodInfo method)
        {
            return method
                .GetCustomAttribute<HandlerNameAttribute>()?
                .Name ?? method.Name;
        }
    }
}
