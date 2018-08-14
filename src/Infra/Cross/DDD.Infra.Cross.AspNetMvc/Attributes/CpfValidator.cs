using DDD.Infra.Cross.Common.Extensions;
using DDD.Infra.Cross.Common.Validators;
using System.ComponentModel.DataAnnotations;

namespace DDD.Infra.Cross.AspNetMvc.Attributes
{
    public class CpfValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return ValidadorDeCPF.Validar((value as string).ApenasNumeros());
        }
    }
}
