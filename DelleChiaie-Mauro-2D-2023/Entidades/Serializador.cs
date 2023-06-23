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
        public static void SerializarEnJson(Venta ventas, string rutaArchivo)
        {
            try
            {
                // Leer el contenido actual del archivo JSON
                string json = File.ReadAllText(rutaArchivo);

                // Deserializar el JSON existente en una lista de ventas
                List<Venta> ventasExistentes = JsonConvert.DeserializeObject<List<Venta>>(json);

                // Agregar la nueva venta a la lista
                ventasExistentes.Add(ventas);

                // Serializar la lista actualizada de ventas en formato JSON
                string jsonActualizado = JsonConvert.SerializeObject(ventasExistentes, Newtonsoft.Json.Formatting.Indented);

                // Escribir el JSON actualizado en el archivo
                File.WriteAllText(rutaArchivo, jsonActualizado);
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
