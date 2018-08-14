using System.Text.RegularExpressions;

namespace DDD.Infra.Cross.Common.Validators
{
    public class ValidadorDeCPF
    {
        public static bool Validar(string numero)
        {
            if (string.IsNullOrEmpty(numero))
                return false;

            if (numero.Length > 11)
                return false;

            while (numero.Length != 11)
                numero = '0' + numero;

            var igual = true;
            for (var i = 1; i < 11 && igual; i++)
                if (numero[i] != numero[0])
                    igual = false;

            if (igual || numero == "12345678909")
                return false;

            var numeros = new int[11];

            for (var i = 0; i < 11; i++)
                numeros[i] = int.Parse(numero[i].ToString());

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
    }
}
