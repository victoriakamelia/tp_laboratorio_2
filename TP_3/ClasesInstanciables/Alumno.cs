using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta {AlDia, Deudor, Becado}

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region Constructores
        /// <summary>
        /// Constructor por defecto para Alumno.
        /// </summary>
        public Alumno(): base()
        {
            this.claseQueToma = default(Universidad.EClases);
            this.estadoCuenta = default(EEstadoCuenta);
        }

        /// <summary>
        /// Constructor con parámeros para Alumno.
        /// </summary>
        /// <param name="id">ID del Alumno.</param>
        /// <param name="nombre">Nombre del Alumno.</param>
        /// <param name="apellido">Apellido del Alumno.</param>
        /// <param name="dni">DNI del Alumnno.</param>
        /// <param name="nacionalidad">Nacionalidad del Alumno.</param>
        /// <param name="claseQueToma">Clase que toma el Alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">ID del Alumno.</param>
        /// <param name="nombre">Nombre del Alumno.</param>
        /// <param name="apellido">Apellido del Alumno.</param>
        /// <param name="dni">DNI del Alumnno.</param>
        /// <param name="nacionalidad">Nacionalidad del Alumno.</param>
        /// <param name="claseQueToma">Clase que toma el Alumno.</param>
        /// <param name="estadoCuenta">Estado de cuenta del Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Override del Método "MostrarDatos" de la Clase Base.
        /// Muestra los atributos de un Alumno.
        /// </summary>
        /// <returns>Retona un string con los atributos de un Alumno.</returns>
        protected override string MostrarDatos()
		{
			StringBuilder retorno = new StringBuilder();

			retorno.Append(base.MostrarDatos());
            if(this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                retorno.AppendLine("ESTADO DE CUENTA: Cuota al día");
            }
            else
            {
                retorno.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta.ToString()}");
            }
	
			retorno.AppendLine(this.ParticiparEnClase());
			return retorno.ToString();
		}

        /// <summary>
        /// Override del Método "ParticiparEnClase" de la Clase Base.
        /// </summary>
        /// <returns>Retorna un strin con la clase que toma el Alumno.</returns>
        protected override string ParticiparEnClase()
		{
			StringBuilder retorno = new StringBuilder();

			retorno.AppendLine($"TOMA CLASE DE {this.claseQueToma.ToString()}");

			return retorno.ToString();
		}

        /// <summary>
        /// Propociona accesibilidad a los datos generados en el método "MostrarDatos".
        /// </summary>
        /// <returns>Retorna un string con los atributos de un Alumno.</returns>
		public override string ToString()
		{
			return this.MostrarDatos();
		}

        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Evalúa si un Alumno está en una clase y si su estado de cuenta está al día.
        /// </summary>
        /// <param name="a">Alumno a evaluar.</param>
        /// <param name="clase">Clase a evaluar.</param>
        /// <returns>Devuelve verdadero si se encuentra en la clase y su estado de cuenta
        /// está al dia, caso contrario devuelve falso.</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (!(a != clase) && (a.estadoCuenta != EEstadoCuenta.Deudor));
        }

        /// <summary>
        /// Evalúa si un Alumno está en una clase.
        /// </summary>
        /// <param name="a">Alumno a evaluar.</param>
        /// <param name="clase">Clase a evaluar.</param>
        /// <returns>Devuelve verdadero si el alumno no está en la clase, caso
        /// contrario devuelve falso.</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a.claseQueToma == clase);
        }
        #endregion
    }
}
