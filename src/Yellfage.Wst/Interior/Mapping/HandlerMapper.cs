using System;
using System.Collections.Generic;
using System.Reflection;

using Yellfage.Wst.Filtration;
using Yellfage.Wst.Interior.Filtration;
using Yellfage.Wst.Interior.Handling;

namespace Yellfage.Wst.Interior.Mapping
{
    internal class HandlerMapper : Mapper, IHandlerMapper
    {
        private IHandlerFilterStore FilterStore { get; }
        private IHandlerStore HandlerStore { get; }

        public HandlerMapper(
            IFilterScreener filterScreener,
            IFilterExplorer filterExplorer,
            IHandlerFilterStore filterStore,
            IHandlerStore handlerStore) : base(filterScreener, filterExplorer)
        {
            FilterStore = filterStore;
            HandlerStore = handlerStore;
        }

        public void Map(MethodInfo method, IEnumerable<IFilter> outerFilters)
        {
            if (method.IsGenericMethod)
            {
                throw new NotSupportedException(
                    $"Unable to map the '{method.Name}' method: " +
                    $"generic methods are not supported");
            }

            string name = ResolveHandlerName(method);

            if (HandlerStore.TryGet(name, out Handler _))
            {
                throw new NotSupportedException(
                    $"Unable to map the '{name}' handler: " +
                    "handler name duplication and method overloading are not supported");
            }

            IEnumerable<IFilter> filters = ResolveFilters(method, outerFilters);

            var handler = new Handler(method);

            HandlerStore.Add(name, handler);

            FilterStore.AddRange(handler, filters);
        }

        private string ResolveHandlerName(MethodInfo methodInfo)
        {
            return methodInfo
                    .GetCustomAttribute<HandlerNameAttribute>()?
                    .Name ?? methodInfo.Name;
        }
    }
}
