using System;

namespace Yellfage.Wst.Filtration
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class DisableExceptionFilterAttribute : DisableFilterAttribute
    {
        public DisableExceptionFilterAttribute() : base(typeof(AbstractExceptionFilterAttribute))
        {
        }
    }
}
