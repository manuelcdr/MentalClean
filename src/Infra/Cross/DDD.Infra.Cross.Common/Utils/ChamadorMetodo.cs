using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DDD.Infra.Cross.Common.Utils
{
    public class ChamadorMetodo
    {
        public static object ChamarMetodoGenerico(object objetoChamador, string metodo, Type[] tiposGenericos, params object[] parametros)
        {
            MethodInfo method = null;

            if (parametros?.Count() > 0)
                method = objetoChamador.GetType().GetMethod(metodo, parametros.Select(x => x.GetType()).ToArray());
            else
                method = objetoChamador.GetType().GetMethod(metodo, Type.EmptyTypes);

            MethodInfo genericMethod = method.MakeGenericMethod(tiposGenericos);
            return genericMethod.Invoke(objetoChamador, parametros);
        }

        public static object ChamarMetodoGenerico(object objetoChamador, string metodo, Type[] tiposGenericos)
        {
            return ChamarMetodoGenerico(objetoChamador, metodo, tiposGenericos, null);
        }

        public static object ChamarMetodo(object objetoChamador, string metodo, params object[] parametros)
        {
            MethodInfo method = null;

            if (parametros?.Count() > 0)
                method = objetoChamador.GetType().GetMethod(metodo, parametros.Select(x => x.GetType()).ToArray());
            else
                method = objetoChamador.GetType().GetMethod(metodo, Type.EmptyTypes);

            return method.Invoke(objetoChamador, parametros);
        }
    }
}
