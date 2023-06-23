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
            string contrasenia = textBox2.Text;
            bool esVendedor;
            Login login = new Login();

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasenia))
            {
                MessageBox.Show("Ingrese el correo y la contraseña.");
                return;
            }

            try
            {
                bool autenticado = login.AutenticarUsuario(correo, contrasenia, out esVendedor);

                if (autenticado)
                {
                    //Aqui la logica de inicio de sesion
                    if (esVendedor)
                    {
                        // Acciones para un vendedor
                        MessageBox.Show("Bienvenido Vendedor");
                        frmHeladera frmHeladera = new frmHeladera();
                        frmHeladera.Show();
                    }
                    else
                    {
                        frmVenta frmVenta = new frmVenta();
                        MessageBox.Show("Bienvenido Cliente");
                        frmVenta.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Credenciales inválidas. Por favor, verifique el correo y la contraseña.");
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error genérico en caso de excepción
                MessageBox.Show("Error en el inicio de sesión: " + ex.Message);
            }
        }
        private void AutocompletarVendedor()
        {
            textBox1.Text = "pepito@mail.com";
            textBox2.Text = "pepito123";
            button2.Enabled = false;
            textBox2.UseSystemPasswordChar = true;
            button3.Enabled = true;
        }
        private void AutocompletarCliente()
        {
            textBox1.Text = "mauro@mail.com";
            textBox2.Text = "mauro123";
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

        #region Parte Vieja
        //string correo = textBox1.Text;
        //string constrasenia = textBox2.Text;
        //Login login = new Login();
        //Vendedor vendedor = new Vendedor();

        //bool inicioSesionExitoso = login.RedirigirUsuario(correo, constrasenia);  

        //if(inicioSesionExitoso)
        //{
        //    if(login.UsuarioActual.ClienteOVendedor())
        //    {
        //        frmHeladera heladera = new frmHeladera();
        //        heladera.Show();
        //        this.Hide();
        //    }
        //    else
        //    {
        //        frmVenta venta = new frmVenta(vendedor);
        //        venta.Show();
        //        this.Hide();
        //    }
        //}
        //else
        //{
        //    MessageBox.Show("Correo o constraseña incorrectos");
        //}
        #endregion



        #endregion
    }
}