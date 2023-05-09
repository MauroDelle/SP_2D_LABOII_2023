using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vendedor : Persona
    {
        #region ATRIBUTOS
        private List<Cliente> listaClientes;
        private List<Producto> listaProductos;
        private List<Venta> historialVentas;
        #endregion

        #region CONSTRUCTORES

        public Vendedor(string nombre,string correo,string constrasenia):base(nombre,correo,constrasenia)
        {
            listaClientes= new List<Cliente>();
            listaProductos = new List<Producto>();
            historialVentas= new List<Venta>();
            CargarProductos();
            CargarClientes();
        }
        public Vendedor():this("Sin nombre", "Sin correo", "Sin contraseña")
        { 
            listaClientes = new List<Cliente>();
            ListaProductos = new List<Producto>();
            historialVentas = new List<Venta>();
        }
        #endregion

        #region PROPIEDADES
        public List<Venta> HistorialVentas { get { return this.historialVentas; } set { this.historialVentas = value; } }
        public List<Producto> ListaProductos { get { return this.listaProductos; } set { this.listaProductos = value; } }
        public List<Cliente> ListaClientes { get { return this.listaClientes; } set { this.listaClientes = value; } }
        #endregion

        #region MÉTODOS

        /// <summary>
        /// Determina si el objeto actual es una instancia de la clase Vendedor.
        /// </summary>
        /// <returns>Devuelve true si el objeto es una instancia de Vendedor, de lo contrario devuelve false.</returns>
        public override bool EsVendedor()
        {
            return true;
        }

        /// <summary>
        /// Método que se encarga de vender un producto a un cliente, actualizando la cantidad de producto disponible y el saldo del cliente.
        /// </summary>
        /// <param name="producto">El producto que se desea vender.</param>
        /// <param name="cantidad">La cantidad de producto que se desea vender.</param>
        /// <param name="cliente">El cliente que realiza la compra.</param>
        /// <returns>Retorna true si se pudo realizar la venta correctamente, false en caso contrario.</returns>
        public bool VenderProducto(Producto producto,double cantidad,Cliente cliente)
        {
            if(cliente == null || cantidad <= 0)
            {
                return false;
            }

            double precioTotal = producto.PrecioPorKilo * cantidad;

            if (cliente.Saldo < precioTotal)
            {
                return false;
            }
            // Validar que la cantidad seleccionada no exceda el stock disponible
            if (cantidad > producto.CantidadEnKilos)
            {
                return false;
            }
            producto.CantidadEnKilos -= cantidad;
            cliente.Saldo -= precioTotal;
            DateTime fecha = DateTime.Now;

            Venta venta = new Venta(producto, cantidad, precioTotal,fecha);
            AgregarVenta(venta);
            return true;
        }

        /// <summary>
        /// Método que permite reponer la cantidad de un producto en el stock actual.
        /// </summary>
        /// <param name="producto">El producto a reponer en el stock.</param>
        /// <param name="cantidad">La cantidad de producto a reponer.</param>
        /// <returns>Devuelve true si se pudo reponer el producto, false en caso contrario.</returns>
        public bool ReponerProducto(Producto producto, double cantidad)
        {
            if (producto == null || cantidad <= 0)
            {
                return false;
            }
            producto.CantidadEnKilos += cantidad;
            return true;
        }

        /// <summary>
        /// Agrega una lista de clientes predefinidos a la lista de clientes del sistema.
        /// </summary>
        public void CargarClientes()
        {
            ListaClientes.Add(new Cliente("Juan",5000));
            ListaClientes.Add(new Cliente("María",7000));
            ListaClientes.Add(new Cliente("Carlos",3000));
            ListaClientes.Add(new Cliente("Mauro",4070));
            ListaClientes.Add(new Cliente("Claudio",5600));
            ListaClientes.Add(new Cliente("Camila",10560));
            ListaClientes.Add(new Cliente("Karina",10340));
            ListaClientes.Add(new Cliente("Aurora",6438));
            ListaClientes.Add(new Cliente("Hugo",5600));
            ListaClientes.Add(new Cliente("Fermín",5400));
        }

        /// <summary>
        /// Agrega una lista de productos predefinidos a la lista de productos del sistema.
        /// </summary>
        public void CargarProductos()
        {
            ListaProductos.Add(new Producto("Asado", 1700, 10, TipoCorteCarne.Vacuno));
            ListaProductos.Add(new Producto("Vacio", 2000, 6, TipoCorteCarne.Vacuno));
            ListaProductos.Add(new Producto("Cuadril", 2500, 4, TipoCorteCarne.Vacuno));
            ListaProductos.Add(new Producto("Falda", 1200, 15, TipoCorteCarne.Vacuno));
            ListaProductos.Add(new Producto("Pechuga", 900, 10, TipoCorteCarne.Ave));
            ListaProductos.Add(new Producto("Bondiola", 1650, 15, TipoCorteCarne.Vacuno));
            ListaProductos.Add(new Producto("Matambre", 1500, 9, TipoCorteCarne.Cerdo));
            ListaProductos.Add(new Producto("Matambre", 2500, 6, TipoCorteCarne.Vacuno));
            ListaProductos.Add(new Producto("Peceto", 3000, 8, TipoCorteCarne.Vacuno));
        }

        /// <summary>
        /// Busca un cliente en la lista de clientes por su nombre y devuelve el cliente encontrado.
        /// </summary>
        /// <param name="clienteRecibido">Cliente a buscar.</param>
        /// <returns>Devuelve el cliente encontrado o null si no existe.</returns>
        public Cliente ObtenerClientePorNombre(Cliente clienteRecibido)
        {
            foreach (Cliente cliente in ListaClientes)
            {
                if (cliente.Nombre == clienteRecibido.Nombre)
                {
                    return cliente;
                }
            }
            return null;
        }

        //public List<Producto> ObtenerProductosDisponibles()
        //{
        //    List<Producto> productosDisponibles = new List<Producto>();

        //    foreach (Producto producto in listaProductos)
        //    {
        //        if(producto.CantidadEnKilos > 0)
        //        {
        //            productosDisponibles.Add(producto);
        //        }
        //    }
        //    return productosDisponibles;
        //}

        /// <summary>
        /// Agrega una venta al historial de ventas del vendedor.
        /// </summary>
        /// <param name="venta">La venta a agregar.</param>
        public void AgregarVenta(Venta venta)
        {
            historialVentas.Add(venta);
        }

        /// <summary>
        /// Retorna el historial completo de ventas realizadas por el vendedor.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Venta que representan el historial de ventas realizadas por el vendedor.</returns>
        public List<Venta> ObtenerHistorialVenta()
        {
            return this.historialVentas;
        }
        #endregion
    }
}
