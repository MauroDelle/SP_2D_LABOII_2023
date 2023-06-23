using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class ReponerMultiHilo
    {
        //public event EventHandler<string>? ProgresoReposicion;
        //public event EventHandler? ReposicionTerminada;
        ProductoDAO productoDAO = new ProductoDAO();
        public delegate void ProgresoReposicionEventHandler(int progreso);
        public delegate void ReposicionTerminadaEventHandler();

        public event ProgresoReposicionEventHandler? ProgresoReposicion;
        public event ReposicionTerminadaEventHandler? ReposicionTerminada;

        public void RealizarReposicionConcurrente(List<Producto> productos)
        {
            ProgresoReposicion?.Invoke(0); // Iniciar progreso en 0
            // Crear un semáforo para controlar la cantidad máxima de hilos concurrentes
            SemaphoreSlim semaphore = new SemaphoreSlim(10); // Establece el número máximo de hilos concurrentes aquí

            // Crear una lista para almacenar las tareas de reposición
            List<Task> tasks = new List<Task>();

            foreach (Producto producto in productos)
            {
                if (producto.CantidadEnKilos == 0)
                {
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

            // Esperar a que todas las tareas de reposición estén completas
            Task.WaitAll(tasks.ToArray());
            // Notificar finalización
            ReposicionTerminada?.Invoke();
        }
    }
}
