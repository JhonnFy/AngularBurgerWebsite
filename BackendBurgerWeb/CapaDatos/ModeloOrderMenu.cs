using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ModeloOrderMenu
    {
        public long id { get; set; }
        public long client_cc { get; set; }
        public long hamburger_id { get; set; }
        public int quantity { get; set; }
        public decimal total_price { get; set; }
        public string status { get; set; }
        public long store_id { get; set; }
        public DateTime created_at { get; set; }

        public ModeloOrderMenu()
        {
            id = 0;
            client_cc = 0;
            hamburger_id = 0;
            quantity = 0;
            total_price = 0;
            status = string.Empty;
            store_id = 0;
            created_at = DateTime.Now;
        }
    }
}
