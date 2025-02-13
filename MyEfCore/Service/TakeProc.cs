using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyEfCore.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.Service
{
    //public class TakeProc //как вызывать через ef процедуры
    //{

    //    IConfigurationRoot Configuration;
    //    public TakeProc(IConfigurationRoot configurationRoot)
    //    {
    //        this.Configuration = configurationRoot;
    //    }
    //    public void proc()
    //    {
    //        using (Context db = new Context())
    //        {
    //            var books = db.books.FromSqlRaw("exec pBooks");
    //            foreach (var item in books)
    //            {
    //                Console.WriteLine($"{item.Id} - {item.Title}");
    //            }
    //        }
    //    }

    //    public void proc2() //для процедуры принимающей параметр
    //    {
    //        using (Context db = new Context())
    //        {
    //            SqlParameter p = new SqlParameter("@book_id", 1);
    //            var books = db.books.FromSqlRaw("exec pBooks;2 @book_id", p);
    //            foreach (var item in books)
    //            {
    //                Console.WriteLine($"{item.Id} - {item.Title}");
    //            }
    //        }
    //    }

    //    public void proc3() //для процедуры принимающей более одного параметра через инетерполяцию (можно просто дублировать SQLPArameter)
    //    {
    //        using (Context db = new Context())
    //        {
    //            var books = db.books.FromSqlInterpolated($"exec pBooks;2 {1}, {2}");
    //            foreach (var item in books)
    //            {
    //                Console.WriteLine($"{item.Id} - {item.Title}");
    //            }
    //        }
    //    }

    //    public void proc4()
    //    {
    //        using (Context db = new Context()) //через DTO
    //        {
    //            var bookCategories = db.bookCategories2.FromSqlRaw("exec pBooks;4");
    //            foreach (var item in bookCategories)
    //            {
    //                Console.WriteLine($"{item.book_name} - {item.category_name}");
    //            }
    //        }
    //    }

    //    public void proc5()
    //    {
    //        using (Context db = new Context()) //через DTO
    //        {
    //            var bookCategories = db.bookCategoryCounts.FromSqlRaw("exec pBooks;4");
    //            foreach (var item in bookCategories)
    //            {
    //                Console.WriteLine($"{item.cnt} - {item.category_name}");
    //            }
    //        }
    //    }

    //    public void proc6() //транзакции на ADO
    //    {
    //        using (SqlConnection db = new SqlConnection("db"))
    //        {
    //            db.Open();
    //            SqlTransaction sqlTransaction = db.BeginTransaction();
    //            try
    //            {
    //                using (SqlCommand cmd = new SqlCommand("pBook;3", db))
    //                {
    //                    cmd.Transaction = sqlTransaction;
    //                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    //                    SqlDataReader reader = cmd.ExecuteReader();
    //                    while (reader.Read())
    //                    {
    //                        Console.WriteLine($"{reader[0].ToString()}");
    //                    }
    //                    sqlTransaction.Commit();
    //                }
    //            }
    //            catch (Exception)
    //            {
    //                sqlTransaction.Rollback();
    //            }
    //            db.Close();
    //        }

            


    //    }

    //    public void proc7() //транзакции EF Core
    //    {
    //        using (Context db = new Context())
    //        {
    //        var transaction = db.Database.BeginTransaction();
    //            try
    //            {
    //                var books = db.books.FromSqlInterpolated($"exec pBooks;2 {1}, {2}");
    //                foreach (var item in books)
    //                {
    //                    Console.WriteLine($"{item.Id} - {item.Title}");
    //                }
    //                db.SaveChanges();
    //                transaction.Commit();   
    //            }
    //            catch (Exception)
    //            {
    //                transaction.Rollback();
    //            }
    //        }
    //    }
    //}
}
