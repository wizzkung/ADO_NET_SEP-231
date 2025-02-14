using Dapper;
using Dapper_.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Dapper_
{
    internal class Program
    {

        public static IConfiguration config;
        static void Main(string[] args)
        {
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //Dapp.GetSelect();

            //  Dapp.GetBookById("5");
            // Dapp.GetBookByIdAnonymous("1");
            // Dapp.InsertBook(new Book { book_id = " ", book_name = "Самыый" });
            //Dapp.OutputParam();
            Dapp.MultiSelect("3");


        }
    }

    public static class Dapp
    {
        public static void GetDate()
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                var res = db.ExecuteScalar<string>("select getdate()");
                Console.WriteLine(res);
            }
        }


        public static void GetSelect()
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                var res = db.Query<Book>("select book_id, book_name FROM Book");
                foreach (var item in res)
                {
                    Console.WriteLine(item.book_id);
                }
            }
        }

        public static void GetSelectWithNoClass()
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                var res = db.Query<dynamic>("select book_id, book_name FROM Book");
                foreach (var item in res)
                {
                    string book_id = item.book_id.ToString(); //если нужно типизировать поле или через Convert.ToString()
                    Console.WriteLine(item.book_id);
                }
            }
        }


        public static void GetBookById(string id)
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                var res = db.Query<Book>("pBook;5", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                foreach (var item in res)
                {
                    string book_id = item.book_id.ToString();
                    Console.WriteLine($"{item.book_id} - {item.book_name}");
                }
            }
        }


        public static void GetBookByIdAnonymous(string id)
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                var res = db.Query<Book>("pBook;5", new { @id = id }, commandType: System.Data.CommandType.StoredProcedure);
                foreach (var item in res)
                {
                    string book_id = item.book_id.ToString();
                    Console.WriteLine($"{item.book_id} - {item.book_name}");
                }
            }
        }


        public static void InsertBook(Book book) //Через модель должно передаваться с одинаковым кол-вом параметров процедуры что и классов
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                DynamicParameters p = new DynamicParameters(book);

                db.Execute("pBook", p, commandType: System.Data.CommandType.StoredProcedure);
               
            }
        }


        public static void OutputParam()
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CNT", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                db.Execute("pBook;6", p, commandType: System.Data.CommandType.StoredProcedure);
                int cnt = p.Get<int>("@CNT");
                Console.WriteLine(cnt);

            }
        }


        public static void MultiSelect(string id)
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@id", id);
                using (var res = db.QueryMultiple("pBook;5", p, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var first = res.Read<dynamic>();
                    var second = res.Read<dynamic>();
                    foreach (var item in first) 
                    {
                        Console.WriteLine($"{item.book_name}");
                    }

                    foreach (var item in second)
                    {
                        Console.WriteLine($"{item.book_id}");
                    }    
                }
            }
        }
    }
}




