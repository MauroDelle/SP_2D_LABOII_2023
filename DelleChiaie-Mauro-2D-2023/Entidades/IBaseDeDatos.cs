using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IBaseDeDatos<T> where T : class
    {
        static string ConexionBase()
        {
            return @"Data Source=localhost;Database=CarniceriaDB;Trusted_Connection=True;";
        }
        
        void Conectar();
        void Desconectar();
        T ObtenerPorId(int id);
        List<T> ObtenerTodos();
    }
}
