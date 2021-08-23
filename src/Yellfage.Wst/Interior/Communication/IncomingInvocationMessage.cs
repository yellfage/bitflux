#pragma warning disable CS8618

using System.Collections.Generic;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal abstract class IncomingInvocationMessage : IncomingMessage
    {
        public string HandlerName { get; set; }
        public IList<object?> Arguments { get; set; }

        protected bool IsInvocationMessageValid()
        {
            return HandlerName is not null && Arguments is not null;
        }
    }
}
