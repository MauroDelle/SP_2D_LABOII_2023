using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : Usuario
    {
        #region ATRIBUTOS
        private int edad;
        private double saldo;
        private List<Producto> carritoDeProductos;
        #endregion

        #region CONSTRUCTORES
        public Cliente():base(0, "", "", "", 0, 0)
        {
            carritoDeProductos = new List<Producto>();
        }

        public Cliente(double saldo):base(0, "", "", "", 0, 0)
        {
            this.Saldo = 0;
            //ventasRealizadas = new List<Venta>();   
        }
        #endregion

        #region PROPIEDADES
        public double Saldo { get => saldo; set => saldo = value; }
        public int Edad { get => edad; set => edad = value; }
        public List<Producto> CarritoDeProductos { get => carritoDeProductos; set => carritoDeProductos = value; }
        #endregion

        #region MÉTODOS
        /// <summary>
        /// Carga la lista de clientes desde el origen de datos.
        /// </summary>
        /// <returns>La lista de clientes cargada.</returns>
        /// <remarks>
        /// Se utiliza un objeto de la clase ClienteDAO para obtener todos los clientes desde el origen de datos.
        /// El método devuelve la lista de clientes obtenida.
        /// </remarks>
        public List<Cliente> CargarClientes()
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            List<Cliente> clientes = clienteDAO.ObtenerTodos();
            return clientes;
        }

        /// <summary>
        /// Agrega un producto al carrito de compras.
        /// </summary>
        /// <param name="producto">El producto que se desea agregar al carrito.</param>
        /// <param name="cantidad">La cantidad del producto que se desea agregar.</param>
        /// <remarks>
        /// Crea un nuevo objeto Producto con la información del producto proporcionado,
        /// incluyendo el ID, nombre, precio por kilo, cantidad y tipo de corte.
        /// A continuación, agrega el producto al carrito de productos.
        /// </remarks>
        public void AgregarProductoAlCarrito(Producto producto, double cantidad)
        {
            carritoDeProductos.Add(new Producto(producto.Id,producto.Nombre,producto.PrecioPorKilo,cantidad,producto.TipoCorte));
        }

        /// <summary>
        /// Calcula el monto total de la compra.
        /// </summary>
        /// <param name="esPagoConCredito">Indica si el pago se realizará con tarjeta de crédito.</param>
        /// <param name="carritoDeProductos">La lista de productos en el carrito de compras.</param>
        /// <returns>El monto total de la compra.</returns>
        /// <remarks>
        /// Calcula el monto total de la compra sumando el precio por kilo de cada producto en el carrito,
        /// multiplicado por la cantidad en kilos de cada producto.
        /// Si el pago se realiza con tarjeta de crédito, se agrega un recargo del 5% al monto total.
        /// Devuelve el monto total de la compra.
        /// </remarks>
        public double CalcularMontoTotal(bool esPagoConCredito, List<Producto> carritoDeProductos)
        {
            double montoTotal = 0;

            foreach (Producto producto in carritoDeProductos)
            {
                montoTotal += producto.PrecioPorKilo * producto.CantidadEnKilos;
            }
            if (esPagoConCredito)
            {
                montoTotal += montoTotal * 0.05;
            }
            return montoTotal;
        }

        /// <summary>
        /// Realiza una compra con los productos del carrito de compras.
        /// </summary>
        /// <param name="esPagoConCredito">Indica si el pago se realizará con tarjeta de crédito.</param>
        /// <param name="carritoDeProductos">La lista de productos en el carrito de compras.</param>
        /// <exception cref="Exception">Se lanza una excepción si ocurre algún error durante la compra.</exception>
        /// <remarks>
        /// Crea una lista de ventas realizadas para almacenar los detalles de cada venta.
        /// Se utiliza un objeto de la clase ProductoDAO para obtener información adicional de los productos desde la base de datos.
        /// Se obtiene la fecha actual como fecha de venta.
        /// Se calcula el monto total de la compra utilizando el método CalcularMontoTotal.
        /// Se verifica si el cliente tiene suficiente saldo para la compra y se lanza una excepción si no es así.
        /// Para cada producto en el carrito de compras, se realiza lo siguiente:
        ///     - Se obtiene el producto de la base de datos utilizando su ID.
        ///     - Se verifica si el producto existe en la base de datos y se lanza una excepción si no es así.
        ///     - Se verifica si hay suficiente stock disponible para la cantidad deseada del producto y se lanza una excepción si no es así.
        ///     - Se actualiza la cantidad en kilos del producto en la base de datos restando la cantidad deseada.
        ///     - Se calcula el precio total para el producto.
        ///     - Se crea una instancia de Venta con los datos correspondientes.
        ///     - Se agrega la venta a la lista de ventas realizadas.
        /// Se actualiza el saldo del cliente según el método de pago (con o sin tarjeta de crédito).
        /// Se guarda el historial de compras en formato XML utilizando el método Serializador.SerializarXml.
        /// Se guarda el historial de compras en un archivo de texto utilizando el método ArchivoTexto.GuardarHistorialCompraTxt.
        /// Se limpia el carrito de productos.
        /// </remarks>
        public void RealizarCompra(bool esPagoConCredito, List<Producto> carritoDeProductos)
        {
            List<Venta> ventasRealizadas = new List<Venta>();
            ProductoDAO productoDAO = new ProductoDAO();

            DateTime fechaVenta = DateTime.Now;

            // Calcular el monto total de la compra
            double montoTotal = CalcularMontoTotal(esPagoConCredito,carritoDeProductos);


            // Verificar si el cliente tiene suficiente saldo para la compra
            if (montoTotal > Saldo)
            {
                throw new Exception("El cliente no tiene suficiente saldo para realizar la compra.");
            }

            foreach (Producto productoCarrito in carritoDeProductos)
            {
                int productoId = productoCarrito.Id;
                double cantidadEnKilos = productoCarrito.CantidadEnKilos;

                Producto producto = productoDAO.ObtenerPorId(productoId);

                if (producto == null)
                {
                    throw new Exception($"El producto con Id {productoId} no existe en la base de datos.");
                }

                if (producto.CantidadEnKilos < cantidadEnKilos)
                {
                    throw new Exception($"No hay suficiente stock para el producto {producto.Nombre}. Stock disponible: {producto.CantidadEnKilos} kg.");
                }

                producto.CantidadEnKilos -= cantidadEnKilos;
                productoDAO.ActualizarEnBaseDeDatos(producto);

                // Calcular el precio total para este producto
                double precioTotal = productoCarrito.PrecioPorKilo * productoCarrito.CantidadEnKilos;

                // Crear una instancia de Venta con los datos correspondientes
                Venta venta = new Venta(productoCarrito,productoCarrito.CantidadEnKilos,precioTotal,fechaVenta);
                
                // Agregar la venta a la lista de ventas realizadas
                ventasRealizadas.Add(venta);
            }
            // Actualizar el saldo del cliente
            if (esPagoConCredito)
            {
                Saldo -= montoTotal * 1.05; // Aplicar un recargo del 5% para pagos con tarjeta de crédito
            }
            else
            {
                Saldo -= montoTotal;
            }
            // Limpiar el carrito de productos
            Serializador.SerializarXml(ventasRealizadas);
            ArchivoTexto.GuardarHistorialCompraTxt(ventasRealizadas);
            carritoDeProductos.Clear();
        }
        #endregion

    }
}
