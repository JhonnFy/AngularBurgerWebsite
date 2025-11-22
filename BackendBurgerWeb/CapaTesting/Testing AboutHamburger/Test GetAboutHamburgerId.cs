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
    public class Test_GetAboutHamburgerId
    {
        [TestMethod]
        public void TestGetAboutHamburgerId()
        {
            CRUDaboutHamburger objCrud = new CRUDaboutHamburger();
            var MetodAbout = objCrud.GetAboutHamburgerId(100);

            try
            {
                foreach (var metodAbout in MetodAbout)
                {
                    Debug.WriteLine($@"
                            [Debug Test]
                            Id: {metodAbout.id},
                            Name: {metodAbout.name}
                        ");

                    Console.WriteLine($@"
                            [Console Test]
                            Id: {metodAbout.id},
                            Name: {metodAbout.name}
                        ");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("[****].[Error].[TestGetAboutHamburgerId]" + ex.Message);
                Assert.Fail("[****].[Error].[TestGetAboutHamburgerId]" + ex.Message);
            }
        }
    }
}
