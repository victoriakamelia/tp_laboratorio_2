using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Profesor.
        /// </summary>
        public Profesor() : base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
        }

        /// <summary>
        /// Constructor de clase de Profesor.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor con parámetros de Profesor.
        /// </summary>
        /// <param name="id">ID del Profesor.</param>
        /// <param name="nombre">Nombre del Profesor.</param>
        /// <param name="apellido">Apellido del Profesor.</param>
        /// <param name="dni">Dni del Profesor.</param>
        /// <param name="nacionalidad">Nacionalidad del Profesor.</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Carga Clases de forma aleatoria en la lista de clases de un Profesor.
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 3));
            }
        }

        /// <summary>
        /// Override de "MostrarDatos" de la clase base. Muestra los atributos de un Profesor.
        /// </summary>
        /// <returns>Retorna un string con los atributos de un Profesor.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.MostrarDatos());
            retorno.AppendLine(this.ParticiparEnClase());

            return retorno.ToString();
        }

        /// <summary>
        /// Override de "ParticiparEnClase" de la clase base. Muestra las clases del día de un Profesor.
        /// </summary>
        /// <returns>String con las clases del día de un Profesor.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("CLASES DEL DIA: ");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                retorno.AppendLine(clase.ToString());
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Override de "ToString" que permite generar accesibilidad a los atributos de un Profesor.
        /// </summary>
        /// <returns>String con las clases del día de un Profesor.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Evalúa si un profesor una clase en particular.
        /// </summary>
        /// <param name="i">Profesor a evaluar.</param>
        /// <param name="clase">Clase a evaluar.</param>
        /// <returns>Retorna verdadero si el Profesor da esa clase, caso contrario retorna falso.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases claseQueDa in i.clasesDelDia)
            {
                if (claseQueDa == clase)
                {
                    return true;
                }           
            }
            return false;
        }

        /// <summary>
        /// Evalúa si un profesor una clase en particular.
        /// </summary>
        /// <param name="i">Profesor a evaluar.</param>
        /// <param name="clase">Clase a evaluar.</param>
        /// <returns>Retorna verdadero si el Profesor no da esa clase, caso contrario retorna falso.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion

    }
}
