using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CRUDorderAbout
    {
        private Conexion conexion = new Conexion();


        public ModeloOrderAbout PostOrderAbout(ModeloOrderAbout PostOrder)
        {
            ModeloOrderAbout model = null; 

            try
            {
                using (var db  = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (var cmd = new  SqlCommand("PostOrderAbout",db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", PostOrder.id);
                        cmd.Parameters.AddWithValue("@client_cc", PostOrder.client_cc);
                        cmd.Parameters.AddWithValue("@hamburger_id", PostOrder.hamburger_id);
                        cmd.Parameters.AddWithValue("@quantity", PostOrder.quantity);
                        cmd.Parameters.AddWithValue("@total_price", PostOrder.total_price);
                        cmd.Parameters.AddWithValue("@status", PostOrder.status);
                        cmd.Parameters.AddWithValue("@store_id", PostOrder.store_id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            model = PostOrder;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[****].[Error].[PostOrderAbout]" + ex.Message);
            }
            return model;
        }


        public ModeloOrderAbout GetOrderAboutId(int id)
        {
            ModeloOrderAbout model = null;

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (var cmd = new SqlCommand("GetOrderAboutid", db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                model = new ModeloOrderAbout()
                                {
                                    id = reader.GetInt64(0),
                                    client_cc = reader.IsDBNull(1) ? 0 : reader.GetInt64(1),
                                    hamburger_id =reader.IsDBNull(2) ? 0 : reader.GetInt64(2),
                                    quantity = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                                    total_price = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4),
                                    status = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                    store_id = reader.IsDBNull(6) ? 0 : reader.GetInt64(6),
                                    created_at = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime(7)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[****].[Error].[GetOrderAboutId]" + ex.Message);
            }
            return model;
        }





























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
                                    client_cc = reader.IsDBNull(1) ? 0 : reader.GetInt64(1),
                                    hamburger_id =reader.IsDBNull(2) ? 0 : reader.GetInt64(2),
                                    quantity = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                                    total_price = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4),
                                    status = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                    store_id = reader.IsDBNull(6) ? 0 : reader.GetInt64(6),
                                    created_at = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime(7)
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
