using System;
using System.Threading.Tasks;

using Yellfage.Wst.Communication;
using Yellfage.Wst.Filters.Internal;

namespace Yellfage.Wst.Internal
{
    internal class InvocationProcessor : IInvocationProcessor
    {
        private IHandlerDescriptorProvider HandlerDescriptorProvider { get; }
        private IFilterExecutor FilterExecutor { get; }
        private IHandlerExecutor HandlerExecutor { get; }

        public InvocationProcessor(
            IHandlerDescriptorProvider handlerDescriptorProvider,
            IFilterExecutor filterExecutor,
            IHandlerExecutor handlerExecutor)
        {
            HandlerDescriptorProvider = handlerDescriptorProvider;
            FilterExecutor = filterExecutor;
            HandlerExecutor = handlerExecutor;
        }

        public async Task ProcessAsync<T>(IInvocationContext<T> context, IProtocol protocol)
        {
            if (HandlerDescriptorProvider.TryGet(
                context.HandlerName,
                out HandlerDescriptor? handlerDescriptor))
            {
                if (!BindArguments(context.Args, handlerDescriptor.ParameterTypes, protocol))
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

        private bool BindArguments(object?[] args, Type[] parameterTypes, IProtocol protocol)
        {
            if (parameterTypes.Length != args.Length)
            {
                return false;
            }

            for (int i = 0; i < parameterTypes.Length; i++)
            {
                if (protocol.TryConvertValue(args[i], parameterTypes[i], out object? convertedValue))
                {
                    args[i] = convertedValue;
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
