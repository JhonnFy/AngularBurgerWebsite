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

        public List<ModeloContact> GetContacts()
        {
            var ListaReadContact = new List<ModeloContact>();

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
                            ListaReadContact.Add(modelo);
                        }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[CRUDcontact].[GetContacts]" + ex.Message);
                throw new Exception("[****].[ERROR].[CRUDcontact].[GetContacts]" + ex.Message);
            }
            return ListaReadContact;
        }
    }
}
