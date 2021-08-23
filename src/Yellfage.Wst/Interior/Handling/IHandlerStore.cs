using System.Diagnostics.CodeAnalysis;

namespace Yellfage.Wst.Interior.Handling
{
    internal interface IHandlerStore
    {
        void Add(string name, Handler handler);
        bool TryGet(string name, [MaybeNullWhen(false)] out Handler handler);
    }
}
