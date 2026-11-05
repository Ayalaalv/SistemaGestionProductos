using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SistemaGestionProductos.Entidades;

namespace SistemaGestionProductos.Datos
{
    public class CategoriaDatos
    {
        public List<Categoria> ObtenerTodas()
        {
            List<Categoria> lista = new List<Categoria>();
            string sql = "SELECT IdCategoria, Nombre, Descripcion FROM Categorias ORDER BY Nombre";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Categoria cat = new Categoria();
                        cat.IdCategoria = lector.GetInt32(0);
                        cat.Nombre = lector.GetString(1);
                        cat.Descripcion = lector.IsDBNull(2) ? string.Empty : lector.GetString(2);
                        lista.Add(cat);
                    }
                }
            }
            return lista;
        }

        public void Insertar(Categoria cat)
        {
            string sql = "INSERT INTO Categorias (Nombre, Descripcion) VALUES (@nombre, @descripcion)";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@nombre", cat.Nombre);
                comando.Parameters.AddWithValue("@descripcion", cat.Descripcion);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void Actualizar(Categoria cat)
        {
            string sql = "UPDATE Categorias SET Nombre = @nombre, Descripcion = @descripcion " +
                         "WHERE IdCategoria = @id";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@nombre", cat.Nombre);
                comando.Parameters.AddWithValue("@descripcion", cat.Descripcion);
                comando.Parameters.AddWithValue("@id", cat.IdCategoria);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idCategoria)
        {
            string sql = "DELETE FROM Categorias WHERE IdCategoria = @id";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@id", idCategoria);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public int ContarProductos(int idCategoria)
        {
            string sql = "SELECT COUNT(*) FROM Productos WHERE IdCategoria = @id";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@id", idCategoria);
                conexion.Open();
                return (int)comando.ExecuteScalar();
            }
        }
    }
}