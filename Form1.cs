namespace SistemaGestionProductos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string mensaje;
            bool ok = Datos.Conexion.ProbarConexion(out mensaje);
            MessageBox.Show(mensaje);
        

        }
    }
}
