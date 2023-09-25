namespace CRUD
{
    partial class FormAvionesAM
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
            btnCancelar = new Button();
            btnAceptar = new Button();
            lblCantidad = new Label();
            txtModelo = new TextBox();
            lblModelo = new Label();
            txtMarca = new TextBox();
            lblMarca = new Label();
            numCapacidad = new NumericUpDown();
            lblMatricula = new Label();
            lblAgregaroModificar = new Label();
            txtMatricula = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numCapacidad).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(140, 227);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(83, 26);
            btnCancelar.TabIndex = 26;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(9, 227);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(83, 26);
            btnAceptar.TabIndex = 25;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(9, 176);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(104, 15);
            lblCantidad.TabIndex = 23;
            lblCantidad.Text = "Cantidad Maxima:";
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(82, 121);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(118, 23);
            txtModelo.TabIndex = 22;
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Location = new Point(9, 129);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(51, 15);
            lblModelo.TabIndex = 21;
            lblModelo.Text = "Modelo:";
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(82, 79);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(118, 23);
            txtMarca.TabIndex = 20;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(17, 82);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(43, 15);
            lblMarca.TabIndex = 19;
            lblMarca.Text = "Marca:";
            // 
            // numCapacidad
            // 
            numCapacidad.Location = new Point(119, 174);
            numCapacidad.Maximum = new decimal(new int[] { 800, 0, 0, 0 });
            numCapacidad.Name = "numCapacidad";
            numCapacidad.Size = new Size(81, 23);
            numCapacidad.TabIndex = 18;
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.Location = new Point(9, 41);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(60, 15);
            lblMatricula.TabIndex = 17;
            lblMatricula.Text = "Matricula:";
            // 
            // lblAgregaroModificar
            // 
            lblAgregaroModificar.AutoSize = true;
            lblAgregaroModificar.Location = new Point(33, 9);
            lblAgregaroModificar.Name = "lblAgregaroModificar";
            lblAgregaroModificar.Size = new Size(158, 15);
            lblAgregaroModificar.TabIndex = 16;
            lblAgregaroModificar.Text = "Agregar o Modificar Aviones";
            // 
            // txtMatricula
            // 
            txtMatricula.Location = new Point(80, 38);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(118, 23);
            txtMatricula.TabIndex = 27;
            // 
            // FormAvionesAM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(237, 264);
            Controls.Add(txtMatricula);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(lblCantidad);
            Controls.Add(txtModelo);
            Controls.Add(lblModelo);
            Controls.Add(txtMarca);
            Controls.Add(lblMarca);
            Controls.Add(numCapacidad);
            Controls.Add(lblMatricula);
            Controls.Add(lblAgregaroModificar);
            Name = "FormAvionesAM";
            Text = "FormAvionesAM";
            Load += FormAvionesAM_Load;
            ((System.ComponentModel.ISupportInitialize)numCapacidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnAceptar;
        private Label lblCantidad;
        private TextBox txtModelo;
        private Label lblModelo;
        private TextBox txtMarca;
        private Label lblMarca;
        private NumericUpDown numCapacidad;
        private Label lblMatricula;
        private Label lblAgregaroModificar;
        private TextBox txtMatricula;
    }
}