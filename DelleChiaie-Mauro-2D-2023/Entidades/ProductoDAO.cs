using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace Entidades
{
    public class ProductoDAO : IBaseDeDatos<Producto>
    {
        #region ATRIBUTOS
        private IBaseDeDatos<Producto> baseDeDatos;
        private SqlConnection connectionString;
        #endregion

        #region CONSTRUCTOR
        public ProductoDAO()
        {
            this.connectionString = new SqlConnection(IBaseDeDatos<Producto>.ConexionBase());
        }
        #endregion

        #region GENERICS


        /// <summary>
        /// Establece la conexión con la base de datos si no está abierta.
        /// </summary>
        public void Conectar()
        {
            if (connectionString.State != ConnectionState.Open)
            {
                connectionString.Open();
            }
        }

        /// <summary>
        /// Cierra la conexión con la base de datos si no está cerrada.
        /// </summary>
        public void Desconectar()
        {
            if(connectionString.State != ConnectionState.Closed)
            {
                connectionString.Close();
            }
        }

        /// <summary>
        /// Obtiene un producto de la base de datos por su ID.
        /// </summary>
        /// <param name="id">ID del producto a obtener.</param>
        /// <returns>El producto encontrado, o el valor predeterminado si no se encuentra ningún producto con el ID especificado.</returns>
        public Producto ObtenerPorId(int id)
        {
            Producto producto = default(Producto);

            string query = "SELECT * FROM Productos WHERE ID = @Id";

            Conectar();

            using (SqlCommand command = new SqlCommand(query, connectionString))
            {
                command.Parameters.AddWithValue("@Id", id);

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        producto = new Producto
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("ID")),
                            Nombre = reader.GetString(reader.GetOrdinal("NombreCorte")),
                            PrecioPorKilo = reader.GetDouble(reader.GetOrdinal("Precio")),
                            CantidadEnKilos = reader.GetDouble(reader.GetOrdinal("Cantidad")),
                            TipoCorte = reader.GetString(reader.GetOrdinal("TipoCorte"))
                        };
                    }
                }
            }
            Desconectar();

            return producto;
        }

        /// <summary>
        /// Obtiene todos los productos de la base de datos.
        /// </summary>
        /// <returns>Una lista de productos.</returns>
        public List<Producto> ObtenerTodos()
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                Conectar();
                string query = "SELECT * FROM Productos";
                SqlCommand command = new SqlCommand(query, connectionString);

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Producto producto = new Producto
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("ID")),
                            Nombre = reader.GetString(reader.GetOrdinal("NombreCorte")),
                            PrecioPorKilo = reader.GetDouble(reader.GetOrdinal("Precio")),
                            CantidadEnKilos = reader.GetDouble(reader.GetOrdinal("Cantidad")),
                            TipoCorte = reader.IsDBNull(reader.GetOrdinal("TipoCorte")) ? null : reader.GetString(reader.GetOrdinal("TipoCorte"))
                        };
                        productos.Add(producto);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones (puedes personalizarlo según tus necesidades)
                Console.WriteLine("Error al obtener la lista de productos: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }

            return productos;
        }


        #endregion

        #region MÉTODOS


        /// <summary>
        /// Agrega un nuevo producto a la base de datos.
        /// </summary>
        /// <param name="producto">El producto a agregar.</param>
        public void AgregarProducto(Producto producto)
        {
            try
            {
                Conectar();

                string query = "INSERT INTO Productos (NombreCorte,Precio,Cantidad,TipoCorte)" +
                               "VALUES (@Nombre,@Precio,@Cantidad,@TipoCorte)";
                SqlCommand command = new SqlCommand(@query, connectionString);  

                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Precio",producto.PrecioPorKilo);
                command.Parameters.AddWithValue("@Cantidad",producto.CantidadEnKilos);
                command.Parameters.AddWithValue("@TipoCorte",producto.TipoCorte ?? (object)DBNull.Value);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al agregar el producto: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        /// <summary>
        /// Elimina un producto de la base de datos por su ID.
        /// </summary>
        /// <param name="id">El ID del producto a eliminar.</param>
        public void EliminarProducto(int id)
        {
            try
            {
                Conectar();
                string query = "DELETE FROM Productos WHERE ID = @Id";

                SqlCommand command = new SqlCommand(query, connectionString);

                command.Parameters.AddWithValue("@Id",id);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el producto: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        /// <summary>
        /// Modifica un producto existente en la base de datos.
        /// </summary>
        /// <param name="producto">El producto con los nuevos valores a modificar.</param>
        public void ModificarProducto(Producto producto)
        {
            try
            {
                Conectar();

                string query = "UPDATE Productos SET NombreCorte = @Nombre, Precio = @Precio, Cantidad = @Cantidad, TipoCorte = @TipoCorte WHERE ID = @Id";

                SqlCommand command = new SqlCommand(query, connectionString);

                command.Parameters.AddWithValue("@Id", producto.Id);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Precio", producto.PrecioPorKilo);
                command.Parameters.AddWithValue("@Cantidad", producto.CantidadEnKilos);
                command.Parameters.AddWithValue("@TipoCorte", (object)producto.TipoCorte ?? DBNull.Value);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar el producto: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        /// <summary>
        /// Actualiza la cantidad de un producto en la base de datos.
        /// </summary>
        /// <param name="producto">El producto con la nueva cantidad a actualizar.</param>
        public void ActualizarCantidadProducto(Producto producto)
        {
            try
            {
                Conectar();

                // Actualizar la cantidad del producto en la base de datos
                string query = "UPDATE Productos SET Cantidad = @cantidad WHERE ID = @id";
                SqlCommand command = new SqlCommand(query, connectionString);
                command.Parameters.AddWithValue("@cantidad", producto.CantidadEnKilos);
                command.Parameters.AddWithValue("@id", producto.Id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la cantidad del producto: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        /// <summary>
        /// Actualiza la cantidad de un producto en la base de datos.
        /// </summary>
        /// <param name="producto">El producto con la nueva cantidad a actualizar.</param>
        public void ActualizarEnBaseDeDatos(Producto producto)
        {
            try
            {
                Conectar();

                string query = "UPDATE Productos SET Cantidad = @Cantidad WHERE ID = @Id";

                SqlCommand command = new SqlCommand(query, connectionString);

                command.Parameters.AddWithValue("@Cantidad", producto.CantidadEnKilos);
                command.Parameters.AddWithValue("@Id", producto.Id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el producto en la base de datos: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        /// <summary>
        /// Obtiene una lista de productos que coinciden con el nombre o tipo de corte especificado.
        /// </summary>
        /// <param name="nombre">El nombre o tipo de corte a buscar.</param>
        /// <returns>Una lista de productos que coinciden con el nombre o tipo de corte especificado.</returns>
        public List<Producto> ObtenerProductosPorNombre(string nombre)
        {
            List<Producto> productos = new List<Producto>();
            Conectar();

            string query = "SELECT * FROM Productos WHERE NombreCorte LIKE @Nombre OR TipoCorte LIKE @Nombre";
            SqlCommand command = new SqlCommand(query, connectionString);
            command.Parameters.AddWithValue("@Nombre",nombre);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("ID"));
                    string nombreP = reader.GetString(reader.GetOrdinal("NombreCorte"));
                    double precioPorKilo = reader.GetDouble(reader.GetOrdinal("Precio"));
                    double cantidadEnKilos = reader.GetDouble(reader.GetOrdinal("Cantidad"));
                    string tipoCorte = reader.IsDBNull(reader.GetOrdinal("TipoCorte")) ? null : reader.GetString(reader.GetOrdinal("TipoCorte"));

                    Producto producto = new Producto(id, nombreP, precioPorKilo,cantidadEnKilos,tipoCorte);
                    productos.Add(producto);
                }
            }

            Desconectar();
            return productos;
        }

        #endregion

    }
}
