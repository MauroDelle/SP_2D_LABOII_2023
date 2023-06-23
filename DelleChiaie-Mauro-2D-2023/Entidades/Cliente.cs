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
        //private List<Venta> ventasRealizadas;
        #endregion

        public Cliente():base(0, "", "", "", 0, 0)
        {
            carritoDeProductos = new List<Producto>();
        }

        public Cliente(double saldo):base(0, "", "", "", 0, 0)
        {
            this.Saldo = 0;
            //ventasRealizadas = new List<Venta>();   
        }



        public double Saldo { get => saldo; set => saldo = value; }
        public int Edad { get => edad; set => edad = value; }
        public List<Producto> CarritoDeProductos { get => carritoDeProductos; set => carritoDeProductos = value; }

        public List<Cliente> CargarClientes()
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            List<Cliente> clientes = clienteDAO.ObtenerTodos();
            return clientes;
        }

        //#region PROPIEDADES 
        //public List<Producto> CarritoDeProductos { get { return this.carritoDeProductos; } set { this.carritoDeProductos = value; } }
        //public List<Venta> VentasRealizadas { get { return this.ventasRealizadas; } set { this.ventasRealizadas = value; } }
        //public double Saldo{get { return this.saldo; }set { this.saldo = value; }}

        //public int Id { get => id; set => id = value; }
        //public string Apellido { get => apellido; set => apellido = value; }
        //public string Nombre1 { get => nombre; set => nombre = value; }
        //#endregion

        //#region MÉTODOS

        ///// <summary>
        ///// Un override que devuelve un bool dependiendo que tipo de usuario es
        ///// </summary>
        ///// <returns></returns>
        ////public override bool ClienteOVendedor()
        ////{
        ////    return false;
        ////}

        ///// <summary>|
        ///// Un método que recibe un producto tipo Producto y una cantidad especifica, y agrega a la lista de-
        ///// carritoDeProductos un nuevo elemento.
        ///// </summary>
        ///// <param name="producto"></param>
        ///// <param name="cantidad"></param>
        public void AgregarProductoAlCarrito(Producto producto, double cantidad)
        {
            carritoDeProductos.Add(new Producto(producto.Id,producto.Nombre,producto.PrecioPorKilo,cantidad,producto.TipoCorte));
        }

        ///// <summary>
        ///// Un metodo Mostrar que utiliza stringBuilder para mostrar los campos de la clase venta
        ///// </summary>
        ///// <returns></returns>
        //public string Mostrar()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    foreach (Venta venta in ventasRealizadas)
        //    {
        //        sb.AppendLine($"Fecha: {venta.FechaVenta}, Monto: {venta.PrecioTotal:C}, Cantidad: {venta.Cantidad}," +
        //            $" Saldo actual: ${this.saldo}C");
        //    }

        //    return sb.ToString();
        //}

        ///// <summary>
        ///// Método utilizado en el metodo RealizarCompra, para calcular el monto total, recibe un bool y una lista
        ///// de los productos en el carrito, acumula el precio total de los productos seleccionados y el bool dependiendo que
        ///// retorne calcula el +5% de recargo o no
        ///// </summary>
        ///// <param name="esPagoConCredito"></param>
        ///// <param name="carritoDeProductos"></param>
        ///// <returns></returns>
        public double CalcularMontoTotal(bool esPagoConCredito, List<Producto> carritoDeProductos)
        {
            double montoTotal = 0;

            foreach (Producto producto in carritoDeProductos)
            {
                montoTotal += producto.PrecioPorKilo * producto.CantidadEnKilos;
            }
            if (esPagoConCredito)
            {
                montoTotal += 1.05;
            }
            return montoTotal;
        }

        ///// <summary>
        ///// Realiza la compra de los productos seleccionados por el cliente y actualiza el saldo del vendedor.
        ///// </summary>
        ///// <param name="esPagoConCredito">Indica si el pago se realiza con tarjeta de crédito o no.</param>
        ///// <param name="carritoDeProductos">Lista de productos seleccionados por el cliente para comprar.</param>
        ///// <param name="ListaProductos">Lista de todos los productos disponibles para la venta.</param>
        ///// <exception cref="Exception">Lanza una excepción si el cliente no tiene suficiente saldo para realizar la compra.</exception>
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
            //}
            //#endregion





        }
}
