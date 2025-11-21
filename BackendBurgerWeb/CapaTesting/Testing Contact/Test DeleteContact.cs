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
    public class Test_DeleteContact
    {
        [TestMethod]
        public void TestDeleteContact()
        {
            CRUDcontact TestCRUDcontact = new CRUDcontact();
            var deleteContact = TestCRUDcontact.GetContactId(1);

            try
            {
                if (deleteContact == null || deleteContact.Count == 0 )
                {
                    Debug.WriteLine($"[****].[ERROR].[El Id Seleccionado No Existe En La dB]");
                    Console.WriteLine("[****].[ERROR].[El Id Seleccionado No Existe En La dB]");
                    Assert.Fail("[****].[ERROR].[El Id Seleccionado No Existe En La dB]");
                }
                else
                {
                    ModeloContact deleteModeloContact = new ModeloContact
                    {
                        id = 1
                    };
                    TestCRUDcontact.DeleteContact((int)deleteModeloContact.id);
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
