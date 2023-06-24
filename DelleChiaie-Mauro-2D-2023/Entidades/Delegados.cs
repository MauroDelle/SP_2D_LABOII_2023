using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Delegados
    {
        #region MÉTODOS
        /// <summary>
        /// Delegado que define la firma de un método para aplicar descuentos o recargos.
        /// </summary>
        /// <param name="totalPagar">El monto total a pagar.</param>
        /// <param name="esEfectivo">Indica si el pago se realiza en efectivo.</param>
        /// <param name="edadCliente">La edad del cliente.</param>
        /// <returns>El monto total con el descuento o recargo aplicado.</returns>
        public delegate double DescuentoRecargoDelegate(double totalPagar,bool esEfectivo, int edadCliente);

        /// <summary>
        /// Aplica un descuento o recargo al monto total a pagar, según la edad del cliente y el método de pago.
        /// </summary>
        /// <param name="totalPagar">El monto total a pagar.</param>
        /// <param name="esEfectivo">Indica si el pago se realiza en efectivo.</param>
        /// <param name="edadCliente">La edad del cliente.</param>
        /// <returns>El monto total con el descuento o recargo aplicado.</returns>
        /// <remarks>
        /// Si la edad del cliente es mayor a 60 y el pago es en efectivo, se aplica un descuento del 20% al monto total.
        /// Si la edad del cliente es menor o igual a 60 y el pago no es en efectivo, se aplica un recargo del 5% al monto total.
        /// Se retorna el monto total con el descuento o recargo aplicado.
        /// </remarks>
        public static double AplicarDescuentoRecargo(double totalPagar, bool esEfectivo, int edadCliente)
        {
            if (edadCliente > 60)
            {
                if (esEfectivo)
                {
                    double descuento = totalPagar * 0.20; // Aplico el descuento del 10%
                    totalPagar -= descuento;
                }
            }
            else
            {
                if (!esEfectivo)
                {
                    double recargo = totalPagar * 0.05;
                    totalPagar += recargo;
                }
            }
            return totalPagar;
        }
        #endregion
    }
}
