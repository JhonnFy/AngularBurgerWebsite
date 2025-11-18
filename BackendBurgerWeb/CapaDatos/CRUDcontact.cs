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
