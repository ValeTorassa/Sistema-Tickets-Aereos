using Controladora;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FormPasajerosDGV : Form
    {
        public FormPasajerosDGV()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormPasajerosAM formPasajerosAM = new FormPasajerosAM();
            formPasajerosAM.ShowDialog();
            ActualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPasajeros.Rows.Count > 0)
            {
                var pasajero = (Pasajero)dgvPasajeros.CurrentRow.DataBoundItem;
                FormPasajerosAM formPasajerosAM = new FormPasajerosAM(pasajero);
                formPasajerosAM.ShowDialog();
                ActualizarGrilla();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPasajeros.Rows.Count > 0)
            {
                var pasajero = (Pasajero)dgvPasajeros.CurrentRow.DataBoundItem;
                var mensaje = ControladoraPasajero.Instancia.EliminarPasajero(pasajero);
                MessageBox.Show(mensaje, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarGrilla();
            }
        }

        private void FormPasajerosDGV_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvPasajeros.DataSource = null;
            dgvPasajeros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPasajeros.DataSource = ControladoraPasajero.Instancia.RecuperarPasajeros();
        }
    }
}
