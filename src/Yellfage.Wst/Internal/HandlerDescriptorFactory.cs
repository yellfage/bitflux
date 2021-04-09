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

        public HandlerDescriptorFactory(
            IHandlerNameResolver handlerNameResolver,
            IFilterExplorer filterExplorer)
        {
            HandlerNameResolver = handlerNameResolver;
            FilterExplorer = filterExplorer;
        }

        public HandlerDescriptor Create(
            MethodInfo methodInfo,
            Type workerType,
            IEnumerable<IInvocationFilter> externalFilters)
        {
            string name = HandlerNameResolver.Resolve(methodInfo);

            IEnumerable<IInvocationFilter> localFilters = FilterExplorer
                .ExploreInvocationFilters(methodInfo);

            IList<IInvocationFilter> filterDescriptors = externalFilters
                .Concat(localFilters)
                .ToList();

            var methodExecutor = new MethodExecutor(
                methodInfo,
                methodInfo.IsAwaitable());

            Type[] parameterTypes = methodInfo
                .GetParameters()
                .Select(parameterInfo => parameterInfo.ParameterType)
                .ToArray();

            return new HandlerDescriptor(
                name,
                methodInfo,
                methodExecutor,
                workerType,
                parameterTypes,
                filterDescriptors);
        }
    }
}
