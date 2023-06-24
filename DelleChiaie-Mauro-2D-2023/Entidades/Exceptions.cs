using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SqlExceptions : Exception
    {
        public SqlExceptions()
        {
        }

        public SqlExceptions(string message) : base(message)
        {
        }

        public SqlExceptions(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
