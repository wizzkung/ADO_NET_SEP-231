using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace MySqlClient
{
    public class Program
    {
        Ado ado = new Ado();
       public static IConfigurationRoot Configuration;


        static string conStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kimle\\OneDrive\\Документы\\citymvc.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";
        static string conStr2 = "Server=LERA;Database=testDB;User Id=user1;Password=1234;TrustServerCertificate=True;\r\n";
        static string con3 = "Server=LERA;Database=ado;Trusted_Connection=True;";
        static void Main()
        {
            Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //Console.WriteLine("Hello, World!");
            //TestConnection();
            //Console.WriteLine(ShowDate());
            //SelectFromTable2();
            //SelectFromView();
            //SelectFromTableFunction();
            //InsertProc();
            //SelectFromProc();
            //Ado.ShowAll();
            //Ado_ClassWork.Select();
            // Ado_ClassWork.OutMoreAgainstPop(5000000);
            Cars.OutModel("Hyundai Sonata");
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

        static void SelectFromTable()
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CityAdo", db))
                {
                    var reader = cmd.ExecuteReader();
                    if(reader.HasRows)
                    while(reader.Read())
                    {
                        Console.WriteLine($"{reader["id"].ToString()} - {reader["name"].ToString()} - {reader["date_birth"].ToString()}");
                    }
                }
                    db.Close();

            }

        }

        static void SelectFromTable2()
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CityAdo", db))
                {
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    Console.WriteLine($"Rows: {dt.Rows.Count} - Columns: { dt.Columns.Count}" );
                 foreach(DataRow i in dt.Rows)
                    {
                        Console.WriteLine($"{i["id"].ToString()} - {i["name"].ToString()} - {i["date_birth"].ToString()}");
                    }
                            //Console.WriteLine($"{reader["id"].ToString()} - {reader["name"].ToString()} - {reader["date_birth"].ToString()}");
    
                }
                db.Close();

            }

        }


        static void SelectFromProc()
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pCity;2", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    Console.WriteLine($"Rows: {dt.Rows.Count} - Columns: {dt.Columns.Count}");
                    foreach (DataRow i in dt.Rows)
                    {
                        Console.WriteLine($"{i["id"].ToString()} - {i["name"].ToString()} - {i["date_birth"].ToString()}");
                    }
                    //Console.WriteLine($"{reader["id"].ToString()} - {reader["name"].ToString()} - {reader["date_birth"].ToString()}");

                }
                db.Close();

            }

        }

        static void SelectFromView()
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vCity", db))
                {
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    Console.WriteLine($"Rows: {dt.Rows.Count} - Columns: {dt.Columns.Count}");
                    foreach (DataRow i in dt.Rows)
                    {
                        Console.WriteLine($"{i["id"].ToString()} - {i["name"].ToString()} - {i["date_birth"].ToString()}");
                    }
                    //Console.WriteLine($"{reader["id"].ToString()} - {reader["name"].ToString()} - {reader["date_birth"].ToString()}");

                }
                db.Close();

            }

        }

        static void SelectFromTableFunction()
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fCity(2)", db))
                {
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    Console.WriteLine($"Rows: {dt.Rows.Count} - Columns: {dt.Columns.Count}");
                    foreach (DataRow i in dt.Rows)
                    {
                        Console.WriteLine($"{i["id"].ToString()} - {i["name"].ToString()} - {i["date_birth"].ToString()}");
                    }
                    //Console.WriteLine($"{reader["id"].ToString()} - {reader["name"].ToString()} - {reader["date_birth"].ToString()}");

                }
                db.Close();

            }

        }

        static void InsertProc()
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pCity", db))
                {
                   cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", "Shymkent");
                    cmd.Parameters.AddWithValue("@date_birth", DateTime.Now.AddYears(-100));
                    cmd.ExecuteNonQuery();
                }
                db.Close();

            }
        }
    }
}
