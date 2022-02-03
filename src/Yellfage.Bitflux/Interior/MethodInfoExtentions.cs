using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Yellfage.Bitflux.Interior
{
    internal static class MethodInfoExtentions
    {
        public static bool IsAwaitable(this MethodInfo method)
        {
            MethodInfo? getAwaiterMethod = method.ReturnType
                .GetRuntimeMethods()
                .FirstOrDefault(runtimeMethod =>
                    runtimeMethod.Name.Equals("GetAwaiter", StringComparison.OrdinalIgnoreCase) &&
                    runtimeMethod.GetParameters().Length == 0);

            if (getAwaiterMethod is null)
            {
                return false;
            }

            bool isCompletedPropertyExists = getAwaiterMethod.ReturnType
                .GetRuntimeProperties()
                .Any(property =>
                    property.Name.Equals("IsCompleted", StringComparison.OrdinalIgnoreCase) &&
                    property.PropertyType == typeof(bool) &&
                    property.GetMethod is not null);

            if (!isCompletedPropertyExists)
            {
                return false;
            }

            if (!typeof(INotifyCompletion).IsAssignableFrom(getAwaiterMethod.ReturnType))
            {
                return false;
            }

            bool getResultMethodExists = getAwaiterMethod.ReturnType
                .GetRuntimeMethods()
                .Any(runtimeMethod =>
                    runtimeMethod.Name.Equals("GetResult", StringComparison.OrdinalIgnoreCase) &&
                    runtimeMethod.GetParameters().Length == 0);

            if (!getResultMethodExists)
            {
                return false;
            }

            return true;
        }
    }
}
