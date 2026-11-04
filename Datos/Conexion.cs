using System;
using Microsoft.Data.SqlClient;

namespace SistemaGestionProductos.Datos
{
    public class Conexion
    {
        private static readonly string _cadenaConexion =
            @"Server=LAPTOP-20BJTKI5\SQLEXPRESS;
              Database=GestionProductosDB;
              Integrated Security=True;
              TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadenaConexion);
        }

        public static bool ProbarConexion(out string mensaje)
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    mensaje = "Conexión exitosa a SQL Server.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensaje = "No se pudo conectar: " + ex.Message;
                return false;
            }
        }
    }
}