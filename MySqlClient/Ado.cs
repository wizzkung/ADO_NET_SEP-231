using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Azure;
using System.Drawing;

namespace MySqlClient
{
    internal class Ado
    {
        static string conStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kimle\\OneDrive\\Документы\\citymvc.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";
        public static void InsertData(string name, int age, decimal size)
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pStarsAdo;3", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("age", age);
                    cmd.Parameters.AddWithValue("size", size);
                    cmd.ExecuteNonQuery();
                }
                db.Close();
            }
        }

        public static void ShowAll()
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pStarsAdo", db))
                {
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine($"{dr["id"].ToString()} - {dr["name"].ToString()} -{dr["age"].ToString()} - {dr["size"].ToString()} ");
                    }
                }
                db.Close();
            }
        }


        public static void ShowById(int id)
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pStarsAdo;2", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"{reader["id"].ToString()} - {reader["name"].ToString()} - {reader["age"].ToString()} - {reader["size"].ToString()}");
                        }
                        else
                        {
                            Console.WriteLine("Not found");
                        }
                    }
                    db.Close();
                }
            }
        }

        public static void Update(int id, string name, int age, decimal size)
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pStarsAdo;4", db))                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);  
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@size", size);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Updated");
                }
                db.Close();
            }
        }

        public static void Delete(int id)
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pStarsAdo;5", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Запись {id} удалена");
                    }
                    else
                    {
                        Console.WriteLine($"Запись {id} не найдена");
                    }
                }
                db.Close();
            }
        }


    }
}
