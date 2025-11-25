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
    public class Test_DeleteClients
    {
        [TestMethod]
        public void TestDeleteClients()
        {
            CRUDclients TestCRUDclients = new CRUDclients();
            var TestMethod = TestCRUDclients.GetClientsId(3);

            try
            {
                if (TestMethod !=null && TestMethod.Count>0)
                {
                    TestCRUDclients.DeleteClients(3);

                    Debug.WriteLine($@"
                            [Registro {TestMethod[0].cc} Eliminado Correctamente]
                        ");

                    Console.WriteLine($@"
                            [Registro {TestMethod[0].cc} Eliminado Correctamente]
                        ");
                }
                else
                {
                    Debug.WriteLine($"[****].[Error].[TestDeleteClients].[{TestMethod[0].cc}]");
                    Console.WriteLine($"[****].[Error].[TestDeleteClients].[{TestMethod[0].cc}]");
                    Assert.Fail($"[****].[Error].[TestDeleteClients].[{TestMethod[0].cc}]");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"[****].[Exception].[TestDeleteClients].[{TestMethod[0].cc}]");
                Console.WriteLine($"[****].[Exception].[TestDeleteClients].[{TestMethod[0].cc}]");
                Assert.Fail($"[****].[Exception].[TestDeleteClients].[{TestMethod[0].cc}]");
            }
        }
    }
}
