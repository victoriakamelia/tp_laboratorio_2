using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que es string recibido sea una operación válida, caso contrario, retorna '+'.
        /// </summary>
        /// <param name="operador">String con la operación a validar.</param>
        /// <returns>String con la operación validada.</returns>
        private static string ValidarOperador(string operador)
        {
           if(operador == "+" || operador == "-" ||
              operador == "*" || operador == "/")
           {
               return operador;
           }
           else
           {
               return "+";
           }
        }
        /// <summary>
        /// Manda a validar la operación solicitada y la ejecuta.
        /// </summary>
        /// <param name="numeroUno">Primer número recibido.</param>
        /// <param name="numeroDos">Segundo número recibido.</param>
        /// <param name="operador">Opeación a realizar.</param>
        /// <returns>Retorna el resultado de la operación solicitada.</returns>
        public static double Operar(Numero numeroUno, Numero numeroDos, string operador)
        {
            operador = ValidarOperador(operador);
            double retorno = 0;
            
            switch (operador)
            {
                case "+":
                    retorno=numeroUno + numeroDos;
                    break;
                case "-":
                    retorno=numeroUno - numeroDos;
                    break;
                case "/":
                    retorno=numeroUno / numeroDos;
                    break;
                case "*":
                    retorno=numeroUno * numeroDos;
                    break;
            }
            return retorno;
        }
    }


}
