using DDD.Infra.Cross.AspNetMvc.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MentalClean.UI.Questionario.Controllers
{
    public abstract class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
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
