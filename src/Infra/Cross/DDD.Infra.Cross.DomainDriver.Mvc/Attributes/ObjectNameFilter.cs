namespace DDD.Infra.Cross.DomainDriver.Mvc.Attributes
{
    public class ObjectNameFilterAttribute : ArgumentFilterAttribute
    {
        public ObjectNameFilterAttribute(params string[] objectNames) 
            : base("objectName", objectNames)
        {
        }
    }
}
