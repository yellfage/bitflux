using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Yellfage.Wst.Filters.Internal;

namespace Yellfage.Wst.Internal
{
    internal class InvocationProcessor : IInvocationProcessor
    {
        private IHandlerDescriptorProvider HandlerDescriptorProvider { get; }
        private IArgumentConverter ArgumentConverter { get; }
        private IFilterExecutor FilterExecutor { get; }
        private IHandlerExecutor HandlerExecutor { get; }

        public InvocationProcessor(
            IHandlerDescriptorProvider handlerDescriptorProvider,
            IArgumentConverter argumentConverter,
            IFilterExecutor filterExecutor,
            IHandlerExecutor handlerExecutor)
        {
            HandlerDescriptorProvider = handlerDescriptorProvider;
            ArgumentConverter = argumentConverter;
            FilterExecutor = filterExecutor;
            HandlerExecutor = handlerExecutor;
        }

        public async Task ProcessAsync<T>(IInvocationContext<T> context)
        {
            if (HandlerDescriptorProvider.TryGet(
                context.HandlerName,
                out HandlerDescriptor? handlerDescriptor))
            {
                if (!BindArguments(context.Args, handlerDescriptor.ParameterTypes))
                {
                    await context.ReplyErrorAsync($"Unable to bind the '{context.HandlerName}' handler " +
                        "parameters with provided arguments");

                    return;
                }

                await FilterExecutor.ExecuteInvocationFiltersAsync(
                    handlerDescriptor.Filters,
                    context,
                    () => HandlerExecutor.ExecuteAsync(handlerDescriptor, context));
            }
            else
            {
                await context.ReplyErrorAsync($"The '{context.HandlerName}' handler not found");
            }
        }

        private bool BindArguments(IList<object?> arguments, Type[] parameterTypes)
        {
            if (parameterTypes.Length != arguments.Count)
            {
                return false;
            }

            for (int i = 0; i < parameterTypes.Length; i++)
            {
                if (ArgumentConverter.TryConvert(arguments[i], parameterTypes[i], out object? convertedValue))
                {
                    arguments[i] = convertedValue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
