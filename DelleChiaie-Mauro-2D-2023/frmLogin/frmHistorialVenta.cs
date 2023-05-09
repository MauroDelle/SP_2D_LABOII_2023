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
        #region CONSTRUCTOR
        public frmHistorialVenta(List<Venta> historialVenta)
        {
            InitializeComponent();
            DataGridViewTextBoxColumn colProducto = new DataGridViewTextBoxColumn();
            colProducto.DataPropertyName = "Producto";
            colProducto.HeaderText = "Producto";
            dataGridView1.Columns.Add(colProducto);

            DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn();
            colFecha.DataPropertyName = "FechaVenta";
            colFecha.HeaderText = "Fecha";
            dataGridView1.Columns.Add(colFecha);

            DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn();
            colCantidad.DataPropertyName = "Cantidad";
            colCantidad.HeaderText = "Cantidad";
            dataGridView1.Columns.Add(colCantidad);

            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.DataPropertyName = "PrecioTotal";
            colTotal.HeaderText = "Total";
            dataGridView1.Columns.Add(colTotal);

            foreach (Venta venta in historialVenta)
            {
                dataGridView1.Rows.Add(venta._Producto.Nombre, venta.FechaVenta, venta.Cantidad, venta.PrecioTotal);
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
        #endregion

    }
}
