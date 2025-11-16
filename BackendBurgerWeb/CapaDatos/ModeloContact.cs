using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ModeloContact
    {
        public long id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public long phone { get; set; }

        public ModeloContact()
        {
            id = 0;
            name = string.Empty;
            address = string.Empty;
            phone = 0;
        }

    }
}
