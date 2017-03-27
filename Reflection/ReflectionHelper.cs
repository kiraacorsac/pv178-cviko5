using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    public static class ReflectionHelper
    {
        public static T SetFieldValue<T>(object instance, string fieldName, object value)
             where T : class
        {
            throw new NotImplementedException();
        }

        public static void SetFieldValue(object instance, string fieldName, object value)
        {
            var field = instance.GetType()
                .GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            field?.SetValue(instance, value);
        }

        public static T GetPropertyValue<T>(object obj, string propertyName)
           where T : class
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}