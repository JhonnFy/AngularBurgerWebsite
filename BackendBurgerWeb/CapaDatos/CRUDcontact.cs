using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CRUDcontact
    {

        private Conexion conexion = new Conexion();

        public bool PutContact(ModeloContact putContact)
        {
            try
            {
                using var db = conexion.ObtenerCadenaDeConexion();
                db.Open();

                string @Put =
                    "UPDATE contact " +
                    "SET " +
                    "name = @name," +
                    "address = @address," +
                    "phone = @phone " +
                    "WHERE id = @id ";
                    

                using (SqlCommand runPut = new SqlCommand(Put, db))
                {
                    runPut.Parameters.AddWithValue("@id", putContact.id);
                    runPut.Parameters.AddWithValue("@name", putContact.name);
                    runPut.Parameters.AddWithValue("@address", putContact.address);
                    runPut.Parameters.AddWithValue("@phone", putContact.phone);

                    int RegistrosActualizado = runPut.ExecuteNonQuery();
                    return RegistrosActualizado > 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[CapaDatos].[CRUDcontact].[PutContact]" + ex.Message);
                throw new Exception("ERROR [CapaDatos].[Update Estudinate].[PutContact]" + ex.Message);
            }
        }


        public bool PostContac(ModeloContact newContac)
        {
            try
            {
                using var db = conexion.ObtenerCadenaDeConexion();
                db.Open();


                using (var checkId = new SqlCommand("SELECT * FROM contact WHERE id = @id", db))
                {
                    checkId.Parameters.AddWithValue("@id", newContac.id);
                    if (checkId.ExecuteScalar() != null)
                    {
                        Debug.WriteLine("[****].[INFO].[CapaDatos].[CRUDcontact].[PostContac].[Contac Ya Registrado]");
                        return false;
                    }
                }

                string @Post =
                    "INSERT INTO contact" +
                    "(id, name, address, phone)" +
                    "VALUES" +
                    "(@id, @name, @address, @phone)";

                using (SqlCommand runPost = new SqlCommand(Post, db))
                {
                    runPost.Parameters.AddWithValue("@id", newContac.id);
                    runPost.Parameters.AddWithValue("@name", newContac.name);
                    runPost.Parameters.AddWithValue("@address", newContac.address);
                    runPost.Parameters.AddWithValue("@phone", newContac.phone);

                    int RegistrosDb = runPost.ExecuteNonQuery();
                    return RegistrosDb > 0;

                }

            }
            catch(Exception ex)
            {
                Debug.WriteLine("[****].[INFO].[CapaDatos].[CRUDcontact].[PostContac].[Contac NO Registrado]");
                Console.WriteLine("[****].[INFO].[CapaDatos].[CRUDcontact].[PostContac].[Contac NO Registrado]");
                throw new Exception("[****].[INFO].[CapaDatos].[CRUDcontact].[PostContac].[Contac NO Registrado] " + ex.Message);
            }
            
        }



        public List<ModeloContact> GetContactsId(int id)
        {
            var ListaGetContactId = new List<ModeloContact>();

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    string @read =
                        "SELECT * FROM contact " +
                        "WHERE ID = @id";

                    using (SqlCommand readSelect = new SqlCommand(read, db))
                    {

                        readSelect.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader runreadSelect = readSelect.ExecuteReader())
                        {
                            while (runreadSelect.Read())
                            {
                                var modelo = new ModeloContact
                                {
                                    id = runreadSelect.GetInt64(0),
                                    name = runreadSelect.GetString(1),
                                    address = runreadSelect.GetString(2),
                                    phone = runreadSelect.GetInt64(3)
                                };
                                ListaGetContactId.Add(modelo);
                            }

                        }
                    }
                }
            }catch(Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[CRUDcontact].[GetContactsId]" + ex.Message);
                throw new Exception("[****].[ERROR].[CRUDcontact].[GetContactsId]" + ex.Message);
            }

            return ListaGetContactId;
        }


        public List<ModeloContact> GetContacts()
        {
            var ListaGetContact = new List<ModeloContact>();

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    string @read =
                        "SELECT * FROM contact";

                    using (SqlCommand readSelect = new SqlCommand(read, db))
                    using (SqlDataReader runReadSelect = readSelect.ExecuteReader())
                        while (runReadSelect.Read())
                        {
                            var modelo = new ModeloContact
                            {
                                id = runReadSelect.GetInt64(0),
                                name = runReadSelect.GetString(1),
                                address = runReadSelect.GetString(2),
                                phone = runReadSelect.GetInt64(3)
                            };
                            ListaGetContact.Add(modelo);
                        }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[CRUDcontact].[GetContacts]" + ex.Message);
                throw new Exception("[****].[ERROR].[CRUDcontact].[GetContacts]" + ex.Message);
            }
            return ListaGetContact;
        }
    }
}
