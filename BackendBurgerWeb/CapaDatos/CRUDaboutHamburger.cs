using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CRUDaboutHamburger
    {
        Conexion conexion = new Conexion();

        public bool PutAboutHamburger(ModeloAboutHamburger PutHamburger)
        {
            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    string @Put =
                        "UPDATE aboutHamburger " +
                        "SET name = @name " +
                        "WHERE id = @id ";

                    using (SqlCommand objSql = new SqlCommand(Put, db))
                    {
                        objSql.Parameters.AddWithValue("@id", PutHamburger.id);
                        objSql.Parameters.AddWithValue("@name",PutHamburger.name);

                        int RunPut = objSql.ExecuteNonQuery();
                        return RunPut > 0;

                    }
                }
            }
            catch(Exception ex) 
            {
                Debug.WriteLine("[****].[ERROR].[CapaDatos].[PostContact]");
                throw new Exception("[****].[ERROR].[CapaDatos].[PostContact] " + ex.Message);
            }
        }
        

        public bool PostAboutHamburger(ModeloAboutHamburger newAboutMenu)
        {
            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    string @Post =
                        "INSERT INTO aboutHamburger (id, name)" +
                        "VALUES (@id, @name) ";
                    using (SqlCommand createAboutMenu = new SqlCommand(Post, db))
                    {
                        createAboutMenu.Parameters.AddWithValue("@id", newAboutMenu.id);
                        createAboutMenu.Parameters.AddWithValue("@name", newAboutMenu.name);
                        
                        int CreateRows = createAboutMenu.ExecuteNonQuery();
                        return CreateRows > 0;
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[CapaDatos].[PostContact]");
                throw new Exception("[****].[ERROR].[CapaDatos].[PostContact] " + ex.Message);
            }
        }
        

        public List<ModeloAboutHamburger> GetAboutHamburgerId(int id)
        {
            var listModeloAbout = new List<ModeloAboutHamburger>();
            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    string @GetId =
                        "SELECT id, name FROM aboutHamburger " +
                        "WHERE id = @id";
                    using (SqlCommand objSql = new SqlCommand(GetId, db))
                    {
                        objSql.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader objData = objSql.ExecuteReader())
                        {
                            while (objData.Read())
                            {
                                var modeloAbout = new ModeloAboutHamburger
                                {
                                    id = objData.GetInt64(0),
                                    name = objData.GetString(1)
                                };
                                listModeloAbout.Add(modeloAbout);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los datos de AboutHamburger por ID: " + ex.Message);
            }
            return listModeloAbout;
        }
        
        
        public List<ModeloAboutHamburger> GetAboutHamburger()
        {
            var listaModeloAbout = new List<ModeloAboutHamburger>();

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    string @Get =
                        "SELECT id, name FROM AboutHamburger ";

                    using (SqlCommand objSqlCommand = new SqlCommand(Get, db))
                    using (SqlDataReader objData = objSqlCommand.ExecuteReader())
                    {
                        while (objData.Read())
                        {
                            var Modelo = new ModeloAboutHamburger
                            {
                                id = objData.GetInt64(0),
                                name = objData.GetString(1)
                            };
                            listaModeloAbout.Add(Modelo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los datos de AboutHamburger: " + ex.Message);
            }
            return listaModeloAbout;
        }
    }
}
