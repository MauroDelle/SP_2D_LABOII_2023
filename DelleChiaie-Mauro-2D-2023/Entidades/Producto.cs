using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        private int id;
        private string nombre;
        private double precioPorKilo;
        private double cantidadEnKilos;
        private string tipoCorte;
        #endregion

        #region CONSTRUCTORES

        public Producto()
        {
        }

        public Producto(string nombre, double precioPorKilo, double cantidadEnKilos, string tipoCorte)
        {
            this.nombre = nombre;
            this.precioPorKilo = precioPorKilo;
            this.cantidadEnKilos = cantidadEnKilos;
            this.TipoCorte = tipoCorte;
        }

        public Producto(int id, string nombre,double precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.precioPorKilo = precio;
        }

        public Producto(int id,string nombre,double precio,double cantidadEnKilos)
        {
            this.id = id;
            this.nombre = nombre;
            this.precioPorKilo= precio;
            this.cantidadEnKilos = cantidadEnKilos;
        }

        public Producto(string nombre,double precio,double cantidadEnKilos)
        {
            this.nombre = nombre;
            this.precioPorKilo = precio;
            this.cantidadEnKilos = cantidadEnKilos;
        }

        public Producto(int id, string nombre, double precioPorKilo, double cantidadEnKilos, string tipoCorte)
        {
            this.id = id;
            this.nombre = nombre;
            this.precioPorKilo = precioPorKilo;
            this.cantidadEnKilos = cantidadEnKilos;
            this.tipoCorte = tipoCorte;
        }

        #endregion

        #region PROPIEDADES
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public double PrecioPorKilo { get { return precioPorKilo; } set { precioPorKilo = value; } }
        public double CantidadEnKilos { get { return cantidadEnKilos; } set { cantidadEnKilos = value; } }

        public string TipoCorte { get => tipoCorte; set => tipoCorte = value; }
        public int Id { get => id; set => id = value; }

        //public @string TipoCorte{get { return tipoCorte; }set{ tipoCorte = value;}}
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

        public static List<Producto> CargarProductos()
        {
            ProductoDAO productoDAO = new ProductoDAO();
            return productoDAO.ObtenerTodos();
        }
        public override string ToString()
        {
            return $"ID: {id}\n\n" +
                   $"Nombre: {nombre}\n\n" +
                   $"Precio por Kilo: {precioPorKilo}\n\n" +
                   $"Cantidad en Kilos: {cantidadEnKilos}\n\n" +
                   $"Tipo de Corte: {tipoCorte}\n\n";
        }


        /// <summary>
        /// Sobrecarga del operador de igualdad para determinar si dos productos son iguales.
        /// </summary>
        /// <param name="p1">Primer producto a comparar.</param>
        /// <param name="p2">Segundo producto a comparar.</param>
        /// <returns>Devuelve true si los productos son iguales, false en caso contrario.</returns>
        public static bool operator ==(Producto p1, Producto p2)
        {
            bool retorno = false;

            if (p1 is not null && p2 is not null)
            {
                retorno = (p1.Nombre == p2.Nombre);
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


        public void ModificarProducto(double nuevaCantidad)
        {
            if (nuevaCantidad <= 0)
            {
                throw new InvalidOperationException("La cantidad del producto debe ser mayor a cero.");
            }

            if (nuevaCantidad > 30)
            {
                throw new InvalidOperationException("La cantidad del producto no puede ser mayor a 30.");
            }
            ProductoDAO productoDAO = new ProductoDAO();
            productoDAO.ModificarProducto(this);
        }

        public void AgregarProducto(string nombreCorte, double precio, double cantidad, string tipoCorte)
        {
            if (string.IsNullOrEmpty(nombreCorte))
            {
                throw new ArgumentException("El nombre del corte no puede estar vacío.");
            }

            if (precio <= 0)
            {
                throw new ArgumentException("El precio debe ser mayor a cero.");
            }

            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor a cero.");
            }

            if (string.IsNullOrEmpty(tipoCorte))
            {
                throw new ArgumentException("El tipo de corte no puede estar vacío.");
            }
            Producto nuevoProducto = new Producto(nombreCorte, precio, cantidad, tipoCorte);
            ProductoDAO productoDAO = new ProductoDAO();
            productoDAO.AgregarProducto(nuevoProducto);
        }
    
        public void EliminarProducto(int idProducto)
        {
            if (idProducto <= 0)
            {
                throw new ArgumentException("El ID del producto debe ser mayor a cero.");
            }

            ProductoDAO productoDAO = new ProductoDAO();
            productoDAO.EliminarProducto(idProducto);
        }

        public void ActualizarEnBaseDeDatos(string nuevoNombre, double nuevoPrecio, double nuevaCantidad)
        {
            // Validar los datos antes de la actualización

            if (string.IsNullOrEmpty(nuevoNombre))
            {
                throw new InvalidOperationException("El nombre del corte no puede estar vacío.");
            }

            if (nuevoPrecio <= 0)
            {
                throw new InvalidOperationException("El precio debe ser mayor a cero.");
            }

            if (nuevaCantidad <= 0)
            {
                throw new InvalidOperationException("La cantidad debe ser mayor a cero.");
            }

            if (string.IsNullOrEmpty(TipoCorte))
            {
                throw new InvalidOperationException("El tipo de corte no puede estar vacío.");
            }
            // Actualizar los valores del producto
            Nombre = nuevoNombre;
            PrecioPorKilo = nuevoPrecio;
            CantidadEnKilos = nuevaCantidad;

            // Actualizar el producto en la base de datos utilizando ProductoDAO.ModificarProducto
            try
            {
                ProductoDAO productoDAO = new ProductoDAO();
                productoDAO.ModificarProducto(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el producto en la base de datos: " + ex.Message);
                throw; // Lanzar la excepción para manejarla en el código que llamó a este método
            }
        }


        public List<Producto> ObtenerProductosDesdeBaseDeDatos()
        {
            ProductoDAO productoDAO = new ProductoDAO();
            List<Producto> productos = productoDAO.ObtenerTodos();
            return productos;
        }

        #endregion


        public void AgregarAlCarrito(Producto producto,int cantidad)
        {
            if (cantidad <= producto.cantidadEnKilos)
            {




            }
        }





    }
}
