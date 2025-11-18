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

        public ModeloContact(string name, string address, long phone)
        {
            this.name = name;
            this.address = address;
            this.phone = phone;
        }

        public ModeloContact()
        {
            name = string.Empty;
            address = string.Empty;
            phone = 0;
        }

    }
}
