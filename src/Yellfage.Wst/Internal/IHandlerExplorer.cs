using System;
using System.Reflection;
using System.Collections.Generic;

namespace Yellfage.Wst.Internal
{
    internal interface IHandlerExplorer
    {
        IList<MethodInfo> ExploreWorker(Type workerType);
    }
}
