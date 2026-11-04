using System;

namespace SistemaGestionProductos.Entidades
{
    public class Producto
    {
        private int _idProducto;
        private string _nombre = string.Empty;
        private decimal _precio;
        private int _stock;
        private DateTime _fechaRegistro;
        private int _idCategoria;
        private string _nombreCategoria = string.Empty;

        public int IdProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public DateTime FechaRegistro
        {
            get { return _fechaRegistro; }
            set { _fechaRegistro = value; }
        }

        public int IdCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }

        public string NombreCategoria
        {
            get { return _nombreCategoria; }
            set { _nombreCategoria = value; }
        }

        public decimal ValorInventario
        {
            get { return _precio * _stock; }
        }

        public Producto() { }
    }
}