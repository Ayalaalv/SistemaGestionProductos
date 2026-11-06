using System;
using System.Collections.Generic;
using SistemaGestionProductos.Datos;
using SistemaGestionProductos.Entidades;

namespace SistemaGestionProductos.Logica
{
    public class ProductoLogica
    {
        private readonly ProductoDatos _datos = new ProductoDatos();

        public List<Producto> ObtenerProductos()
        {
            return _datos.ObtenerTodos();
        }

        public List<Producto> Buscar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return _datos.ObtenerTodos();

            return _datos.BuscarPorNombre(texto.Trim());
        }

        public void Registrar(Producto prod)
        {
            Validar(prod);
            prod.FechaRegistro = DateTime.Now;  
            _datos.Insertar(prod);
        }

        public void Modificar(Producto prod)
        {
            if (prod.IdProducto <= 0)
                throw new Exception("Debe seleccionar un producto para modificar.");

            Validar(prod);
            _datos.Actualizar(prod);
        }

        public void Eliminar(int idProducto)
        {
            if (idProducto <= 0)
                throw new Exception("Debe seleccionar un producto para eliminar.");

            _datos.Eliminar(idProducto);
        }

        private void Validar(Producto prod)
        {
            if (string.IsNullOrWhiteSpace(prod.Nombre))
                throw new Exception("El nombre del producto es obligatorio.");

            if (prod.Nombre.Length > 100)
                throw new Exception("El nombre no puede superar los 100 caracteres.");

            if (prod.Precio <= 0)
                throw new Exception("El precio debe ser mayor que cero.");

            if (prod.Stock < 0)
                throw new Exception("El stock no puede ser negativo.");

            if (prod.IdCategoria <= 0)
                throw new Exception("Debe seleccionar una categoría.");
        }
    }
}