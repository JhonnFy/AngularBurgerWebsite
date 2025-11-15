using System;
using System.Configuration;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;


namespace CapaDatos
{
    public class Conexion
    {

        private readonly string cadenaConexion;

        public Conexion()
        {
            try
            {
                var cs = ConfigurationManager.ConnectionStrings["CadenaSQL"];

                if (cs == null || string.IsNullOrEmpty(cs.ConnectionString))
                {
                    Debug.WriteLine("[----CapaDatos----].[ERROR].[No Se Conecta A dbBurgerWeb].[cs Vacia]");
                    Console.WriteLine("[----CapaDatos----].[ERROR].[No Se Conecta A dbBurgerWeb].[cs Vacia]");
                    throw new Exception("[----CapaDatos----].[ERROR].Cadena de conexión vacía o no encontrada.");
                }

                cadenaConexion = cs.ConnectionString;
                Debug.WriteLine("[****CapaDatos****].[OK].[Conexion Exitosa A dbBurgerWeb]");
                Console.WriteLine("[****CapaDatos****].[OK].[Conexion Exitosa A dbBurgerWeb]");

            }
            catch (Exception ex)
            {
                Debug.WriteLine("[----CapaDatos----].[ERROR].[No Se Conecta A BurgerWeb]" + ex.Message);
                Console.WriteLine("[----CapaDatos----].[ERROR].[No Se Conecta A BurgerWeb]" + ex.Message);
            }
        }

        public SqlConnection ObtenerCadenaDeConexion()
        {
            Debug.WriteLine("[****CapaDatos****].[OK].[Retornando Cadena De Conexion]");
            Console.WriteLine("[****CapaDatos****].[OK].[Retornando Cadena De Conexion]");
            return new SqlConnection(cadenaConexion);
        }

    }
}
