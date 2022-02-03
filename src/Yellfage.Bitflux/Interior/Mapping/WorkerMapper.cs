using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Yellfage.Bitflux.Filters;
using Yellfage.Bitflux.Interior.Filters;

namespace Yellfage.Bitflux.Interior.Mapping
{
    internal class WorkerMapper<TMarker> : IWorkerMapper<TMarker>
    {
        private IFilterResearcher<TMarker> FilterResearcher { get; }
        private IHandlerMapper<TMarker> HandlerMapper { get; }

        public WorkerMapper(
            IFilterResearcher<TMarker> filterResearcher,
            IHandlerMapper<TMarker> handlerMapper)
        {
            FilterResearcher = filterResearcher;
            HandlerMapper = handlerMapper;
        }

        public void Map(Type type, IEnumerable<IFilter> outerFilters)
        {
            IEnumerable<IFilter> filters = FilterResearcher.Research(type, outerFilters);

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
