using BreakItMakeIt_Exercises.Chapter_03_SOLID.SRP.Assignment;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakItMakeIt_Exercises.Chapter_03_SRP.SRP.Solution.Database
{

    public interface IOrderRepository
    {
        void Save(Order order);
        List<Order> GetAll();
    }

    public class SqlOrderRepository : IOrderRepository
    {
        private readonly string _connectionString;

        public SqlOrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Save(Order order)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = "INSERT INTO Orders (Product, Quantity, Price) VALUES (@Product, @Quantity, @Price)";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Product", order.Product);
            cmd.Parameters.AddWithValue("@Quantity", order.Quantity);
            cmd.Parameters.AddWithValue("@Price", order.Price);
            cmd.ExecuteNonQuery();
        }

        public List<Order> GetAll()
        {
            var orders = new List<Order>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = "SELECT Id, Product, Quantity, Price FROM Orders";
            using var cmd = new SqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                orders.Add(new Order
                {
                    //Id = (int)reader["Id"],
                    Product = reader["Product"].ToString(),
                    Quantity = (int)reader["Quantity"],
                    Price = (decimal)reader["Price"]
                });
            }
            return orders;
        }
    }

}
