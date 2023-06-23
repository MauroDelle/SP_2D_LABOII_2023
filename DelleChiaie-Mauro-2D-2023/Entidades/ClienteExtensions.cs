using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ClienteExtensions
    {
        public static string FormatearSaldo(this Cliente cliente)
        {
            return cliente.Saldo.ToString("C2");
        }

        public static string FormatearEdad(this Cliente cliente)
        {
            return cliente.Edad.ToString("C2");
        }

    }
}
