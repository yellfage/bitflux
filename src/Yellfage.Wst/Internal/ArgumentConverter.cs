using System;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Internal
{
    internal class ArgumentConverter : IArgumentConverter
    {
        private IProtocol Protocol { get; }

        public ArgumentConverter(IProtocol protocol)
        {
            Protocol = protocol;
        }

        public bool TryConvert(object? argument, Type type, out object? convertedArgument)
        {
            try
            {
                convertedArgument = Protocol.ConvertValue(argument, type);
            }
            catch
            {
                convertedArgument = null;
            }

            return convertedArgument is not null;
        }
    }
}
