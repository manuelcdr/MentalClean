namespace DDD.Infra.Cross.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static object GetId(this object obj)
        {
            var type = obj.GetType();
            var propId = type.GetProperty("Id");
            if (propId == null)
                return null;
            return propId.GetValue(obj);
        }
    }
}
