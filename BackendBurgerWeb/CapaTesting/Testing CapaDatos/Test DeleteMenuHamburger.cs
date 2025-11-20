using CapaDatos;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_CapaDatos
{
    [TestClass]
    public class Test_DeleteMenuHamburger
    {
        [TestMethod]
        public void TestDeleteMenuHamburger()
        {
            try
            {
                int DeleteId = 6;
                CRUDmenuHamburger objCrudMenu = new CRUDmenuHamburger();
                var menu = objCrudMenu.GetMenuHamburgerId(DeleteId);


                if (menu !=null && menu.Any())
                {
                    ModeloMenuHamburger DeleteMenuId = new ModeloMenuHamburger
                    {
                        id = DeleteId
                    };

                    bool resultado = objCrudMenu.DeleteMenuHamburger(DeleteMenuId);

                    Console.WriteLine("[Delete MenuHamburger] El registro Fue Eliminado Correctamente.");
                    Debug.WriteLine("[Delete MenuHamburger] El registro Fue Eliminado Correctamente.");
                    Assert.IsTrue(resultado, "[Delete MenuHamburger] El registro Fue Eliminado Correctamente.");

                }
                else
                {
                    Console.WriteLine("[Delete MenuHamburger] El registro NO Fue Eliminado.");
                    Debug.WriteLine("[Delete MenuHamburger] El registro NO Fue Eliminado.");
                    Assert.Fail("[Delete MenuHamburger] El registro NO Fue Eliminado.");
                }
            }
            catch(Exception ex)
            {
                Assert.Fail($"[Delete contact] La prueba falló con una excepción: {ex.Message}");
                Console.WriteLine("[Delete MenuHamburger] El registro NO Fue Eliminado.");
                Debug.WriteLine("[Delete MenuHamburger] El registro NO Fue Eliminado.");
            }


            //try
            //{
            //    ModeloMenuHamburger DeleteMenu = new ModeloMenuHamburger
            //    {
            //        id = 5
            //    };

            //    CRUDmenuHamburger objCrudMenu = new CRUDmenuHamburger();
            //    bool resultado = objCrudMenu.DeleteMenuHamburger(DeleteMenu);

            //    Console.WriteLine("[Delete MenuHamburger] El registro Fue Eliminado Correctamente.");
            //    Debug.WriteLine("[Delete MenuHamburger] El registro Fue Eliminado Correctamente.");
            //    Assert.IsTrue(resultado, "[Delete MenuHamburger] El registro Fue Eliminado Correctamente.");
            //    }
            //      catch(Exception ex)
            //    {
            //      Assert.Fail($"[Delete contact] La prueba falló con una excepción: {ex.Message}");
            //    }
        }
    }
}


