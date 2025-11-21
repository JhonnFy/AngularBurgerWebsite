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
            var listMenuHamburger = new List<ModeloMenuHamburger>();

                try
                {
                    using (var db = conexion.ObtenerCadenaDeConexion())
                    {
                        db.Open();
                    string @Get =
                        "SELECT id, name FROM menuHamburger";
                    using (SqlCommand objSqlCommand = new SqlCommand(Get, db))
                    using (SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader())
                        {
                            while (objSqlDataReader.Read())
                            {
                                var modeloMenuHamburger = new ModeloMenuHamburger
                                {
                                    id = objSqlDataReader.GetInt64(0),
                                    name = objSqlDataReader.GetString(1)
                                };
                            listMenuHamburger.Add(modeloMenuHamburger);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine("[****].[Error].[CRUDmenuHamburger.GetHamburger] " + ex.Message);
                    throw new Exception("[****].[Error].[CRUDmenuHamburger.GetHamburger] " + ex.Message);
                }
            return listMenuHamburger;
        }
    }
}
