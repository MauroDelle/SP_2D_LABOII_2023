using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        #region ATRIBUTOS
        private string nombre;
        private double precioPorKilo;
        private double cantidadEnKilos;
        private TipoCorteCarne tipoCorte;
        #endregion

        #region CONSTRUCTORES
        public Producto(string nombre, double precioPorKilo, double cantidadEnKilos, TipoCorteCarne tipoCorte)
        {
            this.nombre = nombre;
            this.precioPorKilo = precioPorKilo;
            this.cantidadEnKilos = cantidadEnKilos;
            this.tipoCorte = tipoCorte;
        }
        public Producto(string nombre, double precio, double cantidad)
        {
            this.nombre = nombre;
            this.precioPorKilo = precio;
            this.cantidadEnKilos = cantidad;
        }
        #endregion

        #region PROPIEDADES
        public string Nombre{get{return this.nombre;}set{this.nombre = value;}}
        public double PrecioPorKilo{get{ return precioPorKilo;}set {precioPorKilo = value;}}
        public double CantidadEnKilos { get { return cantidadEnKilos;}set { cantidadEnKilos = value;}}
        public TipoCorteCarne TipoCorte{get { return tipoCorte; }set{ tipoCorte = value;}}
        #endregion

        #region MÉTODOS

        /// <summary>
        /// Compara si el objeto actual es igual a otro objeto dado.
        /// </summary>
        /// <param name="obj">El objeto que se va a comparar.</param>
        /// <returns>Devuelve verdadero si el objeto actual es igual al objeto dado; de lo contrario, devuelve falso.</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Producto)
            {
                retorno = this == ((Producto)obj);
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad para determinar si dos productos son iguales.
        /// </summary>
        /// <param name="p1">Primer producto a comparar.</param>
        /// <param name="p2">Segundo producto a comparar.</param>
        /// <returns>Devuelve true si los productos son iguales, false en caso contrario.</returns>
        public static bool operator == (Producto p1, Producto p2)
        {
            bool retorno = false;

            if (p1 is not null && p2 is not null)
            {
                retorno = (p1.TipoCorte == p2.tipoCorte) && (p1.Nombre == p2.Nombre);    
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador "!=" para comparar dos objetos de tipo Producto.
        /// </summary>
        /// <param name="p1">El primer objeto Producto a comparar.</param>
        /// <param name="p2">El segundo objeto Producto a comparar.</param>
        /// <returns>Retorna true si los dos objetos son distintos, false en caso contrario.</returns>
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }
        #endregion

    }
}
