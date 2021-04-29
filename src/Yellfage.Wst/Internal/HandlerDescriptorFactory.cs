using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Yellfage.Wst.Filters;
using Yellfage.Wst.Filters.Internal;

namespace Yellfage.Wst.Internal
{
    internal class HandlerDescriptorFactory : IHandlerDescriptorFactory
    {
        private IHandlerNameResolver HandlerNameResolver { get; }
        private IFilterExplorer FilterExplorer { get; }
        private IDisabledFilterTypeExplorer DisabledFilterTypeExplorer { get; }
        private IFilterSifter FilterSifter { get; }

        public HandlerDescriptorFactory(
            IHandlerNameResolver handlerNameResolver,
            IFilterExplorer filterExplorer,
            IDisabledFilterTypeExplorer disabledFilterTypeExplorer,
            IFilterSifter filterSifter)
        {
            HandlerNameResolver = handlerNameResolver;
            FilterExplorer = filterExplorer;
            DisabledFilterTypeExplorer = disabledFilterTypeExplorer;
            FilterSifter = filterSifter;
        }

        public HandlerDescriptor Create(
            MethodInfo methodInfo,
            Type workerType,
            IEnumerable<IInvocationFilter> externalFilters)
        {
            string name = HandlerNameResolver.Resolve(methodInfo);

            // TODO: incapsulate {
            IEnumerable<IInvocationFilter> rawFilters = externalFilters
                .Concat(FilterExplorer.ExploreInvocationFilters(methodInfo));

            IEnumerable<Type> disabledFilterTypes = DisabledFilterTypeExplorer.ExploreAll(methodInfo);

            IList<IInvocationFilter> filters = FilterSifter
                .Sift<IInvocationFilter>(rawFilters, disabledFilterTypes)
                .ToList();
            // }

            var methodExecutor = new MethodExecutor(methodInfo);

            return new HandlerDescriptor(
                name,
                methodInfo,
                methodExecutor,
                workerType,
                filters);
        }
    }
}
