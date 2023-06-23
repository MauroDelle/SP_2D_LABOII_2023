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
    public partial class frmReponer : Form
    {
        #region ATRIBUTO

        private Vendedor vendedor;
        #endregion

        #region CONSTRUCTOR
        public frmReponer(Vendedor vendedorPrincipal)
        {
            InitializeComponent();
            vendedor = vendedorPrincipal;
        }
        #endregion

        #region FUNCIONES

        private void frmReponer_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = null;

            //if (vendedor.ListaProductos != null)
            //{
            //    dataGridView1.DataSource = vendedor.ListaProductos;
            //}
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //// Obtener el producto seleccionado en el DataGridView
            //Producto productoSeleccionado = (Producto)dataGridView1.CurrentRow.DataBoundItem;
            //// Obtener la cantidad de kilos ingresada
            //if (!double.TryParse(textBox1.Text, out double cantidad) || cantidad <= 0 || cantidad >= 15)
            //{
            //    MessageBox.Show("Debe ingresar una cantidad válida. 1-15");
            //    return;
            //}

            //// Reponer el producto
            //if (vendedor.ReponerProducto(productoSeleccionado, cantidad))
            //{
            //    MessageBox.Show("Reposición realizada con éxito.");
            //}
            //else
            //{
            //    MessageBox.Show("No se pudo realizar la reposición.");
            //}
        }

        private void frmReponer_Activated(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = null;
            //if (vendedor.ListaProductos != null)
            //{
            //    dataGridView1.DataSource = vendedor.ListaProductos;
            //}
        }
        #endregion

        #region SIN USAR

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
