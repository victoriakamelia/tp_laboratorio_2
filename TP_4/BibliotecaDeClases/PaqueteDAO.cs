using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public static class PaqueteDAO
	{
		private static SqlCommand comando;
		private static SqlConnection conexion;

        #region Constructores

		/// <summary>
		/// Constructor de PaqueteDAO.
		/// </summary>
        static PaqueteDAO()
		{
			conexion = new SqlConnection(@"Server=localhost;Database=correo-sp-2017;Trusted_Connection=True;");
			comando = new SqlCommand();
			comando.Connection = conexion;
		}
        #endregion

        #region Métodos
		/// <summary>
		/// Método para insertar un paquete en la base de datos.
		/// </summary>
		/// <param name="p">Paquete a insertar.</param>
		/// <returns>Retorna verdadero si pudo insertar, caso contrario lanza una excepción.</returns>
        public static bool Insertar(Paquete p)
		{
			try
			{

				comando.CommandText = "INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES ( @direccionEntrega, @trackingID, @Alumno);";
				comando.Parameters.Clear();
				comando.Parameters.AddWithValue("@direccionEntrega", p.DireccionEntrega);
				comando.Parameters.AddWithValue("@trackingID", p.TrackingID);
				comando.Parameters.AddWithValue("@Alumno", "Victoria Pereyra");
				
				conexion.Open();

				SqlDataReader sqlReader = comando.ExecuteReader();
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				if (!(conexion is null))
					conexion.Close();
			}
			return true;
		}
        #endregion
    }
}