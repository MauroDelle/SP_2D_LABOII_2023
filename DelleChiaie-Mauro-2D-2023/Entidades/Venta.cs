using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        //#region ATRIBUTOS
        private DateTime fechaVenta;
        private Producto producto;
        private double cantidad;
        private double precioTotal;
        //#endregion

        //#region CONSTRUCTORES

        public Venta() { }
        public Venta(Producto producto, double cantidad, double precioTotal, DateTime fechaVenta)
        {
            this.producto = producto;
            this.cantidad = cantidad;
            this.precioTotal = precioTotal;
            this.fechaVenta = fechaVenta;
        }

        //#region PROPIEDADES
        public DateTime FechaVenta{get { return fechaVenta; }set { fechaVenta = value;}}
        public double Cantidad{get { return this.cantidad; }set { this.cantidad = value;}}
        public double PrecioTotal{get { return this.precioTotal; }set{this.precioTotal = value;}}
        public Producto Producto { get => producto; set => producto = value; }
        //#endregion

        public override string ToString()
        {
            return $"Fecha de Venta: {fechaVenta}\n\n" +
                $"Producto: {producto}\n\n" +
                $"Precio Total: {precioTotal}\n\n";
        }



    }
}
