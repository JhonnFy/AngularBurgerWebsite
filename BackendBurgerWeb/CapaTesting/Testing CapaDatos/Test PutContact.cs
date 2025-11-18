using CapaDatos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_CapaDatos
{
    [TestClass]
    public class Test_PutContact
    {
        [TestMethod]
        public void TestPutContact()
        {
            try
            {
                ModeloContact objModeloContac = new ModeloContact(
                    name: "Actualizado Desde Test", 
                    address: "Dir Test", 
                    phone: 2222222222
                );
                objModeloContac.id = 4;

                CRUDcontact runUpdate = new CRUDcontact();
                bool resultado = runUpdate.PutContact(objModeloContac);

                var contac = runUpdate.GetContactsId((int)objModeloContac.id);
                if (contac != null && contac.Any())
                {
                    Debug.WriteLine("[****].[OK].[Capa Testing].[La Actualización Del Registro Fue Exitosa.]");
                    Debug.WriteLine($"Id {contac.First().id }");
                    Debug.WriteLine($"Name {contac.First().name}");
                    Debug.WriteLine($"Address {contac.First().address}");
                    Debug.WriteLine($"Phone {contac.First().phone}");

                    Console.WriteLine("[****].[OK].[Capa Testing].[La Actualización Del Registro Fue Exitosa.]");
                    Console.WriteLine($"Id {contac.First().id}");
                    Console.WriteLine($"Name {contac.First().name}");
                    Console.WriteLine($"Address {contac.First().address}");
                    Console.WriteLine($"Phone {contac.First().phone}");

                    Assert.IsTrue(resultado, "[****].[OK].[Capa Testing].[La Actualización Del Registro Fue Exitosa.]");
                }
                else
                {
                    Debug.WriteLine("[****].[INFO].[CapaDatos].[Test PUTContact].[PUTContact].[Contac NO Actualizado]");
                    Console.WriteLine("[****].[INFO].[CapaDatos].[Test PUTContact].[PUTContact].[Contac NO Actualizado]");
                    Assert.Fail("[****].[INFO].[CapaDatos].[Test PUTContact].[PUTContact].[Contac NO Actualizado]");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[INFO].[CapaDatos].[Test PutContact].[PutContac].[Contac NO Registrado]" + ex.Message);
                Console.WriteLine("[****].[INFO].[CapaDatos].[Test PutContact].[PutContac].[Contac NO Registrado]" + ex.Message);
                throw new Exception($"[****].[INFO].[CapaDatos].[Test PutContact].[PutContac].[Contac NO Registrado] " + ex.Message);
            }
        }
    }
}

