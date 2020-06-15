using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
		/// <summary>
		/// Guarda en un archivo xml el objeto pasado por parámetros en la ruta solicitada.
		/// </summary>
		/// <param name="archivo">Ruta solicitada.</param>
		/// <param name="datos">Objeto a guardar.</param>
		/// <returns>Retorna verdadero si pudo o lanza una excepción.</returns>
		public bool Guardar(string archivo, T datos)
		{
			XmlSerializer serializacion = new XmlSerializer(typeof(T));
			XmlTextWriter writer = null;
			try
			{
				writer = new XmlTextWriter(archivo, Encoding.UTF8);
				serializacion.Serialize(writer, datos);
			}
			catch (Exception e)
			{
				throw new ArchivosException(e);
			}
			finally
			{
				if (!(writer is null))
					writer.Close();
			}
			return true;
		}

		/// <summary>
		/// Lee un archivo xml en la ruta solicitada y guarda lo leído.
		/// </summary>
		/// <param name="archivo">Ruta solicitada.</param>
		/// <param name="datos">Objeto que guardará lo leído.</param>
		/// <returns>Retorna verdadero si pudo o lanza una excepción.</returns>
		public bool Leer(string archivo, out T datos)
		{
			XmlSerializer serializacion = new XmlSerializer(typeof(T));
			XmlTextReader reader = null;
			datos = default(T);
			try
			{
				reader = new XmlTextReader(archivo);
				datos = (T)serializacion.Deserialize(reader);
			}
			catch (Exception e)
			{
				throw new ArchivosException(e);
			}
			finally
			{
				if (!(reader is null))
					reader.Close();
			}
			return true;
		}
	}
}
