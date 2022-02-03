#pragma warning disable CS8618

using System.Collections.Generic;

using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal abstract class IncomingInvocationMessage : IncomingMessage
    {
        public string Id { get; set; }
        public string HandlerName { get; set; }
        public IList<object?> Arguments { get; set; }

        internal override bool IsValid()
        {
            return Id is not null && HandlerName is not null && Arguments is not null;
        }
    }
}
