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
        #endregion

        #region MÉTODOS


        /// <summary>
        /// Obtiene el código hash del objeto actual.
        /// </summary>
        /// <returns>Valor hash del objeto.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 17;
                hashCode = hashCode * 23 + (Nombre != null ? Nombre.GetHashCode() : 0);
                hashCode = hashCode * 23 + PrecioPorKilo.GetHashCode();
                hashCode = hashCode * 23 + CantidadEnKilos.GetHashCode();
                hashCode = hashCode * 23 + (TipoCorte != null ? TipoCorte.GetHashCode() : 0);
                return hashCode;
            }
        }

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
        /// Carga y devuelve una lista de productos desde la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Producto que representa los productos cargados desde la base de datos.</returns>
        /// <remarks>
        /// Este método utiliza la clase ProductoDAO para obtener todos los productos desde la base de datos.
        /// Devuelve una lista de objetos Producto que contiene los productos cargados.
        /// </remarks>
        public static List<Producto> CargarProductos()
        {
            ProductoDAO productoDAO = new ProductoDAO();
            return productoDAO.ObtenerTodos();
        }

        /// <summary>
        /// Devuelve una representación en forma de cadena del objeto Producto.
        /// </summary>
        /// <returns>Una cadena que contiene los atributos del producto, incluyendo ID, nombre, precio por kilo, cantidad en kilos y tipo de corte.</returns>
        /// <remarks>
        /// Este método devuelve una cadena que muestra los atributos del producto, formateados en líneas separadas.
        /// La cadena resultante tiene el siguiente formato:
        /// 
        /// ID: {id}
        /// 
        /// Nombre: {nombre}
        /// 
        /// Precio por Kilo: {precioPorKilo}
        /// 
        /// Cantidad en Kilos: {cantidadEnKilos}
        /// 
        /// Tipo de Corte: {tipoCorte}
        /// 
        /// </remarks>
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

        /// <summary>
        /// Modifica la cantidad de un producto y lo actualiza en la base de datos.
        /// </summary>
        /// <param name="nuevaCantidad">La nueva cantidad del producto.</param>
        /// <exception cref="InvalidOperationException">Se lanza cuando la nueva cantidad es menor o igual a cero, o mayor a 30.</exception>
        /// <remarks>
        /// Este método permite modificar la cantidad de un producto y actualizarlo en la base de datos.
        /// Recibe como parámetro la nueva cantidad del producto.
        /// Si la nueva cantidad es menor o igual a cero, se lanza una excepción de tipo InvalidOperationException.
        /// Si la nueva cantidad es mayor a 30, se lanza una excepción de tipo InvalidOperationException.
        /// Utiliza la clase ProductoDAO para realizar la modificación en la base de datos.
        /// </remarks>
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


        /// <summary>
        /// Agrega un nuevo producto a la base de datos.
        /// </summary>
        /// <param name="nombreCorte">El nombre del corte del producto.</param>
        /// <param name="precio">El precio del producto.</param>
        /// <param name="cantidad">La cantidad del producto.</param>
        /// <param name="tipoCorte">El tipo de corte del producto.</param>
        /// <exception cref="ArgumentException">Se lanza cuando el nombre del corte, el precio, la cantidad o el tipo de corte son valores inválidos o vacíos.</exception>
        /// <remarks>
        /// Este método permite agregar un nuevo producto a la base de datos.
        /// Recibe como parámetros el nombre del corte, el precio, la cantidad y el tipo de corte del producto.
        /// Si el nombre del corte es nulo o vacío, se lanza una excepción de tipo ArgumentException.
        /// Si el precio es menor o igual a cero, se lanza una excepción de tipo ArgumentException.
        /// Si la cantidad es menor o igual a cero, se lanza una excepción de tipo ArgumentException.
        /// Si el tipo de corte es nulo o vacío, se lanza una excepción de tipo ArgumentException.
        /// Crea una instancia de la clase Producto con los valores proporcionados y utiliza la clase ProductoDAO para agregarlo a la base de datos.
        /// </remarks>
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

        /// <summary>
        /// Elimina un producto de la base de datos.
        /// </summary>
        /// <param name="idProducto">El ID del producto a eliminar.</param>
        /// <exception cref="ArgumentException">Se lanza cuando el ID del producto es menor o igual a cero.</exception>
        /// <remarks>
        /// Este método permite eliminar un producto de la base de datos.
        /// Recibe como parámetro el ID del producto a eliminar.
        /// Si el ID del producto es menor o igual a cero, se lanza una excepción de tipo ArgumentException.
        /// Utiliza la clase ProductoDAO para eliminar el producto de la base de datos.
        /// </remarks>
        public void EliminarProducto(int idProducto)
        {
            if (idProducto <= 0)
            {
                throw new ArgumentException("El ID del producto debe ser mayor a cero.");
            }

            ProductoDAO productoDAO = new ProductoDAO();
            productoDAO.EliminarProducto(idProducto);
        }

        /// <summary>
        /// Actualiza los datos de un producto en la base de datos.
        /// </summary>
        /// <param name="nuevoNombre">El nuevo nombre del producto.</param>
        /// <param name="nuevoPrecio">El nuevo precio del producto.</param>
        /// <param name="nuevaCantidad">La nueva cantidad del producto.</param>
        /// <exception cref="InvalidOperationException">Se lanza cuando alguno de los datos es inválido o está vacío.</exception>
        /// <remarks>
        /// Este método permite actualizar los datos de un producto en la base de datos.
        /// Recibe como parámetros el nuevo nombre, el nuevo precio y la nueva cantidad del producto.
        /// Valida los datos antes de la actualización y lanza una excepción de tipo InvalidOperationException si alguno de los datos es inválido o está vacío.
        /// Actualiza los valores del producto en memoria y luego utiliza la clase ProductoDAO para actualizar el producto en la base de datos.
        /// Si ocurre un error al actualizar el producto en la base de datos, se lanza una excepción y se muestra un mensaje de error en la consola.
        /// </remarks>
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


        /// <summary>
        /// Obtiene la lista de productos desde la base de datos.
        /// </summary>
        /// <returns>La lista de productos obtenida desde la base de datos.</returns>
        /// <remarks>
        /// Este método utiliza la clase ProductoDAO para obtener todos los productos desde la base de datos.
        /// Retorna la lista de productos obtenida.
        /// </remarks>
        public List<Producto> ObtenerProductosDesdeBaseDeDatos()
        {
            ProductoDAO productoDAO = new ProductoDAO();
            List<Producto> productos = productoDAO.ObtenerTodos();
            return productos;
        }

        #endregion
    }
}
