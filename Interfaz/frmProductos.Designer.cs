namespace SistemaGestionProductos.Interfaz
{
    partial class FrmProductos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle estiloPrecio = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloStock = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloFecha = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloValor = new DataGridViewCellStyle();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            lblStock = new Label();
            txtStock = new TextBox();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnMostrarTodos = new Button();
            dgvProductos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colValorInventario = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
           
            // lblNombre
           
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 15);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
        
            // txtNombre
           
            txtNombre.Location = new Point(110, 12);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 27);
            txtNombre.TabIndex = 1;
           
            // lblPrecio
           
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(12, 50);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(53, 20);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "Precio:";
           
            // txtPrecio
          
            txtPrecio.Location = new Point(110, 47);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(120, 27);
            txtPrecio.TabIndex = 3;
            
            // lblStock
           
            lblStock.AutoSize = true;
            lblStock.Location = new Point(12, 85);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(48, 20);
            lblStock.TabIndex = 4;
            lblStock.Text = "Stock:";
            
            // txtStock
           
            txtStock.Location = new Point(110, 82);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(120, 27);
            txtStock.TabIndex = 5;
           
            // lblCategoria
            
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(12, 120);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(77, 20);
            lblCategoria.TabIndex = 6;
            lblCategoria.Text = "Categoría:";
           
            // cmbCategoria
           
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(110, 117);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(250, 28);
            cmbCategoria.TabIndex = 7;
          
            // btnAgregar
           
            btnAgregar.Location = new Point(400, 12);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(110, 32);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
           
            // btnModificar
            
            btnModificar.Location = new Point(520, 12);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(110, 32);
            btnModificar.TabIndex = 9;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
           
            // btnEliminar
            
            btnEliminar.Location = new Point(400, 52);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(110, 32);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            
            // btnLimpiar
            
            btnLimpiar.Location = new Point(520, 52);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(110, 32);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            
            // lblBuscar
            
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(12, 168);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(55, 20);
            lblBuscar.TabIndex = 12;
            lblBuscar.Text = "Buscar:";
            
            // txtBuscar
           
            txtBuscar.Location = new Point(110, 165);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Nombre del producto";
            txtBuscar.Size = new Size(250, 27);
            txtBuscar.TabIndex = 13;
            
            // btnBuscar
           
            btnBuscar.Location = new Point(370, 163);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(110, 32);
            btnBuscar.TabIndex = 14;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
           
            // btnMostrarTodos
            
            btnMostrarTodos.Location = new Point(490, 163);
            btnMostrarTodos.Name = "btnMostrarTodos";
            btnMostrarTodos.Size = new Size(140, 32);
            btnMostrarTodos.TabIndex = 15;
            btnMostrarTodos.Text = "Mostrar todos";
            btnMostrarTodos.UseVisualStyleBackColor = true;
            btnMostrarTodos.Click += btnMostrarTodos_Click;
            
            // dgvProductos
           
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colPrecio, colStock, colFecha, colCategoria, colValorInventario });
            dgvProductos.Location = new Point(12, 210);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(876, 338);
            dgvProductos.TabIndex = 16;
            dgvProductos.CellClick += dgvProductos_CellClick;
           
            // colId
            
            colId.DataPropertyName = "IdProducto";
            colId.FillWeight = 10F;
            colId.HeaderText = "Id";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
           
            // colNombre
           
            colNombre.DataPropertyName = "Nombre";
            colNombre.FillWeight = 30F;
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 6;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
           
            // colPrecio
           
            colPrecio.DataPropertyName = "Precio";
            estiloPrecio.Alignment = DataGridViewContentAlignment.MiddleRight;
            estiloPrecio.Format = "N2";
            colPrecio.DefaultCellStyle = estiloPrecio;
            colPrecio.FillWeight = 15F;
            colPrecio.HeaderText = "Precio";
            colPrecio.MinimumWidth = 6;
            colPrecio.Name = "colPrecio";
            colPrecio.ReadOnly = true;
            
            // colStock
            
            colStock.DataPropertyName = "Stock";
            estiloStock.Alignment = DataGridViewContentAlignment.MiddleRight;
            colStock.DefaultCellStyle = estiloStock;
            colStock.FillWeight = 10F;
            colStock.HeaderText = "Stock";
            colStock.MinimumWidth = 6;
            colStock.Name = "colStock";
            colStock.ReadOnly = true;
            
            // colFecha
           
            colFecha.DataPropertyName = "FechaRegistro";
            estiloFecha.Format = "dd/MM/yyyy HH:mm";
            colFecha.DefaultCellStyle = estiloFecha;
            colFecha.FillWeight = 20F;
            colFecha.HeaderText = "Fecha registro";
            colFecha.MinimumWidth = 6;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
          
            // colCategoria
         
            colCategoria.DataPropertyName = "NombreCategoria";
            colCategoria.FillWeight = 20F;
            colCategoria.HeaderText = "Categoría";
            colCategoria.MinimumWidth = 6;
            colCategoria.Name = "colCategoria";
            colCategoria.ReadOnly = true;
           
            // colValorInventario
           
            colValorInventario.DataPropertyName = "ValorInventario";
            estiloValor.Alignment = DataGridViewContentAlignment.MiddleRight;
            estiloValor.Format = "N2";
            colValorInventario.DefaultCellStyle = estiloValor;
            colValorInventario.FillWeight = 18F;
            colValorInventario.HeaderText = "Valor inventario";
            colValorInventario.MinimumWidth = 6;
            colValorInventario.Name = "colValorInventario";
            colValorInventario.ReadOnly = true;
         
            // FrmProductos
          
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 560);
            Controls.Add(dgvProductos);
            Controls.Add(btnMostrarTodos);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(cmbCategoria);
            Controls.Add(lblCategoria);
            Controls.Add(txtStock);
            Controls.Add(lblStock);
            Controls.Add(txtPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            MinimumSize = new Size(800, 450);
            Name = "FrmProductos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Productos";
            Load += FrmProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Label lblStock;
        private TextBox txtStock;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Button btnMostrarTodos;
        private DataGridView dgvProductos;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colValorInventario;
    }
}