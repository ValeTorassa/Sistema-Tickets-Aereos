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
    public partial class FormPasajerosAM : Form
    {
        private Pasajero pasajero;
        private bool modificar = false;

        public FormPasajerosAM()
        {
            InitializeComponent();
        }

        public FormPasajerosAM(Pasajero pasajeroModificar)
        {
            InitializeComponent();
            pasajero = pasajeroModificar;
            modificar = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (modificar)
                {
                    var pasajero = new Pasajero()
                    {
                        NumeroPasaporte = numPasaporte.Value.ToString(),
                        NombreApellido = txtNombreApellido.Text,
                        Nacionalidad = txtNacionalidad.Text,
                        FechaNacimiento = timePickerNacimiento.Value
                    };
                    var mensaje = ControladoraPasajero.Instancia.ModificarPasajero(pasajero);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var pasajero = new Pasajero()
                    {
                        NumeroPasaporte = numPasaporte.Value.ToString(),
                        NombreApellido = txtNombreApellido.Text,
                        Nacionalidad = txtNacionalidad.Text,
                        FechaNacimiento = timePickerNacimiento.Value
                    };
                    var mensaje = ControladoraPasajero.Instancia.AgregarPasajero(pasajero);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPasajerosAM_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Pasajero";
                numPasaporte.Enabled = false;
                numPasaporte.Value = Convert.ToDecimal(pasajero.NumeroPasaporte);
                txtNombreApellido.Text = pasajero.NombreApellido;
                txtNacionalidad.Text = pasajero.Nacionalidad;
                timePickerNacimiento.Value = pasajero.FechaNacimiento;
            }
            else lblAgregaroModificar.Text = "Agregar Pasajero";
        }

        private bool ValidarCampos()
        {
            if (numPasaporte.Value == 0)
            {
                MessageBox.Show("Debe ingresar un numero de pasaporte", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.txtNombreApellido.Text))
            {
                MessageBox.Show("Debe ingresar un nombre y un apellido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.txtNacionalidad.Text))
            {
                MessageBox.Show("Debe ingresar una nacionalidad", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
