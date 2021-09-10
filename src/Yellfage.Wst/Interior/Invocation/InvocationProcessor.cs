using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

using Yellfage.Wst.Interior.Communication;
using Yellfage.Wst.Interior.Filtration;
using Yellfage.Wst.Interior.Handling;

namespace Yellfage.Wst.Interior.Invocation
{
    internal class InvocationProcessor : IInvocationProcessor
    {
        private IHandlerStore HandlerStore { get; }
        private IHandlerFilterStore HandlerFilterStore { get; }
        private IFilterExecutor FilterExecutor { get; }
        private IArgumentConverter ArgumentConverter { get; }

        public InvocationProcessor(
            IHandlerStore handlerStore,
            IHandlerFilterStore handlerFilterStore,
            IFilterExecutor filterExecutor,
            IArgumentConverter argumentConverter)
        {
            HandlerStore = handlerStore;
            HandlerFilterStore = handlerFilterStore;
            FilterExecutor = filterExecutor;
            ArgumentConverter = argumentConverter;
        }

        public async Task ProcessAsync<TMarker>(IInvocationExecutionContext<TMarker> context)
        {
            if (HandlerStore.TryGet(context.HandlerName, out Handler? handler))
            {
                if (!BindArguments(handler.Parameters, context.Arguments))
                {
                    await context.ReplyErrorAsync(
                        $"Unable to bind the '{context.HandlerName}' handler " +
                        "parameters with provided arguments");

                    return;
                }

                await FilterExecutor.ExecuteAsync(
                    HandlerFilterStore.GetAll(handler),
                    context,
                    () => handler.ExecuteAsync(context));
            }
            else
            {
                await context.ReplyErrorAsync($"The '{context.HandlerName}' handler not found");
            }
        }

        public bool BindArguments(IList<ParameterInfo> parameters, IList<object?> arguments)
        {
            if (parameters.Count != arguments.Count)
            {
                return false;
            }

            for (int i = 0; i < parameters.Count; i++)
            {
                if (ArgumentConverter.TryConvert(
                    arguments[i],
                    parameters[i].ParameterType,
                    out object? convertedArgument))
                {
                    arguments[i] = convertedArgument;

                    if (arguments[i] is null && !parameters[i].IsNullable())
                    {
                        return false;
                    }
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
