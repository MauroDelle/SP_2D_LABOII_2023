namespace Formularios
{
    partial class frmHistorialVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistorialVenta));
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            textBoxHistorial = new TextBox();
            btnSerializarJson = new Button();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.download1;
            pictureBox2.Location = new Point(49, 41);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(508, 348);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.neon_orange_color_solid_background_1920x1080;
            pictureBox1.Location = new Point(25, 62);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(508, 348);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // textBoxHistorial
            // 
            textBoxHistorial.Location = new Point(81, 22);
            textBoxHistorial.Multiline = true;
            textBoxHistorial.Name = "textBoxHistorial";
            textBoxHistorial.Size = new Size(490, 334);
            textBoxHistorial.TabIndex = 8;
            textBoxHistorial.TextChanged += textBoxHistorial_TextChanged;
            // 
            // btnSerializarJson
            // 
            btnSerializarJson.Location = new Point(595, 22);
            btnSerializarJson.Name = "btnSerializarJson";
            btnSerializarJson.Size = new Size(111, 44);
            btnSerializarJson.TabIndex = 9;
            btnSerializarJson.Text = "Json";
            btnSerializarJson.UseVisualStyleBackColor = true;
            btnSerializarJson.Click += btnSerializarJson_Click;
            // 
            // button1
            // 
            button1.Location = new Point(595, 263);
            button1.Name = "button1";
            button1.Size = new Size(111, 44);
            button1.TabIndex = 10;
            button1.Text = "Des.Json";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(595, 192);
            button2.Name = "button2";
            button2.Size = new Size(111, 44);
            button2.TabIndex = 11;
            button2.Text = "Des.Xml";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // frmHistorialVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(718, 429);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnSerializarJson);
            Controls.Add(textBoxHistorial);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmHistorialVenta";
            Text = "frmHistorialVenta";
            Load += frmHistorialVenta_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        public TextBox textBoxHistorial;
        private Button btnSerializarJson;
        private Button button1;
        private Button button2;
    }
}