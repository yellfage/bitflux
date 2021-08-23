using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Yellfage.Wst.Interior.Handling
{
    internal class Handler
    {
        public ParameterInfo[] Parameters => Method.GetParameters();

        private MethodInfo Method { get; }

        public Handler(MethodInfo method)
        {
            Method = method;
        }

        public async Task ExecuteAsync<TMarker>(IInvocationContext<TMarker> context)
        {
            var worker = (Worker<TMarker>)context.ServiceProvider.GetRequiredService(Method.DeclaringType!);

            worker.Context = context;

            object? result = await ExecuteMethodAsync(worker, context.Arguments.ToArray());

            await context.ReplyAsync(result);
        }

        private async Task<object?> ExecuteMethodAsync(object? obj, object?[] arguments)
        {
            dynamic? methodResult = Method.Invoke(obj, arguments);

            if (Method.IsAwaitable())
            {
                await methodResult;

                string taskResultReturnTypeName = ( (object)methodResult! )
                    .GetType()
                    .GetProperty("Result")!
                    .PropertyType
                    .FullName!;

                if (taskResultReturnTypeName != "System.Threading.Tasks.VoidTaskResult")
                {
                    return methodResult!.GetAwaiter().GetResult();
                }

                return null;
            }

            return methodResult;
        }
    }
}
