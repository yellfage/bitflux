using System.Diagnostics.CodeAnalysis;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal interface IHandlerStore<TMarker>
    {
        void Add(string name, IHandler handler);
        bool TryGet(string name, [MaybeNullWhen(false)] out IHandler handler);
        bool Contains(string name);
    }
}
