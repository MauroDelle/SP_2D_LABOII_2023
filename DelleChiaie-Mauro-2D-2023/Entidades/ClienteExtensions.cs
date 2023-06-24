using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ClienteExtensions
    {
        #region MÉTODOS

        /// <summary>
        /// Formatea el saldo del cliente en formato de moneda.
        /// </summary>
        /// <param name="cliente">El objeto Cliente.</param>
        /// <returns>El saldo formateado en formato de moneda.</returns>
        /// <remarks>
        /// Se utiliza el método ToString con el formato "C2" para formatear el saldo del cliente.
        /// El formato "C2" indica que el saldo se mostrará en formato de moneda con 2 decimales.
        /// Se devuelve el saldo formateado como una cadena de texto.
        /// </remarks>
        public static string FormatearSaldo(this Cliente cliente)
        {
            return cliente.Saldo.ToString("C2");
        }

        /// <summary>
        /// Formatea la edad del cliente.
        /// </summary>
        /// <param name="cliente">El objeto Cliente.</param>
        /// <returns>La edad formateada.</returns>
        /// <remarks>
        /// Se utiliza el método ToString con el formato "C2" para formatear la edad del cliente.
        /// El formato "C2" indica que la edad se mostrará como un número entero.
        /// Se devuelve la edad formateada como una cadena de texto.
        /// </remarks>
        public static string FormatearEdad(this Cliente cliente)
        {
            return cliente.Edad.ToString("C2");
        }
        #endregion
    }
}
