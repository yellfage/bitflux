using System;
using System.Collections.Generic;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Internal
{
    internal class DefaultHubOptions : HubOptions
    {
        public DefaultHubOptions() : base(
                new HashSet<string>(),
                TimeSpan.FromSeconds(30),
                4096,
                8,
                new List<IProtocol>())
        {
        }
    }
}
