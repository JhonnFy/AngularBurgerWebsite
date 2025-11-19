using CapaDatos;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CapaTesting.Testing_CapaDatos
{

    [TestClass]
    public class Test_PostContac
    {
        private Conexion conexion = new Conexion();

        [TestMethod]
        public void TestPostContact()
        {
            try
            {
                ModeloContact newContact = new ModeloContact
                {
                    id = 5,
                    name = "Test contac 5",
                    address = "Direccion 5",
                    phone = 1111111111
                };

                CRUDcontact metodContact = new CRUDcontact();
                bool runSql = metodContact.PostContac(newContact);


                var contact = metodContact.GetContactsId((int)newContact.id);
                if (runSql &&  contact != null  && contact.Any())
                {
                    Debug.WriteLine("[****].[OK].[Capa Testing].[La Creación Del Registro Fue Exitosa.]");
                    Debug.WriteLine($"Id: {contact.First().id}");
                    Debug.WriteLine($"Name: {contact.First().name}");
                    Debug.WriteLine($"Address: {contact.First().address}");
                    Debug.WriteLine($"Phone: {contact.First().phone}");
                    
                    Console.WriteLine("[****].[OK].[Capa Testing].[La Creación Del Registro Fue Exitosa.]");
                    Console.WriteLine($"Id: {contact.First().id}");
                    Console.WriteLine($"Name: {contact.First().name}");
                    Console.WriteLine($"Address: {contact.First().address}");
                    Console.WriteLine($"Phone: {contact.First().phone}");
                    Assert.IsTrue(runSql, "[****].[OK].[Capa Testing].[La Creación Del Registro Fue Exitosa.]");
                }
                else
                {
                    Debug.WriteLine("[****].[INFO].[CapaDatos].[Test POSTContact].[PostContac].[Contac NO Registrado]");
                    Console.WriteLine("[****].[INFO].[CapaDatos].[Test POSTContact].[PostContac].[Contac NO Registrado]");
                    Assert.Fail("[****].[INFO].[CapaDatos].[Test POSTContact].[PostContac].[Contac NO Registrado]");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[INFO].[CapaDatos].[Test POSTContact].[PostContac].[Contac NO Registrado]" + ex.Message);
                Console.WriteLine("[****].[INFO].[CapaDatos].[Test POSTContact].[PostContac].[Contac NO Registrado]" + ex.Message);
                throw new Exception($"[****].[INFO].[CapaDatos].[Test POSTContact].[PostContac].[Contac NO Registrado] " + ex.Message);
            }
        }
    }
}
