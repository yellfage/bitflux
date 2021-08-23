using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Yellfage.Wst.Interior.Handling
{
    internal class HandlerStore : IHandlerStore
    {
        private IDictionary<string, Handler> Handlers { get; }

        public HandlerStore() : this(new Dictionary<string, Handler>())
        {
        }

        public HandlerStore(IDictionary<string, Handler> handlers)
        {
            Handlers = handlers;
        }

        public void Add(string name, Handler handler)
        {
            Handlers.Add(name, handler);
        }

        public bool TryGet(string name, [MaybeNullWhen(false)] out Handler handler)
        {
            return Handlers.TryGetValue(name, out handler);
        }
    }
}
