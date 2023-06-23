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
        public Login(int id,string nombre, string correo,string contrasenia,int idPersona,int idCliente):base(id,nombre,correo,contrasenia,idPersona,idCliente)
        {
            this.id = id;
            this.nombre = nombre;
            this.correo = correo;
            this.contrasenia = contrasenia;
            this.idPersona = idPersona;
        }
        public Login() : base(0,"","","",0,0)
        {

        }

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


    }
}
