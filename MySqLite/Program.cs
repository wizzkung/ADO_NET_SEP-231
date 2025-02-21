using Microsoft.Data.Sqlite;
using Dapper;

namespace MySqLite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MySqLite.GetData3();
            //MySqLite.GetData2();
            MySqLite.GetData5();


        }
    }

    class MySqLite
    {
        public static void GetData()
        {
            using (var db = new SqliteConnection(@"Data Source=C:\Users\kimle\OneDrive\Документы\SQLite\MyDataBase.db"))
            {
                try
                {
                    db.Open();
                    using (var cmd = new SqliteCommand("select * from country", db))
                    {
                        var dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Console.WriteLine($"{dr[0]} - {dr[1]}");
                        }
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally { db.Close(); }
            }
        }

        public static void GetData2()
        {
            using (var db = new SqliteConnection(@"Data Source=C:\Users\kimle\OneDrive\Документы\SQLite\MyDataBase.db"))
            {
                try
                {
                    var rows = db.Query<Country>("select * from country join city on country.id = city.country_id");
                    foreach (var row in rows)
                    {
                        Console.WriteLine($"{row.name} --- {row.name}");
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally { db.Close(); }
            }
        }


        public static void GetData3()
        {
            using (var db = new SqliteConnection(@"Data Source=C:\Users\kimle\OneDrive\Документы\SQLite\MyDataBase.db"))
            {
                try
                {
                    var countries = db.Query<Country>("SELECT * FROM country").ToList();
                    var cities = db.Query<City>("SELECT * FROM city").ToList();

                    var query = from c in countries
                                join ci in cities on c.id equals ci.country_id
                                select new
                                {
                                    Country = c.name,
                                    City = ci.name
                                };

                    foreach (var item in query)
                    {
                        Console.WriteLine($"{item.Country}: {item.City}");
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally { db.Close(); }
            }
        }

        public static void GetData4()
        {
            using (var db = new SqliteConnection(@"Data Source=C:\Users\kimle\OneDrive\Документы\SQLite\MyDataBase.db"))
            {
                try
                {
                    var countries = db.Query<Country>("SELECT * FROM country").ToList();
                    var cities = db.Query<City>("SELECT * FROM city").ToList();

                    var groupedData = countries
                        .GroupJoin(
                            cities,
                            c => c.id,      
                            ci => ci.country_id, 
                            (c, cityGroup) => new
                            {
                                Country = c.name,
                                CityCount = cityGroup.Count() 
                            })
                        .OrderByDescending(x => x.CityCount);

                    foreach (var item in groupedData)
                    {
                        Console.WriteLine($"{item.Country}: {item.CityCount}");
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally { db.Close(); }
            }
        }


        public static void GetData5()
        {
            using (var db = new SqliteConnection(@"Data Source=C:\Users\kimle\OneDrive\Документы\SQLite\MyDataBase.db"))
            {
                try
                {
                    var countries = db.Query<Country>("SELECT * FROM country").ToList();
                    var cities = db.Query<City>("SELECT * FROM city").ToList();

                    var country = countries
                 .GroupJoin(
                     cities,
                     c => c.id,
                     ci => ci.country_id,
                     (c, cityGroup) => new
                     {
                         Country = c,
                         CityCount = cityGroup.Count(),
                         Cities = cityGroup.ToList()
                     })
                 .OrderByDescending(x => x.CityCount)
                 .FirstOrDefault();

                    var topCities = country.Cities
                  .OrderByDescending(c => c.population)
                  .Take(2)
                  .ToList();

                    Console.WriteLine("Два самых населенных города:");
                    foreach (var city in topCities)
                    {
                        Console.WriteLine($"{city.name} - {city.population} чел.");
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally { db.Close(); }
            }
        }


    }
}
