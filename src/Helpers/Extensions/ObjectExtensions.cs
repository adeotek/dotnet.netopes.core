using System;

namespace Netopes.Core.Helpers.Extensions
{
    public static class ObjectExtensions
    {
        public static void ThrowIfNull<T>(this T @object, string paramName)
        {
            if (@object == null) throw new ArgumentNullException(paramName, $"Parameter {paramName} cannot be null.");
        }
    }
}