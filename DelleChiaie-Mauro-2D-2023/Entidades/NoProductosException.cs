using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class NoProductosException : Exception
    {
        public NoProductosException(string message) : base(message)
        {
        }
    }
}
