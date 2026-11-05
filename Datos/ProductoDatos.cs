using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SistemaGestionProductos.Entidades;

namespace SistemaGestionProductos.Datos
{
    public class ProductoDatos
    {
        private const string ConsultaBase =
            "SELECT p.IdProducto, p.Nombre, p.Precio, p.Stock, p.FechaRegistro, " +
            "p.IdCategoria, c.Nombre AS NombreCategoria " +
            "FROM Productos p " +
            "INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria ";

        public List<Producto> ObtenerTodos()
        {
            return EjecutarConsulta(ConsultaBase + "ORDER BY p.Nombre", null);
        }

        public List<Producto> BuscarPorNombre(string texto)
        {
            string sql = ConsultaBase + "WHERE p.Nombre LIKE @texto ORDER BY p.Nombre";
            return EjecutarConsulta(sql, texto);
        }

        private List<Producto> EjecutarConsulta(string sql, string texto)
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                if (texto != null)
                {
                    comando.Parameters.AddWithValue("@texto", "%" + texto + "%");
                }

                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Producto prod = new Producto();
                        prod.IdProducto = lector.GetInt32(0);
                        prod.Nombre = lector.GetString(1);
                        prod.Precio = lector.GetDecimal(2);
                        prod.Stock = lector.GetInt32(3);
                        prod.FechaRegistro = lector.GetDateTime(4);
                        prod.IdCategoria = lector.GetInt32(5);
                        prod.NombreCategoria = lector.GetString(6);
                        lista.Add(prod);
                    }
                }
            }
            return lista;
        }

        public void Insertar(Producto prod)
        {
            string sql = "INSERT INTO Productos (Nombre, Precio, Stock, FechaRegistro, IdCategoria) " +
                         "VALUES (@nombre, @precio, @stock, @fecha, @idCategoria)";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@nombre", prod.Nombre);
                comando.Parameters.AddWithValue("@precio", prod.Precio);
                comando.Parameters.AddWithValue("@stock", prod.Stock);
                comando.Parameters.AddWithValue("@fecha", prod.FechaRegistro);
                comando.Parameters.AddWithValue("@idCategoria", prod.IdCategoria);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void Actualizar(Producto prod)
        {
            string sql = "UPDATE Productos SET Nombre = @nombre, Precio = @precio, " +
                         "Stock = @stock, IdCategoria = @idCategoria " +
                         "WHERE IdProducto = @id";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@nombre", prod.Nombre);
                comando.Parameters.AddWithValue("@precio", prod.Precio);
                comando.Parameters.AddWithValue("@stock", prod.Stock);
                comando.Parameters.AddWithValue("@idCategoria", prod.IdCategoria);
                comando.Parameters.AddWithValue("@id", prod.IdProducto);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idProducto)
        {
            string sql = "DELETE FROM Productos WHERE IdProducto = @id";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@id", idProducto);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }
    }
}