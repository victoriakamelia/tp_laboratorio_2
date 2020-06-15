using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public  sealed class Estacionamiento
    {
        public enum ETipo
        {
            Moto, Automovil, Camioneta, Todos
        }

        private int espacioDisponible;
        private List<Vehiculo> vehiculos;
        
        #region "Constructores"
        /// <summary>
        /// Constructor de la clase Estacionamiento.
        /// Inicializa la lista de Vehiculos.
        /// </summary>
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Constructor de la clase Estacionamiento.
        /// </summary>
        /// <param name="espacioDisponible">Espacio disponible del Estacionamiento.</param>
        public Estacionamiento(int espacioDisponible): this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido.
        /// </summary>
        /// <param name="unEstacionamiento">Elemento a exponer.</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar.</param>
        /// <returns></returns>
        public static string Mostrar(Estacionamiento unEstacionamiento, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", unEstacionamiento.vehiculos.Count, unEstacionamiento.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo unVehiculo in unEstacionamiento.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Camioneta:
                        if(unVehiculo is Camioneta)
                        {
                            sb.AppendLine(unVehiculo.Mostrar());
                        }
                        
                        break;
                    case ETipo.Moto:
                        if(unVehiculo is Moto)
                        {
                            sb.AppendLine(unVehiculo.Mostrar());
                        }
                        
                        break;
                    case ETipo.Automovil:
                        if(unVehiculo is Automovil)
                        {
                            sb.AppendLine(unVehiculo.Mostrar());
                        }
                        
                        break;
                    case ETipo.Todos:
                        sb.AppendLine(unVehiculo.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista.
        /// </summary>
        /// <param name="unEstacionamiento">Objeto donde se agregará el elemento.</param>
        /// <param name="unVehiculo">Objeto a agregar.</param>
        /// <returns>Retorna el Estacionamiento en donde pudo o no agregar un Vehiculo.</returns>
        public static Estacionamiento operator +(Estacionamiento unEstacionamiento, Vehiculo unVehiculo)
        {
            bool existeEnLista = false;
            if (unEstacionamiento.vehiculos.Count < unEstacionamiento.espacioDisponible)
            {
                foreach (Vehiculo vehiculoQueBusco in unEstacionamiento.vehiculos)
                {
                    if (vehiculoQueBusco == unVehiculo)
                    {
                        existeEnLista = true;
                    }
                }

                if (!existeEnLista)
                {
                    unEstacionamiento.vehiculos.Add(unVehiculo);
                }
            
            }

            return unEstacionamiento;
        }

        /// <summary>
        /// Quitará un elemento de la lista.
        /// </summary>
        /// <param name="unEstacionamiento">Objeto donde se quitará el elemento</param>
        /// <param name="unVehiculo">Objeto a quitar</param>
        /// <returns>Retorna el Estacionamiento en donde pudo o no quitar un Vehiculo.</returns>
        public static Estacionamiento operator -(Estacionamiento unEstacionamiento, Vehiculo unVehiculo)
        {
            foreach (Vehiculo vehiculoQueBusco in unEstacionamiento.vehiculos)
            {
                if (vehiculoQueBusco == unVehiculo)
                {
                    unEstacionamiento.vehiculos.Remove(vehiculoQueBusco);
                    break;
                }
            }

            return unEstacionamiento;
        }
        #endregion
    }
}