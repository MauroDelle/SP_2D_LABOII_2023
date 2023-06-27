using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Entidades.Delegados;

namespace Entidades
{
    public class Vendedor : Usuario
    {
        #region ATRIBUTOS
        private List<Venta> historialVentas;
        private DescuentoRecargoDelegate descuentoRecargoDelegate;
        public event Action<Producto> ActualizarCantidadProductoEvent;

        #endregion

        #region CONSTRUCTORES
        public Vendedor() : base(0, "", "", "", 0, 0)
        {
            this.historialVentas = new List<Venta>();
        }
        #endregion

        #region PROPIEDADES
        public List<Venta> HistorialVentas { get { return this.historialVentas; } set { this.historialVentas = value; } }
        #endregion

        #region MÉTODOS

        /// <summary>
        /// Actualiza el saldo del cliente proporcionado.
        /// </summary>
        /// <param name="cliente">El objeto Cliente que contiene la información del cliente.</param>
        public void ActualizarSaldoCliente(Cliente cliente)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            int idCliente = clienteDAO.ObtenerIdCLientePorNombre(cliente.Nombre);
            double saldoCliente = clienteDAO.ObtenerSaldoClientePorId(idCliente);

            cliente.Saldo = saldoCliente;
        }

        /// <summary>
        /// Realiza una venta de un producto a un cliente.
        /// </summary>
        /// <param name="producto">El producto que se va a vender.</param>
        /// <param name="cliente">El cliente al que se le realiza la venta.</param>
        /// <param name="cantidad">La cantidad del producto que se va a vender.</param>
        /// <param name="esEfectivo">Indica si el pago se realiza en efectivo.</param>
        /// <returns>
        /// true si la venta se realizó correctamente, false si la venta no se pudo realizar.
        /// </returns>
        /// <exception cref="Exception">Se lanza una excepción en caso de que ocurra un error durante la venta.</exception>
        public bool Vender(Producto producto, Cliente cliente, int cantidad, bool esEfectivo)
        {
            bool retorno = false;
            bool aplicarDescuentoJubilado = false;
            if (producto != null && producto.CantidadEnKilos >= cantidad)
            {
                try
                {
                    double precioTotal = producto.PrecioPorKilo * cantidad;

                    //Utilizo el delegado para calcular el descuento o recargo
                    Delegados.DescuentoRecargoDelegate descuentoRecargoDelegate = Delegados.AplicarDescuentoRecargo;
                    double descuentoRecargo = descuentoRecargoDelegate(precioTotal, esEfectivo, cliente.Edad);

                    double montoFinal = descuentoRecargo;

                    ClienteDAO clienteDAO = new ClienteDAO();
                    int idCliente = clienteDAO.ObtenerIdCLientePorNombre(cliente.Nombre);

                    if (idCliente != -1)
                    {
                        double saldoCliente = clienteDAO.ObtenerSaldoClientePorId(idCliente);

                        if (saldoCliente >= montoFinal)
                        {
                            saldoCliente -= montoFinal;
                            clienteDAO.ActualizarSaldoCliente(idCliente, saldoCliente);
                            cliente.Saldo = saldoCliente;

                            ProductoDAO productoDAO = new ProductoDAO();
                            producto.CantidadEnKilos -= cantidad;
                            productoDAO.ActualizarCantidadProducto(producto);
                            //ActualizarCantidadProductoEvent?.Invoke(producto);
                            Venta venta = new Venta(producto, cantidad, montoFinal, DateTime.Now);
                            ArchivoTexto.GuardarHistorialVentaEnTxt(venta, @"C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Debug\net6.0\historial_ventas.txt");
                            AgregarVenta(venta);
                            retorno = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Manejo de la excepción
                    Console.WriteLine("Saldo Insuficiente: " + ex.Message);
                }
            }

            return retorno;
        }

        /// <summary>
        /// Agrega una venta al historial de ventas.
        /// </summary>
        /// <param name="venta">La venta que se va a agregar.</param>
        public void AgregarVenta(Venta venta)
        {
            HistorialVentas.Add(venta);
        }

        /// <summary>
        /// Obtiene el historial de ventas.
        /// </summary>
        /// <returns>Una lista de objetos Venta que representa el historial de ventas.</returns>
        public List<Venta> ObtenerHistorialVenta()
        {
            return this.HistorialVentas;
        }

        #endregion
    }
}
