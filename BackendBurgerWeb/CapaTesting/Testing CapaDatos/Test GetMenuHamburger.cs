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
    public class Test_GetMenuHamburger
    {
        [TestMethod]
        public void TestGetMenuHamburger()
        {
            try
            {
                CRUDmenuHamburger objGetMenuHamburger = new CRUDmenuHamburger();
                var MenuHamburger = objGetMenuHamburger.GetMenuHamburger();

                if (MenuHamburger == null)
                {
                    Assert.Fail("[****].[Error].[EL Metodo GetMenuHamburger, Fallo]");
                    Debug.WriteLine("[****].[Error].[EL Metodo GetMenuHamburger, Fallo]");
                    Console.WriteLine("[****].[Error].[EL Metodo GetMenuHamburger, Fallo]");
                }else
                {
                    Debug.WriteLine($"[****].[TestOk].[TotalRegistros] {MenuHamburger.Count}");
                    Console.WriteLine($"[****].[TestOk].[TotalRegistros] {MenuHamburger.Count}");

                    int i = 0;
                    while(i < MenuHamburger.Count)
                    {
                        Debug.WriteLine("[****].[TestGetMenuHamburger].[OK] " + MenuHamburger[i].name);
                        Console.WriteLine("[****].[TestGetMenuHamburger].[OK] " + MenuHamburger[i].name);
                        i++;
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[TestGetMenuHamburger] " + ex.Message);
                throw new Exception("[****].[ERROR].[TestGetMenuHamburger] " + ex.Message);
            }
        }
    }
}
