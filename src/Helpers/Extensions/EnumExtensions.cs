using System;
using System.Collections.Generic;
using System.Linq;

namespace Netopes.Core.Helpers.Extensions
{
    public static class EnumExtensions<T>
    {
        public static IEnumerable<(string? Name, T Value)> ToEnumerableTuples()
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException("Method applies only to Enum types!");
            }

            return Enum.GetValues(typeof(T)).OfType<T>().Select(v => (Name: v?.ToString(), Value: v));
        }

        public static IEnumerable<(string? Name, object? Value)> ToEnumerableObjectTuples()
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException("Method applies only to Enum types!");
            }

            return Enum.GetValues(typeof(T)).OfType<T>().Select(v => (Name: v?.ToString(), Value: (object?)v));
        }

        public static IEnumerable<string?> ToEnumerableStrings()
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException("Method applies only to Enum types!");
            }
            
            return Enum.GetValues(typeof(T)).OfType<T>().Select(v => v?.ToString());
        }
    }
}