using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CRUDaboutHamburger
    {
        Conexion conexion = new Conexion();

        public ModeloAboutHamburger GetAboutHamburgersId(long id)
        {
            ModeloAboutHamburger model = null;

            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();

                    using (var cmd = new SqlCommand("GetAboutHamburgerId", db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;

                        using (var reader = cmd.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                model = new ModeloAboutHamburger()
                                {
                                    id = reader.GetInt64(reader.GetOrdinal("id")),
                                    name = reader.IsDBNull(reader.GetOrdinal("name")) ? "" : reader.GetString(reader.GetOrdinal("name"))
                                };
                            }
                        }

                    }
                }
            }catch(Exception ex)
            {
                throw new Exception("[****].[Error].[GetAboutHamburgersId]" + ex.Message);
            }
            return model;
        }


        public List<ModeloAboutHamburger> GetAboutHamburgers()
        {
            var list = new List<ModeloAboutHamburger>();
            
            try
            {
                using (var db = conexion.ObtenerCadenaDeConexion())
                {
                    db.Open();
                    using (var cmd = new SqlCommand("GetAboutHamburger", db))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new ModeloAboutHamburger
                                {
                                    id = reader.GetInt64(reader.GetOrdinal("id")),
                                    name = reader.IsDBNull(reader.GetOrdinal("name")) ? "" : reader.GetString(reader.GetOrdinal("name"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[****].[Error].[GetAboutHamburgers]" + ex.Message);
            }
            return list;
        }
    }
}
