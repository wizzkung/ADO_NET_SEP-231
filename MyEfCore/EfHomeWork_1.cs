using MyEfCore.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEfCore.Model;
using MyEfCore.Migrations;
using MyStar = MyEfCore.Model.Stars;

namespace MyEfCore
{
    public class EfHomeWork_1
    {
        public void DataAdd()
        {
            using (Context Context = new Context())
            {
                var rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    MyStar stars = new MyStar
                    {
                        Name = $"Star_{rnd.Next(1, 1000)}",
                        Age = rnd.Next(1, 10000),
                        Size = Math.Round((decimal)(rnd.NextDouble() * 100), 2)
                    };
                    Context.Stars.Add(stars);
                }
                Context.SaveChanges();
            }
        }

        public void EditEverySecond()
        {
            using (Context Context = new Context())
            {
                var star = Context.Stars.Where(z => z.Id % 2 == 0).ToList();

                foreach (var stars in star)
                {
                    stars.Name += "+";
                }

                Context.SaveChanges();
            }
        }

        public void DeleteWherePlusExist()
        {
            using (Context context = new Context())
            {
                var star = context.Stars.Where(z => z.Name.Contains("+")).ToList();
                context.Stars.RemoveRange(star);
                context.SaveChanges();
            }
        }

        public void ShowData()
        {
            using (Context context = new Context())
            {
                var stars = context.Stars.ToList();

                foreach (var star in stars)
                {
                    Console.WriteLine($"Name: {star.Name}");
                    Console.WriteLine($"Age: {star.Age}");
                    Console.WriteLine($"Id: {star.Id}");
                    Console.WriteLine($"Size: {star.Size}");
                    Console.WriteLine("---------------");   
                }
            }
        }


    }
}
