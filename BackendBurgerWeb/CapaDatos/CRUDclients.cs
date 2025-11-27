using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CRUDclients
    {
        private Conexion conexion = new Conexion();

        public bool DeleteClients (ModeloClients DeleteClients)
        {
            ModeloClients model = null;

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();

                    using (var cmd = new SqlCommand("DeleteClients",db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cc", DeleteClients.cc);


                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            model = DeleteClients;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("[****].[Error].[DeleteClients]" + ex.Message);
            }
            return model != null;
        }

        public bool PutClient(ModeloClients PutClient)
        {
            ModeloClients model = null;

           try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (var cmd = new SqlCommand("PutClients", db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PutClients", "PutAllClients");

                        cmd.Parameters.AddWithValue("@cc", PutClient.cc);
                        cmd.Parameters.AddWithValue("@name", PutClient.name);
                        cmd.Parameters.AddWithValue("@address", PutClient.address);
                        cmd.Parameters.AddWithValue("@phone1", PutClient.phone1);
                        cmd.Parameters.AddWithValue("@phone2", PutClient.phone2);
                        cmd.Parameters.AddWithValue("@reference", PutClient.reference);
                        cmd.Parameters.AddWithValue("@payment_method", PutClient.payment_method);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            model = PutClient;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[****].[Error].[PutClients]" + ex.Message);
            }
            return model != null;
        }

        
        public ModeloClients PostClients(ModeloClients PostClients)
        {
            ModeloClients model = null;
            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (var cmd = new SqlCommand("PostClients", db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@cc", PostClients.cc);
                        cmd.Parameters.AddWithValue("@name", PostClients.name);
                        cmd.Parameters.AddWithValue("@address", PostClients.address);
                        cmd.Parameters.AddWithValue("@phone1", PostClients.phone1);
                        cmd.Parameters.AddWithValue("@phone2", PostClients.phone2);
                        cmd.Parameters.AddWithValue("@reference", PostClients.reference);
                        cmd.Parameters.AddWithValue("@payment_method", PostClients.payment_method);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            model = PostClients;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[****].[Error].[PostClients]" + ex.Message);
            }
            return model;
        }


        public ModeloClients GetClientsId(int cc)
        {
            ModeloClients model = null;

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (var cmd = new SqlCommand("GetClientsId",db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cc", cc);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                model = new ModeloClients
                                {
                                    cc = reader.GetInt64(0),
                                    name = reader.GetString(1),
                                    address = reader.GetString(2),
                                    phone1 = reader.GetInt64(3),
                                    phone2 = reader.GetInt64(4),
                                    reference = reader.GetString(5),
                                    payment_method = reader.GetString(6)
                                };
                            }
                        } 
                    }
                }
            }catch (Exception ex)
            {
                throw new Exception("[****].[Error].[GetClients]" + ex.Message);
            }
            return model;
        }

        public List<ModeloClients> GetClients()
        {
            var list = new List<ModeloClients>();
            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (var cmd = new SqlCommand("GetClients",db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                list.Add(new ModeloClients
                                {
                                    cc = reader.GetInt64(0),
                                    name = reader.GetString(1),
                                    address = reader.GetString(2),
                                    phone1 = reader.GetInt64(3),
                                    phone2 = reader.GetInt64(4),
                                    reference = reader.GetString(5),
                                    payment_method = reader.GetString(6)
                                });
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("[****].[Error].[GetClients]" + ex.Message);
            }
            return list;
        }
    }
}
