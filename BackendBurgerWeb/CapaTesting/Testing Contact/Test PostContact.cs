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
    public class Test_PostContact
    {
        [TestMethod]
        public void TestPostContact()
        {
            CRUDcontact TestCRUDcontact = new CRUDcontact();
            var TestMetod = TestCRUDcontact.GetContactId(8);

            try
            {
                if (TestMetod != null && TestMetod.Count > 0)
                {
                    Debug.WriteLine("[****].[ERROR].[El ID: " + TestMetod.First().id + "] Se Encuentra Registrado En La DB");
                    Console.WriteLine("[****].[ERROR].[El ID: " + TestMetod.First().id + "] Se Encuentra Registrado En La DB");
                    Assert.Fail("[****].[ERROR].[El ID: " + TestMetod.First().id + "] Se Encuentra Registrado En La DB");
                }
                else
                {
                    var newModelContact = new ModeloContact()
                    {
                        id = 8,
                        name = "Test Name8",
                        address = "Test Address8",
                        phone = 3104552800
                    };

                    Debug.WriteLine("[****].[Debug Desde TestPostContact]");
                    Debug.WriteLine("[****].[Id] " + newModelContact.id);
                    Debug.WriteLine("[****].[Name] " + newModelContact.name);
                    Debug.WriteLine("[****].[Address] " + newModelContact.address);
                    Debug.WriteLine("[****].[Phone] " +newModelContact.phone);

                    Console.WriteLine("[****].[Debug Desde TestPostContact]");
                    Console.WriteLine("[****].[Id] " + newModelContact.id);
                    Console.WriteLine("[****].[Name] " + newModelContact.name);
                    Console.WriteLine("[****].[Address] " + newModelContact.address);
                    Console.WriteLine("[****].[Phone] " + newModelContact.phone);

                    Assert.IsTrue(TestCRUDcontact.PostContact(newModelContact));
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[El ID " + TestMetod.First().id + "] Se Encuentra Registrado En La DB");
                Assert.Fail("[****].[ERROR].[El ID " + TestMetod.First().id + "] Se Encuentra Registrado En La DB");
            }
        }
    }
}
