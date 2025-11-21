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
    public class Test_GetMenuHamburger
    {
        [TestMethod]
        public void TestGetMenuHamburger()
        {
            CRUDmenuHamburger TestCRUDmenuHamburger = new CRUDmenuHamburger();
            var MetodGetMenu = TestCRUDmenuHamburger.GetMenuHamburger();

            try
            {
                if (MetodGetMenu == null)
                {
                    Debug.WriteLine("[****].[ERROR].[TestGetMenuHamburger Vacio]");
                    Assert.Fail("[****].[ERROR].[TestGetMenuHamburger Vacio]");
                }else if (MetodGetMenu.Count > 0)
                {
                    foreach(var ModelGetMenu in MetodGetMenu)
                    {
                        Debug.WriteLine($@"
                                [Debug Desde Test].[TestGetMenuHamburger] 
                                Id: {ModelGetMenu.id},
                                Name: {ModelGetMenu.name}
                            ");

                        Console.WriteLine($@"
                                [Console Desde Test].[TestGetMenuHamburger]
                                Id: {ModelGetMenu.id},
                                Name: {ModelGetMenu.name}
                            ");

                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[TestGetMenuHamburger Vacio]");
                Assert.Fail("[****].[ERROR].[TestGetMenuHamburger Vacio]");
            }

        }
    }
}
