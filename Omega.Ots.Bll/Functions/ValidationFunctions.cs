using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Omega.Ots.Bll.Functions
{
    public static class ValidationFunctions
    {
        public static List<PropertyAttribute<TAttribute>> GetPropertyAttributesFromType<TAttribute>(this Type enttiyType) where TAttribute : Attribute
        {
            var list = new List<PropertyAttribute<TAttribute>>();
            var properties = enttiyType.GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes<TAttribute>(true).ToList();
                if (!attributes.Any()) continue;

                list.AddRange(attributes.Select(x => new PropertyAttribute<TAttribute>(property, x)));
            }

            var interfaces = enttiyType.GetInterfaces();
            foreach (var infaces in interfaces)
            {
                list.AddRange(infaces.GetPropertyAttributesFromType<TAttribute>());
            }

            return list;
        }
        public class PropertyAttribute<TAttribute>
        {
            public PropertyInfo Property { get; }
            public TAttribute Attribute { get; }

            public PropertyAttribute(PropertyInfo property, TAttribute attribute)
            {
                Property = property;
                Attribute = attribute;
            }
        }
    }
}