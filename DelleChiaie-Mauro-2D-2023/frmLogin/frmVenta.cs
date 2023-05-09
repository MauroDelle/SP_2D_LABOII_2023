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
    public partial class frmVenta : Form
    {
        #region ATRIBUTOS
        private Vendedor _vendedor;
        private Cliente cliente;
        #endregion

        #region CONSTRUCTOR

        public frmVenta(Vendedor vendedor)
        {
            InitializeComponent();
            _vendedor = vendedor;
            _vendedor.CargarProductos();
            cliente = new Cliente();
        }
        #endregion

        #region SIN USAR
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void btnAgregarAlCarro_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region FUNCIONES
        private void frmVenta_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            dgvCarrito.Columns.Add("Nombre", "Nombre");
            dgvCarrito.Columns.Add("Precio", "Precio por kilo");
            dgvCarrito.Columns.Add("Cantidad","Cantidad");

            dgvCarrito.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "Remover",
                HeaderText = "Remover",
                Text = "Remover",
                UseColumnTextForButtonValue = true
            });

            if (_vendedor.ListaProductos != null)
            {
                dataGridView1.DataSource = _vendedor.ListaProductos;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double montoMaximo)&& montoMaximo > 0)
            {
                cliente.Saldo = montoMaximo;
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un monto válido mayor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string terminoBusqueda = txtBusqueda.Text.ToLower();

            List<Producto> productosFiltrados = _vendedor.ListaProductos.Where(p => p.Nombre.ToLower().Contains(terminoBusqueda)).ToList();

            if (productosFiltrados.Count == 0)
            {
                MessageBox.Show("No se encontraron productos que coincidan con el término de búsqueda.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridView1.DataSource= productosFiltrados;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            if (_vendedor.ListaProductos != null)
            {
                dataGridView1.DataSource = _vendedor.ListaProductos;
            }
        }
        private void ActualizarCarritoDeCompras()
        {
            //Limpio el datagridview del carrito de compras
            dgvCarrito.Rows.Clear();

            List<Producto> productosEnCarrito = cliente.CarritoDeProductos;

            foreach (Producto producto in productosEnCarrito)
            {
                dgvCarrito.Rows.Add(producto.Nombre, producto.PrecioPorKilo,producto.CantidadEnKilos);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //primero verifico si se hizo clic en el boton de agregar al carrito;
            if (e.ColumnIndex == dataGridView1.Columns["Agregar"].Index && e.RowIndex >= 0)
            {
                //obtengo el producto seleccionado
                Producto producto = (Producto)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                double cantidad = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].Value);

                if (cantidad > 0)
                {
                    cliente.AgregarProductoAlCarrito(producto, cantidad);

                    //actualizo la visualizacion del carrito de compras
                    ActualizarCarritoDeCompras();
                }
                else
                {
                    MessageBox.Show("Por favor ingrese una cantidad válida.");
                }
            }
        }
        private void dgvCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCarrito.Columns["Remover"].Index && e.RowIndex >= 0)
            {
                // Obtengo el índice de la fila seleccionada
                int rowIndex = e.RowIndex;

                // Verifico si hay elementos en el carrito
                if (cliente.CarritoDeProductos.Count > 0)
                {
                    // Obtengo el producto correspondiente a la fila seleccionada
                    Producto producto = cliente.CarritoDeProductos[rowIndex];

                    // Remuevo el producto del carrito
                    cliente.CarritoDeProductos.Remove(producto);

                    // Actualizo la tabla
                    ActualizarCarritoDeCompras();
                }
                else
                {
                    MessageBox.Show("No hay productos en el carrito.", "Carrito vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (cliente.CarritoDeProductos.Count == 0 || cliente.Saldo < 900)
            {
                MessageBox.Show("No hay productos en el carrito. y el monto debe ser mayor a $900 Por favor agregue productos antes de realizar la compra.", "Carrito vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    bool esPagoConCredito = radioButtonCredito.Checked;
                    cliente.RealizarCompra(esPagoConCredito, cliente.CarritoDeProductos, _vendedor.ListaProductos);
                    MessageBox.Show("Compra realizada con éxito.");
                    MessageBox.Show(cliente.Mostrar());
                    // refresco la fuente de datos en la interfaz de usuario
                    textBox1.Text = cliente.Saldo.ToString();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = _vendedor.ListaProductos;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al realizar la compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
