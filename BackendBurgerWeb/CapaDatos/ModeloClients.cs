using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ModeloClients
    {
        public string cc { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string reference { get; set; }
        public string payment_method { get; set; }

        public ModeloClients()
        {
            cc = string.Empty;
            name = string.Empty;
            address = string.Empty;
            phone1 = string.Empty;
            phone2 = string.Empty;
            reference = string.Empty;
            payment_method = string.Empty;
        }

    }
}
