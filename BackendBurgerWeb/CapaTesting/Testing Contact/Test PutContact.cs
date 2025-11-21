using CapaDatos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_Contact
{
    [TestClass]
    public class Test_PutContact
    {
        [TestMethod]
        public void TestPutContact()
        {
            CRUDcontact TestCRUDcontact = new CRUDcontact();
            var putNewContact = TestCRUDcontact.GetContactId(1);
            
            try
            {
                if (putNewContact == null || putNewContact.Count == 0 )
                {
                    Debug.WriteLine("[****].[ERROR].[El Id Seleccionado No Existe En La dB]");
                    Console.WriteLine("[****].[ERROR].[El Id Seleccionado No Existe En La dB]");
                    Assert.Fail("[****].[ERROR].[El Id Seleccionado No Existe En La dB]");
                }
                else
                {
                    ModeloContact putModeloContact = new ModeloContact
                    {
                        id = 1,
                        name = "TEST Name Modificado",
                        address = "TEST Address Moficado",
                        phone = 1111111111
                    };
                    TestCRUDcontact.PutContact(putModeloContact);

                    Debug.WriteLine("[****].[SUCCESS].[Contacto Modificado Exitosamente]");
                    Debug.WriteLine($"Id:  {putModeloContact.id}");
                    Debug.WriteLine($"Name: {putModeloContact.name}");
                    Debug.WriteLine($"Address: {putModeloContact.address}");
                    Debug.WriteLine($"Phone: {putModeloContact.phone}");
                    Assert.IsTrue(true, "[****].[SUCCESS].[Contacto Modificado Exitosamente]");

                    Console.WriteLine("[****].[SUCCESS].[Contacto Modificado Exitosamente]");
                    Console.WriteLine($"Id:  {putModeloContact.id}");
                    Console.WriteLine($"Name: {putModeloContact.name}");
                    Console.WriteLine($"Address: {putModeloContact.address}");
                    Console.WriteLine($"Phone: {putModeloContact.phone}");
                    Assert.IsTrue(true, "[****].[SUCCESS].[Contacto Modificado Exitosamente]");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception thrown during test: " + ex.Message);
                Assert.Fail("Exception thrown during test: " + ex.Message);
            }
        }
    }
}
