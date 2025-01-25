using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.Model.ManyToMany
{
    internal class ManyToMany
    {
    }

    public class Orders
    {
       
        public int id { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }

    public class Products
    {
        public int id { get; set; }
        public string name { get; set; }    
        public string category { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }

    public class OrderDetails
    {
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public Orders Order { get; set; }
        public Products Product { get; set; }
    }
}
