using System;

namespace Yellfage.Wst.Internal
{
    internal interface IArgumentConverter
    {
        bool TryConvert(object? argument, Type type, out object? convertedArgument);
    }
}
