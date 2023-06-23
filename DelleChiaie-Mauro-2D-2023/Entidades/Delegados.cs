using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Delegados
    {
        public delegate double DescuentoRecargoDelegate(double totalPagar,bool esEfectivo, int edadCliente);

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




    }
}
