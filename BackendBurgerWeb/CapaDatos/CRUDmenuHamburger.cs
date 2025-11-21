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

        public bool PostMenuHamburger(ModeloMenuHamburger createMenu)
        {
            try
            {
                CRUDmenuHamburger objCrudMenu = new CRUDmenuHamburger();

                using(var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();

                    string @Post =
                        "INSERT INTO menuHamburger (id, name)" +
                        "VALUES (@id,@name) ";
                    using (SqlCommand objSqlCommand = new SqlCommand(Post, db))
                    {
                        objSqlCommand.Parameters.AddWithValue("@id", createMenu.id);
                        objSqlCommand.Parameters.AddWithValue("@name", createMenu.name);

                        int RowsAffected = objSqlCommand.ExecuteNonQuery();
                        return RowsAffected > 0;
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("[****].[Error].[CRUDmenuHamburger.PostMenuHamburger] " + ex.Message);
                throw new Exception("[****].[Error].[CRUDmenuHamburger.PostMenuHamburger] " + ex.Message);
            }
        }


        public List<ModeloMenuHamburger> GetMenuHamburgerId(int id)
        {

            var listaMenuHamburger = new List<ModeloMenuHamburger>();

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    string @GetId =
                        "SELECT id, name FROM menuHamburger " +
                        "WHERE id = @id";

                    using (SqlCommand objSqlCommand = new SqlCommand(GetId, db))
                    {
                        objSqlCommand.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader())
                        {
                            while (objSqlDataReader.Read())
                            {
                                var ModeloMenu = new ModeloMenuHamburger
                                {
                                    id = objSqlDataReader.GetInt64(0),
                                    name = objSqlDataReader.GetString(1)
                                };
                                listaMenuHamburger.Add(ModeloMenu);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("[****].[Error].[CRUDmenuHamburger.GetMenuHamburgerId] " + ex.Message);
                throw new Exception("[****].[Error].[CRUDmenuHamburger.GetMenuHamburgerId] " + ex.Message);
            }
            return listaMenuHamburger;
        }


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
