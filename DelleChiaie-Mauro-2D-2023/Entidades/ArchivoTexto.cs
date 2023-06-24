using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArchivoTexto
    {
        #region MÉTODOS

        /// <summary>
        /// Guarda el historial de una venta en un archivo de texto.
        /// </summary>
        /// <param name="venta">La venta que se desea guardar en el historial.</param>
        /// <param name="rutaArchivo">La ruta completa del archivo de texto donde se guardará el historial.</param>
        /// <exception cref="Exception">Se lanza una excepción si ocurre un error al guardar el historial de ventas.</exception>
        public static void GuardarHistorialVentaEnTxt(Venta venta, string rutaArchivo)
        {
			try
			{
                // Crea un StreamWriter para escribir en el archivo de texto
                using (StreamWriter sw = new StreamWriter(rutaArchivo, true))
                {
                    //Escribo cada venta en una linea del archivo
                    sw.WriteLine($"Historial:");
                    sw.WriteLine(venta.ToString());
                }
            }
            catch (Exception ex)
			{
                throw new Exception($"Error al guardar el historial de ventas en el archivo: {ex.Message}", ex);
			}
        }

        /// <summary>
        /// Obtiene el contenido de un archivo como una cadena de texto.
        /// </summary>
        /// <param name="rutaArchivo">La ruta completa del archivo.</param>
        /// <returns>El contenido del archivo como una cadena de texto.</returns>
        /// <remarks>
        /// Si ocurre un error al obtener el contenido del archivo, se muestra un mensaje de error en la consola
        /// y se devuelve una cadena vacía.
        /// </remarks>
        public static string ObtenerContenido(string rutaArchivo)
        {
            try
            {
                // Lee el contenido del archivo y lo devuelve como una cadena de texto
                return File.ReadAllText(rutaArchivo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el contenido del archivo: " + ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Guarda el historial de compras en un archivo de texto.
        /// </summary>
        /// <param name="ventas">La lista de ventas que se desea guardar en el historial.</param>
        /// <remarks>
        /// El archivo de texto donde se guarda el historial se encuentra en la siguiente ruta:
        /// C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Debug\net6.0\historial_Compra.txt
        /// Cada venta en la lista se escribe en el archivo de texto con su respectiva información, incluyendo la fecha de venta,
        /// el producto, la cantidad y el precio total. Se separan las ventas con líneas divisorias.
        /// Si ocurre un error al guardar las ventas en el archivo de texto, se muestra un mensaje de error en la consola.
        /// </remarks>
        public static void GuardarHistorialCompraTxt(List<Venta> ventas)
        {
            string filePath = @"C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Debug\net6.0\historial_Compra.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath,true))
                {
                    foreach (Venta venta in ventas)
                    {
                        sw.WriteLine($"Fecha de Venta: {venta.FechaVenta}");
                        sw.WriteLine($"Producto: {venta.Producto}");
                        sw.WriteLine($"Cantidad: {venta.Cantidad}");
                        sw.WriteLine($"Precio Total: {venta.PrecioTotal}");
                        sw.WriteLine("---------------");
                    }
                }

                Console.WriteLine("Las ventas se han guardado en el archivo de texto.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar las ventas en el archivo de texto: " + ex.Message);
            }
        }

        #endregion
    }
}
