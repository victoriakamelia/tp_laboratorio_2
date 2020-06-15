using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
		/// <summary>
		/// Guarda en un archivo el texto pasado por parámetros en la ruta solicitada.
		/// </summary>
		/// <param name="archivo">Ruta solicitada.</param>
		/// <param name="datos">Texto a guardar en el archivo.</param>
		/// <returns>Retorna verdadero si pudo o lanza una excepción.</returns>
		public bool Guardar(string archivo, string datos)
		{
			StreamWriter escritura = null;
			try
			{
				escritura = new StreamWriter(archivo);
				escritura.Write(datos);
			}
			catch (Exception ex)
			{
				throw new ArchivosException(ex);
			}
			finally
			{
				if (!(escritura is null))
					escritura.Close();
			}
			return true;
		}

		/// <summary>
		/// Lee un archivo de la ruta solicitada y guarda lo leído.
		/// </summary>
		/// <param name="archivo">Ruta solicitada.</param>
		/// <param name="datos">Variable en la que se guardará el texto leído.</param>
		/// <returns>Retorna verdadero si pudo o lanza una excepción.</returns>
		public bool Leer(string archivo, out string datos)
		{
			StreamReader lectura = null;
			datos = "";

			try
			{
				lectura = new StreamReader(archivo);
				datos = lectura.ReadToEnd();
			}
			catch (Exception ex)
			{
				throw new ArchivosException(ex);
			}
			finally
			{
				if (!(lectura is null))
					lectura.Close();
			}
			return true;
		}
	}
}
