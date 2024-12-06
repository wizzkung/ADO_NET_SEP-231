using Microsoft.Data.SqlClient;
using System;

namespace MySqlClient
{
    public class Program
    {
        static string conStr = "Server=LERA;Database=testDB;Trusted_Connection=True;TrustServerCertificate=True;\r\n";
        static string conStr2 = "Server=LERA;Database=testDB;User Id=user1;Password=1234;TrustServerCertificate=True;\r\n";
        static void Main()
        {
            Console.WriteLine("Hello, World!");
            TestConnection();
            Console.WriteLine(ShowDate());
        }

        static string ShowDate()
        {
            string result = null;
            using (SqlConnection db = new SqlConnection(conStr2))
            {
                
                db.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT GETDATE()", db))
                {
                    var ob = cmd.ExecuteScalar();
                    if (ob != null)
                       result = ob.ToString();
                }
                    db.Close();
             

            }
            return result;
        }
        static void TestConnection()
        {
            using (SqlConnection db = new SqlConnection(conStr2))
            {
                Console.WriteLine(db.State.ToString());
                db.Open();
                Console.WriteLine(db.State.ToString());
                db.Close();
                Console.WriteLine(db.State.ToString());
                    
            }
        }

    }
}
