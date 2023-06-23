using System.Xml;
using System.Xml.Serialization;
using System.Text.Json;
using Newtonsoft.Json;

namespace Entidades
{
    public static class Serializador
    {
        public static bool SerializarEnJson(List<Venta> ventas)
        {
            bool esValido = false;

            try
            {
                string rutaArchivo = @"C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Archivos\ventas.json";

                // Crear o abrir el archivo JSON en modo de escritura
                using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
                {
                    // Serializar cada venta por separado y escribirla en el archivo
                    foreach (Venta venta in ventas)
                    {
                        string json = JsonConvert.SerializeObject(venta);
                        writer.WriteLine(json);
                        writer.WriteLine(); // Agregar una línea vacía como separador
                    }
                }
                esValido = true;
            }
            catch (Exception ex)
            {
                esValido = false;
                throw new Exception(ex.Message);
            }

            return esValido;
        }

        public static void SerializarXml(List<Venta> ventasRealizadas)
        {
            // Obtener la ruta del archivo XML
            string rutaArchivo = @"C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Archivos\ventas.xml";

            // Crear un objeto XmlSerializer para realizar la serialización
            XmlSerializer serializer = new XmlSerializer(typeof(List<Venta>));

            // Crear un FileStream para escribir en el archivo
            using (FileStream fileStream = new FileStream(rutaArchivo, FileMode.Create))
            {
                // Serializar la lista de ventas y escribir los datos en el archivo
                serializer.Serialize(fileStream, ventasRealizadas);
            }
        }

    }
}
