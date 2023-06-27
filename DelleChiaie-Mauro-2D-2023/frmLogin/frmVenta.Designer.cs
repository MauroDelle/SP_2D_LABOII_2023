namespace Formularios
{
    partial class frmVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVenta));
            pictureBox3 = new PictureBox();
            textBox1 = new TextBox();
            button1 = new Button();
            txtBusqueda = new TextBox();
            button2 = new Button();
            button3 = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            dgvCarrito = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Quitar = new DataGridViewButtonColumn();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            radioButtonEfectivo = new RadioButton();
            radioButtonCredito = new RadioButton();
            groupBox5 = new GroupBox();
            btnComprar = new Button();
            Agregar = new DataGridViewButtonColumn();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.download1;
            pictureBox3.Location = new Point(-1, 1);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(1157, 74);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(6, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(88, 29);
            textBox1.TabIndex = 11;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(100, 16);
            button1.Name = "button1";
            button1.Size = new Size(107, 35);
            button1.TabIndex = 12;
            button1.Text = "Confirmar Saldo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtBusqueda.Location = new Point(6, 19);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(145, 25);
            txtBusqueda.TabIndex = 13;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(157, 14);
            button2.Name = "button2";
            button2.Size = new Size(74, 35);
            button2.TabIndex = 14;
            button2.Text = "Buscar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(237, 17);
            button3.Name = "button3";
            button3.Size = new Size(67, 30);
            button3.TabIndex = 15;
            button3.Text = "Volver";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.download1;
            pictureBox2.Location = new Point(34, 147);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(560, 264);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.neon_orange_color_solid_background_1920x1080;
            pictureBox1.Location = new Point(21, 156);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(558, 265);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // dgvCarrito
            // 
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Columns.AddRange(new DataGridViewColumn[] { Nombre, Precio, Cantidad, Quitar });
            dgvCarrito.Location = new Point(649, 123);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.ReadOnly = true;
            dgvCarrito.RowHeadersVisible = false;
            dgvCarrito.RowTemplate.Height = 25;
            dgvCarrito.Size = new Size(469, 288);
            dgvCarrito.TabIndex = 19;
            dgvCarrito.CellContentClick += dgvCarrito_CellContentClick;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio";
            Precio.Name = "Precio";
            Precio.ReadOnly = true;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            // 
            // Quitar
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle1.BackColor = Color.Red;
            dataGridViewCellStyle1.ForeColor = Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = Color.Red;
            Quitar.DefaultCellStyle = dataGridViewCellStyle1;
            Quitar.HeaderText = "Borrar Carro";
            Quitar.Name = "Quitar";
            Quitar.ReadOnly = true;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.download1;
            pictureBox4.Location = new Point(637, 145);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(481, 277);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 20;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.neon_orange_color_solid_background_1920x1080;
            pictureBox5.Location = new Point(624, 154);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(479, 278);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 21;
            pictureBox5.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Font = new Font("Bebas Neue", 13F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(17, 103);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(583, 329);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "Productos Disponibles";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // groupBox2
            // 
            groupBox2.Font = new Font("Bebas Neue", 13F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(614, 103);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(512, 329);
            groupBox2.TabIndex = 25;
            groupBox2.TabStop = false;
            groupBox2.Text = "Carrito";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.PowderBlue;
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(txtBusqueda);
            groupBox3.Controls.Add(button2);
            groupBox3.Font = new Font("Bebas Neue", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox3.Location = new Point(163, 11);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(312, 53);
            groupBox3.TabIndex = 25;
            groupBox3.TabStop = false;
            groupBox3.Text = "Buscador";
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.PowderBlue;
            groupBox4.Controls.Add(button1);
            groupBox4.Controls.Add(textBox1);
            groupBox4.Font = new Font("Bebas Neue", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox4.Location = new Point(763, 11);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(215, 64);
            groupBox4.TabIndex = 26;
            groupBox4.TabStop = false;
            groupBox4.Text = "Presupuesto";
            groupBox4.Enter += groupBox4_Enter;
            groupBox4.Validating += groupBox4_Validating;
            // 
            // radioButtonEfectivo
            // 
            radioButtonEfectivo.AutoSize = true;
            radioButtonEfectivo.Font = new Font("Bebas Neue", 12F, FontStyle.Regular, GraphicsUnit.Point);
            radioButtonEfectivo.Location = new Point(13, 30);
            radioButtonEfectivo.Name = "radioButtonEfectivo";
            radioButtonEfectivo.Size = new Size(73, 25);
            radioButtonEfectivo.TabIndex = 27;
            radioButtonEfectivo.TabStop = true;
            radioButtonEfectivo.Text = "EFECTIVO";
            radioButtonEfectivo.UseVisualStyleBackColor = true;
            // 
            // radioButtonCredito
            // 
            radioButtonCredito.AutoSize = true;
            radioButtonCredito.Font = new Font("Bebas Neue", 12F, FontStyle.Regular, GraphicsUnit.Point);
            radioButtonCredito.Location = new Point(13, 63);
            radioButtonCredito.Name = "radioButtonCredito";
            radioButtonCredito.Size = new Size(157, 25);
            radioButtonCredito.TabIndex = 28;
            radioButtonCredito.TabStop = true;
            radioButtonCredito.Text = "TARJETA DE CRÉDITO (+%5)";
            radioButtonCredito.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(radioButtonEfectivo);
            groupBox5.Controls.Add(radioButtonCredito);
            groupBox5.Font = new Font("Bebas Neue", 13F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox5.Location = new Point(21, 448);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(207, 105);
            groupBox5.TabIndex = 25;
            groupBox5.TabStop = false;
            groupBox5.Text = "Método de Pago";
            groupBox5.Enter += groupBox5_Enter;
            groupBox5.Validating += groupBox5_Validating;
            // 
            // btnComprar
            // 
            btnComprar.Location = new Point(274, 478);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(97, 42);
            btnComprar.TabIndex = 27;
            btnComprar.Text = "Comprar";
            btnComprar.UseVisualStyleBackColor = true;
            btnComprar.Click += btnComprar_Click;
            // 
            // Agregar
            // 
            Agregar.HeaderText = "Agregar";
            Agregar.Name = "Agregar";
            Agregar.ReadOnly = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Agregar });
            dataGridView1.Location = new Point(46, 125);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(548, 275);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // frmVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1135, 565);
            Controls.Add(btnComprar);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(dgvCarrito);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox5);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(pictureBox3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVenta";
            Load += frmVenta_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox3;
        private TextBox textBox1;
        private Button button1;
        private TextBox txtBusqueda;
        private Button button2;
        private Button button3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private DataGridView dgvCarrito;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private RadioButton radioButtonEfectivo;
        private RadioButton radioButtonCredito;
        private GroupBox groupBox5;
        private Button btnComprar;
        private DataGridViewButtonColumn Agregar;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewButtonColumn Quitar;
    }
}