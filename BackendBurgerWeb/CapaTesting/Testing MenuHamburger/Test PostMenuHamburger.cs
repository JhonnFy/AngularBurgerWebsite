using CapaDatos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_MenuHamburger
{
    [TestClass]
    public class Test_PostMenuHamburger
    {
        [TestMethod]
        public void TestPostMenuHamburger()
        {
            try
            {
                CRUDmenuHamburger TestCrudMenu = new CRUDmenuHamburger();
                var MetodGetId = TestCrudMenu.GetMenuHamburgerId(10);

                if (MetodGetId != null && MetodGetId.Count == 0)
                {
                    var ModeloMenu = new ModeloMenuHamburger
                    {
                        id = 10,
                        name = "BancoDePruebas 10"
                    };

                    Debug.WriteLine($@"
                            [Debug Desde Test]
                            Id: {ModeloMenu.id},
                            Name: {ModeloMenu.name}
                        ");

                    Console.WriteLine($@"
                            [Console Desde Test]
                            Id: {ModeloMenu.id},
                            Name: {ModeloMenu.name}
                        ");
                    Assert.IsTrue(TestCrudMenu.PostMenuHamburger(ModeloMenu));
                }else
                {
                    Debug.WriteLine($"[****].[Error].[El Id Ya Se Encuentra Registrado]");
                    Console.WriteLine("[****].[Error].[El Id Ya Se Encuentra Registrado]");
                    Assert.Fail("[****].[Error].[El Id Ya Se Encuentra Registrado]");
                    throw new Exception("[****].[Error].[El Id Ya Se Encuentra Registrado]");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"[****].[Error].[El Id Ya Se Encuentra Registrado]");
                Console.WriteLine("[****].[Error].[El Id Ya Se Encuentra Registrado]");
                Assert.Fail("[****].[Error].[El Id Ya Se Encuentra Registrado]");
                throw new Exception("[****].[Error].[El Id Ya Se Encuentra Registrado]");
            }
        }
    }
}
