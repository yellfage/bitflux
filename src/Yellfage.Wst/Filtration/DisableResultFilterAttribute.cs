using System;

namespace Yellfage.Wst.Filtration
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class DisableResultFilterAttribute : DisableFilterAttribute
    {
        public DisableResultFilterAttribute() : base(typeof(AbstractResultFilterAttribute))
        {
        }
    }
}
