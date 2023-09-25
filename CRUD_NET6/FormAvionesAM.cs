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
    public partial class FormAvionesAM : Form
    {
        private Avion avion;
        private bool modificar = false;

        public FormAvionesAM()
        {
            InitializeComponent();
        }

        public FormAvionesAM(Avion avionModificar)
        {
            InitializeComponent();
            avion = avionModificar;
            modificar = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (modificar)
                {
                    var avion = new Avion()
                    {
                        Matricula = txtMatricula.Text,
                        Marca = txtMarca.Text,
                        Modelo = txtModelo.Text,
                        CapacidadMaxima = (int)numCapacidad.Value
                    };
                    var mensaje = ControladoraAvion.Instancia.ModificarAvion(avion);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var avion = new Avion()
                    {
                        Matricula = txtMatricula.Text,
                        Marca = txtMarca.Text,
                        Modelo = txtModelo.Text,
                        CapacidadMaxima = (int)numCapacidad.Value
                    };
                    var mensaje = ControladoraAvion.Instancia.AgregarAvion(avion);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }
    

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAvionesAM_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Avión";
                txtMatricula.Enabled = false;
                txtMatricula.Text = avion.Matricula;
                txtMarca.Text = avion.Marca;
                txtModelo.Text = avion.Modelo;
                numCapacidad.Value = avion.CapacidadMaxima;
            }
            else lblAgregaroModificar.Text = "Agregar Avión";
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtMatricula.Text))
            {
                MessageBox.Show("Debe ingresar una matrícula", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                MessageBox.Show("Debe ingresar una marca", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtModelo.Text))
            {
                MessageBox.Show("Debe ingresar un modelo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numCapacidad.Value == 0)
            {
                MessageBox.Show("Debe ingresar un numero de pasaporte", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
