using System;

namespace Yellfage.Wst.Filtration
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class DisableAuthorizationFilterAttribute : DisableFilterAttribute
    {
        public DisableAuthorizationFilterAttribute() : base(typeof(AbstractAuthorizationFilterAttribute))
        {
        }
    }
}
