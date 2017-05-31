using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRentingProject.Models;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace CarRentingProject.Providers
{
    public class EmployeeProvider
    {
        private static string connString;

        public EmployeeProvider()
        {
            connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        public IList<Employee> RetrieveEmployee()
        {
            IList<Employee> employeeList = new List<Employee>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM employee";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.id = reader.GetInt32("id");
                        employee.name = reader.GetString("name");
                        employee.password = reader.GetString("password");

                        employeeList.Add(employee);
                    }
                }
            }

            return employeeList;
        }


        public void AddEmployee(Employee employee)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO employee(id, name, password) VALUES(@id, @name, @password)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", employee.id);
                cmd.Parameters.AddWithValue("@name", employee.name);
                cmd.Parameters.AddWithValue("@password", employee.password);
               
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE employee SET name = @name, password = @password WHERE id = @id;";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", employee.id);
                cmd.Parameters.AddWithValue("@name", employee.name);
                cmd.Parameters.AddWithValue("@password", employee.password);
                cmd.ExecuteNonQuery();
            }
        }

        public Employee GetById(int id)
        {
            Employee employee = new Employee();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM employee WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(statement, conn);

                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employee.id = reader.GetInt32("id");
                        employee.name = reader.GetString("name");
                        employee.password = reader.GetString("password");
                    }
                }
            }

            return employee;
        }

        public void DeleteEmployee(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM employee WHERE id=@id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}