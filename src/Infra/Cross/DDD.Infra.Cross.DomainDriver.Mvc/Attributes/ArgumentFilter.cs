using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.Infra.Cross.DomainDriver.Mvc.Attributes
{
    public class ArgumentFilterAttribute : Attribute
    {
        public string ArgumentName { get; private set; }
        private List<string> _values;
        public IEnumerable<String> TypeNames => _values.ToArray();

        public ArgumentFilterAttribute(string argumentName, params string[] values)
        {
            _values = new List<string>(values);
            ArgumentName = argumentName;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.ContainsKey(ArgumentName))
                return;

            var value = (string)context.ActionArguments[ArgumentName];

            if (!_values.Any(x => x == value))
                return;

            context.Result = new NotFoundResult();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
