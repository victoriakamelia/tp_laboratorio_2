using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Entidades
{
	public class Paquete : IMostrar<Paquete>
	{
		public enum EEstado
		{
			Ingresado,
			EnViaje,
			Entregado
		}

		public delegate void DelegadoEstado(object sender, EventArgs e);
		public delegate void DelegadoError(string mensaje);
		public event DelegadoEstado InformaEstado;
		public event DelegadoError ocurrioError;

		public string direccionEntrega;
		public EEstado estado;
		public string trackingID;

		#region Propiedades

		/// <summary>
		/// Propiedad el atributo direccionDeEntrega.
		/// </summary>
		public string DireccionEntrega
		{
			get
			{
				return this.direccionEntrega;
			}
			set
			{
				this.direccionEntrega = value;
			}
		}

		/// <summary>
		/// Propiedad el atributo estado.
		/// </summary>
		public EEstado Estado
		{
			get
			{
				return this.estado;
			}
			set
			{
				this.estado = value;
			}
		}

		/// <summary>
		/// Propiedad el atributo trackingID.
		/// </summary>
		public string TrackingID
		{
			get
			{
				return this.trackingID;
			}
			set
			{
				this.trackingID = value;
			}
		}

		#endregion

		#region Constructores

		/// <summary>
		/// Constructor de Paquete.
		/// </summary>
		/// <param name="direccionEntrega">Diercción de entrega de Paquete.</param>
		/// <param name="trackingID">Tracking Id de Paquete.</param>
		public Paquete(string direccionEntrega, string trackingID)
		{
			this.estado = default(EEstado);
			this.direccionEntrega = direccionEntrega;
			this.trackingID = trackingID;
		}

		#endregion

		#region Métodos

		/// <summary>
		/// Método que cambia el estado de un paquete cada 4 segundos. Una vez en estado Entregado, lo inserta en la base de datos.
		/// </summary>
		public void MockCicloDeVida()
		{
			while (this.Estado != EEstado.Entregado)
			{
				Thread.Sleep(4000);
				this.estado++;
				this.InformaEstado.Invoke(this, null);
			}
			try
			{
				PaqueteDAO.Insertar(this);
			}
			catch (Exception e)
			{
				this.ocurrioError(e.Message);
			}
		}

		/// <summary>
		/// Override de ToString.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this.MostrarDatos((IMostrar<Paquete>)this);
		}

		/// <summary>
		/// Muestra los atributos de un Paquete.
		/// </summary>
		/// <param name="elemento">Paquete a mostrar.</param>
		/// <returns>String con los atributos de un Paquete.</returns>
		public string MostrarDatos(IMostrar<Paquete> elemento)
		{
			Paquete paquete = (Paquete)elemento;
			string retorno = string.Format("{0} para {1}\r\n", paquete.trackingID, paquete.direccionEntrega);
			return retorno;
		}
		#endregion

		#region Sobrecarga de operadores

		/// <summary>
		/// Sobrecarga del operador == para verificar si un paquete tiene el mismo ID que otro.
		/// </summary>
		/// <param name="p1">Primer paquete a comparar.</param>
		/// <param name="p2">Segundo paquete a comparar.</param>
		/// <returns>Retorna verdadero si los paquetes tienen el mismo ID, caso contrario retorna falso.</returns>
		public static bool operator ==(Paquete p1, Paquete p2)
		{
			return (p1.TrackingID == p2.TrackingID);
		}

		/// <summary>
		/// Sobrecarga del operador != para verificar si un paquete tiene el mismo ID que otro.
		/// </summary>
		/// <param name="p1">Primer paquete a comparar.</param>
		/// <param name="p2">Segundo paquete a comparar.</param>
		/// <returns>Retorna verdadero si los paquetes no tienen el mismo ID, caso contrario retorna falso.</returns>

		public static bool operator !=(Paquete p1, Paquete p2)
		{
			return !(p1 == p2);
		}
		#endregion
	}
}