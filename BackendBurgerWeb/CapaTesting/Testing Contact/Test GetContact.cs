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
    public class Test_GetContact
    {
        [TestMethod]
        public void TestGetContact()
        {
            try
            {

                CRUDcontact TestCRUDcontact = new CRUDcontact();
                var TestMetod = TestCRUDcontact.GetContact();

                if (TestMetod == null)
                {
                    Debug.WriteLine("[****].[ERROR].[TestGetContact Vacio]");
                    Assert.Fail("[****].[ERROR].[TestGetContact Vacio]");
                }
                else if (TestMetod.Count > 0)
                {
                    foreach (var modeloContact in TestMetod)
                    {
                        Debug.WriteLine($@"
                                    [Debug Desde Test]
                                    Id: {modeloContact.id}
                                    Name: {modeloContact.name}
                                    Address: {modeloContact.address}
                                    Phone: {modeloContact.phone}
                            ");

                        Console.WriteLine($@"
                                    [Debug Desde Test]
                                    Id: {modeloContact.id}
                                    Name: {modeloContact.name}
                                    Address: {modeloContact.address}
                                    Phone: {modeloContact.phone}
                            ");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[TestGetContact Vacio]");
                Assert.Fail("[****].[ERROR].[TestGetContact Vacio]");
            }
        }
    }
}
