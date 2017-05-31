using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRentingProject.Models;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace CarRentingProject.Providers
{
    public class CustomerProvider
    {
        private static string connString;

        public CustomerProvider()
        {
            connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        public IList<Customer> RetrieveCustomer()
        {
            IList<Customer> customerList = new List<Customer>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM customer";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.id = reader.GetInt32("id");
                        customer.name = reader.GetString("name");
                        customer.password = reader.GetString("password");
                        customer.cnp = reader.GetString("cnp");
                        customer.birthdate = reader.GetDateTime("birthdate");
                        customer.address = reader.GetString("address");

                        customerList.Add(customer);
                    }
                }
            }

            return customerList;
        }


        public void AddCustomer(Customer customer)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO customer(id, name, password, cnp, birthdate, address) VALUES(@id, @name, @password, @cnp, @birthdate, @address)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", customer.id);
                cmd.Parameters.AddWithValue("@name", customer.name);
                cmd.Parameters.AddWithValue("@password", customer.password);
                cmd.Parameters.AddWithValue("@cnp", customer.cnp);
                cmd.Parameters.AddWithValue("@birthdate", customer.birthdate);
                cmd.Parameters.AddWithValue("@address", customer.address);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE customer SET name = @name, password = @password, cnp = @cnp, birthdate = @birthdate, address = @address WHERE id = @id;";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", customer.id);
                cmd.Parameters.AddWithValue("@name", customer.name);
                cmd.Parameters.AddWithValue("@password", customer.password);
                cmd.Parameters.AddWithValue("@cnp", customer.cnp);
                cmd.Parameters.AddWithValue("@birthdate", customer.birthdate);
                cmd.Parameters.AddWithValue("@address", customer.address);
                cmd.ExecuteNonQuery();
            }
        }

        public Customer GetById(int id)
        {
            Customer customer = new Customer();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM customer WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(statement, conn);

                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        customer.id = reader.GetInt32("id");
                        customer.name = reader.GetString("name");
                        customer.password = reader.GetString("password");
                        customer.cnp = reader.GetString("cnp");
                        customer.birthdate = reader.GetDateTime("birthdate");
                        customer.address = reader.GetString("address");
                    }
                }
            }

            return customer;
        }

        public void DeleteCustomer(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM customer WHERE id=@id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}