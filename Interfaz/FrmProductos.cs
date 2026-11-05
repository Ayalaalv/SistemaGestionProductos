using System;
using System.Windows.Forms;
using SistemaGestionProductos.Entidades;
using SistemaGestionProductos.Logica;

namespace SistemaGestionProductos.Interfaz
{
    // Formulario de mantenimiento (CRUD) de productos con búsqueda por nombre.
    // Igual que en categorías: el formulario solo lee controles y llama a la capa Logica.
    public partial class FrmProductos : Form
    {
        private readonly ProductoLogica _productoLogica = new ProductoLogica();
        private readonly CategoriaLogica _categoriaLogica = new CategoriaLogica();

        // Id del producto seleccionado en la grilla. 0 = ninguno.
        private int _idSeleccionado = 0;

        public FrmProductos()
        {
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            RefrescarLista();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                _productoLogica.Registrar(LeerFormulario());
                MostrarExito("Producto registrado correctamente.");
                LimpiarCampos();
                RefrescarLista();
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
                _productoLogica.Modificar(LeerFormulario());
                MostrarExito("Producto modificado correctamente.");
                LimpiarCampos();
                RefrescarLista();
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
                MostrarError("Seleccione un producto de la lista.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar el producto \"" + txtNombre.Text + "\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                _productoLogica.Eliminar(_idSeleccionado);
                MostrarExito("Producto eliminado correctamente.");
                LimpiarCampos();
                RefrescarLista();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RefrescarLista();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            RefrescarLista();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvProductos.Rows[e.RowIndex].DataBoundItem is Producto prod)
            {
                _idSeleccionado = prod.IdProducto;
                txtNombre.Text = prod.Nombre;
                txtPrecio.Text = prod.Precio.ToString();
                txtStock.Text = prod.Stock.ToString();
                // Como ValueMember = "IdCategoria", asignar SelectedValue
                // selecciona automáticamente la categoría correcta en el combo.
                cmbCategoria.SelectedValue = prod.IdCategoria;
            }
        }

        // ----- Métodos auxiliares -----

        private void CargarCategorias()
        {
            try
            {
                // DisplayMember = lo que el usuario ve; ValueMember = lo que el programa usa.
                cmbCategoria.DataSource = _categoriaLogica.ObtenerCategorias();
                cmbCategoria.DisplayMember = "Nombre";
                cmbCategoria.ValueMember = "IdCategoria";
                cmbCategoria.SelectedIndex = -1; // sin categoría elegida al inicio
            }
            catch (Exception ex)
            {
                MostrarError("No se pudieron cargar las categorías: " + ex.Message);
            }
        }

        // Si hay texto en el buscador, filtra por nombre; si está vacío,
        // ProductoLogica.Buscar devuelve todos. Así un solo método sirve
        // para la carga inicial, la búsqueda y el refresco después de guardar.
        private void RefrescarLista()
        {
            try
            {
                dgvProductos.DataSource = _productoLogica.Buscar(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MostrarError("No se pudieron cargar los productos: " + ex.Message);
            }
        }

        // Convierte los textos de pantalla a un objeto Producto.
        // Convertir texto a número es tarea de la interfaz (la capa Logica recibe
        // ya un decimal/int); las reglas de negocio (precio > 0, stock >= 0, etc.)
        // se validan en ProductoLogica.
        private Producto LeerFormulario()
        {
            if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio))
                throw new Exception("El precio debe ser un número válido.");

            if (!int.TryParse(txtStock.Text.Trim(), out int stock))
                throw new Exception("El stock debe ser un número entero.");

            Producto prod = new Producto();
            prod.IdProducto = _idSeleccionado;
            prod.Nombre = txtNombre.Text.Trim();
            prod.Precio = precio;
            prod.Stock = stock;
            // Si no hay nada seleccionado, SelectedValue es null -> 0, y la Logica lo rechaza.
            prod.IdCategoria = cmbCategoria.SelectedValue is int idCategoria ? idCategoria : 0;
            return prod;
        }

        private void LimpiarCampos()
        {
            _idSeleccionado = 0;
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            cmbCategoria.SelectedIndex = -1;
            dgvProductos.ClearSelection();
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
