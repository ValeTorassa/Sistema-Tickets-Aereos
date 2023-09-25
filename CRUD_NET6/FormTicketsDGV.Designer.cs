namespace CRUD
{
    partial class FormTicketsDGV
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
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            lblPasajeros = new Label();
            dgvTickets = new DataGridView();
            btnVerTicket = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTickets).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(498, 242);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(280, 242);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 8;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 242);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblPasajeros
            // 
            lblPasajeros.AutoSize = true;
            lblPasajeros.Location = new Point(263, 10);
            lblPasajeros.Name = "lblPasajeros";
            lblPasajeros.Size = new Size(92, 15);
            lblPasajeros.TabIndex = 6;
            lblPasajeros.Text = "Tickets Emitidos";
            // 
            // dgvTickets
            // 
            dgvTickets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTickets.Location = new Point(12, 28);
            dgvTickets.Name = "dgvTickets";
            dgvTickets.RowTemplate.Height = 25;
            dgvTickets.Size = new Size(561, 195);
            dgvTickets.TabIndex = 5;
            // 
            // btnVerTicket
            // 
            btnVerTicket.Location = new Point(263, 271);
            btnVerTicket.Name = "btnVerTicket";
            btnVerTicket.Size = new Size(109, 32);
            btnVerTicket.TabIndex = 10;
            btnVerTicket.Text = "Ver Ticket";
            btnVerTicket.UseVisualStyleBackColor = true;
            btnVerTicket.Click += btnVerTicket_Click;
            // 
            // FormTicketsDGV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 315);
            Controls.Add(btnVerTicket);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(lblPasajeros);
            Controls.Add(dgvTickets);
            Name = "FormTicketsDGV";
            Text = "FormTicketsDGV";
            Load += FormTicketsDGV_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTickets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
        private Label lblPasajeros;
        private DataGridView dgvTickets;
        private Button btnVerTicket;
    }
}