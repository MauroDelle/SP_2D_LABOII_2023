using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class frmVenta : Form
    {
        #region ATRIBUTOS
        private Vendedor _vendedor;
        private Cliente cliente;
        private Producto producto;
        private List<string> nombresProductosEnCarrito = new List<string>(); // Lista auxiliar para almacenar los nombres de los productos en el carrito

        #endregion

        #region CONSTRUCTOR

        public frmVenta()
        {
            InitializeComponent();
            CargarProductos();
            cliente = new Cliente();
            producto = new Producto();
        }
        #endregion

        #region SIN USAR
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private int ObtenerCantidad()
        {
            int cantidad = 0;
            bool cantidadValida = false;

            while (!cantidadValida)
            {
                string cantidadStr = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la cantidad:", "Cantidad", "");

                if (int.TryParse(cantidadStr, out cantidad) && cantidad > 0)
                {
                    cantidadValida = true;
                }
                else
                {
                    MessageBox.Show("Cantidad inválida. Por favor, ingrese un número válido mayor o igual a cero.");
                }
            }

            return cantidad;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Agregar"].Index)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                Producto producto = (Producto)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                // Validar si el producto ya está en el carrito
                if (nombresProductosEnCarrito.Contains(producto.Nombre))
                {
                    MessageBox.Show("Ya has agregado este producto al carrito.");
                    return;
                }

                int cantidad = ObtenerCantidad(); // Obtener la cantidad ingresada por el usuario

                if (cantidad > producto.CantidadEnKilos)
                {
                    MessageBox.Show("No hay suficiente stock disponible.");
                    return;
                }

                DataGridViewCell stockCell = row.Cells["CantidadEnKilos"];
                stockCell.Value = producto.CantidadEnKilos.ToString();

                cliente.AgregarProductoAlCarrito(producto, cantidad);
                dgvCarrito.Rows.Add(producto.Nombre, producto.PrecioPorKilo, cantidad);

                if (producto.CantidadEnKilos == 0)
                {
                    row.Visible = false; // Ocultar la fila cuando la cantidad llega a cero
                }

                // Agregar el nombre del producto a la lista auxiliar
                nombresProductosEnCarrito.Add(producto.Nombre);
            }
        }
        private void btnAgregarAlCarro_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region FUNCIONES
        private void frmVenta_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double montoMaximo) && montoMaximo > 0)
            {
                cliente.Saldo = montoMaximo;
                textBox1.Text = cliente.Saldo.ToString("C2");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un monto válido mayor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBusqueda.Text.Trim();

            // Validar que el texto contenga solo letras, espacios y la primera letra sea mayúscula
            if (!Regex.IsMatch(textoBusqueda, "^[A-Za-zÁÉÍÓÚÑáéíóúñ ]+$"))
            {
                MessageBox.Show("El texto ingresado no es válido. Solo se permiten letras y espacios.");
                return;
            }

            // Convertir la primera letra a mayúscula
            textoBusqueda = char.ToUpper(textoBusqueda[0]) + textoBusqueda.Substring(1);

            ProductoDAO productoDAO = new ProductoDAO();
            List<Producto> productosFiltrados = productoDAO.ObtenerProductosPorNombre(textoBusqueda);

            if (productosFiltrados.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados para la búsqueda.");
            }
            else
            {
                dataGridView1.DataSource = productosFiltrados;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Producto.CargarProductos();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dgvCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCarrito.Columns["Quitar"].Index && e.RowIndex >= 0)
            {
                if (dgvCarrito.Rows.Count > 0)
                {
                    try
                    {
                        QuitarDelCarrito(e.RowIndex);
                        nombresProductosEnCarrito.Clear();
                        dgvCarrito.Rows.Clear();
                        dataGridView1.DataSource = Producto.CargarProductos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al quitar el producto del carrito: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El carrito está vacío.", "Carrito Vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (!radioButtonCredito.Checked && !radioButtonEfectivo.Checked)
            {
                MessageBox.Show("Por favor, seleccione un método de pago.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cliente.CarritoDeProductos.Count == 0)
            {
                MessageBox.Show("No hay productos en el carrito!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (cliente.Saldo < 0)
            {
                MessageBox.Show("No ingreso el saldo!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                try
                {
                    bool esPagoConCredito = radioButtonCredito.Checked;

                    cliente.RealizarCompra(esPagoConCredito, cliente.CarritoDeProductos);
                    dgvCarrito.Rows.Clear();
                    nombresProductosEnCarrito.Clear();
                    MessageBox.Show("Compra realizada con éxito.");
                    // Actualizar el valor del TextBox con el nuevo saldo del cliente
                    textBox1.Text = cliente.Saldo.ToString("C2");
                    dataGridView1.DataSource = Producto.CargarProductos();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al realizar la compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

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

        private void QuitarDelCarrito(int rowIndex)
        {
            try
            {
                if (rowIndex < 0 || rowIndex >= dgvCarrito.Rows.Count)
                {
                    MessageBox.Show("No se ha seleccionado un producto válido para eliminar.", "Producto no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataGridViewRow selectedRow = dgvCarrito.Rows[rowIndex];

                // Verificar si las celdas no son null antes de acceder a sus valores
                if (selectedRow.Cells["Nombre"].Value != null && selectedRow.Cells["precio"].Value != null && selectedRow.Cells["Cantidad"].Value != null)
                {
                    string nombreProducto = selectedRow.Cells["Nombre"].Value.ToString();
                    double precioProducto = Convert.ToDouble(selectedRow.Cells["precio"].Value);
                    double cantidadProducto = Convert.ToDouble(selectedRow.Cells["Cantidad"].Value);

                    // Resto del código de actualización del stock en el DataGridView de productos aquí...

                    dgvCarrito.Rows.RemoveAt(rowIndex);
                    cliente.CarritoDeProductos.Remove(producto);
                }
                else
                {
                    MessageBox.Show("La fila seleccionada no contiene valores válidos.", "Valores no válidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto del carrito: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double ObtenerPresupuestoActual()
        {
            double presupuesto = 0.0;
            if (double.TryParse(textBox1.Text, out presupuesto))
            {
                return presupuesto;
            }

            // Si el valor ingresado no es válido, mostrar un mensaje de error o tomar alguna acción apropiada
            MessageBox.Show("Ingrese un valor válido para el presupuesto actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return presupuesto;
        }
        private bool ObtenerTipoPago()
        {
            // Verificar qué radio button está seleccionado y devolver el valor correspondiente
            if (radioButtonEfectivo.Checked)
            {
                return true; // Efectivo
            }
            else if (radioButtonCredito.Checked)
            {
                return false; // Tarjeta de crédito
            }

            // Si no se seleccionó ningún radio button, mostrar un mensaje de error o tomar alguna acción apropiada
            MessageBox.Show("Seleccione el tipo de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        #endregion

    }
}
