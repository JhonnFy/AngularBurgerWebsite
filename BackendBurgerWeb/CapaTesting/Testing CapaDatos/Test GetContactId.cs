using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaTesting.Testing_CapaDatos
{
    [TestClass]
    public class GetContactId
    {
        [TestMethod]
        public void TestGetContactId()
        {
            try
            {
                CRUDcontact objGetContactId = new CRUDcontact();
                var contactId = objGetContactId.GetContactsId(2);

                if (contactId == null)
                {
                    Assert.Fail("[****].[Error].[El Metodo GetContactsId, Fallo]");
                    Debug.WriteLine("[****].[Error].[El Metodo GetContactsId, Fallo]");
                }else
                {
                    Debug.WriteLine("Registro Encontrado:");
                    Debug.WriteLine($"Id: {contactId.First().id}");
                    Debug.WriteLine($"Nombre: {contactId.First().name}");
                    Debug.WriteLine($"Address: {contactId.First().address}");
                    Debug.WriteLine($"Phone: {contactId.First().phone}");

                    Console.WriteLine("Registro Encontrado:");
                    Console.WriteLine($"Id: {contactId.First().id}");
                    Console.WriteLine($"Nombre: {contactId.First().name}");
                    Console.WriteLine($"Address: {contactId.First().address}");
                    Console.WriteLine($"Phone: {contactId.First().phone}");

                }
            }catch(Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[TestGetContactsId]" + ex.Message);
                throw new Exception("[****].[ERROR].[TestGetContactsId]" + ex.Message);
            }
        }



    }
}
