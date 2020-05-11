using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }

        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        private string chasis;
        private ConsoleColor color;
        private EMarca marca;
        
        /// <summary>
        /// ReadOnly: Retornará el tamaño.
        /// </summary>
        protected abstract ETamanio Tamanio { get; }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="chasis">Recibe el valor a guardar en el atributo "chasis".</param>
        /// <param name="marca">Recibe el valor a guardar en el atributo "marca"</param>
        /// <param name="color">Recibe el valor a guardar en el atributo "color"</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>Retornará un srting con los datos del Vehiculo.</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Recibe un vehículo cuyos atributos serán devueltos por string.
        /// </summary>
        /// <param name="unVehiculo">Vehiculo a mostrar.</param>
        public static explicit operator string(Vehiculo unVehiculo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", unVehiculo.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", unVehiculo.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", unVehiculo.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis.
        /// </summary>
        /// <param name="vehiculoUno">Primer Vehiculo a comparar.</param>
        /// <param name="vehiculoDos">Segundo Vehiculo a comparar.</param>
        /// <returns>Bool informando si los vehículos son o no iguales.</returns>
        public static bool operator ==(Vehiculo vehiculoUno, Vehiculo vehiculoDos)
        {
            return (vehiculoUno.chasis == vehiculoDos.chasis);
        }

        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto.
        /// </summary>
        /// <param name="vehiculoUno">Primer Vehiculo a comparar</param>
        /// <param name="vehiculoDos">Segundo Vehiculo a comparar.</param>
        /// <returns>Bool informando si los vehículos son o no distintos.</returns>
        public static bool operator !=(Vehiculo vehiculoUno, Vehiculo vehiculoDos)
        {
            return !(vehiculoUno == vehiculoDos);
        }
    }
}
