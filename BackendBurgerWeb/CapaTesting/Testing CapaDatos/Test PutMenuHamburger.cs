using CapaDatos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_CapaDatos
{
    [TestClass]
    public class Test_PutMenuHamburger
    {
        [TestMethod]
        public void TestPutMenuHamburger()
        {
            try
            {
                ModeloMenuHamburger newMenu = new ModeloMenuHamburger();
                newMenu.id = 100;
                CRUDmenuHamburger metodMenu = new CRUDmenuHamburger();
                var menu = metodMenu.GetMenuHamburgerId((int)newMenu.id);

                if (menu !=null && menu.Any())
                {
                    newMenu.name = "Put DesdeElTest 100";
                    newMenu.id = 4;
                    
                    bool resultado = metodMenu.PutmenuHamburger(newMenu);

                    Debug.WriteLine("[****].[OK].[Capa Testing].[La Actualización Del Registro Fue Exitosa.]");
                    Debug.WriteLine($"Id: {menu.First().id}");
                    Debug.WriteLine($"Name: {menu.First().name}");

                    Console.WriteLine("[****].[OK].[Capa Testing].[La Actualización Del Registro Fue Exitosa.]");
                    Console.WriteLine($"Id: {menu.First().id}");
                    Console.WriteLine($"Name: {menu.First().name}");


                    Assert.IsTrue(resultado, "[****].[OK].[Capa Testing].[La Actualización Del Registro Fue Exitosa.]");
                }
                else
                {
                    Debug.WriteLine("[****].[INFO].[CapaDatos].[Test PostMenuHamburger].[PostMenuHamburger].[Contac NO Actualizado]");
                    Console.WriteLine("[****].[INFO].[CapaDatos].[Test PostMenuHamburger].[PostMenuHamburger].[Contac NO Actualizado]");
                    Assert.Fail("[****].[INFO].[CapaDatos].[Test PostMenuHamburger].[PostMenuHamburger].[Contac NO Actualizado]");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("[****].[INFO].[CapaDatos].[Test PostMenuHamburger].[PostMenuHamburger].[Contac NO Actualizado]");
                Console.WriteLine("[****].[INFO].[CapaDatos].[Test PostMenuHamburger].[PostMenuHamburger].[Contac NO Actualizado]");
                Assert.Fail("[****].[INFO].[CapaDatos].[Test PostMenuHamburger].[PostMenuHamburger].[Contac NO Actualizado]");
            }
        }

    }
}
