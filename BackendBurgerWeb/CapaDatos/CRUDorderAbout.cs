using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CRUDorderAbout
    {
        private Conexion conexion = new Conexion();

        public List<ModeloOrderAbout> GetOrderAbout()
        {
            var list = new List<ModeloOrderAbout>();
            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (var cmd =  new SqlCommand("GetOrderAbout",db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new ModeloOrderAbout
                                {
                                    id = reader.GetInt64(0),
                                    client_cc = reader.GetInt64(1),
                                    hamburger_id = reader.GetInt64(2),
                                    quantity = reader.GetInt32(3),
                                    total_price = reader.GetDecimal(4),
                                    status = reader.GetString(5),
                                    store_id = reader.GetInt64(6),
                                    created_at = reader.GetDateTime(7)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[****].[Error].[GetGetOrderAbout]" + ex.Message);
            }
            return list;
        }
    }
}
