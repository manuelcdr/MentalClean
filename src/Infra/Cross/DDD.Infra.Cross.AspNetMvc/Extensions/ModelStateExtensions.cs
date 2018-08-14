using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace DDD.Infra.Cross.AspNetMvc.Extensions
{
    public static class ModelStateExtensions
    {
        public static Dictionary<string, object> GetErrors(this ModelStateDictionary modelState)
        {
            if (modelState.ErrorCount <= 0)
                return null;

            var errors = new Dictionary<string, object>();

            foreach (var field in modelState)
            {
                if (field.Value.ValidationState != ModelValidationState.Invalid)
                    continue;

                var name = field.Key;
                var value = field.Value.RawValue;
                var errorsMessages = field.Value.Errors;

                var errorObject = new
                {
                    value,
                    errors = errorsMessages
                };

                errors.Add(name, errorObject);
            }

            return errors;
        }
    }
}
