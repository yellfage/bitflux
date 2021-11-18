using System;
using System.Diagnostics.CodeAnalysis;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Invocation
{
    internal class ArgumentConverter<TMarker> : IArgumentConverter<TMarker>
    {
        private IProtocol<TMarker> Protocol { get; }

        public ArgumentConverter(IProtocol<TMarker> protocol)
        {
            Protocol = protocol;
        }

        public bool TryConvert(
            Type type,
            object? argument,
            [MaybeNullWhen(false)] out object? convertedArgument)
        {
            try
            {
                convertedArgument = Protocol.Convert(type, argument);

                return true;
            }
            catch
            {
                convertedArgument = null;

                return false;
            }

            // We must return bool explicitly because convertedArgument can be null
            // The next statement "return convertedArgument is not null" may result in an error
        }
    }
}
