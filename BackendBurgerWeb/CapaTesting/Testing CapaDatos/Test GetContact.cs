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
    public class Test_ReadContact
    {
        [TestMethod]
        public void TestingGetContacts()
        {
            try
            {
                CRUDcontact objGetContacts = new CRUDcontact();
                var contacts = objGetContacts.GetContacts();


                if (contacts == null)
                {
                    Assert.Fail("[****].[Error].[El Metodo GetContacts, Fallo]");
                    Debug.WriteLine("[****].[Error].[El Metodo GetContacts, Fallo]");
                }
                else
                {
                    Debug.WriteLine($"[****].[TestOK].[Total Registros] {contacts.Count}");
                    Console.WriteLine($"[****].[TestOK].[Total Registros] {contacts.Count}");

                    int i = 0;
                    while (i < contacts.Count)
                    {
                        Debug.WriteLine("[****].[TestingGetContacts].[OK] " + contacts[i].name);
                        Console.WriteLine("[****].[TestingGetContacts].[OK] " + contacts[i].name);
                        i++;
                    }
                }
            } 

            
            catch(Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[TestReadContact].[TestingGetContacts]" + ex.Message);
                throw new Exception("[****].[ERROR].[TestReadContact].[TestingGetContacts]" + ex.Message);

            }

        }
    }
}
