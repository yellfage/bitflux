using System;
using System.Diagnostics.CodeAnalysis;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class ArgumentConverter : IArgumentConverter
    {
        private IProtocol Protocol { get; }

        public ArgumentConverter(IProtocol protocol)
        {
            Protocol = protocol;
        }

        public bool TryConvert(
            object? value,
            Type type,
            [MaybeNullWhen(false)] out object? convertedArgument)
        {
            try
            {
                convertedArgument = Protocol.Convert(value, type);

                return true;
            }
            catch
            {
                convertedArgument = null;

                return false;
            }
        }
    }
}
