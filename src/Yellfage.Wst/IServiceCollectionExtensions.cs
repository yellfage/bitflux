using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

using Yellfage.Wst.Internal;
using Yellfage.Wst.Filters.Internal;

namespace Yellfage.Wst
{
    public static class IServiceCollectionExtensions
    {
        public static void AddWst(this IServiceCollection services)
        {
            AddMisc(services);
            AddWorkers(services);
        }

        private static void AddMisc(IServiceCollection services)
        {
            services
                .AddSingleton<WstMarkerService>()
                .AddSingleton<IFilterExplorer, FilterExplorer>()
                .AddSingleton<IDisabledFilterTypeExplorer, DisabledFilterTypeExplorer>()
                .AddSingleton<IFilterSifter, FilterSifter>()
                .AddSingleton<IFilterExecutor, FilterExecutor>()
                .AddSingleton<IFilterPipelineFactory, FilterPipelineFactory>()
                .AddSingleton<IHandlerExplorer, HandlerExplorer>()
                .AddSingleton<IHandlerExecutor, HandlerExecutor>()
                .AddSingleton<IHandlerNameResolver, HandlerNameResolver>()
                .AddSingleton<IHandlerDescriptorFactory, HandlerDescriptorFactory>();
        }

        private static void AddWorkers(IServiceCollection services)
        {
            Assembly assembly = Assembly.GetEntryAssembly()!;

            foreach (Type type in assembly.ExportedTypes)
            {
                if (typeof(Worker).IsAssignableFrom(type))
                {
                    services.AddTransient(type);
                }
            }
        }
    }
}
