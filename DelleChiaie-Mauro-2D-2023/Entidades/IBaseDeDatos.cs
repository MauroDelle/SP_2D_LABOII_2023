using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IBaseDeDatos<T> where T : class
    {
        /// <summary>
        /// Devuelve la cadena de conexión para la base de datos de la Carnicería.
        /// </summary>
        /// <returns>La cadena de conexión para la base de datos.</returns>
        /// <remarks>
        /// La cadena de conexión contiene la información necesaria para establecer la conexión con la base de datos de la Carnicería.
        /// Incluye el origen de datos (Data Source) que en este caso es "localhost", el nombre de la base de datos (Database) que es "CarniceriaDB",
        /// y la configuración de conexión segura a través de Windows Authentication (Trusted_Connection=True).
        /// </remarks>
        static string ConexionBase()
        {
            return @"Data Source=localhost;Database=CarniceriaDB;Trusted_Connection=True;";
        }

        #region GENERICS
        void Conectar();
        void Desconectar();
        T ObtenerPorId(int id);
        List<T> ObtenerTodos();
        #endregion
    }
}
