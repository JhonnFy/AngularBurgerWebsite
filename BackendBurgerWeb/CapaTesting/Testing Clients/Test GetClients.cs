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
    public class Test_GetClients
    {
        [TestMethod]
        public void TestGetClients()
        {
            CRUDclients classCRUDclients = new CRUDclients();
            var MethodClients = classCRUDclients.GetClients();

            try
            {
                foreach (var run in MethodClients)
                {
                    Debug.WriteLine($@"
                            [Debug Desde TestGetClients]
                            Cc: {run.cc},
                            Name: {run.name},
                            Address: {run.address},
                            Phone1: {run.phone1},
                            Phone2: {run.phone2},
                            Reference {run.reference},
                            Payment_method {run.payment_method}
                        ");

                    Console.WriteLine($@"
                            [Console Desde TestGetClients]
                            Cc: {run.cc},
                            Name: {run.name},
                            Address: {run.address},
                            Phone1: {run.phone1},
                            Phone2: {run.phone2},
                            Reference {run.reference},
                            Payment_method {run.payment_method}
                        ");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("[****].[Error].[TestGetClients]");
                Console.WriteLine("[****].[Error].[TestGetClients]");
                Assert.Fail("[****].[Error].[TestGetClients]");
            }
        }
    }
}
