using System;
using System.Windows.Forms;
using SistemaGestionProductos.Entidades;
using SistemaGestionProductos.Logica;

namespace SistemaGestionProductos.Interfaz
{
    public partial class FrmProductos : Form
    {
        private readonly ProductoLogica _productoLogica = new ProductoLogica();
        private readonly CategoriaLogica _categoriaLogica = new CategoriaLogica();

        private int _idSeleccionado = 0;

        private readonly ErrorProvider errorProvider = new ErrorProvider();

        public FrmProductos()
        {
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink; 
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            RefrescarLista();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

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
            if (!ValidarCampos())
                return;

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
                errorProvider.Clear();
                _idSeleccionado = prod.IdProducto;
                txtNombre.Text = prod.Nombre;
                txtPrecio.Text = prod.Precio.ToString();
                txtStock.Text = prod.Stock.ToString();
                cmbCategoria.SelectedValue = prod.IdCategoria;
            }
        }


        private bool ValidarCampos()
        {
            errorProvider.Clear();
            bool valido = true;

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider.SetError(txtNombre, "Ingrese el nombre del producto.");
                valido = false;
            }

            if (!decimal.TryParse(txtPrecio.Text.Trim(), out _))
            {
                errorProvider.SetError(txtPrecio, "Ingrese un precio numérico, por ejemplo 1500.50");
                valido = false;
            }

            if (!int.TryParse(txtStock.Text.Trim(), out _))
            {
                errorProvider.SetError(txtStock, "Ingrese una cantidad entera, por ejemplo 10.");
                valido = false;
            }

            if (cmbCategoria.SelectedIndex < 0)
            {
                errorProvider.SetError(cmbCategoria, "Seleccione una categoría.");
                valido = false;
            }

            return valido;
        }

        private void CargarCategorias()
        {
            try
            {
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

        private Producto LeerFormulario()
        {
            Producto prod = new Producto();
            prod.IdProducto = _idSeleccionado;
            prod.Nombre = txtNombre.Text.Trim();
            prod.Precio = decimal.Parse(txtPrecio.Text.Trim());
            prod.Stock = int.Parse(txtStock.Text.Trim());
            prod.IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue); return prod;
        }

        private void LimpiarCampos()
        {
            _idSeleccionado = 0;
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            cmbCategoria.SelectedIndex = -1;
            errorProvider.Clear();
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