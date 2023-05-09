using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Login
    {
        #region ATRIBUTOS
        private List<Vendedor> vendedores;
        private List<Cliente> clientes;
        #endregion

        #region PROPIEDAD
        public Persona UsuarioActual { get; private set; }

        #endregion

        #region CONSTRUCTOR
        public Login()
        {
            // Hardcodear vendedor
            vendedores = new List<Vendedor>();
            Vendedor vendedor1 = new Vendedor("Juan", "juan@gmail.com", "vendedorvendedor1");
            vendedores.Add(vendedor1);

            // Hardcodear cliente
            clientes = new List<Cliente>();
            Cliente cliente1 = new Cliente("Mauro", "mauro@gmail.com", "clientecliente1");
            clientes.Add(cliente1);
        }
        #endregion

        #region MÉTODOS
        /// <summary>Busca un usuario por su correo y contraseña en las listas de vendedores y clientes.</summary>
        ///<param name = "correo" > Correo electrónico del usuario a buscar.</param>
        ///<param name = "contrasenia" > Contraseña del usuario a buscar.</param>
        ///<returns>Un objeto de tipo Persona que representa el usuario encontrado, o null si no se encontró un usuario con los datos proporcionados.</returns>
        public Persona BuscarUsuario(string correo, string contrasenia)
        {
            foreach (Vendedor vendedor in vendedores)
            {
                if (vendedor.Correo == correo && vendedor.Contrasenia == contrasenia)
                    return vendedor;
            }

            foreach (Cliente cliente in clientes)
            {
                if (cliente.Correo == correo && cliente.Contrasenia == contrasenia)
                    return cliente;
            }
            return null;
        }

        /// <summary>
        /// Intenta redirigir al usuario a su cuenta, verificando su correo y contraseña.
        /// </summary>
        /// <param name="correo">El correo del usuario.</param>
        /// <param name="contrasenia">La contraseña del usuario.</param>
        /// <returns>Verdadero si se puede redirigir al usuario, falso en caso contrario.</returns>
        public bool RedirigirUsuario(string correo,string contrasenia)
        {
            Persona usuario = BuscarUsuario(correo, contrasenia);

            if (usuario != null)
            {
                UsuarioActual = usuario;

                return true;
            }
            return false;
        }
        #endregion

    }
}
