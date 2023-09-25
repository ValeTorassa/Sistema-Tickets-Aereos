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
    public partial class FormTicketVisualizer : Form
    {
        TicketAereo ticketSeleccionado;

        public FormTicketVisualizer(TicketAereo ticket)
        {
            InitializeComponent();
            ticketSeleccionado = ticket;
        }

        private void FormTicketVisualizer_Load(object sender, EventArgs e)
        {
            lblNumTicket.Text = ticketSeleccionado.NumeroTicket.ToString();

            lblNombreApellido.Text = ticketSeleccionado.Pasajero.NombreApellido;
            lblNombreApellido2.Text = ticketSeleccionado.Pasajero.NombreApellido;

            lblFecha.Text = ticketSeleccionado.FechaVuelo.ToString("dd/MM/yyyy");
            lblFecha2.Text = ticketSeleccionado.FechaVuelo.ToString("dd/MM/yyyy");

            string asiento = ticketSeleccionado.Avion.GenerarAsientoAleatorio().ToString();

            lblAsiento.Text = asiento;
            lblAsiento2.Text = asiento;

            lblOrigen.Text = ticketSeleccionado.Origen;
            lblOrigen2.Text = ticketSeleccionado.Origen;

            lblDestino.Text = ticketSeleccionado.Destino;
            lblDestino2.Text = ticketSeleccionado.Destino;

            lblMatricula.Text = ticketSeleccionado.Avion.Matricula;

        }
    }
}
