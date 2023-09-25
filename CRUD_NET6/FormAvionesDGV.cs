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
    public partial class FormAvionesDGV : Form
    {
        public FormAvionesDGV()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAvionesAM formAvionesAM = new FormAvionesAM();
            formAvionesAM.ShowDialog();
            ActualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvAviones.Rows.Count > 0)
            {
                var avion = (Avion)dgvAviones.CurrentRow.DataBoundItem;
                FormAvionesAM formAvionesAM = new FormAvionesAM(avion);
                formAvionesAM.ShowDialog();
                ActualizarGrilla();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAviones.Rows.Count > 0)
            {
                var avion = (Avion)dgvAviones.CurrentRow.DataBoundItem;
                var mensaje = ControladoraAvion.Instancia.EliminarAvion(avion);
                MessageBox.Show(mensaje, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarGrilla();
            }
        }

        private void FormAvionesDGV_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvAviones.DataSource = null;
            dgvAviones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAviones.DataSource = ControladoraAvion.Instancia.RecuperarAviones();
        }
    }
}
