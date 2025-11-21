using CapaDatos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting
{
    [TestClass]
    public class Test_GetContactId
    {
        [TestMethod]
        public void TestGetContactId()
        {
            try
            {
                CRUDcontact TestCRUDcontact = new CRUDcontact();
                var TestMetod = TestCRUDcontact.GetContactId(5);

                if (TestMetod == null || TestMetod.Count == 0 )
                {
                    Debug.WriteLine("[****].[ERROR].[TestGetContactId Vacio]");
                    Assert.Fail("[****].[ERROR].[TestGetContactId Vacio]");
                }else if (TestMetod.Count > 0) 
                {
                    foreach(var modeloContactId in TestMetod)
                    {
                        Debug.WriteLine($@"
                                [Debug Desde Test]
                                Id: {modeloContactId.id}       
                                Name: {modeloContactId.name}
                                Address: {modeloContactId.address}
                                Phone: {modeloContactId.phone}
                            ");

                        Console.WriteLine($@"
                                [Console Desde Test]
                                Id: {modeloContactId.id}
                                Name: {modeloContactId.name}
                                Address: {modeloContactId.address}
                                Phone: {modeloContactId.phone}
                            ");
                        Assert.IsTrue(modeloContactId.id > 0);
                    }    
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("[****].[ERROR].[TestGetContactId Vacio]");
                Assert.Fail("[****].[ERROR].[TestGetContactId Vacio]");
            }
        }
    }
}
