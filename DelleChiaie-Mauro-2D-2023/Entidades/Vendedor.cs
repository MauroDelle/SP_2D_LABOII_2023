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

        List<Venta> historialVentas;
        private DescuentoRecargoDelegate descuentoRecargoDelegate;
        public event Action<Producto> ActualizarCantidadProductoEvent;
        #endregion

        #region CONSTRUCTORES

        public Vendedor() : base(0, "", "", "", 0, 0)
        {
            // Constructor vacío
            historialVentas = new List<Venta>();
        }

        public Vendedor(int id,string nombre,string correo,string constrasenia,int idPersona,int idCliente,DescuentoRecargoDelegate descuentoRecargoDelegate):base(id,nombre,correo,constrasenia,idPersona,idCliente)
        {
            this.descuentoRecargoDelegate = descuentoRecargoDelegate;    
            this.historialVentas= new List<Venta>();
        }

        //public Vendedor():this("Sin nombre", "Sin correo", "Sin contraseña",true)
        //{ 
        //    listaClientes = new List<Cliente>();
        //    ListaProductos = new List<Producto>();
        //    historialVentas = new List<Venta>();
        //}
        #endregion

        #region PROPIEDADES
        public List<Venta> HistorialVentas { get { return this.historialVentas; } set { this.historialVentas = value; } }
        #endregion

        #region MÉTODOS

        public void ActualizarSaldoCliente(Cliente cliente)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            int idCliente = clienteDAO.ObtenerIdCLientePorNombre(cliente.Nombre);
            double saldoCliente = clienteDAO.ObtenerSaldoClientePorId(idCliente);

            cliente.Saldo = saldoCliente;
        }
        public bool Vender(Producto producto, Cliente cliente, int cantidad, bool esEfectivo)
        {
            try
            {
                if (producto != null && producto.CantidadEnKilos >= cantidad)
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
                            ActualizarCantidadProductoEvent?.Invoke(producto);
                            Venta venta = new Venta(producto, cantidad, montoFinal, DateTime.Now);
                            ArchivoTexto.GuardarHistorialVentaEnTxt(venta, @"C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Debug\net6.0\historial_ventas.txt");
                            string nombreArchivo = "historial_ventas.json";
                            string rutaArchivoJson = Path.Combine(@"C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Archivos", nombreArchivo);
                            Serializador.SerializarEnJson(venta,rutaArchivoJson);
                            return true; // La venta se realizó correctamente
                        }
                    }
                }
                return false; // La venta no se pudo realizar
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                Console.WriteLine("Stock Insuficiente: " + ex.Message);
                return false; // La venta no se pudo realizar debido a un error
            }
        }


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
