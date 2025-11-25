using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaTesting.Testing_Clients
{
    [TestClass]
    public class Test_GetClientsId
    {
        [TestMethod]
        public void TestGetClientsId()
        {
            CRUDclients classClients = new CRUDclients();
            var MethodClients = classClients.GetClientsId(4);

            try
            {
                if (MethodClients != null && MethodClients.Count >0)
                {
                    foreach (var runMethod in MethodClients)
                    {
                        Debug.WriteLine($@"
                                [Test WriteLine]:
                                [Cc:].[{runMethod.cc}]
                                [Name:].[{runMethod.name}]
                                [Address].[{runMethod.address}]
                                [Phone1].[{runMethod.phone1}]
                                [Phone2].[{runMethod.phone2}]
                                [Reference].[{runMethod.reference}]
                                [Payment_method].[{runMethod.payment_method}]
                            ");
                        Console.WriteLine($@"
                                [Test ConsoleWriteLine]
                                [Cc:].[{runMethod.cc}]
                                [Name].[{runMethod.name}]
                                [Address].[{runMethod.address}]
                                [Phone1].[{runMethod.phone1}]
                                [Phone2].[{runMethod.phone2}]
                                [Reference].[{runMethod.reference}]
                                [Payment_method].[{runMethod.payment_method}]
                            ");
                    }
                }
                else
                {
                    Debug.WriteLine("[****].[Error].[GetClientsId]");
                    Console.WriteLine("[****].[Error].[GetClientsId]");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("[****].[Error].[GetClientsId] " + ex.Message);
                Console.WriteLine("[****].[Error].[GetClientsId] " + ex.Message);
            }
        }
    }
}
