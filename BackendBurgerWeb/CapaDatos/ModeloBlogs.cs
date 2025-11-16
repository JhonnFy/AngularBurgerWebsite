using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ModeloBlogs
    {
        public long id { get; set; }
        public long order_id { get; set; }
        public string order_type { get; set; }
        public long client_cc { get; set; }
        public string hamburger_name { get; set; }
        public int quantity { get; set; }
        public decimal total_price { get; set; }
        public string payment_method { get; set; }
        public string store_name { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }

        public ModeloBlogs()
        {
            id = 0;
            order_id = 0;
            order_type = string.Empty;
            client_cc = 0;
            hamburger_name = string.Empty;
            quantity = 0;
            total_price = 0;
            payment_method = string.Empty;
            store_name = string.Empty;
            status = string.Empty;
            created_at = DateTime.Now;
        }

    }
}
