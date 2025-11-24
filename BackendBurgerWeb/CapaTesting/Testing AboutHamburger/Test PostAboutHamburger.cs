using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Diagnostics;

namespace CapaTesting.Testing_PostAboutHamburger
{
    [TestClass]
    public class Test_PostAboutHamburger
    {
        [TestMethod]
        public void TestPostAboutHamburger()
        {
            CRUDaboutHamburger TestCrudAbout = new CRUDaboutHamburger();
            var GetIdMethod = TestCrudAbout.GetAboutHamburgerId(5);

            try
            {
                if (GetIdMethod != null && GetIdMethod.Count > 0)
                {
                    Debug.WriteLine($"[****].[Error].[El Id: [{GetIdMethod[0].id}].[Se Encuentra Registrado]");
                    Console.WriteLine($"[****].[Error].[El Id: [{GetIdMethod[0].id}].[Se Encuentra Registrado]");
                    Assert.Fail($"[****].[Error].[El Id: [{GetIdMethod[0].id}].[Se Encuentra Registrado]");
                }
                else
                {
                    var Modelo = new ModeloAboutHamburger
                    {
                        id = 5,
                        name = "Test5"
                    };
                    TestCrudAbout.PostAboutHamburger(Modelo);

                    Debug.WriteLine($@"
                           [Debug Desde Test:]
                           Id: {Modelo.id},
                           Name: {Modelo.name}
                        ");

                    Console.WriteLine($@"
                           [Console Desde Test:]
                           Id: {Modelo.id},
                           Name: {Modelo.name}
                        ");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[****].[Exception].[El Id: [{GetIdMethod[0].id}].[Se Encuentra Registrado]");
                Console.WriteLine($"[****].[Exception].[El Id: [{GetIdMethod[0].id}].[Se Encuentra Registrado]");
                Assert.Fail($"[****].[Exception].[El Id: [{GetIdMethod[0].id}].[Se Encuentra Registrado]");
            }
        }
    }
}
