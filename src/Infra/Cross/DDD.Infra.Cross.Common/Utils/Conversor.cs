using DDD.Infra.Cross.Common.Enums;
using System;

namespace DDD.Infra.Cross.Common.Utils
{
    public class Conversor
    {
        public static DiasDaSemana Converter(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return DiasDaSemana.Domingo;
                case DayOfWeek.Monday:
                    return DiasDaSemana.Segunda;
                case DayOfWeek.Tuesday:
                    return DiasDaSemana.Terca;
                case DayOfWeek.Wednesday:
                    return DiasDaSemana.Quarta;
                case DayOfWeek.Thursday:
                    return DiasDaSemana.Quinta;
                case DayOfWeek.Friday:
                    return DiasDaSemana.Sexta;
                case DayOfWeek.Saturday:
                    return DiasDaSemana.Sabado;
                default:
                    return 0;
            }
        }
    }
}
