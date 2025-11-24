using CapaDatos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_AboutHamburger
{
    [TestClass]
    public class Test_GetAboutHamburger
    {
        [TestMethod]
        public void TestGetAboutHamburger()
        {
            try
            {
                CRUDaboutHamburger objCrud = new  CRUDaboutHamburger();
                var result = objCrud.GetAboutHamburger();

                foreach (var lista in result)
                {
                    Debug.WriteLine($@"
                            [Debug Desde Test]
                            Id: {lista.id},
                            Name: {lista.name}
                        ");

                    Console.WriteLine($@"
                            [Consol Desde Test]
                            Id: {lista.id},
                            Name: {lista.name}
                        ");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[****].[Error.][Test].[GetAboutHamburger]");
                Assert.Fail("[****].[Error.][Test].[GetAboutHamburger]");
            }
        }
    }
}
