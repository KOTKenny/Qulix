using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BLL.Extensions
{
    //Мапперы для использование DTO
    public class Mapper
    {
        public static T Map<T>(object source) where T : new()
        {
            if (source == null)
                return default(T);

            var result = new T();
            var targetType = typeof(T);
            var sourceProperties = source.GetType().GetProperties();
            foreach (var sourceProperty in sourceProperties)
            {
                if (sourceProperty.CanRead)
                {
                    var targetProperty = targetType.GetProperty(sourceProperty.Name);

                    if (targetProperty != null && sourceProperty.PropertyType == targetProperty.PropertyType)
                        targetProperty.SetValue(result, sourceProperty.GetValue(source));
                }
            }

            return result;
        }

        public static T Map<T>(object source, Dictionary<string, KeyValuePair<string, Delegate>> anotherValues) where T : new()
        {
            if (source == null)
                return default(T);

            var result = new T();
            var targetType = typeof(T);
            var sourceProperties = source.GetType().GetProperties();
            foreach (var sourceProperty in sourceProperties)
            {
                if (sourceProperty.CanRead)
                {
                    var targetProperty = targetType.GetProperty(sourceProperty.Name);

                    if (targetProperty != null && sourceProperty.PropertyType == targetProperty.PropertyType)
                        targetProperty.SetValue(result, sourceProperty.GetValue(source));
                }
            }

            foreach (var property in anotherValues)
            {
                var targetProperty = targetType.GetProperty(property.Key);

                if (targetProperty != null)
                    targetProperty.SetValue(result, property.Value.Value.DynamicInvoke(source, property.Value.Key));
            }

            return result;
        }

        public static IList<T> MapCollection<T, U>(IList<U> collection) where T : new() where U : class
        {
            IList<T> mappedCollection = new List<T>();

            foreach (var item in collection)
            {
                var mappedItem = Map<T>(item);

                mappedCollection.Add(mappedItem);
            }

            return mappedCollection;
        }

        public static IList<T> MapCollection<T, U>(IList<U> collection, Dictionary<string, KeyValuePair<string, Delegate>> anotherValues) where T : new() where U : class
        {
            IList<T> mappedCollection = new List<T>();

            foreach (var item in collection)
            {
                var mappedItem = Map<T>(item, anotherValues);

                mappedCollection.Add(mappedItem);
            }

            return mappedCollection;
        }
    }
}