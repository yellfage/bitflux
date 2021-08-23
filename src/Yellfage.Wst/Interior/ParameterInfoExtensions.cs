using System;
using System.Linq;
using System.Reflection;

namespace Yellfage.Wst.Interior
{
    internal static class ParameterInfoExtensions
    {
        public static bool IsNullable(this ParameterInfo info)
        {
            if (info.ParameterType.IsValueType)
            {
                return Nullable.GetUnderlyingType(info.ParameterType) is not null;
            }

            Attribute? attribute = info
                .GetCustomAttributes()
                .FirstOrDefault(attribute =>
                    attribute.GetType().FullName == "System.Runtime.CompilerServices.NullableAttribute");

            if (attribute is null)
            {
                return false;
            }

            byte[] flags = (byte[])attribute.GetType().GetField("NullableFlags")!.GetValue(attribute)!;

            return flags[0] == 2;
        }
    }
}