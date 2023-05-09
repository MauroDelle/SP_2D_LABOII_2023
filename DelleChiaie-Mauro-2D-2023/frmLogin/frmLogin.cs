using Entidades;
using Formularios;
using System;

namespace frmLogin
{
    public partial class LoginForm : Form
    {
        #region CONSTRUCTOR
        public LoginForm()
        {
            InitializeComponent();
        }
        #endregion

        #region FUNCIONES
        private void button1_Click(object sender, EventArgs e)
        {
            string correo = textBox1.Text;
            string constrasenia = textBox2.Text;
            Login login = new Login();
            Vendedor vendedor = new Vendedor();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"PS2-Startup-Screen-QuickSounds.com.wav");

            bool inicioSesionExitoso = login.RedirigirUsuario(correo, constrasenia);  

            if(inicioSesionExitoso)
            {
                if(login.UsuarioActual.EsVendedor())
                {
                    frmHeladera heladera = new frmHeladera();
                    player.Play();
                    heladera.Show();
                    this.Hide();
                }
                else
                {
                    frmVenta venta = new frmVenta(vendedor);
                    player.Play();
                    venta.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Correo o constraseña incorrectos");
            }
        }
        private void AutocompletarVendedor()
        {
            textBox1.Text = "juan@gmail.com";
            textBox2.Text = "vendedorvendedor1";
            button2.Enabled = false;
            textBox2.UseSystemPasswordChar = true;
            button3.Enabled = true;
        }
        private void AutocompletarCliente()
        {
            textBox1.Text = "mauro@gmail.com";
            textBox2.Text = "clientecliente1";
            textBox2.UseSystemPasswordChar = true;
            button2.Enabled = true;
            button3.Enabled = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
            AutocompletarVendedor();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGreen;
            AutocompletarCliente();
        }
        private void btnMostrarContraseña_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
        #endregion

        #region SIN USAR
        private void UseSystemPasswordChar(object sender, MouseEventArgs e)
        {
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}