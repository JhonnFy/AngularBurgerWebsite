using CapaDatos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_Clients
{
    [TestClass]
    public class Test_PostClients
    {
        [TestMethod]
        public void TestPostClients()
        {
            CRUDclients TestCRUDclients = new CRUDclients();
            var Method = TestCRUDclients.GetClientsId(7);
            try
            {
                if (Method != null && Method.Count > 0)
                {
                    Debug.WriteLine("[****].[ERROR].[El ID: " + Method.First().cc + "] Se Encuentra Registrado En La DB");
                    Console.WriteLine("[****].[ERROR].[El ID: " + Method.First().cc + "] Se Encuentra Registrado En La DB");
                    Assert.Fail("[****].[ERROR].[El ID: " + Method.First().cc + "] Se Encuentra Registrado En La DB");
                }
                else
                {
                    var Modelo = new ModeloClients()
                    {
                        cc = 7,
                        name = "Test Name 7",
                        address = "Test Address 7",
                        phone1 = 1111111111,
                        phone2 = 2222222222,
                        reference = "Test Reference 7",
                        payment_method = "Test payment_method 7"
                    };

                    Debug.WriteLine($@"
                            [Cliente Regsitrado Exitosamente],
                            [Cc:].[{Modelo.cc}]
                            [Name:].[{Modelo.name}]
                            [Address].[{Modelo.address}]
                            [Phone1].[{Modelo.phone2}]
                            [Phone2].[{Modelo.phone2}]
                            [Reference].[{Modelo.reference}]
                            [payment_method].[{Modelo.payment_method}]
                            [Test Console.WriteLine]
                    ");
                    Console.WriteLine($@"
                            [Cliente Regsitrado Exitosamente],
                            [Cc:].[{Modelo.cc}]
                            [Name:].[{Modelo.name}]
                            [Address].[{Modelo.address}]
                            [Phone1].[{Modelo.phone2}]
                            [Phone2].[{Modelo.phone2}]
                            [Reference].[{Modelo.reference}]
                            [payment_method].[{Modelo.payment_method}]
                            [Test Console.WriteLine]
                    ");
                    Assert.IsTrue(TestCRUDclients.PostClients(Modelo));
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("[****].[Exception].[El ID: " + Method.First().cc + "] Se Encuentra Registrado En La DB");
                Console.WriteLine("[****].[Exception].[El ID: " + Method.First().cc + "] Se Encuentra Registrado En La DB");
                Assert.Fail("[****].[Exception].[El ID: " + Method.First().cc + "] Se Encuentra Registrado En La DB");
            }
        }
    }
}
