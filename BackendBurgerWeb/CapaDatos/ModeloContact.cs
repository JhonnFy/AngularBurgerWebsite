using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ModeloContact
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

        public ModeloContact()
        {
            id = 0;
            name = string.Empty;
            address = string.Empty;
            phone = string.Empty;
        }

    }
}
