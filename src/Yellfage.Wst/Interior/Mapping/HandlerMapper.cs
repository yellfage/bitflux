using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Yellfage.Wst.Filters;
using Yellfage.Wst.Interior.Filters;
using Yellfage.Wst.Interior.Invocation;

namespace Yellfage.Wst.Interior.Mapping
{
    internal class HandlerMapper<TMarker> : IHandlerMapper<TMarker>
    {
        private IHandlerStore<TMarker> HandlerStore { get; }
        private IFilterExplorer<TMarker> FilterExplorer { get; }
        private IHandlerFactory<TMarker> HandlerFactory { get; }

        public HandlerMapper(
            IFilterExplorer<TMarker> filterExplorer,
            IHandlerStore<TMarker> handlerStore,
            IHandlerFactory<TMarker> handlerFactory)
        {
            FilterExplorer = filterExplorer;
            HandlerStore = handlerStore;
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

            IEnumerable<IFilter> filters = outerFilters.Concat(FilterExplorer.Explore(method));

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
