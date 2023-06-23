using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Text.Json;
using System.Data;
using System.IO;
using Newtonsoft.Json;

namespace Entidades
{
    public static class Serializador
    {
        public static void SerializarEnJson(List<Venta> ventas, string rutaArchivo)
        {
            try
            {
                // Serializar la lista de ventas en formato JSON
                string json = JsonConvert.SerializeObject(ventas, Newtonsoft.Json.Formatting.Indented);

                // Escribir el JSON en un archivo
                File.WriteAllText(rutaArchivo, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al serializar en JSON: {ex.Message}", ex);
            }
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
