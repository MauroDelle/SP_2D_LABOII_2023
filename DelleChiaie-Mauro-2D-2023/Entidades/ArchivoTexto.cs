using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArchivoTexto
    {
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


    }
}
