using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CRUDcontact
    {
        private Conexion conexion = new Conexion();

        public bool DeleteContact(ModeloContact DeleteContact)
        {
            ModeloContact model = null;

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();

                    using (var cmd = new SqlCommand("DeleteContact", db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", DeleteContact.id);


                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            model = DeleteContact;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[****].[Error].[DeleteContact]" + ex.Message);
            }
            return model != null;
        }


        public bool PutContact(ModeloContact PutContact)
        {
            ModeloContact model = null;

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (var cmd =  new SqlCommand("PutContact", db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", PutContact.id);
                        cmd.Parameters.AddWithValue("@name", PutContact.name);
                        cmd.Parameters.AddWithValue("@address", PutContact.address);
                        cmd.Parameters.AddWithValue("@phone", PutContact.phone);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            model = PutContact;
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("[****].[Error].[PutContact]" + ex.Message);
            }
            return model != null;
        }

        public ModeloContact PostContac(ModeloContact PostContac)
        {
            ModeloContact model = null;

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (var cmd = new SqlCommand("PostContact", db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id",PostContac.id);
                        cmd.Parameters.AddWithValue("@name",PostContac.name);
                        cmd.Parameters.AddWithValue("@address", PostContac.address);
                        cmd.Parameters.AddWithValue("@phone", PostContac.phone);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            model = PostContac;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("[****].[Error].[PostContact]" + ex.Message);
            }
            return model;
        }
        
        public ModeloContact GetContactId(int id)
        {
            ModeloContact model = null;

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (var cmd = new SqlCommand("GetContactId", db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                model = new ModeloContact()
                                {
                                    id = reader.GetInt64(0),
                                    name = reader.GetString(1),
                                    address = reader.GetString(2),
                                    phone = reader.GetInt64(3)
                                };
                            }
                        }
                    }
                }

            }catch(Exception ex)
            {
                throw new Exception("[****].[Error].[GetContactId]" + ex.Message);
            }
            return model;
        }

        public List<ModeloContact> GetContact()
        {
            var list = new List<ModeloContact>();

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (var cmd = new SqlCommand("GetContact", db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new ModeloContact
                                {
                                    id = reader.GetInt64(0),
                                    name = reader.GetString(1),
                                    address = reader.GetString(2),
                                    phone = reader.GetInt64(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[****].[Error].[GetContact]" + ex.Message);
            }
            return list;
        }
    }
}
