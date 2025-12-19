using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaDatos;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace CapaTesting
{
    [TestClass]
    public class ConexionTests
    {
        [TestMethod]
        public void TestCadenaDeConexion()
        {
            Conexion conexion = new Conexion();

            using (SqlConnection conn = conexion.ObtenerCadenaDeConexion())
            {
                try
                {
                    conn.Open(); 
                    Console.WriteLine("[TEST] Conexión exitosa a la base de datos.");
                    Debug.WriteLine("[TEST] Conexión exitosa a la base de datos.");
                    Assert.IsTrue(conn.State == System.Data.ConnectionState.Open, "La conexión no se abrió correctamente.");
                }
                catch (Exception ex)
                {
                    Assert.Fail("[TEST] Error al conectar a la base de datos: " + ex.Message);
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }
            }
        }
    }
}
