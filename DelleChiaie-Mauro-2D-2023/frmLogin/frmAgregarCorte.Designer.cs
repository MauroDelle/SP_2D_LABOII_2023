namespace Formularios
{
    partial class frmAgregarCorte
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
            dataGridView1 = new DataGridView();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            numericUpDownCantidad = new NumericUpDown();
            comboBoxTipo = new ComboBox();
            button1 = new Button();
            label5 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            buttonEliminar = new Button();
            buttonModificar = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidad).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(44, 46);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(494, 290);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.download1;
            pictureBox2.Location = new Point(12, 21);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(554, 349);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.download1;
            pictureBox1.Location = new Point(604, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(229, 349);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(721, 46);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(80, 23);
            txtNombre.TabIndex = 8;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(721, 91);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(80, 23);
            txtPrecio.TabIndex = 9;
            // 
            // numericUpDownCantidad
            // 
            numericUpDownCantidad.Location = new Point(721, 137);
            numericUpDownCantidad.Name = "numericUpDownCantidad";
            numericUpDownCantidad.Size = new Size(80, 23);
            numericUpDownCantidad.TabIndex = 10;
            // 
            // comboBoxTipo
            // 
            comboBoxTipo.FormattingEnabled = true;
            comboBoxTipo.Location = new Point(721, 181);
            comboBoxTipo.Name = "comboBoxTipo";
            comboBoxTipo.Size = new Size(80, 23);
            comboBoxTipo.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(671, 227);
            button1.Name = "button1";
            button1.Size = new Size(102, 35);
            button1.TabIndex = 12;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Bebas Kai", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(620, 46);
            label5.Name = "label5";
            label5.Size = new Size(76, 24);
            label5.TabIndex = 15;
            label5.Text = "nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Bebas Kai", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(628, 90);
            label1.Name = "label1";
            label1.Size = new Size(68, 24);
            label1.TabIndex = 16;
            label1.Text = "precio:";
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Bebas Kai", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(607, 137);
            label2.Name = "label2";
            label2.Size = new Size(89, 24);
            label2.TabIndex = 17;
            label2.Text = "cantidad:";
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Bebas Kai", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(648, 180);
            label3.Name = "label3";
            label3.Size = new Size(48, 24);
            label3.TabIndex = 18;
            label3.Text = "tipo:";
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(671, 277);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(102, 35);
            buttonEliminar.TabIndex = 19;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(671, 327);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(102, 35);
            buttonModificar.TabIndex = 20;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // button2
            // 
            button2.Location = new Point(610, 227);
            button2.Name = "button2";
            button2.Size = new Size(55, 35);
            button2.TabIndex = 21;
            button2.Text = "Refresh";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // frmAgregarCorte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(845, 389);
            Controls.Add(button2);
            Controls.Add(buttonModificar);
            Controls.Add(buttonEliminar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(comboBoxTipo);
            Controls.Add(numericUpDownCantidad);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombre);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox2);
            Name = "frmAgregarCorte";
            Text = "frmAgregarCorte";
            Load += frmAgregarCorte_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private NumericUpDown numericUpDownCantidad;
        private ComboBox comboBoxTipo;
        private Button button1;
        private Label label5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button buttonEliminar;
        private Button buttonModificar;
        private Button button2;
    }
}