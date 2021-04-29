using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Yellfage.Wst.Internal
{
    internal static class MethodInfoExtentions
    {
        public static bool IsAwaitable(this MethodInfo methodInfo)
        {
            Type returnType = methodInfo.ReturnType;

            MethodInfo? getAwaiterMethodInfo = returnType
                .GetRuntimeMethods()
                .FirstOrDefault(methodInfo =>
                    methodInfo.Name.Equals("GetAwaiter", StringComparison.OrdinalIgnoreCase)
                    && methodInfo.GetParameters().Length == 0);

            if (getAwaiterMethodInfo is null)
            {
                return false;
            }

            Type awaiterReturnType = getAwaiterMethodInfo.ReturnType;

            bool isCompletedPropertyExists = awaiterReturnType
                .GetRuntimeProperties()
                .Any(propertyInfo =>
                    propertyInfo.Name.Equals("IsCompleted", StringComparison.OrdinalIgnoreCase)
                    && propertyInfo.PropertyType == typeof(bool)
                    && propertyInfo.GetMethod is not null);

            if (!isCompletedPropertyExists)
            {
                return false;
            }

            if (!typeof(INotifyCompletion).IsAssignableFrom(awaiterReturnType))
            {
                return false;
            }

            bool getResultMethodExists = awaiterReturnType
                .GetRuntimeMethods()
                .Any(methodInfo =>
                    methodInfo.Name.Equals("GetResult", StringComparison.OrdinalIgnoreCase)
                    && methodInfo.GetParameters().Length == 0);

            if (!getResultMethodExists)
            {
                return false;
            }

            return true;
        }
    }
}
