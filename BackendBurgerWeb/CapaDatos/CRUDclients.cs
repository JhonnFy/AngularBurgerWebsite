using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CRUDclients
    {
        private Conexion conexion = new Conexion();
        

        public List<ModeloClients> GetClients()
        {
            var listClients = new List<ModeloClients>();
            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    string @Get =
                        "SELECT cc,name,address,phone1,phone2,reference,payment_method " +
                        "FROM clients ";
                    using (SqlCommand sqlCommand = new SqlCommand(Get,db))
                    {
                        using (SqlDataReader runSqlCommand = sqlCommand.ExecuteReader())
                        {
                            while (runSqlCommand.Read())
                            {
                                var Modelo = new ModeloClients
                                {
                                    cc = runSqlCommand.GetInt64(0),
                                    name = runSqlCommand.GetString(1),
                                    address = runSqlCommand.GetString(2),
                                    phone1 = runSqlCommand.GetInt64(3),
                                    phone2 = runSqlCommand.GetInt64(4),
                                    reference = runSqlCommand.GetString(5),
                                    payment_method = runSqlCommand.GetString(6)
                                };
                                listClients.Add(Modelo);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("[CRUDClients.GetClients] " + ex.Message);
                throw new Exception("[CRUDClients.GetClients] " + ex.Message);
            }
            return listClients;
        }

    }
}
