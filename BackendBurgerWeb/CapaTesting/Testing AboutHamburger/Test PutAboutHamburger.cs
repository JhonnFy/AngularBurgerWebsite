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
    public class Test_PutAboutHamburger
    {
        [TestMethod]
        public void TestPutAboutHamburger()
        {
            CRUDaboutHamburger TestCrudAbout = new CRUDaboutHamburger();
            var TestMethod = TestCrudAbout.GetAboutHamburgerId(5);

            try
            {
                if (TestMethod != null && TestMethod.Count >0)
                {
                    var Modelo = new ModeloAboutHamburger()
                    {
                        name = "Update Desde Test 5",
                        id = 5
                    };
                    TestCrudAbout.PutAboutHamburger(Modelo);

                    Debug.WriteLine($"[****].[Id: {TestMethod[0].id}].[Actualizado:].[{Modelo.name}]");
                    Console.WriteLine($"[****].[Id: {TestMethod[0].id}].[Actualizado:].[{Modelo.name}]");
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

