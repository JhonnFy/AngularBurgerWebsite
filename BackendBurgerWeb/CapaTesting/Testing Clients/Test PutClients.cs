using CapaDatos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_Clients
{
    [TestClass]
    public class Test_PutClients
    {
        [TestMethod]
        public void TestPutClients()
        {
            CRUDclients TestPutClient = new CRUDclients();
            var Method = TestPutClient.GetClientsId(7);

            try
            {
                if (Method != null && Method.Count > 0)
                {
                    var Modelo = new ModeloClients()
                    {
                        cc = 7,
                        name = "Test Client",
                        address = "Test Address",
                        phone1 = 9999999999,
                        phone2 = 8888888888,
                        reference = "Test Reference",
                        payment_method = "Test Payment Method"
                    };
                    TestPutClient.PutClients(Modelo);

                    Debug.WriteLine($@"
                        [Name:].[{Modelo.name}],
                        [Address].[{Modelo.address}],
                        [Phone1].[{Modelo.phone1}],
                        [Phone2].[{Modelo.phone2}],
                        [Reference].[{Modelo.reference}],
                        [Payment Method].[{Modelo.payment_method}]
                        [Test Debug.WriteLine]
                    ");

                    Console.WriteLine($@"
                        [Name:].[{Modelo.name}],
                        [Address].[{Modelo.address}],
                        [Phone1].[{Modelo.phone1}],
                        [Phone2].[{Modelo.phone2}],
                        [Reference].[{Modelo.reference}],
                        [Payment Method].[{Modelo.payment_method}]
                        [Test Console.WriteLine]
                    ");

                    Assert.IsTrue(true, "[****].[SUCCESS].[Contacto Modificado Exitosamente]");
                }
                else
                {
                    Debug.WriteLine($"[****].[Error].[{Method[0].cc}].[No Regsitrado En La dB]");
                    Console.WriteLine($"[****].[Error].[{Method[0].cc}].[No Regsitrado En La dB]");
                    Assert.Fail($"[****].[Error].[{Method[0].cc}].[No Regsitrado En La dB]");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"[****].[Error].[{Method[0].cc}].[No Regsitrado En La dB]" + ex.Message);
                Assert.Fail($"[****].[Error].[{Method[0].cc}].[No Regsitrado En La dB]" + ex.Message);
            }
        }
    }
}
