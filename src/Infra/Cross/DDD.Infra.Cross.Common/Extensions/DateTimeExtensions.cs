using DDD.Infra.Cross.Common.Enums;
using DDD.Infra.Cross.Common.Utils;
using System;

namespace DDD.Infra.Cross.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static DiasDaSemana ConverterParaDiasDaSemana(this DayOfWeek obj)
        {
            return Conversor.Converter(obj);
        }
    }
}
