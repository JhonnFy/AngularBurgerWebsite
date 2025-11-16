using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ModeloMenuHamburger
    {
        public long id { get; set; }
        public string name { get; set; }

        public ModeloMenuHamburger()
        {
            id = 0;
            name = string.Empty;
        }

    }
}
