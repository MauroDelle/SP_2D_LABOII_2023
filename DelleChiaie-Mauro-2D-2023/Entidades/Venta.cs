using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        #region ATRIBUTOS
        private DateTime fechaVenta;
        private Producto _producto;
        private double cantidad;
        private double precioTotal;
        private bool pagoConCredito;
        private List<Producto> productosVendidos;
        #endregion

        #region CONSTRUCTORES
        public Venta(Producto producto, double cantidad, double precioTotal, DateTime fechaVenta)
        {
            _producto = producto;
            this.cantidad = cantidad;
            this.precioTotal = precioTotal;
            this.fechaVenta = fechaVenta;
        }
        public Venta(List<Producto> productosVendidos, double montoTotal, DateTime fechaVenta)// Invocar al constructor sin parámetros
        {
            this.productosVendidos = productosVendidos;
            this.precioTotal = montoTotal;
            this.fechaVenta = fechaVenta;
            foreach (Producto producto in productosVendidos)
            {
                this.cantidad += producto.CantidadEnKilos;
            }
        }
        #endregion

        #region PROPIEDADES
        public List<Producto> ProductosVendidos{get { return this.productosVendidos; }set { this.productosVendidos = value; }}
        public DateTime FechaVenta{get { return fechaVenta; }set { fechaVenta = value;}}
        public Producto _Producto{get { return this._producto; }set { this._producto = value; }}
        public bool PagoConCredito { get { return this.pagoConCredito; } set { pagoConCredito = value; } }
        public double Cantidad{get { return this.cantidad; }set { this.cantidad = value;}}
        public double PrecioTotal{get { return this.precioTotal; }set{this.precioTotal = value;}}
        #endregion

    }
}
