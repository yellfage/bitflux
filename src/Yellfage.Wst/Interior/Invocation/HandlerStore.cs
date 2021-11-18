using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Yellfage.Wst.Interior.Invocation
{
    internal class HandlerStore<TMarker> : IHandlerStore<TMarker>
    {
        private IDictionary<string, IHandler> Handlers { get; }

        public HandlerStore() : this(new Dictionary<string, IHandler>())
        {
        }

        public HandlerStore(IDictionary<string, IHandler> handlers)
        {
            Handlers = handlers;
        }

        public void Add(string name, IHandler handler)
        {
            Handlers.Add(name, handler);
        }

        public bool TryGet(string name, [MaybeNullWhen(false)] out IHandler handler)
        {
            return Handlers.TryGetValue(name, out handler);
        }

        public bool Contains(string name)
        {
            return Handlers.ContainsKey(name);
        }
    }
}
