using System;
using System.Collections.Generic;
using SistemaGestionProductos.Datos;
using SistemaGestionProductos.Entidades;

namespace SistemaGestionProductos.Logica
{
    public class CategoriaLogica
    {
        private readonly CategoriaDatos _datos = new CategoriaDatos();

        public List<Categoria> ObtenerCategorias()
        {
            return _datos.ObtenerTodas();
        }

        public void Registrar(Categoria cat)
        {
            Validar(cat);
            _datos.Insertar(cat);
        }

        public void Modificar(Categoria cat)
        {
            if (cat.IdCategoria <= 0)
                throw new Exception("Debe seleccionar una categoría para modificar.");

            Validar(cat);
            _datos.Actualizar(cat);
        }

        public void Eliminar(int idCategoria)
        {
            if (idCategoria <= 0)
                throw new Exception("Debe seleccionar una categoría para eliminar.");

            int cantidad = _datos.ContarProductos(idCategoria);
            if (cantidad > 0)
            {
                throw new Exception("No se puede eliminar la categoría porque tiene " +
                                    cantidad + " producto(s) asociado(s).");
            }

            _datos.Eliminar(idCategoria);
        }

        private void Validar(Categoria cat)
        {
            if (string.IsNullOrWhiteSpace(cat.Nombre))
                throw new Exception("El nombre de la categoría es obligatorio.");

            if (cat.Nombre.Length > 100)
                throw new Exception("El nombre no puede superar los 100 caracteres.");

            if (cat.Descripcion != null && cat.Descripcion.Length > 250)
                throw new Exception("La descripción no puede superar los 250 caracteres.");
        }
    }
}