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
    public partial class frmAgregarCorte : Form
    {
        #region PROPIEDADES

        Producto producto = new Producto();
        #endregion

        #region CONSTRUCTOR
        public frmAgregarCorte()
        {
            InitializeComponent();
            CargarProductos();
        }
        #endregion

        #region FUNCIONES

        private void CargarProductos()
        {
            List<Producto> productos = Producto.CargarProductos();
            dataGridView1.DataSource = productos;

            // Configurar las columnas del DataGridView
            dataGridView1.Columns["Id"].HeaderText = "ID";
            dataGridView1.Columns["Nombre"].HeaderText = "Nombre";
            dataGridView1.Columns["PrecioPorKilo"].HeaderText = "Precio por Kilo";
            dataGridView1.Columns["CantidadEnKilos"].HeaderText = "Cantidad en Kilos";
            dataGridView1.Columns["TipoCorte"].HeaderText = "Tipo de Corte";
        }


        private void frmAgregarCorte_Load(object sender, EventArgs e)
        {
            comboBoxTipo.Items.Add("Vacuno");
            comboBoxTipo.Items.Add("Cerdo");
            comboBoxTipo.Items.Add("Ave");

            // Si quieres seleccionar una opción por defecto, puedes hacerlo así:
            comboBoxTipo.SelectedIndex = 0; // Selecciona "Vacuno" por defecto
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreCorte = txtNombre.Text;
                double precio = Convert.ToDouble(txtPrecio.Text);
                double cantidad = Convert.ToDouble(numericUpDownCantidad.Value);
                string tipoCorte = comboBoxTipo.SelectedItem.ToString();

                producto.AgregarProducto(nombreCorte, precio, cantidad, tipoCorte);

                // Lógica adicional después de agregar el producto, como actualizar el DataGridView, mostrar mensajes, etc.
                MessageBox.Show("El producto se agregó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarProductos();

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al agregar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            // Aquí debes limpiar los campos del formulario para permitir el ingreso de un nuevo producto
            txtNombre.Clear();
            txtPrecio.Clear();
            numericUpDownCantidad.Value = 0;
        }
        private void buttonModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Obtener la fila seleccionada
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                    string nombreCorte = txtNombre.Text;
                    double precio = Convert.ToDouble(txtPrecio.Text);
                    double cantidad = Convert.ToDouble(numericUpDownCantidad.Value);
                    string tipoCorte = comboBoxTipo.SelectedItem.ToString();

                    // Validar que todos los campos estén completos
                    if (string.IsNullOrEmpty(nombreCorte) || precio <= 0 || cantidad <= 0 || string.IsNullOrEmpty(tipoCorte))
                    {
                        MessageBox.Show("Todos los campos son requeridos para modificar el producto.", "Modificar Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Crear un objeto Producto con los nuevos valores
                    Producto productoModificado = new Producto(nombreCorte, precio, cantidad, tipoCorte);

                    // Obtener el ID del producto seleccionado en el DataGridView
                    int idProducto = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);

                    // Modificar el producto en la base de datos
                    productoModificado.Id = idProducto;
                    productoModificado.ActualizarEnBaseDeDatos(nombreCorte, precio, cantidad);

                    // Actualizar el DataGridView con los nuevos datos
                    CargarProductos();

                    // Mostrar mensaje de éxito
                    MessageBox.Show("Producto modificado correctamente.", "Modificar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un producto para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el producto: " + ex.Message, "Modificar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Producto.CargarProductos();
        }


        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idProducto = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                try
                {
                    Producto producto = new Producto();

                    producto.EliminarProducto(idProducto);

                    CargarProductos();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error al eliminar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        #endregion

        #region SIN USAR
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion


    }
}
