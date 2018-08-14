using DDD.Infra.Cross.DomainDriver.Abstractions;
using DDD.Infra.Cross.DomainDriver.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DDD.Infra.Cross.DomainDriver.Extensions
{
    public static class DDTypesExtensions
    {
        public static Type GetRefType(this IDDEntity entity, string key, DriverAction action = DriverAction.None)
        {
            return Driver.GetRefType(key, entity.GetType(), action);
        }

        public static Object GetRefObj(this IDDEntity domainObj, string key, DriverAction action = DriverAction.None)
        {
            var refType = domainObj.GetRefType(key, action);

            if (refType == null)
                return null;

            return refType.CreateInstance();
        }

        public static MethodInfo GetActionMethod(this IDDRef objRef, DriverAction action)
        {
            return objRef.GetType().GetActionMethod(action);
        }

        public static object InvokeActionMethod(this IDDRef objRef, DriverAction action, params object[] objects)
        {
            var method = objRef.GetActionMethod(action);

            if (method == null)
                return null;

            return method.Invoke(objRef, objects);
        }

        public static IEnumerable<Type> GetDomainTypes(this IDDRef refObj)
        {
            return refObj.GetType().GetDomainTypes();
        }

        public static DriverAction GetAcceptDriverActions(this IDDRef refObj)
        {
            return refObj.GetType().GetAcceptDriverActions();
        }
    }
}
