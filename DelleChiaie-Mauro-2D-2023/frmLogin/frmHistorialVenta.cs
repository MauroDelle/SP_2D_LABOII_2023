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
        List<Venta> historialVentas;

        #region CONSTRUCTOR
        public frmHistorialVenta(List<Venta> historialVentas)
        {
            InitializeComponent();
            this.historialVentas = historialVentas;
        }

        #endregion

        #region SIN USAR
        private void frmHistorialVenta_Load(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        #endregion

        private void textBoxHistorial_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSerializarJson_Click(object sender, EventArgs e)
        {
            string nombreArchivo = "historial_ventas.json";
            string rutaArchivoJson = Path.Combine(@"C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Archivos", nombreArchivo);

            Serializador.SerializarEnJson(this.historialVentas, rutaArchivoJson);

            MessageBox.Show("Serialización en JSON realizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
