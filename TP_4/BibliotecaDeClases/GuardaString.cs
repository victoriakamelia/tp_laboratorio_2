using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
		/// <summary>
		/// Método de extensión de String.
		/// </summary>
		/// <param name="texto">Texto a guardar en el archivo.</param>
		/// <param name="archivo">Ruta del archivo. </param>
		/// <returns>Retorna verdadero si logró guardar, caso contrario lanza una excepción.</returns>
		public static bool Guardar(this string texto, string archivo)
		{
			StreamWriter writer = null;
			string rutaArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo;

			try
			{
				writer = new StreamWriter(rutaArchivo, true);
				writer.Write(texto);
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				if (!(writer is null))
				{
					writer.Close();
				}
					
			}
			return true;
		}
	}
}
