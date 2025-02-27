using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqLite
{
    public class Orders
    {
    }

    public class Order
    {
        public int order_id { get; set; }
        public string order_date { get; set; }
    }

    public class Product
    {
        public int product_id { get; set; }
        public int quantity { get; set; }

    }

    public class OrderDetails
    {
        public int order_id { get; set; }
        public int product_id { get; set; }
    }
    

}
