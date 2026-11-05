using System;
using System.Windows.Forms;
using SistemaGestionProductos.Entidades;
using SistemaGestionProductos.Logica;

namespace SistemaGestionProductos.Interfaz
{
    // Formulario de mantenimiento (CRUD) de categorías.
    // Regla de capas: este formulario NO valida reglas de negocio ni habla con SQL.
    // Solo lee los controles, arma un objeto Categoria y se lo pasa a CategoriaLogica.
    public partial class FrmCategorias : Form
    {
        private readonly CategoriaLogica _logica = new CategoriaLogica();

        // Id de la fila seleccionada en la grilla. 0 = no hay ninguna seleccionada.
        private int _idSeleccionado = 0;

        public FrmCategorias()
        {
            InitializeComponent();
            // Las columnas se definieron en el diseñador; sin esto la grilla
            // agregaría columnas extra por cada propiedad de Categoria.
            dgvCategorias.AutoGenerateColumns = false;
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
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
            // Si no hay selección no tiene sentido preguntar "¿desea eliminar?".
            // (La capa Logica también lo valida; esto solo evita una pregunta vacía.)
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
                MessageBoxDefaultButton.Button2); // "No" por defecto: evita borrar con un Enter accidental

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

        // Al hacer clic en una fila, se pasan sus datos a los cuadros de texto.
        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return; // clic en el encabezado de columna

            // DataBoundItem es el objeto Categoria original que está detrás de la fila.
            if (dgvCategorias.Rows[e.RowIndex].DataBoundItem is Categoria cat)
            {
                _idSeleccionado = cat.IdCategoria;
                txtNombre.Text = cat.Nombre;
                txtDescripcion.Text = cat.Descripcion;
            }
        }

        // ----- Métodos auxiliares -----

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

        // Convierte lo que hay en pantalla en un objeto Categoria.
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
