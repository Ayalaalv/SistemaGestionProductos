namespace SistemaGestionProductos.Interfaz
{
    partial class FrmPrincipal
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
            lblTitulo = new Label();
            btnCategorias = new Button();
            btnProductos = new Button();
            btnSalir = new Button();
            SuspendLayout();
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(40, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(345, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Sistema de Gestión de Productos";
            btnCategorias.Location = new Point(110, 85);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(200, 40);
            btnCategorias.TabIndex = 1;
            btnCategorias.Text = "Categorías";
            btnCategorias.UseVisualStyleBackColor = true;
            btnCategorias.Click += btnCategorias_Click;
            btnProductos.Location = new Point(110, 135);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(200, 40);
            btnProductos.TabIndex = 2;
            btnProductos.Text = "Productos";
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            btnSalir.Location = new Point(110, 185);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(200, 40);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 250);
            Controls.Add(btnSalir);
            Controls.Add(btnProductos);
            Controls.Add(btnCategorias);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú principal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnCategorias;
        private Button btnProductos;
        private Button btnSalir;
    }
}