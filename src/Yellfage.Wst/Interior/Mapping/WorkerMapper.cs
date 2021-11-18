using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Yellfage.Wst.Filters;
using Yellfage.Wst.Interior.Filters;

namespace Yellfage.Wst.Interior.Mapping
{
    internal class WorkerMapper<TMarker> : IWorkerMapper<TMarker>
    {
        private IFilterExplorer<TMarker> FilterExplorer { get; }
        private IHandlerMapper<TMarker> HandlerMapper { get; }

        public WorkerMapper(
            IFilterExplorer<TMarker> filterExplorer,
            IHandlerMapper<TMarker> handlerMapper)
        {
            FilterExplorer = filterExplorer;
            HandlerMapper = handlerMapper;
        }

        public void Map(Type type, IEnumerable<IFilter> outerFilters)
        {
            IEnumerable<IFilter> filters = outerFilters.Concat(FilterExplorer.Explore(type));

            foreach (MethodInfo method in ResolveMethods(type))
            {
                HandlerMapper.Map(method, filters);
            }
        }

        private IEnumerable<MethodInfo> ResolveMethods(Type type)
        {
            return type
                .GetMethods(
                    BindingFlags.Public |
                    BindingFlags.InvokeMethod |
                    BindingFlags.Instance |
                    BindingFlags.DeclaredOnly)
                .Where(method => !method.IsSpecialName &&
                                 !method.IsGenericMethod);
        }
    }
}
