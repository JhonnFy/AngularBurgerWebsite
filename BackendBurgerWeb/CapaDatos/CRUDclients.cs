using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
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

        public bool DeleteClients(int cc)
        {
            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (SqlCommand objSqlCommand = new SqlCommand("DeleteClients", db))
                    {
                        objSqlCommand.Parameters.AddWithValue("@cc", cc);
                        objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        int RowsAffect = objSqlCommand.ExecuteNonQuery();
                        return RowsAffect > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[Error Class].[CRUDClients.DeleteClients] " + ex.Message);
                throw new Exception("[****].[Error Class].[CRUDClients.DeleteClients] " + ex.Message);
            }
        }

        public bool PutClients(ModeloClients putClients)
        {
            using (var db = conexion.ObtenerCadenaDeConexion())
            {
                try
                {
                    db.Open();
                    using (SqlCommand objSqlCommand = new SqlCommand("PutClients", db))
                    {
                        objSqlCommand.Parameters.AddWithValue("@Accion", "PutAllClients");
                        objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        objSqlCommand.Parameters.AddWithValue("@cc", putClients.cc);
                        objSqlCommand.Parameters.AddWithValue("@name", putClients.name);
                        objSqlCommand.Parameters.AddWithValue("@address", putClients.address);
                        objSqlCommand.Parameters.AddWithValue("@phone1", putClients.phone1);
                        objSqlCommand.Parameters.AddWithValue("@phone2", putClients.phone2);
                        objSqlCommand.Parameters.AddWithValue("@reference", putClients.reference);
                        objSqlCommand.Parameters.AddWithValue("@payment_method", putClients.payment_method);

                        var RowsAffected = objSqlCommand.ExecuteNonQuery();
                        return RowsAffected > 0;

                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine("[****].[Error Class].[CRUDClients.PutClients] " + ex.Message);
                    throw new Exception("[****].[Error Class].[CRUDClients.PutClients] " + ex.Message);
                }
            }
        }

        public bool PostClients(ModeloClients PostClients)
        {
            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (SqlCommand objSqlCommand = new SqlCommand("PostClients",db)) 
                    {
                        objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        objSqlCommand.Parameters.AddWithValue("@cc", PostClients.cc);
                        objSqlCommand.Parameters.AddWithValue("@name", PostClients.name);
                        objSqlCommand.Parameters.AddWithValue("@address", PostClients.address);
                        objSqlCommand.Parameters.AddWithValue("@phone1", PostClients.phone1);
                        objSqlCommand.Parameters.AddWithValue("@phone2", PostClients.phone2);
                        objSqlCommand.Parameters.AddWithValue("@reference", PostClients.reference);
                        objSqlCommand.Parameters.AddWithValue("@payment_method", PostClients.payment_method);

                        int RowsAffected = objSqlCommand.ExecuteNonQuery();
                        return RowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[Error Class].[CRUDClients.PostClients] " + ex.Message);
                throw new Exception("[****].[Error Class].[CRUDClients.PostClients] " + ex.Message);
            }
        }

        public List<ModeloClients> GetClientsId(int cc)
        {
            var listGetClientsId = new List<ModeloClients>();

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();

                    using (SqlCommand objSqlCommand = new SqlCommand("GetClientsId", db))
                    {
                        objSqlCommand.Parameters.AddWithValue("@cc",cc);
                        objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        using (SqlDataReader  runSql = objSqlCommand.ExecuteReader())
                        {
                            while (runSql.Read())
                            {
                                var ModeloId = new ModeloClients
                                {
                                    cc = runSql.GetInt64(0),
                                    name = runSql.GetString(1),
                                    address = runSql.GetString(2),
                                    phone1 = runSql.GetInt64(3),
                                    phone2 = runSql.GetInt64(4),
                                    reference = runSql.GetString(5),
                                    payment_method = runSql.GetString(6)
                                };
                                listGetClientsId.Add(ModeloId);
                            }
                        }
                    }
                }

            }catch (Exception ex)
            {
                Debug.WriteLine("[****].[Error Class].[CRUDClients.GetClientsId] " + ex.Message);
                throw new Exception("[****].[Error Class].[CRUDClients.GetClientsId] " + ex.Message);
            }
            return listGetClientsId;
        }

        public List<ModeloClients> GetClients()
        {
            var listClients = new List<ModeloClients>();
            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("GetClients", db))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
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
                Debug.WriteLine("[****].[Error Class].[CRUDClients.GetClients] " + ex.Message);
                throw new Exception("[****].[Error Class].[CRUDClients.GetClients] " + ex.Message);
            }
            return listClients;
        }
    }
}
