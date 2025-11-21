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
    public class Test_PutMenuHamburger
    {
        [TestMethod]
        public void TestPutMenuHamburger()
        {
            CRUDmenuHamburger objmenuHamburger = new CRUDmenuHamburger();
            var MetodSelectId = objmenuHamburger.GetMenuHamburgerId(10);

            try
            {
                if (MetodSelectId != null && MetodSelectId.Count > 0)
                {
                    foreach (var Modelo in MetodSelectId)
                    {
                        Modelo.name = "Hamburguesa Actualizada";
                        objmenuHamburger.PutMenuHamburger(Modelo);

                        Debug.WriteLine($"Se actualizo el nombre de la hamburguesa a: {Modelo.name}");
                        Console.WriteLine($"Se actualizo el nombre de la hamburguesa a: {Modelo.name}");

                    }
                }
                else
                {
                    Debug.WriteLine("No se encontraron registros con el ID proporcionado.");
                    Assert.Fail("No se encontraron registros con el ID proporcionado");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("No se encontraron registros con el ID proporcionado.");
                Assert.Fail("No se encontraron registros con el ID proporcionado: " + ex.Message);
            }
        }
    }
}
