using System;
using System.Windows.Forms;

namespace SistemaGestionProductos.Interfaz
{
    // Menú principal: solo abre los formularios de mantenimiento.
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            // ShowDialog = ventana modal: el menú queda bloqueado hasta cerrarla.
            // "using" libera el formulario de memoria al cerrarse.
            using (FrmCategorias frm = new FrmCategorias())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            // Se crea un formulario nuevo cada vez, así el ComboBox
            // recarga las categorías que se hayan agregado mientras tanto.
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
