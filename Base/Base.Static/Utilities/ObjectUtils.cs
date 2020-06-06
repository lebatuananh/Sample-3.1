using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Base.Static.Utilities
{
    public static class ObjectUtils
    {
        public static List<string> GetProperyNames(Type type)
        {
            var properties = type.GetProperties();
            var propertyNames = properties.Select(s => s.Name).ToList();
            return propertyNames;
        }

        public static List<object> GetPropertyValues(object obj)
        {
            var result = new List<object>();
            var type = obj.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(obj);
                result.Add(propertyValue);
            }

            return result;
        }

        public static Dictionary<string, Type> GetPropertyTypeMap(Type type)
        {
            var result = new Dictionary<string, Type>();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                if (property.DeclaringType.Equals(type))
                    result.Add(property.Name, property.PropertyType);
                else if (!result.ContainsKey(propertyName))
                    result.Add(property.Name, property.PropertyType);
            }

            return result;
        }

        public static Dictionary<string, string> ValidateObject(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(obj, validationContext, validationResults, true);

            var result = new Dictionary<string, string>();
            foreach (var validationResult in validationResults)
                result.Add(string.Join(",", validationResult.MemberNames), validationResult.ErrorMessage);
            return result;
        }

        public static bool Equal(object obj1, object obj2)
        {
            if (obj1 == null && obj2 == null)
                return true;
            if (obj1 == null && obj2 != null)
                return false;
            if (obj1 != null && obj2 == null)
                return false;
            return obj1.Equals(obj2);
        }

        public static Type GetElementType<T>(this IEnumerable<T> input)
        {
            var interfaces = input.GetType().GetInterfaces();
            Type elementType = null;
            foreach (var i in interfaces)
                if (i.IsGenericType && i.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)))
                    elementType = i.GetGenericArguments()[0];
            return elementType;
        }


        public static Type GetType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null) return type;
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typeName);
                if (type != null)
                    return type;
            }

            return null;
        }
    }
}