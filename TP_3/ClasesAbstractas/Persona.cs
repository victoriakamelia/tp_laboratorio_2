using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
		public enum ENacionalidad{ Argentino, Extranjero}

		private ENacionalidad nacionalidad;
		private int dni;
		private string nombre;
		private string apellido;

		#region Propiedades

		/// <summary>
		/// Propiedad que devuelve o setea el atributo apellido.
		/// </summary>
		public string Apellido
		{
			get
			{
				return this.apellido;
			}
			set
			{
				this.apellido = ValidarNombreApellido(value);
			}
		}


		/// <summary>
		/// Propiedad que devuelve o setea el atributo dni.
		/// </summary>
		public int DNI
		{
			get
			{
				return this.dni;
			}
			set
			{
				this.dni = this.ValidarDni(this.Nacionalidad, value);
			}
		}

		/// <summary>
		/// Propiedad que devuelve o setea el tipo del atributo eNACionalidad.
		/// </summary>
		public ENacionalidad Nacionalidad
		{
			get
			{
				return this.nacionalidad;
			}
			set
			{
				this.nacionalidad = value;
			}
		}

		/// <summary>
		/// Propiedad que devuelve o setea el atributo nombre.
		/// </summary>
		public string Nombre
		{
			get
			{
				return this.nombre;
			}
			set
			{
				this.nombre = ValidarNombreApellido(value);
			}
		}

		/// <summary>
		/// Propiedad que setea el dni pasado en formato string.
		/// </summary>
		public string StringToDNI
		{
			set
			{
				this.dni = this.ValidarDni(this.Nacionalidad, value);
			}
		}

		#endregion

		#region Constructores
		/// <summary>
		/// Constructor para una Persona con valores por defecto.
		/// </summary>
		public Persona() : this("", "", default(ENacionalidad))
		{
			this.DNI = 0;
		}

		/// <summary>
		/// Constructor de una Persona con valores para nombre, apellido y nacionalidad.
		/// </summary>
		/// <param name="nombre">Nombre de Persona.</param>
		/// <param name="apellido">Apellido de Persona.</param>
		/// <param name="nacionalidad">Nacionalidad de Persona.</param>
		public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
		{
			this.Nombre = nombre;
			this.Apellido = apellido;
			this.Nacionalidad = nacionalidad;
		}

		/// <summary>
		/// Constructor de una Persona con valores para nombre, apellido, dni(int) y nacionalidad.
		/// </summary>
		/// <param name="nombre">Nombre de Persona.</param>
		/// <param name="apellido">Apellido de Persona.</param>
		/// <param name="dni">Dni de Persona.</param>
		/// <param name="nacionalidad">Nacionalidad de Persona.</param>
		public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
		{
			this.DNI = dni;
		}
		/// <summary>
		/// Constructor de una Persona con valores para nombre, apellido, dni(string) y nacionalidad.
		/// </summary>
		/// <param name="nombre">Nombre de Persona.</param>
		/// <param name="apellido">Apellido de Persona.</param>
		/// <param name="dni">Dni de Persona.</param>
		/// <param name="nacionalidad">Nacionalidad de Persona.</param>
		public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
		{
			this.StringToDNI = dni;
		}
		#endregion

		#region Métodos

		/// <summary>
		/// Devuelve los atributos cargados en una Persona.
		/// </summary>
		/// <returns>String con los atributos de una Persona.</returns>
		public override string ToString()
		{
			StringBuilder retorno = new StringBuilder();
			retorno.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
			retorno.AppendLine($"NACIONALIDAD: {this.Nacionalidad.ToString()}");

			return retorno.ToString();
		}

		/// <summary>
		/// Valida que el dni se encuentre entre los valores deseados. 
		/// </summary>
		/// <param name="nacionalidad">Tipo de nacionalidad.</param>
		/// <param name="dato">Dni a validar.</param>
		/// <returns>Retorna el dni en caso de que esté entre los valores deseados.</returns>
		private int ValidarDni(ENacionalidad nacionalidad, int dato)
		{
			switch (nacionalidad)
			{
				case ENacionalidad.Argentino:
					if (dato >= 0 && dato <= 89999999)
					{
						return dato;
					}
						
					break;

				case ENacionalidad.Extranjero:
					if (dato >= 90000000 && dato <= 99999999)
					{
						return dato;
					}
					
					break;
			}
			throw new NacionalidadInvalidaException();
		}

		/// <summary>
		/// Valida que el dni sea un valor que se pueda parsear a tipo int y lo retorna.
		/// </summary>
		/// <param name="nacionalidad">Tipo de nacionalidad.</param>
		/// <param name="dato">Dni string a validar y convertir.</param>
		/// <returns>Retorna el dni en caso de que pase las validaciones. /returns>
		private int ValidarDni(ENacionalidad nacionalidad, string dato)
		{
		
				if(int.TryParse(dato, out int dni))
				{
					return this.ValidarDni(nacionalidad, dni);
				}
				throw new DniInvalidoException();		

		}

		/// <summary>
		/// Valida que el string contenga sólo letras.
		/// </summary>
		/// <param name="dato">String a validar</param>
		/// <returns>Retorna un string recibido, en caso de ser válido, o un string vacío en caso de ser inválido.</returns>
		private string ValidarNombreApellido(string dato)
		{
			string soloLetras = "^[\\p{L}]+$";
			if (Regex.IsMatch(dato, soloLetras))
			{
				return dato;
			}else
			{
				return "";
			}

		}
		#endregion
	}
}
