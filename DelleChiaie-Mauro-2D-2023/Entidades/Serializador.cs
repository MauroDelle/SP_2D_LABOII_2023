using System.Xml;
using System.Xml.Serialization;
using System.Text.Json;
using Newtonsoft.Json;

namespace Entidades
{
    public static class Serializador
    {
        #region MÉTODOS

        /// <summary>
        /// Serializa una lista de ventas en formato JSON y las guarda en un archivo.
        /// </summary>
        /// <param name="ventas">La lista de ventas a serializar.</param>
        /// <returns>true si la serialización y guardado fueron exitosos, de lo contrario false.</returns>
        /// <exception cref="Exception">Se lanza una excepción si ocurre un error durante la serialización o el guardado.</exception>
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

        /// <summary>
        /// Serializa una lista de ventas en formato XML y guarda los datos en un archivo.
        /// </summary>
        /// <param name="ventasRealizadas">La lista de ventas a serializar.</param>
        /// <remarks>
        /// El método utiliza la clase XmlSerializer para realizar la serialización de la lista de ventas en formato XML.
        /// Se especifica el tipo de datos a serializar como typeof(List<Venta>).
        /// A continuación, se crea un FileStream para escribir en el archivo XML especificado.
        /// Finalmente, se llama al método Serialize del XmlSerializer para escribir los datos serializados en el archivo.
        /// </remarks>
        public static void SerializarXml(List<Venta> ventasRealizadas)
        {
            // Obtener la ruta del archivo XML
            string rutaArchivo = @"C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Archivos\ventas.xml";

            // Crear un objeto XmlSerializer para realizar la serialización
            XmlSerializer serializer = new XmlSerializer(typeof(List<Venta>));

            // Crear una lista para almacenar las ventas existentes
            List<Venta> ventasExistentes;

            // Verificar si el archivo XML ya existe
            if (File.Exists(rutaArchivo))
            {
                // Crear un FileStream para leer el archivo existente
                using (FileStream fileStream = new FileStream(rutaArchivo, FileMode.Open))
                {
                    // Deserializar las ventas existentes
                    ventasExistentes = (List<Venta>)serializer.Deserialize(fileStream);
                }

                // Agregar las nuevas ventas a la lista existente
                ventasExistentes.AddRange(ventasRealizadas);
            }
            else
            {
                // Si el archivo no existe, utilizar las nuevas ventas como la lista completa
                ventasExistentes = ventasRealizadas;
            }

            // Crear un FileStream para escribir en el archivo
            using (FileStream fileStream = new FileStream(rutaArchivo, FileMode.Create))
            {
                // Serializar la lista combinada de ventas y escribir los datos en el archivo
                serializer.Serialize(fileStream, ventasExistentes);
            }
        }
        #endregion
    }
}
