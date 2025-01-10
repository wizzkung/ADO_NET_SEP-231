using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.Configuration;
using MyEfCore.Model;
using MyEfCore.MyContext;

namespace MyEfCore
{
    public class Program
    {
        public static IConfigurationRoot config;
        static void Main(string[] args)
        {
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            using (Context db = new Context())
            {

                //fetch
                //foreach(var item in db.Country)
                //{
                //    Console.WriteLine(item.Id);
                //}

                //add
                //Country country = new Country
                //{
                //    Name = "Россия",
                //    Capital = "Москва"
                //};

                //db.Country.Add(country);
                //db.SaveChanges();

                //List<Country> countries = new List<Country>()
                //{
                //    new Country{Name = "Казахстан", Capital = "Астана"},
                //    new Country{Name = "США", Capital = "Вашингтон"}

                //};
                //db.Country.AddRange(countries);
                //db.SaveChanges();


                //edit
                //Country? country = db.Country.FirstOrDefault(z => z.Id == 1);
                //if (country != null)
                //{
                //    country.Name = "Казахстан";
                //    country.Capital = "Нур-Султан";
                //    db.SaveChanges();
                //}


                //с идентификатором записи (id)
                //var country = new Country {Id = 3, Name = "США", Capital = "Вашингтон ДС" };
                //db.Entry<Country>(country).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //db.SaveChanges();




                //delete
                //var country = db.Country.Where(z => z.Id == 1 || z.Id == 2).ToList();
                //if (country.Any())
                //{
                //   db.Country.RemoveRange(country);
                //    db.SaveChanges();
                //}

                //Country country = db.Country.FirstOrDefault(z => z.Id == 1);
                //if (country != null)
                //{
                //    db.Country.Remove(country);
                //    db.SaveChanges();
                //}


                foreach (var item in db.Country)
                {
                    Console.WriteLine($"{item.Id}, { item.Name}, { item.Capital}");
                }
            }

        }
    }
}
