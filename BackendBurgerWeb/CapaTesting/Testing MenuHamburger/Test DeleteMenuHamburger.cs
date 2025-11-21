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
    public class Test_DeleteMenuHamburger
    {
        [TestMethod]
        public void TestDeleteMenuHamburger()
        {

            CRUDmenuHamburger objCrudMenu = new CRUDmenuHamburger();
            var MetodMenu = objCrudMenu.GetMenuHamburgerId(6);

            try
            {
                if (MetodMenu != null && MetodMenu.Count>0)
                {
                    foreach (var lista in MetodMenu)
                    {
                        lista.id = 6;
                        objCrudMenu.DeleteMenuHamburger(lista);

                        Debug.WriteLine($@"
                                [Debug Desde Test]
                                Id Eliminado: {lista.id}
                            ");

                        Console.WriteLine($@"
                                [Debug Desde Test]
                                Id Eliminado: {lista.id}
                            ");
                    }
                }
                else
                {
                    Debug.WriteLine("[****].[Registro No Eliminado]");
                    Assert.Fail("[****].[Registro No Eliminado]");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("[****].[Registro No Eliminado]");
                Assert.Fail("[****].[Registro No Eliminado]");
            }

        }

    }
}
