using System;
using System.Windows.Forms;

namespace SistemaGestionProductos.Interfaz
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            using (FrmCategorias frm = new FrmCategorias())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            using (FrmProductos frm = new FrmProductos())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}