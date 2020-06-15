using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD}

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

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
		/// Get y Set de la lista de Profesores.
		/// </summary>
		public List<Profesor> Instructores
		{
			get
			{
				return this.profesores;
			}
			set
			{
				this.profesores = value;
			}
		}

		/// <summary>
		/// Get y Set de la lista de Jornadas.
		/// </summary>
		public List<Jornada> Jornadas
		{
			get
			{
				return this.jornada;
			}
			set
			{
				this.jornada = value;
			}
		}

		/// <summary>
		/// Get y Set de la lista de Jornada, accediendo por medio de un índice.
		/// </summary>
		/// <param name="i">índice.</param>
		/// <returns></returns>
		public Jornada this[int i]
		{
			get
			{
				return this.jornada[i];
			}
			set
			{
				this.jornada[i] = value;
			}
		}

		#endregion

		#region Constructores
		/// <summary>
		/// Constructor por defecto de Universidad.
		/// </summary>
		public Universidad()
		{
			this.alumnos = new List<Alumno>();
			this.jornada = new List<Jornada>();
			this.profesores = new List<Profesor>();
		}
		#endregion

		#region Métodos

		/// <summary>
		/// Guarda en un archivo xml una Universidad.
		/// </summary>
		/// <param name="universidad">Universidad a guardar.</param>
		/// <returns>Retorna verdadero si pudo guardar, caso contrario retorna falso.</returns>
		public static bool Guardar(Universidad universidad)
		{
			Xml<Universidad> xml = new Xml<Universidad>();
			return (xml.Guardar("Universidad.xml", universidad));
		}

		/// <summary>
		/// Lee de un archivo xml una Universidad.
		/// </summary>
		/// <returns>Retorna verdadero si pudo leer, caso contrario retorna falso.</returns>
		public static Universidad Leer()
		{
			Xml<Universidad> xml = new Xml<Universidad>();
			Universidad universidad = new Universidad();
			if (xml.Leer( "Universidad.xml", out universidad))
			{
				return universidad;
			}
			return universidad;

		}

		/// <summary>
		/// Override del método "MostrarDatos" de la Clase Base. Muestra los atributos de una Universidad.
		/// </summary>
		/// <param name="uni">Universidad a mostrar.</param>
		/// <returns>String con los atributos de una Universidad.</returns>
		private static string MostrarDatos(Universidad uni)
		{
			StringBuilder retorno = new StringBuilder();
			retorno.AppendLine("JORNADA:");
			foreach (Jornada jornada in uni.jornada)
			{
				retorno.AppendLine(jornada.ToString());
				retorno.AppendLine("<--------------------------------->\n");
			}
			return retorno.ToString();
		}

		/// <summary>
		/// Override de "ToString" para generar accesibilidad de "MostrarDatos" de Universidad.
		/// </summary>
		/// <returns>String con los atributos de una Universidad.</returns>
		public override string ToString()
		{
			return MostrarDatos(this);
		}
		#endregion

		#region Sobrecarga de operadores
		/// <summary>
		/// Evalúa si un Alumno existe en la Universidad.
		/// </summary>
		/// <param name="g">Universidad a evaluar.</param>
		/// <param name="a">Alumno a evaluar.</param>
		/// <returns>Retorna verdadero si el Alumno está, falso en el caso contrario.</returns>
		public static bool operator ==(Universidad g, Alumno a)
		{
			foreach (Alumno alumnoQueBusco in g.alumnos)
			{
				if (alumnoQueBusco == a)
				{
					return true;
				}
					
			}
			return false;
		}

		/// <summary>
		/// Evalúa si un Alumno existe en la Universidad.
		/// </summary>
		/// <param name="g">Universidad a evaluar.</param>
		/// <param name="a">Alumno a evaluar.</param>
		/// <returns>Retorna verdadero si el Alumno no está, falso en el caso contrario.</returns>
		public static bool operator !=(Universidad g, Alumno a)
		{
			return !(g == a);
		}

		/// <summary>
		/// Evalúa si un Profesor existe en la Universidad.
		/// </summary>
		/// <param name="g">Universidad a evaluar.</param>
		/// <param name="i">Profesor a evaluar.</param>
		/// <returns>Retorna verdadero si el Profesor está, falso en el caso contrario.</returns>
		public static bool operator ==(Universidad g, Profesor i)
		{
			foreach (Profesor profesorQueBusco in g.profesores)
			{
				if (profesorQueBusco == i)
				{
					return true;
				}
					
			}
			return false;
		}

		/// <summary>
		/// Evalúa si un Profesor existe en la Universidad.
		/// </summary>
		/// <param name="g">Universidad a evaluar.</param>
		/// <param name="i">Profesor a evaluar.</param>
		/// <returns>Retorna verdadero si el Profesor no está, falso en el caso contrario.</returns>
		public static bool operator !=(Universidad g, Profesor i)
		{
			return !(g == i);
		}

		/// <summary>
		/// Busca al primer Profesor capaz de dar la clase solicitada.
		/// </summary>
		/// <param name="u">Universidad a evaluar.</param>
		/// <param name="clase">Clase a evaluar.</param>
		/// <returns>Retorna al primer Profesor capaz de dar la clase solicitada, si no hay,
		/// lanza una excepción.</returns>
		public static Profesor operator ==(Universidad u, EClases clase)
		{
			foreach (Profesor profesorQueBusco in u.profesores)
			{
				if (profesorQueBusco == clase)
				{
					return profesorQueBusco;
				}					
			}
			throw new SinProfesorException();
		}

		// <summary>
		/// Busca al primer Profesor que no puede dar la clase solicitada.
		/// </summary>
		/// <param name="u">Universidad a evaluar.</param>
		/// <param name="clase">Clase a evaluar.</param>
		/// <returns>Retorna al primer Profesor que no puede dar la clase solicitada, si no hay,
		/// lanza una excepción.</returns>
		public static Profesor operator !=(Universidad g, EClases clase)
		{
			foreach (Profesor profesorQueBusco in g.profesores)
			{
				if (profesorQueBusco != clase)
				{
					return profesorQueBusco;
				}	
			}
			throw new SinProfesorException();
		}

		/// <summary>
		/// Se agrega una Jornada nueva a la Universidad para la clase solicitada.
		/// </summary>
		/// <param name="g">Universidad a la que se agregará la jornada.</param>
		/// <param name="clase">Clase solicitada.</param>
		/// <returns>Retorna una Universidad con la nueva Jornada, o no.</returns>
		public static Universidad operator +(Universidad g, EClases clase)
		{
			Jornada jornada = new Jornada(clase, g == clase);
			foreach (Alumno alumnoQueBusco in g.alumnos)
			{
				if (alumnoQueBusco == clase)
				{
					jornada += alumnoQueBusco;
				}					
			}
			g.jornada.Add(jornada);
			return g;
		}

		/// <summary>
		/// Se agrega un Alumno a la Universidad, siempre y cuando no se encuentre ya agregado.
		/// </summary>
		/// <param name="u">Universidad en la que se agregará el Alumno.</param>
		/// <param name="a">Alumno a agregar.</param>
		/// <returns>Retorna una Universidad con el nuevo Alumno, o no.</returns>
		public static Universidad operator +(Universidad u, Alumno a)
		{
			if (u != a)
			{
				u.alumnos.Add(a);
				return u;
			}
			
			throw new AlumnoRepetidoException();		
			
		}


		/// <summary>
		/// Se agrega un Profesor a la Universidad, siempre y cuando no se encuentre ya agregado.
		/// </summary>
		/// <param name="u">Universidad en la que se agregará el Profesor.</param>
		/// <param name="i">Profesor a agregar.</param>
		/// <returns>Retorna una Universidad con el nuevo Profesor, o no.</returns>
		public static Universidad operator +(Universidad u, Profesor i)
		{
			if (u != i)
			{
				u.profesores.Add(i);
			}
				
			return u;
		}

		#endregion
	}
}
