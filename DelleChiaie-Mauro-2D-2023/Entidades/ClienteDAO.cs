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
        private SqlConnection connectionString;

        public ClienteDAO()
        {
            this.connectionString = new SqlConnection(IBaseDeDatos<Cliente>.ConexionBase());
        }

        public void Conectar()
        {
            if (connectionString.State != ConnectionState.Open)
            {
                connectionString.Open();
            }
        }
        public void Desconectar()
        {
            if (connectionString.State != ConnectionState.Closed)
            {
                connectionString.Close();
            }
        }
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



    }
}
