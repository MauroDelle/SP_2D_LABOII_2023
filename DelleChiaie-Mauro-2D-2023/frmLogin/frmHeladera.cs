using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class frmHeladera : Form
    {
        #region PROPIEDAD
        private Vendedor vendedor;
        #endregion

        #region CONSTRUCTOR
        public frmHeladera()
        {
            InitializeComponent();
            vendedor = new Vendedor();
            vendedor.CargarProductos();
            vendedor.CargarClientes();

            foreach (Cliente cliente in vendedor.ListaClientes)
            {
                comboBox1.Items.Add(cliente.Nombre);
            }
            comboBox1.DisplayMember = "Nombre";
        }
        #endregion

        #region FUNCIONES
        private void frmHeladera_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            if (vendedor.ListaProductos != null)
            {
                dataGridView1.DataSource = vendedor.ListaProductos;
            }
        }
        private void botonVender_Click(object sender, EventArgs e)
        {
            // Obtener el producto seleccionado en el DataGridView
            Producto productoSeleccionado = (Producto)dataGridView1.CurrentRow.DataBoundItem;

            // Obtener el cliente seleccionado en el ComboBox
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                return;
            }

            Cliente clienteSeleccionado = (Cliente)comboBox1.SelectedItem;
            clienteSeleccionado = vendedor.ObtenerClientePorNombre(clienteSeleccionado);

            if (clienteSeleccionado == null)
            {
                MessageBox.Show("El cliente seleccionado no existe.");
                return;
            }

            // Obtener la cantidad de kilos ingresada
            if (!double.TryParse(numericUpDown1.Text, out double cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad válida.");
                return;
            }

            // Vender el producto al cliente
            bool ventaExitosa = vendedor.VenderProducto(productoSeleccionado, cantidad, clienteSeleccionado);
            

            if (ventaExitosa)
            {
                // Actualizar el DataGridView y el ComboBox
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = vendedor.ListaProductos;

                comboBox1.DataSource = null;
                comboBox1.DataSource = vendedor.ListaClientes;
                comboBox1.DisplayMember = "Nombre";

                // Mostrar mensaje de venta exitosa
                MessageBox.Show("Venta realizada con éxito.");
            }
            else
            {
                // Mostrar mensaje de error
                MessageBox.Show("No se pudo realizar la venta.");
            }

        }
        private void MostrarSaldoClienteSeleccionado()
        {
            // Verificar que se haya seleccionado un cliente
            if (comboBox1.SelectedItem == null)
            {
                textBox1.Text = "";
                return;
            }
            // Actualizar la lista de clientes en el ComboBox
            comboBox1.DataSource = vendedor.ListaClientes;
            comboBox1.DisplayMember = "Nombre";

            // Obtener el cliente seleccionado
            Cliente clienteSeleccionado = (Cliente)comboBox1.SelectedItem;

            // Obtener la instancia del cliente seleccionado desde la lista de clientes del vendedor
            clienteSeleccionado = vendedor.ObtenerClientePorNombre(clienteSeleccionado);

            // Mostrar el saldo del cliente seleccionado en el TextBox correspondiente
            if (clienteSeleccionado != null)
            {
                textBox1.Text = clienteSeleccionado.Saldo.ToString("0.00");
            }
            else
            {
                textBox1.Text = "";
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarSaldoClienteSeleccionado();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MostrarSaldoClienteSeleccionado();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmReponer formReponer = new frmReponer(vendedor);
            formReponer.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmHistorialVenta formHistorial = new frmHistorialVenta(vendedor.ObtenerHistorialVenta());
            formHistorial.ShowDialog();
        }
        #endregion

        #region SIN USAR
        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
