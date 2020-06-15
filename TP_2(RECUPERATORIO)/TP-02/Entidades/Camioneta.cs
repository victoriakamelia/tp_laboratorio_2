using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase derivada de Vehiculo.
    /// </summary>
    public class Camioneta : Vehiculo
    {

        /// <summary>
        /// ReadOnly: retornará tamaño de la Camioneta.
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Constructor de la clase Camioneta.
        /// </summary>
        /// <param name="marca">Marca de la Camioneta.</param>
        /// <param name="chasis">Chasis de la Camioneta.</param>
        /// <param name="color">Color de la Camioneta.</param>
        public Camioneta(EMarca marca, string chasis, ConsoleColor color): base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Muestra los atributos de una Camioneta.
        /// </summary>
        /// <returns>Retorna un string con los atributos de una Camioneta.</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); ;
        }
    }
}
