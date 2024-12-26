using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Azure;
using System.Drawing;
using Microsoft.Extensions.Configuration;

namespace MySqlClient


{
    public class Ado_ClassWork
    {
        static IConfigurationRoot Configuration;
        static string con3 = "Server=LERA;Database=ado;Trusted_Connection=True;TrustServerCertificate=True";
        static public void Select()
        {
            using (SqlConnection db = new SqlConnection(Program.Configuration["db"]))
            {
                db.Open();
                    DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand("pCity", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine($"{dr["0"].ToString()} - {dr["1"].ToString()} - {dr["2"].ToString()} - {dr["3"].ToString()}");
                    }
                        
                }
                    
                db.Close();
            }
        }

       public static void SelectByName(string name)
        {
            using (SqlConnection db = new SqlConnection(Program.Configuration["db"]))
            {
                db.Open();
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand("pCity;2", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@aname", name); - variant 0
                    //SqlParameter pname = new SqlParameter("@aname", name); - variant 1
                    cmd.Parameters.Add(new SqlParameter("@aname", name)); // - variant 2
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine($"{dr["0"].ToString()} - {dr["1"].ToString()} - {dr["2"].ToString()} - {dr["3"].ToString()}");
                    }
                    db.Close();
                }
            }
        }

        public static void Insert(string name, int pop, DateTime dateTime)
        {
            using (SqlConnection db = new SqlConnection(Program.Configuration["db"]))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pCity;3", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("population", pop);
                    cmd.Parameters.AddWithValue("birthdate", dateTime);
                    cmd.ExecuteNonQuery();
                }
                db.Close();
            }
        }

        public static void edit(int id, string name, int pop, DateTime dateTime)
        {
            using (SqlConnection db = new SqlConnection(Program.Configuration["db"]))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pCity;4", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@population", pop);
                    cmd.Parameters.AddWithValue("@birthdate", dateTime);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Updated");
                }
                db.Close();
            }
        }

        public static void InsertNoProcedure(string name, int pop, DateTime dateTime)
        {
            using (SqlConnection db = new SqlConnection(Program.Configuration["db"]))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO City (name, population, birthdate) " +
                      "values('" + name + "', " + pop + ", '" + dateTime.ToString("yyyy-MM-dd") + "')", db))
                {
                    cmd.ExecuteNonQuery();
                }
                db.Close();
            }
        }

        public static void DeleteProcedure(int id)
        {
            using SqlConnection db = new SqlConnection(Program.Configuration["db"]);
            db.Open();

            using SqlCommand cmd = new SqlCommand("pCity", db)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@id", id);

            if (cmd.ExecuteNonQuery() > 0)
                Console.WriteLine($"Запись {id} удалена");
            else
                Console.WriteLine($"Запись {id} не найдена");
        }

        public static void OutParameter()
        {
            using (SqlConnection db = new SqlConnection(Program.Configuration["db"]))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pCity;6", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter ctn = new SqlParameter("@cnt", SqlDbType.Int, 10);
                    ctn.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(ctn);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine(ctn.Value);
                }
                db.Close();
            }
        }

        public static void OutMoreAgainstPop(int pop)
        {
            using (SqlConnection db = new SqlConnection(Program.Configuration["db"]))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pCity;7", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@population", pop);
                    SqlParameter cnt = new SqlParameter("@cnt", SqlDbType.Int);
                    cnt.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(cnt);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine(cnt.Value);
                }
            }
        }

    }
}
