namespace CRUD
{
    partial class FormTicketsAM
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
            txtDestino = new TextBox();
            lblDestino = new Label();
            txtOrigen = new TextBox();
            lblOrigen = new Label();
            lblNumeroTicket = new Label();
            lblAgregaroModificar = new Label();
            numTicket = new NumericUpDown();
            timePickerVuelo = new DateTimePicker();
            lblPasajero = new Label();
            lblAvion = new Label();
            cmbPasajero = new ComboBox();
            cmbAvion = new ComboBox();
            lblCapacidad = new Label();
            lblNumAsientos = new Label();
            ((System.ComponentModel.ISupportInitialize)numTicket).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(271, 234);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(83, 26);
            btnCancelar.TabIndex = 37;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(64, 234);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(83, 26);
            btnAceptar.TabIndex = 36;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(105, 199);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(90, 15);
            lblCantidad.TabIndex = 35;
            lblCantidad.Text = "Fecha de Vuelo:";
            // 
            // txtDestino
            // 
            txtDestino.Location = new Point(90, 121);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new Size(118, 23);
            txtDestino.TabIndex = 34;
            // 
            // lblDestino
            // 
            lblDestino.AutoSize = true;
            lblDestino.Location = new Point(17, 129);
            lblDestino.Name = "lblDestino";
            lblDestino.Size = new Size(50, 15);
            lblDestino.TabIndex = 33;
            lblDestino.Text = "Destino:";
            // 
            // txtOrigen
            // 
            txtOrigen.Location = new Point(90, 79);
            txtOrigen.Name = "txtOrigen";
            txtOrigen.Size = new Size(118, 23);
            txtOrigen.TabIndex = 32;
            // 
            // lblOrigen
            // 
            lblOrigen.AutoSize = true;
            lblOrigen.Location = new Point(17, 82);
            lblOrigen.Name = "lblOrigen";
            lblOrigen.Size = new Size(46, 15);
            lblOrigen.TabIndex = 31;
            lblOrigen.Text = "Origen:";
            // 
            // lblNumeroTicket
            // 
            lblNumeroTicket.AutoSize = true;
            lblNumeroTicket.Location = new Point(109, 39);
            lblNumeroTicket.Name = "lblNumeroTicket";
            lblNumeroTicket.Size = new Size(104, 15);
            lblNumeroTicket.TabIndex = 29;
            lblNumeroTicket.Text = "Numero de Ticket:";
            // 
            // lblAgregaroModificar
            // 
            lblAgregaroModificar.AutoSize = true;
            lblAgregaroModificar.Location = new Point(142, 9);
            lblAgregaroModificar.Name = "lblAgregaroModificar";
            lblAgregaroModificar.Size = new Size(158, 15);
            lblAgregaroModificar.TabIndex = 28;
            lblAgregaroModificar.Text = "Agregar o Modificar Aviones";
            // 
            // numTicket
            // 
            numTicket.Enabled = false;
            numTicket.Location = new Point(219, 37);
            numTicket.Maximum = new decimal(new int[] { 800, 0, 0, 0 });
            numTicket.Name = "numTicket";
            numTicket.Size = new Size(81, 23);
            numTicket.TabIndex = 38;
            // 
            // timePickerVuelo
            // 
            timePickerVuelo.Format = DateTimePickerFormat.Short;
            timePickerVuelo.Location = new Point(201, 193);
            timePickerVuelo.MaxDate = new DateTime(2030, 1, 1, 0, 0, 0, 0);
            timePickerVuelo.MinDate = new DateTime(2023, 9, 12, 0, 0, 0, 0);
            timePickerVuelo.Name = "timePickerVuelo";
            timePickerVuelo.Size = new Size(95, 23);
            timePickerVuelo.TabIndex = 39;
            timePickerVuelo.Value = new DateTime(2023, 9, 14, 0, 0, 0, 0);
            timePickerVuelo.ValueChanged += timePickerVuelo_ValueChanged;
            // 
            // lblPasajero
            // 
            lblPasajero.AutoSize = true;
            lblPasajero.Location = new Point(246, 87);
            lblPasajero.Name = "lblPasajero";
            lblPasajero.Size = new Size(54, 15);
            lblPasajero.TabIndex = 40;
            lblPasajero.Text = "Pasajero:";
            // 
            // lblAvion
            // 
            lblAvion.AutoSize = true;
            lblAvion.Location = new Point(246, 124);
            lblAvion.Name = "lblAvion";
            lblAvion.Size = new Size(41, 15);
            lblAvion.TabIndex = 41;
            lblAvion.Text = "Avion:";
            // 
            // cmbPasajero
            // 
            cmbPasajero.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPasajero.FormattingEnabled = true;
            cmbPasajero.ImeMode = ImeMode.NoControl;
            cmbPasajero.Location = new Point(306, 82);
            cmbPasajero.Name = "cmbPasajero";
            cmbPasajero.Size = new Size(105, 23);
            cmbPasajero.TabIndex = 42;
            // 
            // cmbAvion
            // 
            cmbAvion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAvion.FormattingEnabled = true;
            cmbAvion.ImeMode = ImeMode.NoControl;
            cmbAvion.Location = new Point(306, 121);
            cmbAvion.Name = "cmbAvion";
            cmbAvion.Size = new Size(105, 23);
            cmbAvion.TabIndex = 43;
            cmbAvion.SelectedValueChanged += cmbAvion_SelectedValueChanged;
            // 
            // lblCapacidad
            // 
            lblCapacidad.AutoSize = true;
            lblCapacidad.Location = new Point(64, 161);
            lblCapacidad.Name = "lblCapacidad";
            lblCapacidad.Size = new Size(206, 15);
            lblCapacidad.TabIndex = 44;
            lblCapacidad.Text = "Asientos Disponibles para 06/08/2023:";
            // 
            // lblNumAsientos
            // 
            lblNumAsientos.AutoSize = true;
            lblNumAsientos.Location = new Point(281, 161);
            lblNumAsientos.Name = "lblNumAsientos";
            lblNumAsientos.Size = new Size(19, 15);
            lblNumAsientos.TabIndex = 45;
            lblNumAsientos.Text = "20";
            // 
            // FormTicketsAM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 272);
            Controls.Add(lblNumAsientos);
            Controls.Add(lblCapacidad);
            Controls.Add(cmbAvion);
            Controls.Add(cmbPasajero);
            Controls.Add(lblAvion);
            Controls.Add(lblPasajero);
            Controls.Add(timePickerVuelo);
            Controls.Add(numTicket);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(lblCantidad);
            Controls.Add(txtDestino);
            Controls.Add(lblDestino);
            Controls.Add(txtOrigen);
            Controls.Add(lblOrigen);
            Controls.Add(lblNumeroTicket);
            Controls.Add(lblAgregaroModificar);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormTicketsAM";
            Text = "FormTicketsAM";
            Load += FormTicketsAM_Load;
            ((System.ComponentModel.ISupportInitialize)numTicket).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnAceptar;
        private Label lblCantidad;
        private TextBox txtDestino;
        private Label lblDestino;
        private TextBox txtOrigen;
        private Label lblOrigen;
        private Label lblNumeroTicket;
        private Label lblAgregaroModificar;
        private NumericUpDown numTicket;
        private DateTimePicker timePickerVuelo;
        private Label lblPasajero;
        private Label lblAvion;
        private ComboBox cmbPasajero;
        private ComboBox cmbAvion;
        private Label lblCapacidad;
        private Label lblNumAsientos;
    }
}