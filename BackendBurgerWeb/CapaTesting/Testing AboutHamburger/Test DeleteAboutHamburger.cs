using CapaDatos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_AboutHamburger
{
    [TestClass]
    public class Test_DeleteAboutHamburger
    {
        [TestMethod]
        public void TestDeleteAboutHamburger()
        {
            CRUDaboutHamburger TestCrud = new CRUDaboutHamburger();
            var TestMethod = TestCrud.GetAboutHamburgerId(6);

            try
            {
                if (TestMethod != null && TestMethod.Count >0)
                {
                    var Modelo = new ModeloAboutHamburger
                    {
                        id = 6
                    };
                    TestCrud.DeleteAboutHamburger(Modelo);

                    Debug.WriteLine($@"
                            [Debug Desde Tests]
                            [Id Eliminado: {TestMethod[0].id}]
                        ");

                    Console.WriteLine($@"
                            [Console Desde Tests]
                            [Id Eliminado: {TestMethod[0].id}]
                        ");
                }
                else
                {
                    Debug.WriteLine($"[****].[El Id: {TestMethod[0].id}].[No Se Encuentra Registrado]");
                    Console.WriteLine($"[****].[El Id: {TestMethod[0].id}].[No Se Encuentra Registrado]");
                    Assert.Fail($"[****].[El Id: {TestMethod[0].id}].[No Se Encuentra Registrado]");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"[****].[El Id: {TestMethod[0].id}].[No Se Encuentra Registrado]");
                Console.WriteLine($"[****].[El Id: {TestMethod[0].id}].[No Se Encuentra Registrado]");
                Assert.Fail($"[****].[El Id: {TestMethod[0].id}].[No Se Encuentra Registrado]");
            }
        }
    }
}
