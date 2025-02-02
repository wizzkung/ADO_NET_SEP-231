using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.Configuration;
using MyEfCore.Model;
using MyEfCore.MyContext;
using MyEfCore.Service;

namespace MyEfCore
{
    public class Program
    {
        public static IConfigurationRoot config;
        static void Main(string[] args)
        {
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //ManyToManyService m = new ManyToManyService();
            //m.fetch();
            //EfHomeWork_1 m = new EfHomeWork_1();
            //ModelsService services = new ModelsService();
            BmwServices bmwServices = new BmwServices();
           // bmwServices.Service_1();
            //bmwServices.Service_2();
            //bmwServices.Service_3();
            bmwServices.Service_4();

            //services.Service();
            // services.Family();
            //services.FromNavigation();

            //m.DataAdd();
            //m.ShowData();
            //m.EditEverySecond();
            //m.ShowData();
            //m.DeleteWherePlusExist();
            //m.ShowData();
            //School school = new School();
            //school.Add();





            //using (Context db = new Context())
            //{

            //    //fetch
            //    //foreach(var item in db.Country)
            //    //{
            //    //    Console.WriteLine(item.Id);
            //    //}

            //    //add
            //    //Country country = new Country
            //    //{
            //    //    Name = "Россия",
            //    //    Capital = "Москва"
            //    //};

            //    //db.Country.Add(country);
            //    //db.SaveChanges();

            //    //List<Country> countries = new List<Country>()
            //    //{
            //    //    new Country{Name = "Казахстан", Capital = "Астана"},
            //    //    new Country{Name = "США", Capital = "Вашингтон"}

            //    //};
            //    //db.Country.AddRange(countries);
            //    //db.SaveChanges();


            //    //edit
            //    //Country? country = db.Country.FirstOrDefault(z => z.Id == 1);
            //    //if (country != null)
            //    //{
            //    //    country.Name = "Казахстан";
            //    //    country.Capital = "Нур-Султан";
            //    //    db.SaveChanges();
            //    //}


            //    //с идентификатором записи (id)
            //    //var country = new Country {Id = 3, Name = "США", Capital = "Вашингтон ДС" };
            //    //db.Entry<Country>(country).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //    //db.SaveChanges();




            //    //delete
            //    //var country = db.Country.Where(z => z.Id == 1 || z.Id == 2).ToList();
            //    //if (country.Any())
            //    //{
            //    //   db.Country.RemoveRange(country);
            //    //    db.SaveChanges();
            //    //}

            //    //Country country = db.Country.FirstOrDefault(z => z.Id == 1);
            //    //if (country != null)
            //    //{
            //    //    db.Country.Remove(country);
            //    //    db.SaveChanges();
            //    //}


            //    foreach (var item in db.Country)
            //    {
            //        Console.WriteLine($"{item.Id}, { item.Name}, { item.Capital}");
            //    }
            //}

            ////ГИБРИДНЫЙ ВАРИАНТ БЕЗ МИГРАЦИЙ КОГДА В БД В РУЧНУЮ ДЕЛАЕШЬ ТАБЛИЦЫ ПОТОМ ЗЕРКАЛИШЬ В МОДЕЛИ
            //using (Context db = new Context())
            //{
            //    //var emp = db.Employees.Find(1);
            //    var join = (from e in db.Employees
            //                join s in db.Salary on e.id equals s.employee_id
            //                select new
            //                {
            //                    emp_id = e.id,
            //                    emp_name = e.last_name + e.first_name,
            //                    emp_gender = e.gender == "male" ? "Мужской" : "Женский",
            //                    s_salary = s.salary
            //                }).ToList(); // ToList будет ждать когда все джойны вылезут с бд

            //    foreach (var item in join)
            //    {
            //        {

            //            Console.WriteLine($"{item.emp_id} {item.emp_name} {item.emp_gender} {item.s_salary}");

            //        }
            //    }
            //}
        }
    }
}
