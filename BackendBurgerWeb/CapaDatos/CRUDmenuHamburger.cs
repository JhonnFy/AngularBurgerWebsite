using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CRUDmenuHamburger
    {

        private Conexion conexion = new Conexion();

        public List<ModeloMenuHamburger> GetMenuHamburger()
        {
            var ListaGetMenuHamburger = new List<ModeloMenuHamburger>();
            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    string @Read =
                        "SELECT * FROM menuHamburger";

                    using (SqlCommand readSql = new SqlCommand(Read, db))
                    using (SqlDataReader runReadSql = readSql.ExecuteReader())
                        while(runReadSql.Read())
                        {
                            var modelo = new ModeloMenuHamburger
                            {
                                id = runReadSql.GetInt64(0),
                                name = runReadSql.GetString(1)
                            };
                            ListaGetMenuHamburger.Add(modelo);
                        }
                }
            }catch(Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[CRUDcontact].[GetContacts]" + ex.Message);
                throw new Exception("[****].[ERROR].[CRUDcontact].[GetContacts]" + ex.Message);
            }
            return ListaGetMenuHamburger;
        }


    }
}
