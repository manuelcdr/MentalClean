using DDD.Infra.Cross.AspNetMvc.Extensions;
using DDD.Infra.Cross.DomainDriver;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace MentalClean.UI.Questionario.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected object BindModel(IFormCollection form, Type type)
        {
            var obj = new ExpandoObject();

            foreach (var key in form.Keys)
            {
                StringValues value;
                form.TryGetValue(key, out value);
                obj.TryAdd(key, value.ToString());
            }

            var stringJsonObject = JsonConvert.SerializeObject(obj);
            var model = JsonConvert.DeserializeObject(stringJsonObject, type);

            return model;
        }

        protected object BindModel(object obj, Type type)
        {
            var stringJsonObject = JsonConvert.SerializeObject(obj);
            var model = JsonConvert.DeserializeObject(stringJsonObject, type);

            return model;
        }

        protected IActionResult ResponseApi(object obj = null)
        {
            if (!ModelState.IsValid)
                return Fail(obj);

            return Success(obj);
        }

        protected IActionResult Success(object obj = null)
        {
            var objectReturn = new
            {
                success = true,
                data = obj
            };

            return Ok(objectReturn);
        }

        protected IActionResult Fail(object obj = null)
        {

            var objectReturn = new
            {
                success = false,
                fail = true,
                errors = ModelState.GetErrors(),
                data = obj
            };

            return Ok(objectReturn);
        }

    }
}
