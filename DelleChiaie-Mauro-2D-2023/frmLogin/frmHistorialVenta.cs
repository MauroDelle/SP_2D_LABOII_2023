using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class frmHistorialVenta : Form
    {
        #region ATRIBUTO
        List<Venta> historialVentas;
        #endregion

        #region CONSTRUCTOR
        public frmHistorialVenta(List<Venta> _historialVentas)
        {
            InitializeComponent();
            this.historialVentas = _historialVentas;
            textBoxHistorial.Multiline = true;
            textBoxHistorial.ScrollBars = ScrollBars.Vertical;
            textBoxHistorial.ReadOnly = true;
        }

        #endregion

        #region FUNCIONES
        private void btnSerializarJson_Click(object sender, EventArgs e)
        {
            Serializador.SerializarEnJson(this.historialVentas);

            MessageBox.Show("Serialización en JSON realizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            historialVentas.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxHistorial.Clear();
            string rutaArchivoXml = @"C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Archivos\ventas.xml";

            try
            {
                // Leer el contenido del archivo XML
                string contenidoXml = File.ReadAllText(rutaArchivoXml);

                // Mostrar el contenido en el TextBox
                textBoxHistorial.Text = contenidoXml;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al deserializar el archivo XML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rutaArchivoJson = @"C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Archivos\ventas.json";
            textBoxHistorial.Clear();
            try
            {
                // Leer el contenido del archivo JSON
                string contenidoJson = File.ReadAllText(rutaArchivoJson);

                // Mostrar el contenido en el TextBox
                textBoxHistorial.Text = contenidoJson;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al deserializar el archivo JSON: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region SIN USAR
        private void frmHistorialVenta_Load(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void textBoxHistorial_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }


        #endregion

    }
}
