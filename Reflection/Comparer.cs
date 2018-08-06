using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    public static class Comparer
    {
        public static bool ReflectionComparer<T>(this T first, T second)
        {
            if (ReferenceEquals(first, null))
            {
                return false;
            }

            if (ReferenceEquals(second, null))
            {
                return false;
            }

            if (first.GetType() != second.GetType())
            {
                return false;
            }
            
            var properties = first.GetProperties();

            foreach (var property in properties)
            {
                if (!property.GetType().IsPrimitive && property.PropertyType !=typeof(string))
                {
                    if (!first.GetType().GetProperty(property.Name).GetValue(first)
                        .ReflectionComparer(second.GetType().GetProperty(property.Name).GetValue(second)))
                    {
                        return false;
                    }
                }

                string firstValue = property.GetValue(first).ToString();
                string secondValue = property.GetValue(second).ToString();

                if (!firstValue.Equals(secondValue))
                {
                    return false;
                }
            }

            var fields = first.GetFields();

            foreach (var field in fields)
            {
                if (!field.GetType().IsPrimitive && field.FieldType != typeof(string))
                {
                    if (!first.GetType().GetProperty(field.Name).GetValue(first)
                        .ReflectionComparer(second.GetType().GetProperty(field.Name).GetValue(second)))
                    {
                        return false;
                    }
                }
                string firstValue = field.GetValue(first).ToString();
                string secondValue = field.GetValue(second).ToString();

                if (!firstValue.Equals(secondValue))
                {
                    return false;
                }
            }

            return true;
        }

        private static List<PropertyInfo> GetProperties<T>(this T entity) =>
            entity.GetType().GetProperties(BindingFlags.Static |
                                           BindingFlags.Public |
                                           BindingFlags.NonPublic |
                                           BindingFlags.Default |
                                           BindingFlags.Instance).ToList();

        private static List<FieldInfo> GetFields<T>(this T entity) =>
            entity.GetType().GetFields(BindingFlags.Static |
                                       BindingFlags.Public |
                                       BindingFlags.NonPublic |
                                       BindingFlags.Default |
                                       BindingFlags.Instance).ToList();

    }
}
