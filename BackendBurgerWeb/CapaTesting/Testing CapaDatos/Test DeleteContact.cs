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
    public class Test_DeleteContact
    {
        [TestMethod]
        public void TestDeleteContact()
        {
            try
            {
                ModeloContact DeleteContact = new ModeloContact
                {
                    id = 4
                };
                   
                CRUDcontact objDelete = new CRUDcontact();
                bool resultado = objDelete.DeleteContact(DeleteContact);

                Assert.IsTrue(resultado, "[Delete contact] El registro fue eliminado correctamente.");
                Console.WriteLine("[Delete contact] El registro fue eliminado correctamente.");
                Debug.WriteLine("[Delete contact] El registro fue eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"[Delete contact] La prueba falló con una excepción: {ex.Message}");
            }
        }
    }
}
