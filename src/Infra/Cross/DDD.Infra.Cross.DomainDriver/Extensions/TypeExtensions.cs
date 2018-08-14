using DDD.Infra.Cross.DomainDriver.Abstractions;
using DDD.Infra.Cross.DomainDriver.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DDD.Infra.Cross.DomainDriver.Extensions
{
    public static class TypeExtensions
    {
        public static Type FindType(this IEnumerable<Type> types, string typeName)
        {
            var type = types.SingleOrDefault(t => t.Name.ToLower() == typeName.ToLower());
            return type;
        }

        public static Type FindTypeStartsWith(this IEnumerable<Type> types, string typeName)
        {
            var type = types.SingleOrDefault(t => t.Name.ToLower().StartsWith(typeName.ToLower()));
            return type;
        }

        public static Type FindTypeWith(this IEnumerable<Type> types, string typeName)
        {
            var type = types.SingleOrDefault(t => t.Name.ToLower().Contains(typeName.ToLower()));
            return type;
        }

        public static Type FindRefType(this IEnumerable<Type> types, Type domainType, DriverAction action = DriverAction.None)
        {
            var likeTypes = types
                .Where(t => t.GetCustomAttribute<EntityReferenceAttribute>() != null);

            foreach (var type in likeTypes)
            {
                if (!type.HasDomainType(domainType))
                    continue;

                if (action == DriverAction.None || type.AcceptDriverAction(action))
                    return type;
            }

            return null;
        }

        public static IEnumerable<Type> GetDomainTypes(this Type type)
        {
            var attribute = type.GetCustomAttribute<EntityReferenceAttribute>(false);
            if (attribute == null)
                return null;

            return attribute.DomainTypes;
        }

        public static bool HasDomainType(this Type refType, Type domainType)
        {
            var attribute = refType.GetCustomAttribute<EntityReferenceAttribute>(false);
            if (attribute == null)
                return false;

            return attribute.HasDomainType(domainType);
        }

        public static bool AcceptDriverAction(this Type type, DriverAction action)
        {
            var attribute = type.GetCustomAttribute<AcceptDriverActionsAttribute>(false);

            if (attribute == null && action == DriverAction.None)
                return true;

            return attribute != null && attribute.Actions.HasFlag(action);
        }

        public static MethodInfo GetActionMethod(this Type refType, DriverAction action)
        {
            var methods = refType.GetMethods();
            foreach(var method in methods)
            {
                var attribute = method.GetCustomAttribute<AcceptDriverActionsAttribute>(false);
                if (attribute == null)
                    continue;

                if (attribute.Actions.HasFlag(action))
                    return method;
            }
            return null;
        }

        public static object InvokeActionMethod(this Type refType, DriverAction action, params object[] @params)
        {
            var objRef = refType.CreateInstance() as IDDRef;
            return objRef.InvokeActionMethod(action, @params);
        }    

        public static Object CreateInstance(this Type type, params object[] @params)
        {
            return type.TypeInitializer.Invoke(@params);
        }

        public static DriverAction GetAcceptDriverActions(this Type type)
        {
            var attribute = type.GetCustomAttribute<AcceptDriverActionsAttribute>(false);
            if (attribute == null)
                return DriverAction.None;

            return attribute.Actions;
        }
    }
}
