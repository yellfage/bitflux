using System;

namespace Yellfage.Wst.Filtration
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class DisableValidationFilterAttribute : DisableFilterAttribute
    {
        public DisableValidationFilterAttribute() : base(typeof(AbstractValidationFilterAttribute))
        {
        }
    }
}
