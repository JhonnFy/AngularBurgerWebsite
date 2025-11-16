using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ModeloClients
    {
        public long  cc { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public long phone1 { get; set; }
        public long phone2 { get; set; }
        public string reference { get; set; }
        public string payment_method { get; set; }

        public ModeloClients()
        {
            cc = 0;
            name = string.Empty;
            address = string.Empty;
            phone1 = 0;
            phone2 = 0;
            reference = string.Empty;
            payment_method = string.Empty;
        }

    }
}
