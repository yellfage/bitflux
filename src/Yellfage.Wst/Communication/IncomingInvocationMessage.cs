#pragma warning disable CS8618

using System.Collections.Generic;

namespace Yellfage.Wst.Communication
{
    public abstract class IncomingInvocationMessage : IncomingMessage
    {
        public string InvocationId { get; set; }
        public string HandlerName { get; set; }
        public IList<object?> Args { get; set; }
    }
}
