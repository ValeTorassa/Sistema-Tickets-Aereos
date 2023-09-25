using Controladora;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FormTicketsDGV : Form
    {
        public FormTicketsDGV()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormTicketsAM formTicketAereoAM = new FormTicketsAM();
            formTicketAereoAM.ShowDialog();
            ActualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvTickets.Rows.Count > 0)
            {
                var ticketAereo = (TicketAereo)dgvTickets.CurrentRow.DataBoundItem;
                FormTicketsAM formTicketAereoAM = new FormTicketsAM(ticketAereo);
                formTicketAereoAM.ShowDialog();
                ActualizarGrilla();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTickets.Rows.Count > 0)
            {
                var ticketAereo = (TicketAereo)dgvTickets.CurrentRow.DataBoundItem;
                var mensaje = ControladoraTicketAereo.Instancia.EliminarTicketAereo(ticketAereo);
                MessageBox.Show(mensaje, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarGrilla();
            }
        }

        private void btnVerTicket_Click(object sender, EventArgs e)
        {
            if (dgvTickets.Rows.Count > 0)
            {
                var ticketAereo = (TicketAereo)dgvTickets.CurrentRow.DataBoundItem;
                FormTicketVisualizer formTicketVisualizer= new FormTicketVisualizer(ticketAereo);
                formTicketVisualizer.ShowDialog();
                ActualizarGrilla();
            }
        }

        private void FormTicketsDGV_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvTickets.DataSource = null;
            dgvTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTickets.DataSource = ControladoraTicketAereo.Instancia.RecuperarTicketsAereos();
        }
    }
}
