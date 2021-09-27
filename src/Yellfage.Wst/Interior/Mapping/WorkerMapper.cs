using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Yellfage.Wst.Filtration;
using Yellfage.Wst.Interior.Filtration;

namespace Yellfage.Wst.Interior.Mapping
{
    internal class WorkerMapper : Mapper, IWorkerMapper
    {
        private IHubFilterStore HubFilterStore { get; }
        private IHandlerMapper HandlerMapper { get; }

        public WorkerMapper(
            IFilterScreener filterScreener,
            IFilterExplorer filterExplorer,
            IHubFilterStore hubFilterStore,
            IHandlerMapper handlerMapper) : base(filterScreener, filterExplorer)
        {
            HubFilterStore = hubFilterStore;
            HandlerMapper = handlerMapper;
        }

        public void Map(Type type)
        {
            IEnumerable<IFilter> filters = ResolveFilters(type, HubFilterStore.GetAll());

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
