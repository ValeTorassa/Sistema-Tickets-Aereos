namespace CRUD
{
    partial class FormPasajerosAM
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
            txtNombreApellido = new TextBox();
            lbl = new Label();
            numPasaporte = new NumericUpDown();
            lblPasaporte = new Label();
            lblAgregaroModificar = new Label();
            txtNacionalidad = new TextBox();
            lblNacionalidad = new Label();
            lblFecha = new Label();
            timePickerNacimiento = new DateTimePicker();
            btnAceptar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)numPasaporte).BeginInit();
            SuspendLayout();
            // 
            // txtNombreApellido
            // 
            txtNombreApellido.Location = new Point(146, 85);
            txtNombreApellido.Name = "txtNombreApellido";
            txtNombreApellido.Size = new Size(118, 23);
            txtNombreApellido.TabIndex = 9;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new Point(15, 88);
            lbl.Name = "lbl";
            lbl.Size = new Size(110, 15);
            lbl.TabIndex = 8;
            lbl.Text = "Nombre y Apellido:";
            // 
            // numPasaporte
            // 
            numPasaporte.Location = new Point(146, 42);
            numPasaporte.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numPasaporte.Name = "numPasaporte";
            numPasaporte.Size = new Size(120, 23);
            numPasaporte.TabIndex = 7;
            // 
            // lblPasaporte
            // 
            lblPasaporte.AutoSize = true;
            lblPasaporte.Location = new Point(15, 44);
            lblPasaporte.Name = "lblPasaporte";
            lblPasaporte.Size = new Size(125, 15);
            lblPasaporte.TabIndex = 6;
            lblPasaporte.Text = "Numero de Pasaporte:";
            // 
            // lblAgregaroModificar
            // 
            lblAgregaroModificar.AutoSize = true;
            lblAgregaroModificar.Location = new Point(61, 9);
            lblAgregaroModificar.Name = "lblAgregaroModificar";
            lblAgregaroModificar.Size = new Size(165, 15);
            lblAgregaroModificar.TabIndex = 5;
            lblAgregaroModificar.Text = "Agregar o Modificar Pasajeros";
            // 
            // txtNacionalidad
            // 
            txtNacionalidad.Location = new Point(146, 132);
            txtNacionalidad.Name = "txtNacionalidad";
            txtNacionalidad.Size = new Size(118, 23);
            txtNacionalidad.TabIndex = 11;
            // 
            // lblNacionalidad
            // 
            lblNacionalidad.AutoSize = true;
            lblNacionalidad.Location = new Point(45, 135);
            lblNacionalidad.Name = "lblNacionalidad";
            lblNacionalidad.Size = new Size(80, 15);
            lblNacionalidad.TabIndex = 10;
            lblNacionalidad.Text = "Nacionalidad:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(12, 182);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(122, 15);
            lblFecha.TabIndex = 12;
            lblFecha.Text = "Fecha de Nacimiento:";
            // 
            // timePickerNacimiento
            // 
            timePickerNacimiento.Format = DateTimePickerFormat.Short;
            timePickerNacimiento.Location = new Point(143, 176);
            timePickerNacimiento.MaxDate = new DateTime(2023, 9, 11, 0, 0, 0, 0);
            timePickerNacimiento.MinDate = new DateTime(1919, 7, 17, 0, 0, 0, 0);
            timePickerNacimiento.Name = "timePickerNacimiento";
            timePickerNacimiento.Size = new Size(121, 23);
            timePickerNacimiento.TabIndex = 13;
            timePickerNacimiento.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(12, 233);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(83, 26);
            btnAceptar.TabIndex = 14;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(183, 233);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(83, 26);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormPasajerosAM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(281, 271);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(timePickerNacimiento);
            Controls.Add(lblFecha);
            Controls.Add(txtNacionalidad);
            Controls.Add(lblNacionalidad);
            Controls.Add(txtNombreApellido);
            Controls.Add(lbl);
            Controls.Add(numPasaporte);
            Controls.Add(lblPasaporte);
            Controls.Add(lblAgregaroModificar);
            Name = "FormPasajerosAM";
            Text = "FormPasajerosAM";
            Load += FormPasajerosAM_Load;
            ((System.ComponentModel.ISupportInitialize)numPasaporte).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreApellido;
        private Label lbl;
        private NumericUpDown numPasaporte;
        private Label lblPasaporte;
        private Label lblAgregaroModificar;
        private TextBox txtNacionalidad;
        private Label lblNacionalidad;
        private Label lblFecha;
        private DateTimePicker timePickerNacimiento;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}