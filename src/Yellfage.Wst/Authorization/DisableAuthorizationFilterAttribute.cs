using System;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class DisableAuthorizationFilterAttribute : DisableFilterAttribute
    {
        public DisableAuthorizationFilterAttribute() : base(typeof(AbstractAuthorizationFilterAttribute))
        {
        }
    }
}
