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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaDatos
{
    public class CRUDcontact
    {
        private Conexion conexion = new Conexion();

        public bool DeleteContact(ModeloContact deleteContact)
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
                        cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = deleteContact.id;


                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            model = deleteContact;
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

        public ModeloContact PostContac(ModeloContact postContac)
        {
            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();

                    using (var cmd = new SqlCommand("PostContact", db))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = postContac.id;
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar,50).Value = postContac.name;
                        cmd.Parameters.Add("@address", SqlDbType.NVarChar,200).Value = postContac.address;
                        cmd.Parameters.Add("@phone", SqlDbType.BigInt).Value = postContac.phone;

                        cmd.ExecuteNonQuery();
                        return postContac;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("[****].[Error].[PostContact]" + ex.Message);
            }
        }
        
        public ModeloContact GetContactId(long id)
        {
            ModeloContact model = null;

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (var cmd = new SqlCommand("GetContactId", db))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                model = new ModeloContact()
                                {
                                    id = reader.GetInt64(reader.GetOrdinal("id")),
                                    name = reader.IsDBNull(reader.GetOrdinal("name")) ? "" : reader.GetString(reader.GetOrdinal("name")),
                                    address = reader.IsDBNull(reader.GetOrdinal("address")) ? "" : reader.GetString(reader.GetOrdinal("address")),
                                    phone = reader.IsDBNull(reader.GetOrdinal("phone")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("phone"))
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
                                    id = reader.GetInt64(reader.GetOrdinal("id")),
                                    name = reader.IsDBNull(reader.GetOrdinal("name")) ? "" : reader.GetString(reader.GetOrdinal("name")),
                                    address = reader.IsDBNull(reader.GetOrdinal("address")) ? "" : reader.GetString(reader.GetOrdinal("address")),
                                    phone = reader.IsDBNull(reader.GetOrdinal("phone")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("phone"))
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
