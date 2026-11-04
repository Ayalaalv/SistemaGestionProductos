namespace SistemaGestionProductos.Entidades
{
    public class Categoria
    {
        private int _idCategoria;
        private string _nombre = string.Empty;
        private string _descripcion = string.Empty;

        public int IdCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public Categoria() { }

        public Categoria(int idCategoria, string nombre, string descripcion)
        {
            _idCategoria = idCategoria;
            _nombre = nombre;
            _descripcion = descripcion;
        }

        public override string ToString()
        {
            return _nombre;
        }
    }
}