using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
  
        /// <summary>
        /// Setea el atributo "numero".
        /// </summary>
        private string SetNumero
        {
            set
            {
                double numeroValidado=ValidarNumero(value);
                numero=numeroValidado;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Numero en cero.
        /// </summary>
        public Numero():this(0)
        {
        
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Numero en el valor pasado por parámetros.
        /// </summary>
        /// <param name="unNumero">Valor con el que inicializará un Numero.</param>
        public Numero(double unNumero)
        {
            this.numero=unNumero;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Numero en el valor pasado por parámetros.
        /// </summary>
        /// <param name="StrNumero">Valor con el que inicializará un Numero</param>
        public Numero(string StrNumero)
        {
            this.SetNumero=StrNumero;
        }

        /// <summary>
        /// Realizará las validaciones necesarias para poder 
        /// realizar operaciones con el string pasado por parámetros.
        /// </summary>
        /// <param name="strNumero">parámetro a validar</param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            string auxSacarPunto = strNumero.Replace('.', ',');
            
            double esNumero;
            if(double.TryParse(auxSacarPunto, out esNumero))
            {
                return esNumero;
            }
            else
            {
                return 0;
            }   
        }

        /// <summary>
        /// Valida que la cadena recibida sea un número binario. Si lo es lo convierte a decimal.
        /// Caso contrario retornará un texto avisando que no pudo ejecutar el pedido.
        /// </summary>
        /// <param name="unBinario">Texto a convertir en decimal.</param>
        /// <returns>Retorna el resultado de la operación o un mensanje avisando 
        /// que no pudo ejecutar el pedido.</returns>
        public static string BinarioDecimal(string unBinario)
        {
            for(int i=0; i<unBinario.Length; i++)
            {
                if(unBinario[i] != '1' && unBinario[i] != '0')
                {
                    return "Valor inválido";
                }
            }
            double retorno=Convert.ToInt32(unBinario, 2);
            return retorno.ToString();
        }

        /// <summary>
        // Valida que la cadena recibida sea un número decimal. Si lo es lo convierte a binario.
        /// Caso contrario retornará un texto avisando que no pudo ejecutar el pedido.
        /// </summary>
        /// <param name="numero">Texto a convertir en Binario.</param>
        /// <returns>Retorna el resultado de la operación o un mensanje 
        /// avisando que no pudo ejecutar el pedido.</returns>
        public static string DecimalBinario(string numero)
        {
			if (double.TryParse(numero, out double doubleNumero))
			{
                if(doubleNumero >= 0)
                {
                    return DecimalBinario((int)Math.Abs(doubleNumero));
                }				
			}
			return "Valor inválido";
        }

        /// <summary>
        /// Recibe un numero decimal validado y lo convierte a binario.
        /// </summary>
        /// <param name="numero">NUmero a convertir en binario.</param>
        /// <returns>Retorna un string con el número binario.</returns>
        public static string DecimalBinario(double numero)
        {
            int auxInt = Convert.ToInt32(numero);
            string retorno = Convert.ToString(auxInt, 2);
            Convert.ToInt32(numero);
            return retorno;
        }

        /// <summary>
        /// Suma dos números.
        /// </summary>
        /// <param name="numeroUno">Primer valor a sumar.</param>
        /// <param name="numeroDos">Segundo valor a sumar.</param>
        /// <returns>Retorna el resultado de la operación.</returns>
        public static double operator +(Numero numeroUno, Numero numeroDos)
        {
            return (numeroUno.numero + numeroDos.numero);
        }

        /// <summary>
        /// Resta dos numeros.
        /// </summary>
        /// <param name="numeroUno">Primer número a restar.</param>
        /// <param name="numeroDos">Segundo número a restar.</param>
        /// <returns>Retorna el resultado de la operación.</returns>
        public static double operator -(Numero numeroUno, Numero numeroDos)
        {
            return (numeroUno.numero - numeroDos.numero);
        }

        /// <summary>
        /// Multiplica dos números.
        /// </summary>
        /// <param name="numeroUno">Primer número a multiplicar.</param>
        /// <param name="numeroDos">Segundo número a multiplicar.</param>
        /// <returns>Retorna el resultado de la operación.</returns>
        public static double operator *(Numero numeroUno, Numero numeroDos)
        {
            return (numeroUno.numero * numeroDos.numero);
        }

        /// <summary>
        /// Realiza una división entro dos numeros.
        /// </summary>
        /// <param name="numeroUno">Dividendo.</param>
        /// <param name="numeroDos">Divisor.</param>
        /// <returns>Retorna el resultado de la operación.</returns>
        public static double operator /(Numero numeroUno, Numero numeroDos)
        {
            if(numeroDos.numero != 0)
            {
                return (numeroUno.numero / numeroDos.numero);
            }else
            {
                return double.MinValue;
            }      
        }
   
    }
}
