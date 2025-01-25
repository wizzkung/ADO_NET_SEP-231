using MyEfCore.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.Service
{
    public class ManyToManyService
    {
        public void fetch()
        {
            using (Context db = new Context())
            {
                var join = (from od in db.OrderDetails
                            join o in db.Orders on od.order_id equals o.id
                            join p in db.Products on od.order_id equals p.id
                            select new
                            {
                                orderID = o.id,
                                ProductName = p.name,
                                Quantity = od.quantity,
                                Price = od.price,
                                Total = od.quantity * od.price
                            }).ToList();
                foreach (var item in join)
                {
                    {
                        Console.WriteLine($"{item.ProductName}, {item.Quantity}, {item.Price}, {item.Total}");
                    }
                }
            }
        }
    }
}
