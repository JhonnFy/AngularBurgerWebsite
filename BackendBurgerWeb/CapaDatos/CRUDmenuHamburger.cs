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

        public bool DeleteMenuHamburger(ModeloMenuHamburger deleteMenu)
        {
            using var db = conexion.ObtenerCadenaDeConexion();
            db.Open();

            string OrderMenu_MenuHamburger = "SELECT COUNT(*) FROM order_menu WHERE hamburger_id =@id";
            using (SqlCommand runSelectId = new SqlCommand(OrderMenu_MenuHamburger, db))
            {
                try
                {
                    runSelectId.Parameters.AddWithValue("@id", deleteMenu.id);
                    int runSelectIdCount = (int)runSelectId.ExecuteScalar();
                    if(runSelectIdCount > 0)
                    {
                        Debug.WriteLine("[****].[INFO].[DeleteMenuHamburger] No se puede eliminar, tiene " + runSelectIdCount + " Asociados  [Order_Menu].");
                        return false;
                    }
                    else
                    {
                        string @Delete =
                            "DELETE FROM menuHamburger " +
                            "where id = @id";

                        using (SqlCommand deleteSql = new SqlCommand(Delete, db))
                        {
                            deleteSql.Parameters.AddWithValue("@id", deleteMenu.id);

                            int FilasEliminada = deleteSql.ExecuteNonQuery();
                            return FilasEliminada > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("[****].[ERROR].[Capa Datos].[DeleteMenuHamburger] " + ex.Message);
                    throw new Exception("ERROR [Capa Datos].[DeleteMenuHamburger]" + ex.Message);
                }
            }
        }


        public bool PutmenuHamburger(ModeloMenuHamburger putMenu)
        {
            
                using var db = conexion.ObtenerCadenaDeConexion();
                db.Open();

                string selectId = "SELECT COUNT(*) FROM menuHamburger WHERE id = @id";
                using (SqlCommand runSelectId = new SqlCommand(selectId,db))
                {
                    try
                    {

                        runSelectId.Parameters.AddWithValue("@id", putMenu.id);
                        int runSelectIdCount = ((int)runSelectId.ExecuteScalar());
                        if (runSelectIdCount > 0)
                        {
                        string Put =
                            "UPDATE menuHamburger " +
                            "SET name = @name " +
                            "WHERE id = @id";

                        using (SqlCommand runPut = new SqlCommand(Put, db))
                            {
                                runPut.Parameters.AddWithValue("@id", putMenu.id);
                                runPut.Parameters.AddWithValue("@name", putMenu.name);

                                int RegistrosActualizados = runPut.ExecuteNonQuery();
                                return RegistrosActualizados > 0;
                            }
                        }
                        else
                        {
                            Debug.WriteLine("[****].[INFO].[PutmenuHamburger].[El Id, No Se Encuentra Registrado]");
                            return false;
                        }
                    }
                    catch(Exception ex)
                    {
                        Debug.WriteLine("[****].[ERROR].[CapaDatos].[CRUDcontact].[PutContact]" + ex.Message);
                        throw new Exception("ERROR [CapaDatos].[Update Estudinate].[PutContact]" + ex.Message);
                    }
                }
        }


        public bool PostMenuHamburger(ModeloMenuHamburger newMenu)
        {
                using var db = conexion.ObtenerCadenaDeConexion();
                db.Open();

                string selectId = "SELECT COUNT(*) FROM menuHamburger WHERE id = @id";
                using (SqlCommand runSelectId = new SqlCommand(selectId,db))
                {
                    try
                    {
                        runSelectId.Parameters.AddWithValue("@id", newMenu.id);
                        int runSelectIdCount = (int)runSelectId.ExecuteScalar();
                        if(runSelectIdCount > 0)
                        {
                            Debug.WriteLine("[****].[INFO].[PostmenuHamburger] No se puede Registrar, ya existe" + runSelectIdCount + " Asociados.");
                            return false;
                        }else
                        {
                        string @Post =
                            "INSERT INTO menuHamburger " +
                            "(id, name) " +
                            "VALUES " +
                            "(@id, @name)";

                        using (SqlCommand runPost = new SqlCommand(Post, db))
                            {
                                runPost.Parameters.AddWithValue("@id", newMenu.id);
                                runPost.Parameters.AddWithValue("@name", newMenu.name);

                            int RegistrosDb = runPost.ExecuteNonQuery();
                            return RegistrosDb > 0;
                            }
                        }
                    }
                catch(Exception ex)
                    {
                    Debug.WriteLine("[****].[INFO].[CapaDatos].[CRUDcontact].[PostmenuHamburger].[Menu NO Registrado]");
                    Console.WriteLine("[****].[INFO].[CapaDatos].[CRUDcontact].[PostmenuHamburger].[Menu NO Registrado]");
                    throw new Exception("[****].[INFO].[CapaDatos].[CRUDcontact].[PostmenuHamburger].[Menu NO Registrado] " + ex.Message);
                }

            }   
        }


        public List<ModeloMenuHamburger> GetMenuHamburgerId(int id)
        {
            var ListaGetMenuHamburgerId = new List<ModeloMenuHamburger>();

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    string @Read =
                        "SELECT * FROM menuHamburger " +
                        "WHERE ID = @id";

                    using (SqlCommand readSelect = new SqlCommand(Read, db))
                    {
                        readSelect.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader runReadSelect = readSelect.ExecuteReader())
                        {
                            while (runReadSelect.Read())
                            {
                                var modelo = new ModeloMenuHamburger
                                {
                                    id = runReadSelect.GetInt64(0),
                                    name = runReadSelect.GetString(1)
                                };
                                ListaGetMenuHamburgerId.Add(modelo);
                            }
                        }
                    }
                }
            }catch (Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[CRUDcontact].[Test].[GetMenuHamburgerId]" + ex.Message);
                throw new Exception("[****].[ERROR].[CRUDcontact].[Test].[GetMenuHamburgerId]" + ex.Message);
            }
            return ListaGetMenuHamburgerId;
        }


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
