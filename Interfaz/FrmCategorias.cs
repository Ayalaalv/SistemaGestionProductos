using System;
using System.Windows.Forms;
using SistemaGestionProductos.Entidades;
using SistemaGestionProductos.Logica;

namespace SistemaGestionProductos.Interfaz
{
    public partial class FrmCategorias : Form
    {
        private readonly CategoriaLogica _logica = new CategoriaLogica();

        // Id de la fila seleccionada
        private int _idSeleccionado = 0;

        public FrmCategorias()
        {
            InitializeComponent();
            dgvCategorias.AutoGenerateColumns = false;
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                _logica.Registrar(LeerFormulario());
                MostrarExito("Categoría registrada correctamente.");
                LimpiarCampos();
                CargarCategorias();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                _logica.Modificar(LeerFormulario());
                MostrarExito("Categoría modificada correctamente.");
                LimpiarCampos();
                CargarCategorias();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado <= 0)
            {
                MostrarError("Seleccione una categoría de la lista.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar la categoría \"" + txtNombre.Text + "\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2); 

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                _logica.Eliminar(_idSeleccionado);
                MostrarExito("Categoría eliminada correctamente.");
                LimpiarCampos();
                CargarCategorias();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return; 

            if (dgvCategorias.Rows[e.RowIndex].DataBoundItem is Categoria cat)
            {
                errorProvider.Clear();
                _idSeleccionado = cat.IdCategoria;
                txtNombre.Text = cat.Nombre;
                txtDescripcion.Text = cat.Descripcion;
            }
        }

        private bool ValidarCampos()
        {
            errorProvider.Clear();
            bool valido = true;

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider.SetError(txtNombre, "Ingrese el nombre de la categoría.");
                valido = false;
            }

            return valido;
        }

        private void CargarCategorias()
        {
            try
            {
                dgvCategorias.DataSource = _logica.ObtenerCategorias();
            }
            catch (Exception ex)
            {
                MostrarError("No se pudieron cargar las categorías: " + ex.Message);
            }
        }

        private Categoria LeerFormulario()
        {
            Categoria cat = new Categoria();
            cat.IdCategoria = _idSeleccionado;
            cat.Nombre = txtNombre.Text.Trim();
            cat.Descripcion = txtDescripcion.Text.Trim();
            return cat;
        }

        private void LimpiarCampos()
        {
            _idSeleccionado = 0;
            txtNombre.Clear();
            txtDescripcion.Clear();
            errorProvider.Clear();
            dgvCategorias.ClearSelection();
            txtNombre.Focus();
        }

        private void MostrarExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}