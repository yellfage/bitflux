using System.Collections.Generic;
using System.Reflection;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal interface IArgumentBinder<TMarker>
    {
        /// <exception cref="ArgumentBindingException" />
        void BindMany(IList<ParameterInfo> parameters, IList<object?> arguments);
    }
}
