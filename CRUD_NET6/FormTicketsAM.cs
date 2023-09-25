using Modelo.Entidades;
using Controladora;
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
    public partial class FormTicketsAM : Form
    {
        private TicketAereo ticket;
        private bool modificar = false;

        public FormTicketsAM()
        {
            InitializeComponent();
            LlenarCMB();
            numTicket.Value = ControladoraTicketAereo.Instancia.RecuperarTicketsAereos().Count + 1;
        }

        public FormTicketsAM(TicketAereo ticketModificar)
        {
            InitializeComponent();
            LlenarCMB();
            ticket = ticketModificar;
            modificar = true;
        }


        private void LlenarCMB()
        {
            cmbAvion.DataSource = ControladoraAvion.Instancia.RecuperarAviones();
            cmbPasajero.DataSource = ControladoraPasajero.Instancia.RecuperarPasajeros();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string mensaje;

            if (ValidarCampos())
            {
                if (modificar)
                {
                    var ticketAereo = new TicketAereo()
                    {
                        NumeroTicket = (int)numTicket.Value,
                        Origen = txtOrigen.Text,
                        Destino = txtDestino.Text,
                        Pasajero = (Pasajero)cmbPasajero.SelectedItem,
                        Avion = (Avion)cmbAvion.SelectedItem,
                        FechaVuelo = timePickerVuelo.Value
                    };

                    mensaje = ControladoraTicketAereo.Instancia.ModificarTicketAereo(ticketAereo);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var ticketAereo = new TicketAereo()
                    {
                        NumeroTicket = (int)numTicket.Value,
                        Origen = txtOrigen.Text,
                        Destino = txtDestino.Text,
                        Pasajero = (Pasajero)cmbPasajero.SelectedItem,
                        Avion = (Avion)cmbAvion.SelectedItem,
                        FechaVuelo = timePickerVuelo.Value
                    };

                    var numAsientos = ControladoraTicketAereo.Instancia.AsientosDisponiblesEnAvionFecha(ticketAereo.Avion, timePickerVuelo.Value);

                    if (!ControladoraTicketAereo.Instancia.ExisteTicketRepetido(ticketAereo) && numAsientos > 0)
                    {
                        mensaje = ControladoraTicketAereo.Instancia.AgregarTicketAereo(ticketAereo);
                    }
                    else if (numAsientos <= 0)
                    {
                        mensaje = "El vuelo esta completo para este dia";
                    }
                    else
                    {
                        mensaje = "Ya existe un ticket con el mismo número de pasaporte y fecha de vuelo";
                    }

                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTicketsAM_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Ticket Aéreo";
                numTicket.Enabled = false;
                numTicket.Value = ticket.NumeroTicket;
                txtOrigen.Text = ticket.Origen;
                txtDestino.Text = ticket.Destino;
                cmbPasajero.SelectedItem = ticket.Pasajero;
                cmbAvion.SelectedItem = ticket.Avion;
                timePickerVuelo.Value = ticket.FechaVuelo;
            }
            else
            {
                lblAgregaroModificar.Text = "Agregar Ticket Aéreo";

                CalcularAsientosFechayAvion();
            }
        }


        private bool ValidarCampos()
        {
            if (numTicket.Value == 0)
            {
                MessageBox.Show("Debe ingresar un número de ticket", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtOrigen.Text))
            {
                MessageBox.Show("Debe ingresar un origen", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtDestino.Text))
            {
                MessageBox.Show("Debe ingresar un destino", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbPasajero.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un pasajero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbAvion.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un avión", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        private void cmbAvion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularAsientosFechayAvion();
        }

        private void timePickerVuelo_ValueChanged(object sender, EventArgs e)
        {
            CalcularAsientosFechayAvion();
        }

        private void CalcularAsientosFechayAvion()
        {
            var avionSeleccionado = (Avion)cmbAvion.SelectedItem;
            lblNumAsientos.Text = ControladoraTicketAereo.Instancia.AsientosDisponiblesEnAvionFecha(avionSeleccionado, timePickerVuelo.Value).ToString();
            lblCapacidad.Text = $"Asientos disponibles para {timePickerVuelo.Text} : ";
        }

        private void cmbAvion_SelectedValueChanged(object sender, EventArgs e)
        {
            CalcularAsientosFechayAvion();
        }
    }
}
