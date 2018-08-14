using System;
using System.Collections.Generic;

namespace DDD.Infra.Cross.DomainDriver.Attributes
{
    public class EntityReferenceAttribute : Attribute
    {
        private List<Type> _domainTypes = new List<Type>();
        public IEnumerable<Type> DomainTypes => _domainTypes.ToArray();

        public EntityReferenceAttribute(params Type[] domainType)
        {
            _domainTypes.AddRange(domainType);
        }

        public bool HasDomainType(Type domainType)
        {
            return _domainTypes.Contains(domainType);
        }
    }
}
