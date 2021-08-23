using System;
using System.Diagnostics.CodeAnalysis;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IArgumentConverter
    {
        bool TryConvert(object? value, Type type, [MaybeNullWhen(false)] out object? convertedArgument);
    }
}
