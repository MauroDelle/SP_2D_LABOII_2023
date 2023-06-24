using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class ArchivoTextoTesting
    {
        [TestMethod]
        public void GuardarHistorialVentaEnTxt_DeberiaEscribirVentaEnArchivoTxt()
        {
            // Arrange
            string rutaArchivo = @"C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Debug\net6.0\historial_ventas.txt";
            Venta venta = new Venta(new Producto(), 5, 100.0, DateTime.Now);

            // Act
            ArchivoTexto.GuardarHistorialVentaEnTxt(venta, rutaArchivo);

            // Assert
            string contenidoArchivo = File.ReadAllText(rutaArchivo);
            Assert.IsTrue(contenidoArchivo.Contains("Historial:"));
            Assert.IsTrue(contenidoArchivo.Contains(venta.ToString()));
        }

        public void ObtenerContenido_DeberiaDevolverContenidoArchivo()
        {
            // Arrange
            string rutaArchivo = @"C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Debug\net6.0\historial_ventas.txt";
            string contenidoEsperado = "Contenido de prueba";
            File.WriteAllText(rutaArchivo, contenidoEsperado);

            // Act
            string contenidoObtenido = ArchivoTexto.ObtenerContenido(rutaArchivo);

            // Assert
            Assert.AreEqual(contenidoEsperado, contenidoObtenido);
        }

        public void ObtenerContenido_ArchivoNoExiste_DeberiaDevolverCadenaVacia()
        {
            // Arrange
            string rutaArchivo = @"C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Debug\net6.0\historial_ventas.txt";

            // Act
            string contenidoObtenido = ArchivoTexto.ObtenerContenido(rutaArchivo);

            // Assert
            Assert.AreEqual(string.Empty, contenidoObtenido);
        }

    }


}
