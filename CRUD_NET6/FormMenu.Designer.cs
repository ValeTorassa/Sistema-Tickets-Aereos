namespace CRUD
{
    partial class FormMenu
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
            btnPasajeros = new Button();
            btnTickets = new Button();
            btnAviones = new Button();
            lblMenu = new Label();
            SuspendLayout();
            // 
            // btnPasajeros
            // 
            btnPasajeros.Location = new Point(12, 33);
            btnPasajeros.Name = "btnPasajeros";
            btnPasajeros.Size = new Size(165, 48);
            btnPasajeros.TabIndex = 0;
            btnPasajeros.Text = "Pasajeros";
            btnPasajeros.UseVisualStyleBackColor = true;
            btnPasajeros.Click += btnPasajeros_Click;
            // 
            // btnTickets
            // 
            btnTickets.Location = new Point(12, 102);
            btnTickets.Name = "btnTickets";
            btnTickets.Size = new Size(165, 48);
            btnTickets.TabIndex = 1;
            btnTickets.Text = "Tickets Aereos";
            btnTickets.UseVisualStyleBackColor = true;
            btnTickets.Click += btnTickets_Click;
            // 
            // btnAviones
            // 
            btnAviones.Location = new Point(12, 178);
            btnAviones.Name = "btnAviones";
            btnAviones.Size = new Size(165, 48);
            btnAviones.TabIndex = 2;
            btnAviones.Text = "Aviones";
            btnAviones.UseVisualStyleBackColor = true;
            btnAviones.Click += btnAviones_Click;
            // 
            // lblMenu
            // 
            lblMenu.AutoSize = true;
            lblMenu.Location = new Point(82, 9);
            lblMenu.Name = "lblMenu";
            lblMenu.Size = new Size(38, 15);
            lblMenu.TabIndex = 3;
            lblMenu.Text = "Menu";
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(186, 242);
            Controls.Add(lblMenu);
            Controls.Add(btnAviones);
            Controls.Add(btnTickets);
            Controls.Add(btnPasajeros);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPrincipal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPasajeros;
        private Button btnTickets;
        private Button btnAviones;
        private Label lblMenu;
    }
}