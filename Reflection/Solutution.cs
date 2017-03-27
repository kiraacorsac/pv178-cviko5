using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    public static class Solution
    {
        public static T GetFieldValue<T>(object instance, string fieldName)
             where T : class
        {
            var field = instance.GetType()
                .GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            return field?.GetValue(instance) as T;
        }

        public static void SetFieldValue(object instance, string fieldName, object value)
        {
            var field = instance.GetType()
                .GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            field?.SetValue(instance, value);
        }

        public static T GetPropertyValue<T>(object instance, string propertyName)
           where T : class
        {
            var propertyInfo = instance.GetType()
                .GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            return propertyInfo?.GetGetMethod(true).Invoke(instance, new object[ ] {}) as T;
        }

        public static void SetPropertyValue(object obj, string propertyName, object value)
        {
            var propertyInfo = obj.GetType()
                .GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            propertyInfo?.SetValue(obj, value);
        }

        public static object InvokeMethod(object obj, string methodName, params object[] arguments)
        {
            return
                obj.GetType()
                    .GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Instance)
                    .Invoke(obj, arguments);
        }

        public static object InvokeStaticMethod(Type type, string methodName, params object[] arguments)
        {
            return
                type
                    .GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Static)
                    .Invoke(null, arguments);
        }

        public static string GetDescription<T>(this T enumerationValue)
           where T : struct
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", nameof(enumerationValue));
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }

        public static void SatisfyTheClass(DemandingClass demandingClass)
        {
            var exportedType =
                AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .FirstOrDefault(type => type.GetCustomAttribute(typeof(ExportAttribute)) != null);

            if (exportedType == null)
            {
                throw new InvalidOperationException("Expected type with export atribute does not exist in the app.");
            }

            var demandedInstance = Activator.CreateInstance(exportedType);

            if (demandedInstance == null)
            {
                throw new InvalidOperationException($"Could not create instance of type {exportedType.FullName}. Missing parameterless constructor maybe?");
            }

            SetFieldValue(demandingClass, "demandedClass", demandedInstance);
        }
    }
}