using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades
{
    /// <summary>
    /// Clase derivada de Vehiculo.
    /// </summary>
    public class Automovil : Vehiculo
    {
        public enum ETipo 
        { 
            Monovolumen, Sedan 
        }

        private ETipo tipo;

        /// <summary>
        /// ReadOnly: retornará tamaño del Automovil.
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Constructor de la clase Automovil.
        /// </summary>
        /// <param name="marca">Marca del Automovil.</param>
        /// <param name="chasis">Chasis del Automovil.</param>
        /// <param name="color">Color del Automovil.</param>
        /// <param name="tipo"><Tipo del Automovil./param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo): base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Constructor de la clase Automovil.
        /// Por defecto, "tipo" será Monovolumen.
        /// </summary>
        /// <param name="marca">Marca del Automovil.</param>
        /// <param name="chasis">Chasis del Automovil.</param>
        /// <param name="color">Color del Automovil.</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color): this (marca, chasis, color, ETipo.Monovolumen)
        { 
        }

        /// <summary>
        /// Muestra los atributos de un Automovil.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO: {0}\n", this.Tamanio);
            sb.AppendFormat("TIPO  : {0}",this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
