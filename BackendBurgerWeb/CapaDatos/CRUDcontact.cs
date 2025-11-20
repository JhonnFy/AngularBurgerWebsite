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
