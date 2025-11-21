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
    public class Test_GetMenuHamburgerId
    {
        [TestMethod]
        public void TestGetMenuHamburgerId()
        {
            CRUDmenuHamburger objCrudMenu = new CRUDmenuHamburger();
            var MetodMenu = objCrudMenu.GetMenuHamburgerId(5);

            try
            {
                if (MetodMenu != null && MetodMenu.Count > 0)
                {
                    foreach (var Modelo in MetodMenu)
                    {
                        Debug.WriteLine($@"
                                [Debug Desde Test]
                                Id: {Modelo.id},
                                Name: {Modelo.name}
                            ");
                        Console.WriteLine($@"
                                [Console Desde Test]
                                Id: {Modelo.id},
                                Name: {Modelo.name}
                            ");
                    }
                }else
                {
                    Debug.WriteLine("[****].[Error].[TestGetMenuHamburgerId]");
                    Assert.Fail("[****].[Error].[TestGetMenuHamburgerId]");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("[****].[Error].[TestGetMenuHamburgerId]");
                Assert.Fail("[****].[Error].[TestGetMenuHamburgerId]");
            }
        }
    }
}
