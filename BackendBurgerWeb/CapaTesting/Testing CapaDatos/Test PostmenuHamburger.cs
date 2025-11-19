using CapaDatos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_CapaDatos
{
    [TestClass]
    public class Test_PostmenuHamburger
    {

        [TestMethod]
        public void TestPostmenuHamburger()
        {
            ModeloMenuHamburger newMenu = new ModeloMenuHamburger
            { 
                id = 6, 
                name = "Tes Menu 6" 
            };
            CRUDmenuHamburger metodContact = new CRUDmenuHamburger();

            bool runSql = metodContact.PostmenuHamburger(newMenu);
            var menu = metodContact.GetMenuHamburgerId((int)newMenu.id);
            if (runSql &&  menu != null && menu.Any())
            {
                Debug.WriteLine("[****].[OK].[Capa Testing].[La Creación Del Menu Fue Exitosa.]");
                Debug.WriteLine($"Id: {menu.First().id}");
                Debug.WriteLine($"Name: {menu.First().name}");
                Console.WriteLine("[****].[OK].[Capa Testing].[La Creación Del Menu Fue Exitosa.]");
                Console.WriteLine($"Id: {menu.First().id}");
                Console.WriteLine($"Name: {menu.First().name}");
                Assert.IsTrue(runSql, "[****].[OK].[Capa Testing].[La Creación Del Registro Fue Exitosa.]");
            }
            else
            {
                Debug.WriteLine("[****].[INFO].[CapaDatos].[TestPostmenuHamburger].[PostMenu].[Menu NO Registrado]");
                Console.WriteLine("[****].[INFO].[CapaDatos].[TestPostmenuHamburger].[PostMenu].[Menu NO Registrado]");
                Assert.Fail("[****].[ERROR].[Capa Testing].[La Creación Del Registro NO Fue Exitosa.]");
            }
        }
    }
}