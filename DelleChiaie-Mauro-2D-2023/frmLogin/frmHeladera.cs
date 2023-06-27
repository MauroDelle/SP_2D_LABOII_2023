using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Formularios
{
    public partial class frmHeladera : Form
    {
        #region PROPIEDAD
        private Vendedor vendedor;
        private Cliente clientes;
        private ReponerMultiHilo reponerMultiHilo;
        private bool descuentoPorJubiladoAplicado = false;
        #endregion

        #region CONSTRUCTOR
        public frmHeladera()
        {
            InitializeComponent();
            clientes = new Cliente();
            vendedor = new Vendedor();
            reponerMultiHilo = new ReponerMultiHilo();
            CargarClientes();
            CargarProductos();
        }
        #endregion

        #region FUNCIONES
        private void frmHeladera_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }
        private void botonVender_Click(object sender, EventArgs e)
        {
            // Validar selección de producto
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Producto productoSeleccionado = dataGridView1.CurrentRow.DataBoundItem as Producto;

            // Validar ingreso de cantidad
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cantidad = (int)numericUpDown1.Value;

            // Validar selección de forma de pago
            if (!radioButtonEfectivo.Checked && !radioButtonTarjeta.Checked)
            {
                MessageBox.Show("Debe seleccionar una forma de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool esEfectivo = radioButtonEfectivo.Checked;

            // Validar selección de cliente
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cliente clienteSeleccionado = comboBox1.SelectedItem as Cliente;

            bool ventaExitosa = vendedor.Vender(productoSeleccionado, clienteSeleccionado, cantidad, esEfectivo);

            if (ventaExitosa)
            {
                if (clienteSeleccionado.Edad > 65)
                {
                    MessageBox.Show("Se aplico un descuento por jubilado.");
                }
                // Actualizar el saldo en el formulario
                vendedor.ActualizarSaldoCliente(clienteSeleccionado);

                textBox1.Text = clienteSeleccionado.Saldo.ToString("C2");
                vendedor.ActualizarCantidadProductoEvent += ActualizarCantidadProducto;
                MessageBox.Show("Venta Realizada con Exito!");
                dataGridView1.DataSource = Producto.CargarProductos();
                // Suscribirse al evento
            }
            else
            {
                // Mostrar mensaje de saldo insuficiente
                MessageBox.Show("Stock o Saldo Insuficiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarCantidadProducto(Producto producto)
        {
            // Buscar la fila correspondiente al producto en el DataGridView
            DataGridViewRow fila = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => r.Cells["Id"].Value.ToString() == producto.Id.ToString());

            if (fila != null)
            {
                // Actualizar la cantidad en la columna correspondiente
                fila.Cells["Cantidad"].Value = producto.CantidadEnKilos;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente clienteSeleccionado = comboBox1.SelectedItem as Cliente;

            if (clienteSeleccionado != null)
            {
                textBox1.Text = clienteSeleccionado.FormatearSaldo();
                textBox2.Text = clienteSeleccionado.FormatearEdad();

                int edadCliente = clienteSeleccionado.Edad;
                textBox2.Text = edadCliente.ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            List<Producto> productos = Producto.CargarProductos();
            reponerMultiHilo = new ReponerMultiHilo();

            reponerMultiHilo.ProgresoReposicion += ProgresoReposicionHandler;
            reponerMultiHilo.ReposicionTerminada += ReposicionTerminadaHandler;

            Thread reposicionThread = new Thread(() => reponerMultiHilo.RealizarReposicionConcurrente(productos));
            reposicionThread.Start();
        }


        private void ProgresoReposicionHandler(int progreso)
        {
            // Invocar la actualización del control desde el subproceso principal
            Invoke((MethodInvoker)delegate
            {
                progressBar.Visible = true;
                // Actualizar la interfaz de usuario con el progreso actual
                progressBar.Value = progreso;
                dataGridView1.DataSource = Producto.CargarProductos();
                label1.Text = $"Reponiendo productos... ({progreso}/15)";
            });
        }

        private void ReposicionTerminadaHandler()
        {
            // Invocar la actualización del control desde el subproceso principal
            Invoke((MethodInvoker)delegate
            {
                // Mostrar mensaje de reposición terminada
                MessageBox.Show("Reposición finalizada");
                // Actualizar la interfaz de usuario después de la reposición
                // ...
                label1.Text = "Productos";
                progressBar.Visible = false;
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string contenido = ArchivoTexto.ObtenerContenido(@"C:\Users\delle\OneDrive\Escritorio\PP_2D_LABOII_2023\DelleChiaie-Mauro-2D-2023\Carniceria\bin\Debug\net6.0\historial_ventas.txt");
            frmHistorialVenta formHistorial = new frmHistorialVenta(vendedor.ObtenerHistorialVenta());
            formHistorial.textBoxHistorial.Text = contenido;
            formHistorial.ShowDialog();
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

        private void CargarClientes()
        {
            List<Cliente> listaClientes = clientes.CargarClientes();

            comboBox1.DataSource = listaClientes;
            comboBox1.DisplayMember = "NombreCompleto"; // Propiedad que muestra el nombre completo en el ComboBox
        }

        private void nuevoProducto_Click(object sender, EventArgs e)
        {
            frmAgregarCorte agregarCorte = new frmAgregarCorte();
            agregarCorte.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }
        #endregion

        #region SIN USAR
        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void progressBar_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void btnActualizarSaldo_Click(object sender, EventArgs e)
        {
            double nuevoSaldo;
            if (!double.TryParse(textBox1.Text, out nuevoSaldo) || nuevoSaldo <= 0)
            {
                MessageBox.Show("Ingrese un valor válido y no negativo para el nuevo saldo.");
                return;
            }

            string nombreCliente = comboBox1.SelectedItem.ToString();

            // Utiliza el método ObtenerIdClientePorNombre para obtener el ID del cliente
            ClienteDAO clienteDAO = new ClienteDAO();
            int idCliente = clienteDAO.ObtenerIdCLientePorNombre(nombreCliente);

            // Verifica que se haya obtenido un ID válido
            if (idCliente != -1)
            {
                // Utiliza la instancia de ClienteDAO para actualizar el saldo del cliente
                clienteDAO.ActualizarSaldoCliente(idCliente, nuevoSaldo);

                // Actualiza el valor del textbox con el nuevo saldo
                textBox1.Text = nuevoSaldo.ToString("C2");

                MessageBox.Show("Saldo actualizado correctamente.");
                CargarClientes();
            }
            else
            {
                MessageBox.Show("No se pudo obtener el ID del cliente.");
            }
        }
    }
}
