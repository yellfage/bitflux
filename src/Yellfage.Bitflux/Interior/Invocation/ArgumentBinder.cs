using System.Collections.Generic;
using System.Reflection;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal class ArgumentBinder<TMarker> : IArgumentBinder<TMarker>
    {
        private IArgumentConverter<TMarker> ArgumentConverter { get; }

        public ArgumentBinder(IArgumentConverter<TMarker> argumentConverter)
        {
            ArgumentConverter = argumentConverter;
        }

        /// <exception cref="ArgumentBindingException" />
        public void BindMany(IList<ParameterInfo> parameters, IList<object?> arguments)
        {
            if (parameters.Count != arguments.Count)
            {
                throw new ArgumentBindingException(
                    "Unable to bind arguments: " +
                    "the number of arguments mismatch with the number of parameters");
            }

            for (int i = 0; i < parameters.Count; i++)
            {
                arguments[i] = Bind(parameters[i], arguments[i]);
            }
        }

        /// <exception cref="ArgumentBindingException" />
        private object? Bind(ParameterInfo parameter, object? argument)
        {
            if (ArgumentConverter.TryConvert(
                parameter.ParameterType,
                argument,
                out object? convertedArgument))
            {
                if (argument is null && !parameter.IsNullable())
                {
                    throw new ArgumentBindingException(
                        $"Unable to bind a nullable argument " +
                        $"with the \"{parameter.Name}\" parameter");
                }

                return convertedArgument;
            }

            throw new ArgumentBindingException(
                $"Unable to bind the \"{argument}\" argument " +
                $"with the \"{parameter.Name}\" parameter");
        }
    }
}
