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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnPasajeros_Click(object sender, EventArgs e)
        {
            FormPasajerosDGV formPasajerosDGV = new FormPasajerosDGV();
            formPasajerosDGV.ShowDialog();
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            FormTicketsDGV formTicketsDGV = new FormTicketsDGV();
            formTicketsDGV.ShowDialog();
        }

        private void btnAviones_Click(object sender, EventArgs e)
        {
            FormAvionesDGV formAvionesDGV = new FormAvionesDGV();
            formAvionesDGV.ShowDialog();
        }
    }
}
