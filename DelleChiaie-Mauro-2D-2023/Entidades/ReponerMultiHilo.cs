using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class ReponerMultiHilo
    {
        #region ATRIBUTOS
        ProductoDAO productoDAO = new ProductoDAO();
        #endregion

        #region DELEGATES
        public delegate void ProgresoReposicionEventHandler(int progreso);
        public delegate void ReposicionTerminadaEventHandler();
        #endregion

        #region EVENTOS
        public event ProgresoReposicionEventHandler? ProgresoReposicion;
        public event ReposicionTerminadaEventHandler? ReposicionTerminada;
        #endregion

        #region MÉTODO

        /// <summary>
        /// Realiza la reposición concurrente de productos en base a una lista dada.
        /// Cada producto que tenga una cantidad de cero será repuesto incrementando su cantidad en intervalos regulares.
        /// Se utiliza concurrencia para realizar las reposiciones de manera concurrente y mejorar el rendimiento.
        /// </summary>
        /// <param name="productos">La lista de productos a reponer.</param>
        /// <remarks>
        /// El método utiliza un semáforo para controlar la cantidad máxima de hilos concurrentes que realizan la reposición.
        /// Cada hilo espera a que haya un espacio disponible en el semáforo para comenzar la reposición de un producto.
        /// Durante la reposición, se actualiza la cantidad del producto en la base de datos y se notifica el progreso.
        /// Una vez que se completa la reposición de un producto, se libera un espacio en el semáforo para permitir que otro hilo comience.
        /// Al finalizar todas las reposiciones, se invoca el evento ReposicionTerminada para notificar que el proceso ha finalizado.
        /// </remarks>
        public void RealizarReposicionConcurrente(List<Producto> productos)
        {

                ProgresoReposicion?.Invoke(0); // Iniciar progreso en 0
                                               // Crear un semáforo para controlar la cantidad máxima de hilos concurrentes
                SemaphoreSlim semaphore = new SemaphoreSlim(10); // Establece el número máximo de hilos concurrentes aquí

                // Crear una lista para almacenar las tareas de reposición
                List<Task> tasks = new List<Task>();
                bool productosEnReposicion = false; // Variable para verificar si se encontraron productos para reponer

                foreach (Producto producto in productos)
                {
                    if (producto.CantidadEnKilos == 0)
                    {
                        productosEnReposicion = true; // Hay productos para reponer

                        semaphore.Wait(); // Esperar a que haya un espacio disponible en el semáforo

                        // Crear una tarea para reponer el producto
                        Task task = Task.Run(() =>
                        {
                            for (int i = 1; i <= 15; i++)
                            {
                                Thread.Sleep(2000);
                                producto.CantidadEnKilos = i;

                                // Actualizar la cantidad en la base de datos
                                ProductoDAO productoDAO = new ProductoDAO();
                                productoDAO.ActualizarEnBaseDeDatos(producto);

                                // Notificar progreso
                                ProgresoReposicion?.Invoke(i);
                            }
                            semaphore.Release(); // Liberar un espacio en el semáforo cuando la tarea esté completa
                        });
                        tasks.Add(task);
                    }
                }
            if (!productosEnReposicion)
            {
                throw new NoProductosException("No hay productos para reponer.");
            }
            Task.WaitAll(tasks.ToArray());
                ReposicionTerminada?.Invoke();
                // Esperar a que todas las tareas de reposición estén completas
                // Notificar finalización

        }
       
        #endregion
    }
}
