using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Entidades
{
    public class Login : Usuario
    {

        #region CONSTRUCTORES
        public Login() : base(0,"","","",0,0)
        {

        }
        public Login(int id,string nombre, string correo,string contrasenia,int idPersona,int idCliente):base(id,nombre,correo,contrasenia,idPersona,idCliente)
        {
            this.id = id;
            this.nombre = nombre;
            this.correo = correo;
            this.contrasenia = contrasenia;
            this.idPersona = idPersona;
        }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Autentica al usuario utilizando el correo electrónico y la contraseña proporcionados.
        /// </summary>
        /// <param name="correo">El correo electrónico del usuario.</param>
        /// <param name="contrasenia">La contraseña del usuario.</param>
        /// <param name="esVendedor">Salida que indica si el usuario autenticado es un vendedor.</param>
        /// <returns>True si la autenticación es exitosa, False en caso contrario.</returns>
        /// <remarks>
        /// Este método verifica si el correo electrónico y la contraseña proporcionados coinciden con los registros de la base de datos.
        /// Si la autenticación es exitosa, devuelve True y establece el valor de "esVendedor" en True si el usuario es un vendedor.
        /// En caso de error durante la autenticación, se maneja la excepción y se devuelve False.
        /// </remarks>
        public bool AutenticarUsuario(string correo,string contrasenia, out bool esVendedor)
        {
            esVendedor = false;

            string connectionString = @"Data Source=localhost;Database=CarniceriaDB;Trusted_Connection=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT P.IdPuesto FROM Usuarios U " +
                                   "INNER JOIN Personas P ON U.IdPersona = P.ID " +
                                   "WHERE U.Mail = @Correo AND U.Contrasenia = @Contrasenia";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Correo", correo);
                    command.Parameters.AddWithValue("@Contrasenia", contrasenia);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idPuesto = reader.GetInt32(0);
                            // Verificar si es vendedor
                            if (idPuesto == 2)
                            {
                                esVendedor = true;
                            }
                            return true; // Autenticación exitosa
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                Console.WriteLine("Error durante la autenticación: " + ex.Message);
            }
            return false;
        }
        #endregion
    }
}
