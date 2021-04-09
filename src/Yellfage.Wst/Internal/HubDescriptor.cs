using System;
using System.Collections.Generic;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Internal
{
    internal class HubDescriptor<T>
    {
        public IHub<T> Instance { get; }
        public IServiceProvider ServiceProvider { get; }
        public HubOptions Options { get; }
        public IEnumerable<IFilter> Filters { get; }
        public IEnumerable<HandlerDescriptor> HandlerDescriptors { get; }

        public HubDescriptor(
            IHub<T> instance,
            IServiceProvider serviceProvider,
            HubOptions options,
            IEnumerable<IFilter> filters,
            IEnumerable<HandlerDescriptor> handlerDescriptors)
        {
            Instance = instance;
            ServiceProvider = serviceProvider;
            Options = options;
            Filters = filters;
            HandlerDescriptors = handlerDescriptors;
        }
    }
}
