using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlClient
{
    public class Cars
    {
        static IConfigurationRoot _configuration;
        public static void GetBetweenDates(DateTime dt1, DateTime dt2)
        {
            if (_configuration == null)
                throw new InvalidOperationException("Configuration is not initialized.");

            using (SqlConnection db = new SqlConnection(_configuration["db"]))
            {
                db.Open();

                using (SqlCommand cmd = new SqlCommand("pCars", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                  
                    cmd.Parameters.AddWithValue("@year", dt1);
                    cmd.Parameters.AddWithValue("@year_", dt2);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           
                            Console.WriteLine($"{reader["model"]} - {reader["year"]} - {reader["cost"]} - {reader["color"]}");
                        }
                    }
                }
            }
        }



        public static void OutModel(string model)
        {
            if (_configuration == null)
                throw new InvalidOperationException("Configuration is not initialized.");
            using (SqlConnection db = new SqlConnection(_configuration["db"]))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pCars;2", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@model", model);
                    SqlParameter cnt = new SqlParameter("@cars", SqlDbType.Int);
                    cnt.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(cnt);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine(cnt.Value);
                }

            }

        }

        public static int GetTotalCostByColor(string color)
        {
            if (_configuration == null)
                throw new InvalidOperationException("Configuration is not initialized.");

            using (SqlConnection db = new SqlConnection(_configuration["db"]))
            {
                db.Open();

                using (SqlCommand cmd = new SqlCommand("pCars;3", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@color", color);
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }

    }
}
