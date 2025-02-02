using Microsoft.EntityFrameworkCore;
using MyEfCore.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.Service
{
    public class ModelsService
    {
        //public void Service()
        //{
        //    using (Context db = new Context())
        //    {
        //        var joined = from b in db.Book
        //                     join bc in db.BookCategory on b.book_id equals bc.book_id
        //                     join c in db.Category on bc.category_id equals c.category_id
        //                     select new
        //                     {
        //                         book_name = b.book_name,
        //                         category_name = c.category_name
        //                     };
        //        foreach (var item in joined)
        //        {
        //            Console.WriteLine($"{item.book_name} {item.category_name}");
        //        }
        //    }
        //}

        //public void Family()
        //{
        //    using (Context db = new Context())
        //    {
        //        var joined = from p in db.Parent
        //                     join c in db.Child on p.id equals c.parent_id
        //                     select new
        //                     {
        //                         Parent = p.name,
        //                         Child = c.name
        //                     };

        //        foreach (var item in joined)
        //        {
        //            Console.WriteLine($"{item.Parent} {item.Child}");
        //        }
        //    }
        //}

        //public void FromNavigation()
        //{
        //    using (Context db = new Context())
        //    {
        //        //Lazy загрузка по очереди так же смотри в onConfiguring
        //        var child = db.Child.ToList();
        //        foreach (var item in child)
        //        {
        //            Console.WriteLine($"{item.name}   {item.Parent?.name}");
        //        }


                //Явная загрузка через .load()
                //var p = db.Parent.FirstOrDefault(z => z.id == 1);
                //db.Child.Where(z => z.Parent == p).Load();

                //Console.WriteLine($"parent: {p.name}");
                //foreach(var item in p.Child)
                //{
                //    Console.WriteLine($"Child: {item.name}");
                //}

                //Не явный вызов
                //var res = db.Child.Include(z => z.Parent).ToList();


        //    }
        //}
    }
}
