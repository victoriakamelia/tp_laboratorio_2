using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores
        /// <summary>
        /// Constructor para un Universitario con valores por defecto.
        /// </summary>
        public Universitario() : this(0, "", "", "0", default(ENacionalidad))
        {

        }

        /// <summary>
        /// Constructor de un Universitario con valores para legajo, nombre, apellido, dni y nacionalidad.
        /// </summary>
        /// <param name="legajo">Legajo del Universitario.</param>
        /// <param name="nombre">Nombre del Universitario.</param>
        /// <param name="apellido">Apellido del Universitario.</param>
        /// <param name="dni">Dni del Universitario.</param>
        /// <param name="nacionalidad">Nacionalidad del Universitario.</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Devuelve un booleano con valor verdadero, si el objeto recibido es igual al objeto de la instancia, y falso
        /// si no lo es.
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns>Retorna verdadero si la comparación resultó igual, o falso si no resultó igual.</returns>
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType();
        }

        /// <summary>
        /// Devuelve un string con los datos de un Universitario.
        /// </summary>
        /// <returns>String con los datos de un Universitario.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(base.ToString());
            retorno.AppendLine($"LEGAJO NÚMERO: {this.legajo}");
            return retorno.ToString();
        }

        /// <summary>
        /// Método abstracto a implementar en clases derivadas.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Compara que dos Univertitarios tengan el mismo tipo, legajo o dni para devolver verdadero,
        /// caso contrario retorna falso.
        /// </summary>
        /// <param name="pg1">Primer Universitario a comparar.</param>
        /// <param name="pg2">Segundo Universitario a comparar.</param>
        /// <returns>Retorna verdadero si son del mismo tipo, y tienen el mismo legajo o dni, caso contrario
        /// retorna falso. </returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.Equals(pg2) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI));
        }

        /// <summary>
        /// Compara que dos Univertitarios tengan el mismo tipo, legajo o dni para devolver verdadero,
        /// caso contrario retorna falso.
        /// </summary>
        /// <param name="pg1">Primer Universitario a comparar.</param>
        /// <param name="pg2">Segundo Universitario a comparar.</param>
        /// <returns>Retorna verdadero si son del mismo tipo, y tienen el mismo legajo o dni, caso contrario
        /// retorna falso. </returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

    }
}
