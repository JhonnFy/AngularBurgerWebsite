using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ModeloOrderMenu
    {
        public int id { get; set; }
        public string client_cc { get; set; }
        public int hamburger_id { get; set; }
        public int quantity { get; set; }
        public decimal total_price { get; set; }
        public string status { get; set; }
        public int store_id { get; set; }
        public DateTime created_at { get; set; }

        public ModeloOrderMenu()
        {
            id = 0;
            client_cc = string.Empty;
            hamburger_id = 0;
            quantity = 0;
            total_price = 0;
            status = string.Empty;
            store_id = 0;
            created_at = DateTime.Now;
        }
    }
}
