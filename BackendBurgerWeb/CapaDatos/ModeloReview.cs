using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ModeloReview
    {
        public long id { get; set; }
        public long order_id { get; set; }
        public string order_type { get; set; }
        public string comment { get; set; }
        public DateTime created_at { get; set; }

        public ModeloReview()
        {
            id = 0;
            order_id = 0;
            order_type = string.Empty;
            comment = string.Empty;
            created_at = DateTime.Now;
        }
    }
}
