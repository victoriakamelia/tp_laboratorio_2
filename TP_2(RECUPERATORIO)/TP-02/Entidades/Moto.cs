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
    public class Moto: Vehiculo
    {
        
        /// <summary>
        /// ReadOnly: retornará tamaño de la moto.
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Contructor de la clase Moto.
        /// </summary>
        /// <param name="marca">Marca de la moto.</param>
        /// <param name="chasis">Chasis de la moto.</param>
        /// <param name="color">Color de la moto.</param>
        public Moto(EMarca marca, string chasis, ConsoleColor color): base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Muestra los atributos de una Moto.
        /// </summary>
        /// <returns>Retorna un string con los atributos de una Moto.</returns>
        public  override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
