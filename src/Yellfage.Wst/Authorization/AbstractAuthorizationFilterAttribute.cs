using System;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class AbstractAuthorizationFilterAttribute : FilterAttribute
    {
        public AbstractAuthorizationFilterAttribute()
        {
            Priority = (int)AbstractFilterPriority.Authorization;
        }
    }
}
