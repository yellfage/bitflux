using System;
using System.Reflection;

namespace Yellfage.Wst.Internal
{
    internal static class ParameterInfoExtensions
    {
        public static bool IsFlexible(this ParameterInfo info)
        {
            return info.IsDefined(typeof(ParamArrayAttribute), false);
        }
    }
}
