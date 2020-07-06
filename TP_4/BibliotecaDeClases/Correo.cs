using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo: IMostrar<List<Paquete>>
	{
		private List<Thread> mockPaquete;
		private List<Paquete> paquetes;

		#region Propiedades
		/// <summary>
		/// Get y set del atributo paquetes.
		/// </summary>
		public List<Paquete> Paquetes
		{
			get
			{
				return this.paquetes;
			}
			set
			{
				this.paquetes = value;
			}
		}
		#endregion

		#region Constructores
		/// <summary>
		/// Constructor de Correo.
		/// </summary>
		public Correo()
		{
			this.mockPaquete = new List<Thread>();
			this.paquetes = new List<Paquete>();
		}
		#endregion

		#region Métodos

		/// <summary>
		/// Método que aborta los hilos vivos.
		/// </summary>
		public void FinEntregas()
		{
			foreach (Thread hiloVivo in mockPaquete)
			{
				if (hiloVivo.IsAlive)
				{
					hiloVivo.Abort();
				}
					
			}
		}

		/// <summary>
		/// Método que retorna un string con la lista de paquetes del correo.
		/// </summary>
		/// <param name="elementos"></param>
		/// <returns>String con la lista de paquetes del correo.</returns>
		public string MostrarDatos(IMostrar<List<Paquete>> elementos)
		{
			
			List<Paquete> paquetes = (List<Paquete>)((Correo)elementos).paquetes;
			StringBuilder retorno = new StringBuilder();
			retorno.Append(string.Empty);

			foreach (Paquete paqueteQueBusco in paquetes)
			{
				retorno.AppendLine(string.Format("{0} para {1} ({2})", paqueteQueBusco.TrackingID, paqueteQueBusco.DireccionEntrega, paqueteQueBusco.Estado.ToString()));
			}
			return retorno.ToString();
		}
		#endregion

		#region Operadores

		/// <summary>
		/// Sobrecarga del operador +, que agrega un paquete en el correo, siempre y cuando este no exista previamente. 
		/// </summary>
		/// <param name="c">Correo en el que se agregará el paquete.</param>
		/// <param name="p">´Paquete a agregar en el Correo.</param>
		/// <returns>Retorna el Correo que recibe por parámetros, con o sin modificaciones.</returns>
		public static Correo operator +(Correo c, Paquete p)
		{
			Thread thread;
			foreach (Paquete paqueteQueBusco in c.paquetes)
			{
				if (paqueteQueBusco == p)
				{
					throw new TrackingIdRepetidoException("Trackind Id repetido.");
				}
					
			}
			c.paquetes.Add(p);
			thread = new Thread(p.MockCicloDeVida);
			c.mockPaquete.Add(thread);
			thread.Start();

			return c;
		}
		#endregion

	}
}
