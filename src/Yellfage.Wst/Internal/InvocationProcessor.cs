using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections;
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
                if (!BindArguments(context.Args, handlerDescriptor.ParametersInfo))
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

        private bool BindArguments(IList<object?> arguments, ParameterInfo[] parametersInfo)
        {
            for (int i = 0; i < parametersInfo.Length; i++)
            {
                ParameterInfo parameterInfo = parametersInfo[i];
                Type parameterType = parameterInfo.ParameterType;

                bool isArgumentEnumerable = typeof(IEnumerable).IsAssignableFrom(arguments[i]?.GetType());

                if (i < arguments.Count)
                {
                    if (parameterInfo.IsFlexible() && !isArgumentEnumerable)
                    {
                        arguments[i] = arguments.Skip(i).ToArray();

                        arguments.RemoveRange(i + 1);
                    }

                    if (ArgumentConverter.TryConvert(arguments[i], parameterType, out object? convertedValue))
                    {
                        arguments[i] = convertedValue;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (!parameterInfo.HasDefaultValue)
                    {
                        return false;
                    }

                    arguments.Insert(i, parameterInfo.DefaultValue);
                }
            }

            return true;
        }
    }
}
