using Microsoft.EntityFrameworkCore;
using MyEfCore.Models;
using MyEfCore.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.Service
{
    public class BmwServices
    {
        public void Service_1()
        {
            using (Context db = new Context())
            {
                var join = from b in db.BMW
                           join bm in db.BmwModels on b.id equals bm.serial_number_bmw
                           select new
                           {
                               Series = b.series,
                               Model = bm.series_name
                           };

                foreach (var item in join)
                {
                    Console.WriteLine($"{item.Model} - {item.Series}");
                }

            }

        }

        public void Service_2()
        {
            using (Context db = new Context())
            {
                var res = db.BMW.FirstOrDefault( b => b.id == 1 );
                db.Entry(res).Collection(b => b.BmwModels).Load();
                Console.WriteLine(res.series);
                foreach (var item in res.BmwModels)
                {
                    Console.WriteLine($"{item.series_name}");
                }

            }

        }

        public void Service_3()
        {
            using (Context db = new Context())
            {
                var res = db.BmwModels.Include(z => z.BMW).ToList();

                foreach(var item in res)
                {
                    Console.WriteLine(item.series_name);
                }

            }

        }

        public void Service_4()
        {
            using (Context db = new Context())
            {
               var bmw_models = db.BmwModels.ToList();

                foreach(var item in bmw_models)
                {
                    Console.WriteLine($"{item.series_name} - {item.BMW?.series}");
                }

            }

        }





    }
}
