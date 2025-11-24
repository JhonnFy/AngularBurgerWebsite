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

        public bool DeleteContact(int id)
        {
            try
            {
                var db = conexion.ObtenerCadenaDeConexion();
                db.Open();

                string @Delete =
                    "DELETE FROM contact " +
                    "WHERE id = @id ";

                using (SqlCommand objSqlCommand = new SqlCommand(Delete, db))
                {
                    objSqlCommand.Parameters.AddWithValue("@id", id);

                    int rowsAffected = objSqlCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[CapaDatos].[DeleteContact]");
                throw new Exception("[****].[ERROR].[CapaDatos].[DeleteContact] " + ex.Message);
            }
        }

        public bool PutContact(ModeloContact putNewContact)
        {
            try
            {
                var db = conexion.ObtenerCadenaDeConexion();
                db.Open();

                string @Put =
                    "UPDATE contact SET " +
                    "name = @name, address = @address, phone = @phone " +
                    "WHERE id = @id ";

                using (SqlCommand objSqlCommand = new SqlCommand(Put, db))
                {
                    objSqlCommand.Parameters.AddWithValue("@id", putNewContact.id);
                    objSqlCommand.Parameters.AddWithValue("@name", putNewContact.name);
                    objSqlCommand.Parameters.AddWithValue("@address", putNewContact.address);
                    objSqlCommand.Parameters.AddWithValue("@phone", putNewContact.phone);

                    int rowsAffected = objSqlCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex )
            {
                Debug.WriteLine("[****].[ERROR].[CapaDatos].[PutContact]");
                throw new Exception("[****].[ERROR].[CapaDatos].[PutContact] " + ex.Message);
            }
        }

        public bool PostContact(ModeloContact newContact)
        {
            try
            {
                var db = conexion.ObtenerCadenaDeConexion();
                db.Open();

                string @Post =
                    "INSERT INTO contact (id,name, address, phone) " +
                    "VALUES  (@id,@name,@address,@phone)";

                using (SqlCommand createContact = new SqlCommand(Post, db))
                {
                    createContact.Parameters.AddWithValue("@id", newContact.id);
                    createContact.Parameters.AddWithValue("@name", newContact.name);
                    createContact.Parameters.AddWithValue("@address", newContact.address);
                    createContact.Parameters.AddWithValue("@phone", newContact.phone);

                    int rowsAffected = createContact.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[CapaDatos].[PostContact]");
                throw new Exception("[****].[ERROR].[CapaDatos].[PostContact] " + ex.Message);
            }
        }
        public List<ModeloContact> GetContactId(int id)
        {
            var listsGetContactId = new List<ModeloContact>();

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    string @ReadId =
                        "SELECT id, name, address, phone FROM contact " +
                        "WHERE id = @id ";

                    using (SqlCommand objSqlCommand = new SqlCommand(ReadId, db))
                    {
                        objSqlCommand.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader())
                        {
                            while (objSqlDataReader.Read())
                            {
                                var modelContactId = new ModeloContact
                                {
                                    id = objSqlDataReader.GetInt64(0),
                                    name = objSqlDataReader.GetString(1),
                                    address = objSqlDataReader.GetString(2),
                                    phone = objSqlDataReader.GetInt64(3)
                                };
                                listsGetContactId.Add(modelContactId);
                            }
                        }
                    }

                }
            }catch(Exception ex)
            {
                Debug.WriteLine("[CRUDcontact.GetContactIds] " + ex.Message);
                throw new Exception("CRUDcontact.GetContactId] " + ex.Message);
            }
            return listsGetContactId;
        }

        public List<ModeloContact> GetContact()
        {
            var listaGetContact = new List<ModeloContact>();

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    string @Read =
                        "SELECT id, name, address, phone FROM contact";

                    using (SqlCommand objSqlCommand = new SqlCommand(Read, db))
                    using (SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader())
                    {
                        while (objSqlDataReader.Read())
                        {
                            var modeloContact = new ModeloContact
                            {
                                id = objSqlDataReader.GetInt64(0),
                                name = objSqlDataReader.GetString(1),
                                address = objSqlDataReader.GetString(2),
                                phone = objSqlDataReader.GetInt64(3)
                            };
                            listaGetContact.Add(modeloContact);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[CRUDcontact.GetContacts] " +  ex.Message);
                throw new Exception("[CRUDcontact.GetContacts] " + ex.Message);
            }
            return listaGetContact;
        }
    }
}
