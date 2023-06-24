using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Entidades
{
    public class ClienteDAO : IBaseDeDatos<Cliente>
    {
        #region ATRIBUTO
        private SqlConnection connectionString;
        #endregion

        #region CONSTRUCTOR
        public ClienteDAO()
        {
            this.connectionString = new SqlConnection(IBaseDeDatos<Cliente>.ConexionBase());
        }
        #endregion

        #region MÉTODOS-GENÉRICOS

        /// <summary>
        /// Establece la conexión con la base de datos si no está abierta.
        /// </summary>
        /// <remarks>
        /// Verifica el estado de la conexión `connectionString` y la abre si no está abierta.
        /// </remarks>
        public void Conectar()
        {
            if (connectionString.State != ConnectionState.Open)
            {
                connectionString.Open();
            }
        }

        /// <summary>
        /// Cierra la conexión con la base de datos si está abierta.
        /// </summary>
        /// <remarks>
        /// Verifica el estado de la conexión `connectionString` y la cierra si está abierta.
        /// </remarks>
        public void Desconectar()
        {
            if (connectionString.State != ConnectionState.Closed)
            {
                connectionString.Close();
            }
        }

        /// <summary>
        /// Obtiene un cliente por su ID desde la base de datos.
        /// </summary>
        /// <param name="id">El ID del cliente que se desea obtener.</param>
        /// <returns>El cliente correspondiente al ID especificado.</returns>
        /// <remarks>
        /// Se crea un objeto de tipo Cliente inicializado como null.
        /// Se construye la consulta SQL para seleccionar el cliente con el ID especificado.
        /// Se establece la conexión con la base de datos mediante el método Conectar.
        /// Se utiliza un objeto de tipo SqlCommand para ejecutar la consulta SQL, pasando el parámetro @Id.
        /// Se utiliza un objeto de tipo SqlDataReader para leer los datos obtenidos.
        /// Si se encuentra un registro, se extrae el valor del campo "Saldo" y se crea una instancia de Cliente con ese saldo.
        /// Se cierra la conexión con la base de datos mediante el método Desconectar.
        /// Se devuelve el cliente obtenido, o null si no se encontró ningún registro con el ID especificado.
        /// </remarks>
        public Cliente ObtenerPorId(int id)
        {
            Cliente cliente = null;

            string query = "SELECT * FROM Clientes WHERE ID = @Id";

            Conectar();

            using (SqlCommand command = new SqlCommand(query, connectionString))
            {
                command.Parameters.AddWithValue("@Id",id);

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        double saldo = reader.GetDouble(reader.GetOrdinal("Saldo"));
                        cliente = new Cliente(saldo);
                    }
                }
            }
            Desconectar();

            return cliente;
        }

        /// <summary>
        /// Obtiene una lista de todos los clientes desde la base de datos.
        /// </summary>
        /// <returns>Una lista de clientes.</returns>
        /// <remarks>
        /// Se crea una lista vacía de clientes.
        /// Se establece la conexión con la base de datos mediante el método Conectar.
        /// Se construye la consulta SQL para seleccionar los datos necesarios de las tablas relacionadas.
        /// Se utiliza un objeto de tipo SqlCommand para ejecutar la consulta SQL.
        /// Se utiliza un objeto de tipo SqlDataReader para leer los datos obtenidos.
        /// Para cada registro leído, se crea una instancia de Cliente con los valores correspondientes de Nombre, Edad y Saldo.
        /// Se agrega el cliente a la lista de clientes.
        /// Finalmente, se cierra la conexión con la base de datos mediante el método Desconectar.
        /// Se devuelve la lista de clientes obtenida.
        /// Si ocurre algún error durante el proceso, se captura la excepción y se muestra un mensaje de error.
        /// </remarks>
        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                Conectar();
                string query = "SELECT P.Nombre,P.Edad,C.Saldo " +
               "FROM Clientes C " +
               "INNER JOIN Usuarios U ON U.IdCliente = C.ID " +
               "INNER JOIN Personas P ON U.IdPersona = P.ID";

                SqlCommand command = new SqlCommand(query, connectionString);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            Edad = (int)reader.GetInt32(reader.GetOrdinal("Edad")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Saldo = (float)reader.GetDouble(reader.GetOrdinal("Saldo"))
                        };

                        clientes.Add(cliente);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la lista de clientes: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }   

            return clientes;
        }
        #endregion

        #region MÉTODOS

        /// <summary>
        /// Obtiene el ID de un cliente por su nombre desde la base de datos.
        /// </summary>
        /// <param name="nombre">El nombre del cliente.</param>
        /// <returns>El ID del cliente correspondiente al nombre especificado.</returns>
        /// <remarks>
        /// Se inicializa el ID del cliente como 0.
        /// Se construye la consulta SQL para seleccionar el ID del cliente con el nombre especificado.
        /// Se establece la conexión con la base de datos mediante el método Conectar.
        /// Se utiliza un objeto de tipo SqlCommand para ejecutar la consulta SQL, pasando el parámetro @Nombre.
        /// Se utiliza un objeto de tipo SqlDataReader para leer los datos obtenidos.
        /// Si se encuentra un registro, se obtiene el valor del campo "ID" y se convierte a entero.
        /// Se cierra la conexión con la base de datos mediante el método Desconectar.
        /// Se devuelve el ID del cliente obtenido, o 0 si no se encontró ningún registro con el nombre especificado.
        /// Si ocurre algún error durante el proceso, se captura la excepción y se muestra un mensaje de error.
        /// </remarks>
        public int ObtenerIdCLientePorNombre(string nombre)
        {
            int idCliente = 0;
            string query = "SELECT c.ID FROM Usuarios u INNER JOIN Clientes c ON c.ID = u.IdCliente INNER JOIN Personas p ON u.IdPersona = p.ID WHERE p.Nombre = @Nombre";

            try
            {
                Conectar();

                using (SqlCommand command = new SqlCommand(query, connectionString))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idCliente = Convert.ToInt32(reader["ID"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el ID del cliente: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }

            return idCliente;
        }

        /// <summary>
        /// Actualiza el saldo de un cliente en la base de datos.
        /// </summary>
        /// <param name="idCliente">El ID del cliente.</param>
        /// <param name="nuevoSaldo">El nuevo saldo del cliente.</param>
        /// <remarks>
        /// Se construye la consulta SQL para actualizar el saldo del cliente con el ID especificado.
        /// Se establece la conexión con la base de datos mediante el método Conectar.
        /// Se utiliza un objeto de tipo SqlCommand para ejecutar la consulta SQL, pasando los parámetros @NuevoSaldo y @IdCliente.
        /// Se ejecuta el comando mediante el método ExecuteNonQuery.
        /// Se cierra la conexión con la base de datos mediante el método Desconectar.
        /// Si ocurre algún error durante el proceso, se captura la excepción y se muestra un mensaje de error.
        /// </remarks>
        public void ActualizarSaldoCliente(int idCliente, double nuevoSaldo)
        {
            string query = "UPDATE Clientes SET Saldo = @NuevoSaldo WHERE ID = @IdCliente";
            try
            {
                Conectar();

                using (SqlCommand command = new SqlCommand(query, connectionString))
                {
                    command.Parameters.AddWithValue("@NuevoSaldo", nuevoSaldo);
                    command.Parameters.AddWithValue("@IdCliente", idCliente);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el saldo del cliente: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        /// <summary>
        /// Obtiene el saldo de un cliente por su ID desde la base de datos.
        /// </summary>
        /// <param name="idCliente">El ID del cliente.</param>
        /// <returns>El saldo del cliente correspondiente al ID especificado.</returns>
        /// <remarks>
        /// Se inicializa el saldo como 0.0.
        /// Se construye la consulta SQL para seleccionar el saldo del cliente con el ID especificado.
        /// Se establece la conexión con la base de datos mediante el método Conectar.
        /// Se utiliza un objeto de tipo SqlCommand para ejecutar la consulta SQL, pasando el parámetro @IdCliente.
        /// Se utiliza un objeto de tipo SqlDataReader para leer los datos obtenidos.
        /// Si se encuentra un registro, se obtiene el valor del campo "Saldo" y se convierte a double.
        /// Se cierra la conexión con la base de datos mediante el método Desconectar.
        /// Se devuelve el saldo del cliente obtenido, o 0.0 si no se encontró ningún registro con el ID especificado.
        /// Si ocurre algún error durante el proceso, se captura la excepción y se muestra un mensaje de error.
        /// </remarks>
        public double ObtenerSaldoClientePorId(int idCliente)
        {
            double saldo = 0.0;

            string query = "SELECT Saldo FROM Clientes WHERE ID = @IdCliente";

            try
            {
                Conectar();

                using (SqlCommand command = new SqlCommand(query, connectionString))
                {
                    command.Parameters.AddWithValue("@IdCliente", idCliente);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            saldo = Convert.ToDouble(reader["Saldo"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el saldo del cliente: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }

            return saldo;
        }
        #endregion
    }
}
