namespace Formularios
{
    partial class frmHeladera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHeladera));
            dataGridView1 = new DataGridView();
            botonVender = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            pictureBox3 = new PictureBox();
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            textBox2 = new TextBox();
            label6 = new Label();
            radioButtonEfectivo = new RadioButton();
            radioButtonTarjeta = new RadioButton();
            nuevoProducto = new Button();
            button3 = new Button();
            progressBar = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.Teal;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(29, 161);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(448, 255);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // botonVender
            // 
            botonVender.Location = new Point(526, 348);
            botonVender.Name = "botonVender";
            botonVender.Size = new Size(101, 47);
            botonVender.TabIndex = 3;
            botonVender.Text = "Vender";
            botonVender.UseVisualStyleBackColor = true;
            botonVender.Click += botonVender_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.download1;
            pictureBox1.Location = new Point(12, 148);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(484, 289);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.download1;
            pictureBox2.Location = new Point(-3, -2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(736, 65);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Bebas Neue", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(12, 104);
            label1.Name = "label1";
            label1.Size = new Size(140, 41);
            label1.TabIndex = 6;
            label1.Text = "Productos";
            label1.Click += label1_Click_1;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.download1;
            pictureBox3.Location = new Point(518, 148);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(193, 289);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(526, 189);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(101, 23);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(618, 284);
            numericUpDown1.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.ReadOnly = true;
            numericUpDown1.Size = new Size(91, 23);
            numericUpDown1.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Bebas Neue", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(553, 104);
            label2.Name = "label2";
            label2.Size = new Size(117, 41);
            label2.TabIndex = 10;
            label2.Text = "Clientes";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Bebas Kai", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(526, 283);
            label3.Name = "label3";
            label3.Size = new Size(86, 24);
            label3.TabIndex = 12;
            label3.Text = "cantidad:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Bebas Kai", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(526, 233);
            label4.Name = "label4";
            label4.Size = new Size(61, 24);
            label4.TabIndex = 13;
            label4.Text = "saldo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Bebas Kai", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(526, 162);
            label5.Name = "label5";
            label5.Size = new Size(76, 24);
            label5.TabIndex = 14;
            label5.Text = "nombre:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(593, 234);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(63, 23);
            textBox1.TabIndex = 15;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(502, 12);
            button1.Name = "button1";
            button1.Size = new Size(110, 47);
            button1.TabIndex = 16;
            button1.Text = "Historial";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(301, 12);
            button2.Name = "button2";
            button2.Size = new Size(110, 47);
            button2.TabIndex = 17;
            button2.Text = "Reponer";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Location = new Point(661, 189);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(48, 23);
            textBox2.TabIndex = 18;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Bebas Kai", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(661, 162);
            label6.Name = "label6";
            label6.Size = new Size(48, 24);
            label6.TabIndex = 19;
            label6.Text = "EDAD";
            // 
            // radioButtonEfectivo
            // 
            radioButtonEfectivo.BackColor = Color.PowderBlue;
            radioButtonEfectivo.Location = new Point(632, 348);
            radioButtonEfectivo.Name = "radioButtonEfectivo";
            radioButtonEfectivo.Size = new Size(77, 24);
            radioButtonEfectivo.TabIndex = 20;
            radioButtonEfectivo.TabStop = true;
            radioButtonEfectivo.Text = "Efectivo";
            radioButtonEfectivo.UseVisualStyleBackColor = false;
            // 
            // radioButtonTarjeta
            // 
            radioButtonTarjeta.BackColor = Color.PowderBlue;
            radioButtonTarjeta.Location = new Point(632, 371);
            radioButtonTarjeta.Name = "radioButtonTarjeta";
            radioButtonTarjeta.Size = new Size(77, 24);
            radioButtonTarjeta.TabIndex = 21;
            radioButtonTarjeta.TabStop = true;
            radioButtonTarjeta.Text = "Tarjeta";
            radioButtonTarjeta.UseVisualStyleBackColor = false;
            // 
            // nuevoProducto
            // 
            nuevoProducto.Location = new Point(87, 12);
            nuevoProducto.Name = "nuevoProducto";
            nuevoProducto.Size = new Size(110, 47);
            nuevoProducto.TabIndex = 22;
            nuevoProducto.Text = "Agregar Corte";
            nuevoProducto.UseVisualStyleBackColor = true;
            nuevoProducto.Click += nuevoProducto_Click;
            // 
            // button3
            // 
            button3.Location = new Point(585, 313);
            button3.Name = "button3";
            button3.Size = new Size(71, 28);
            button3.TabIndex = 23;
            button3.Text = "Actualizar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // progressBar
            // 
            progressBar.BackColor = SystemColors.ActiveBorder;
            progressBar.Location = new Point(430, 104);
            progressBar.Maximum = 15;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(66, 38);
            progressBar.TabIndex = 24;
            progressBar.Click += progressBar_Click;
            // 
            // frmHeladera
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(723, 447);
            Controls.Add(progressBar);
            Controls.Add(button3);
            Controls.Add(nuevoProducto);
            Controls.Add(radioButtonTarjeta);
            Controls.Add(radioButtonEfectivo);
            Controls.Add(label6);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(botonVender);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox3);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmHeladera";
            Text = "Heladera";
            Load += frmHeladera_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Button botonVender;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private PictureBox pictureBox3;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private TextBox textBox2;
        private Label label6;
        private RadioButton radioButtonEfectivo;
        private RadioButton radioButtonTarjeta;
        private Button nuevoProducto;
        private Button button3;
        private ProgressBar progressBar;
    }
}