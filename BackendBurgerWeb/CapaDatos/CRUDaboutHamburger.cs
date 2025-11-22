using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CRUDaboutHamburger
    {
        Conexion conexion = new Conexion();

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
