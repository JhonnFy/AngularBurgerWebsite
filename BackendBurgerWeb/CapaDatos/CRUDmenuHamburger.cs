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
        public bool DeleteMenuHamburger(ModeloMenuHamburger DeleteMenuHamburger)
        {
            ModeloMenuHamburger model = null;

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();

                    using (var cmd = new SqlCommand("DeleteMenuHamburger", db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", DeleteMenuHamburger.id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >0)
                        {
                            model = DeleteMenuHamburger;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[****].[Error].[PutmenuHamburger]" + ex.Message);
            }
            return model != null;
        }   



        public bool PutMenuHamburger(ModeloMenuHamburger PutMenuHamburger)
        {
            ModeloMenuHamburger model = null;

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();

                    using (var cmd = new SqlCommand("PutMenuHamburger", db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", PutMenuHamburger.id);
                        cmd.Parameters.AddWithValue("@name", PutMenuHamburger.name);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            model = PutMenuHamburger;
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("[****].[Error].[PutmenuHamburger]" + ex.Message);
            }
            return model != null;
        }
        
        public ModeloMenuHamburger PostMenuHamburger(ModeloMenuHamburger PostMenuHamburger)
        {
            ModeloMenuHamburger model = null;
            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (var cmd = new SqlCommand("PostMenuHamburger",db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", PostMenuHamburger.id);
                        cmd.Parameters.AddWithValue("@name", PostMenuHamburger.name);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            model = PostMenuHamburger;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("[****].[Error].[PostMenuHamburger]" + ex.Message);
            }
            return model;
        }

        public ModeloMenuHamburger GetMenuHamburgerId(int id)
        {
            ModeloMenuHamburger model = null;
            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (var cmd = new SqlCommand("GetMenuHamburgerId",db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                model = new ModeloMenuHamburger()
                                {
                                    id = reader.GetInt64(0),
                                    name = reader.IsDBNull(1) ? "" : reader.GetString(1)
                                };
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("[****].[Error].[GetMenuHamburgerId]" + ex.Message);
            }
            return model;
        }

        public List<ModeloMenuHamburger> GetMenuHamburger()
        {
            var list = new List<ModeloMenuHamburger>();

                try
                {
                    using (var db = conexion.ObtenerCadenaDeConexion())
                    {
                        db.Open();
                        using (var cmd = new SqlCommand("GetMenuHamburger", db))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            using (var reader = cmd.ExecuteReader())
                            {
                                while(reader.Read())
                                {
                                    list.Add(new ModeloMenuHamburger
                                    {
                                        id = reader.GetInt64(0),
                                        name = reader.GetString(1)
                                    });
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                throw new Exception("[****].[Error].[GetMenuHamburger]" + ex.Message);
            }
            return list;
        }
    }
}
