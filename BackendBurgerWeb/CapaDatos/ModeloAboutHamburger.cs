using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ModeloAboutHamburger
    {
        public int id { get; set; }
        public string name { get; set; }

        public ModeloAboutHamburger()
        {
            id = 0;
            name = string.Empty;
        }
    }
}
