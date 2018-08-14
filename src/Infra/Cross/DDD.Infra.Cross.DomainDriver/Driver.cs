using DDD.Infra.Cross.DomainDriver.Attributes;
using DDD.Infra.Cross.DomainDriver.Configuration;
using DDD.Infra.Cross.DomainDriver.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DDD.Infra.Cross.DomainDriver
{
    public class Driver
    {
        private static Dictionary<string, TyperConfigurarion> ReferencesConfigurations = new Dictionary<string, TyperConfigurarion>();
        private static Dictionary<string, Type> ListedDomainTypes = new Dictionary<string, Type>();
        public static Dictionary<string, Dictionary<string, Type>> ListedReferenceTypes = new Dictionary<string, Dictionary<string, Type>>();

        private static TyperConfigurarion DomainConfiguration;
        public static IEnumerable<Type> DomainTypes =>
            Assembly.Load(DomainConfiguration.AssemblyName).GetTypes()
            .Where(x => x.Namespace == DomainConfiguration.Namespace);
        
        public static void Initialize(string rootSection)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var @root = config.GetSection(rootSection);

            foreach(var section in @root.GetChildren())
            {
                var name = section.Key;
                var configuration = new TyperConfigurarion(section);

                if (name.ToLower().Equals("domain"))
                    DomainConfiguration = configuration;
                else
                {
                    ReferencesConfigurations.Add(section.Key, configuration);
                    ListedReferenceTypes[section.Key] = new Dictionary<string, Type>();
                }
            }
        }

        public static IEnumerable<Type> GetRefTypes(string key)
        {
            var @assembly = ReferencesConfigurations[key].AssemblyName;
            var @namespace = ReferencesConfigurations[key].Namespace;

            var types = Assembly.Load(@assembly).GetTypes()
                .Where(x => x.Namespace == @namespace);

            return types;
        }

        public static Type GetRefType(string key, string typeName, DriverAction action = DriverAction.None)
        {
            var listTypeName = typeName + action.ToString();

            if (ListedReferenceTypes[key].ContainsKey(listTypeName))
                return ListedReferenceTypes[key].GetValueOrDefault(listTypeName);

            var domainType = GetDomainType(typeName);

            return GetRefType(key, domainType, action);
        }

        public static Type GetRefType(string key, Type domainType, DriverAction action = DriverAction.None)
        {
            if (domainType == null)
                return null;

            var listTypeName = domainType.Name + action.ToString();

            if (ListedReferenceTypes[key].ContainsKey(listTypeName))
                return ListedReferenceTypes[key].GetValueOrDefault(listTypeName);

            var type = GetRefTypes(key).FindRefType(domainType, action);

            ListedReferenceTypes[key].Add(listTypeName, type);
            return type;
        }

        public static MethodInfo GetActionMethod(Type refType, DriverAction action)
        {
            return refType.GetActionMethod(action);
        }

        public static object InoveActionMethod(Type refType, DriverAction action, params object[] objects)
        {
            return refType.InvokeActionMethod(action, objects);
        }

        public static Type GetDomainType(string typeName)
        {
            if (ListedDomainTypes.ContainsKey(typeName))
                return ListedDomainTypes.GetValueOrDefault(typeName);

            var type = DomainTypes.FindType(typeName);

            ListedDomainTypes.Add(typeName, type);

            return type;
        }
    }
}
