using Entidades;
namespace UnitTesting
{
    [TestClass]
    public class SerializadorTesting
    {
        [TestMethod]
        public void SerializarEnJson_DeberiaSerializarVentasEnArchivoJson()
        {
            // Arrange
            List<Venta> ventas = new List<Venta>()
        {
            new Venta(new Producto(), 5, 100.0, DateTime.Now),
            new Venta(new Producto(), 3, 50.0, DateTime.Now)
        };

            // Act
            bool resultado = Serializador.SerializarEnJson(ventas);

            // Assert
            Assert.IsTrue(resultado);
            // Asegúrate de verificar que el archivo JSON se haya creado y contenga las ventas serializadas correctamente
            // Puedes realizar las comprobaciones necesarias utilizando métodos de lectura de archivos o pruebas adicionales
        }

        [TestMethod]
        public void SerializarXml_DeberiaSerializarVentasEnArchivoXml()
        {
            // Arrange
            List<Venta> ventas = new List<Venta>()
        {
            new Venta(new Producto(), 5, 100.0, DateTime.Now),
            new Venta(new Producto(), 3, 50.0, DateTime.Now)
        };

            // Act
            Serializador.SerializarXml(ventas);

            // Assert
            string rutaArchivo = @"C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Archivos\ventas.xml";
            Assert.IsTrue(File.Exists(rutaArchivo));

            // Puedes realizar más comprobaciones para verificar que el archivo XML se haya creado y contenga las ventas serializadas correctamente
            // Puedes utilizar métodos de lectura de archivos o pruebas adicionales
        }

        [TestMethod]
        public void SerializarXml_SinVentas_DeberiaCrearArchivoXmlVacio()
        {
            // Arrange
            List<Venta> ventas = new List<Venta>();

            // Act
            Serializador.SerializarXml(ventas);

            // Assert
            string rutaArchivo = @"C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Archivos\ventas.xml";
            Assert.IsTrue(File.Exists(rutaArchivo));

            // Puedes realizar más comprobaciones para verificar que el archivo XML se haya creado correctamente, incluso si está vacío
            // Puedes utilizar métodos de lectura de archivos o pruebas adicionales
        }

    }
}