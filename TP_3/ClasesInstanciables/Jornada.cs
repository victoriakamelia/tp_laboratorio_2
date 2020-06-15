using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Propiedades
        /// <summary>
        /// Get y Set de la lista de Alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Get y Set de la Clase.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Get y Set de Profesor.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de Jornada.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor con parámetro de Jornada.
        /// </summary>
        /// <param name="clase">Clase de la Jornada.</param>
        /// <param name="instructor">Instructor de la Jornada.</param>
        public Jornada(Universidad.EClases clase, Profesor instructor): this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Guarda un archivo de texto con la información de una Jornada.
        /// </summary>
        /// <param name="jornada">Jornada a guardar.</param>
        /// <returns>Retorna verdadero si pudo guardar, caso contrario retorna falso.</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return (texto.Guardar("Jornada.txt", jornada.ToString()));
        }

        /// <summary>
        /// Lee un archivo de texto con la información de una Jornada y la guarda.
        /// </summary>
        /// <returns>String con el texto de la información de una Jornada</returns>
        public string Leer()
        {
            string jornada = "";
            Texto texto = new Texto();
            texto.Leer("Jornada.txt", out jornada);
            return jornada;
        }

        /// <summary>
        /// Override de "ToString" para mostrar los atributos de una Jornada.
        /// </summary>
        /// <returns>String con los atributos de una Jornada.</returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append($"CLASE DE {this.clase.ToString()} ");
            retorno.AppendLine($"POR {this.instructor.ToString()}");
            retorno.AppendLine("ALUMNOS:");
            foreach (Alumno alumno in this.alumnos)
            {
                retorno.AppendLine(alumno.ToString());
            }

            return retorno.ToString();
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Evalúa si un Alumno está en una Jornada.
        /// </summary>
        /// <param name="j">Jornada a evaluar.</param>
        /// <param name="a">Alumno a evaluar.</param>
        /// <returns>Retorna verdadero si encontró al Alumno en la jornada, caso contrario
        /// retorna falso.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumnoQueBusco in j.alumnos)
            {
                if (alumnoQueBusco == a)
                {
                    return true;
                }
                    
            }
            return false;
        }

        /// <summary>
        /// Evalúa si un Alumno está en una Jornada.
        /// </summary>
        /// <param name="j">Jornada a evaluar.</param>
        /// <param name="a">Alumno a evaluar.</param>
        /// <returns>Retorna verdadero si no encontró al Alumno en la jornada, caso contrario
        /// retorna falso.</returns>

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un Alumno a una Jornada, siempre y cuando no esté duplicado.
        /// </summary>
        /// <param name="j">Jornada a la que se quiere agregar un Alumno.</param>
        /// <param name="a">Alumno que se quiere agregar.</param>
        /// <returns>Retorna la Jornada a la que se quiere agregar un Alumno.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }else
            {
                throw new AlumnoRepetidoException();
            }
                
            return j;
        }
        #endregion
    }
}
