using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : Persona
    {
        #region ATRIBUTOS
        private double saldo;
        private List<Producto> carritoDeProductos;
        private List<Venta> ventasRealizadas;
        #endregion

        #region CONSTRUCTORES
        public Cliente():base("", "", "")
        {
            this.saldo = 0;
            carritoDeProductos= new List<Producto>();
            ventasRealizadas = new List<Venta>();   
        }
        public Cliente(string nombre,string correo,string contrasenia):base(nombre,correo,contrasenia)
        {
        }
        public Cliente(string nombre,double saldo):base(nombre,"","")
        {
            this.saldo = saldo;
        }
        #endregion

        #region PROPIEDADES 
        public double Saldo{get { return this.saldo; }set { this.saldo = value; }}
        public List<Producto> CarritoDeProductos { get { return this.carritoDeProductos; } set { this.carritoDeProductos = value; } }
        public List<Venta> VentasRealizadas { get { return this.ventasRealizadas; } set { this.ventasRealizadas = value; } }
        #endregion

        #region MÉTODOS

        /// <summary>
        /// Un override que devuelve un bool dependiendo que tipo de usuario es
        /// </summary>
        /// <returns></returns>
        public override bool EsVendedor()
        {
            return false;
        }

        /// <summary>
        /// Un método que recibe un producto tipo Producto y una cantidad especifica, y agrega a la lista de-
        /// carritoDeProductos un nuevo elemento.
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="cantidad"></param>
        public void AgregarProductoAlCarrito(Producto producto,double cantidad)
        {
            carritoDeProductos.Add(new Producto(producto.Nombre,producto.PrecioPorKilo,cantidad));
        }

        /// <summary>
        /// Un metodo Mostrar que utiliza stringBuilder para mostrar los campos de la clase venta
        /// </summary>
        /// <returns></returns>
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Venta venta in ventasRealizadas)
            {
                sb.AppendLine($"Fecha: {venta.FechaVenta}, Monto: {venta.PrecioTotal:C}, Cantidad: {venta.Cantidad}," +
                    $" Saldo actual: ${this.saldo}C");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Método utilizado en el metodo RealizarCompra, para calcular el monto total, recibe un bool y una lista
        /// de los productos en el carrito, acumula el precio total de los productos seleccionados y el bool dependiendo que
        /// retorne calcula el +5% de recargo o no
        /// </summary>
        /// <param name="esPagoConCredito"></param>
        /// <param name="carritoDeProductos"></param>
        /// <returns></returns>
        public double CalcularMontoTotal(bool esPagoConCredito, List<Producto> carritoDeProductos)
        {
            double montoTotal = 0;

            foreach (Producto producto in carritoDeProductos)
            {
                montoTotal += producto.PrecioPorKilo * producto.CantidadEnKilos;
            }
            if(esPagoConCredito)
            {
                montoTotal += 1.05;
            }
            return montoTotal;
        }

        /// <summary>
        /// Realiza la compra de los productos seleccionados por el cliente y actualiza el saldo del vendedor.
        /// </summary>
        /// <param name="esPagoConCredito">Indica si el pago se realiza con tarjeta de crédito o no.</param>
        /// <param name="carritoDeProductos">Lista de productos seleccionados por el cliente para comprar.</param>
        /// <param name="ListaProductos">Lista de todos los productos disponibles para la venta.</param>
        /// <exception cref="Exception">Lanza una excepción si el cliente no tiene suficiente saldo para realizar la compra.</exception>
        public void RealizarCompra(bool esPagoConCredito, List<Producto> carritoDeProductos, List<Producto> ListaProductos)
        {
            DateTime fechaVenta = DateTime.Now;
            double monto = CalcularMontoTotal(esPagoConCredito, carritoDeProductos);

            foreach (Producto productoCarro in carritoDeProductos)
            {
                Producto producto = null;
                foreach (Producto p in ListaProductos)
                {
                    if (p.Equals(productoCarro))
                    {
                        producto = p;
                        break;
                    }
                }
                if (producto == null)
                {
                    throw new Exception($"El producto {productoCarro.Nombre} no se encuentra en el inventario.");
                }
                else if (producto.CantidadEnKilos < productoCarro.CantidadEnKilos)
                {
                    throw new Exception($"No hay suficiente stock para el producto {productoCarro.Nombre}. Stock disponible: {producto.CantidadEnKilos} kg.");
                }
                else
                {
                    producto.CantidadEnKilos -= productoCarro.CantidadEnKilos;
                }
            }

            if (monto > saldo)
            {
                throw new Exception("El cliente no tiene suficiente saldo para realizar la compra.");
            }
            else
            {
                if (esPagoConCredito)
                {
                    saldo -= monto;
                }
                else
                {
                    saldo -= monto;
                }
                Venta venta = new Venta(carritoDeProductos, monto, fechaVenta);
                ventasRealizadas.Add(venta);
                carritoDeProductos.Clear();
            }
        }
        #endregion

    }
}
