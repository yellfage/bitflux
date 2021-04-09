using System.Diagnostics.CodeAnalysis;

namespace Yellfage.Wst.Internal
{
    internal interface IHandlerDescriptorProvider
    {
        bool TryGet(string name, [MaybeNullWhen(false)] out HandlerDescriptor handlerDescriptor);
    }
}
