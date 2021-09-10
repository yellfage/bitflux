using System;

namespace Yellfage.Wst.Filtration
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
