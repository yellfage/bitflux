using System;
using System.Diagnostics.CodeAnalysis;

namespace Yellfage.Wst.Interior.Invocation
{
    internal interface IArgumentConverter<TMarker>
    {
        bool TryConvert(Type type, object? argument, [MaybeNullWhen(false)] out object? convertedArgument);
    }
}
