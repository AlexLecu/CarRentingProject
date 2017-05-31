using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRentingProject.Models;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.IO;

namespace CarRentingProject.Providers
{
    public class CarProvider
    {
        private static string connString;

        public CarProvider()
        {
            connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }


        public void AddCar(Car car)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO car(id, type, brand, country, city, pickup, returnDate, image) VALUES(@id, @type, @brand, @country, @city, @pickup, @returnDate, @image)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", car.id);
                cmd.Parameters.AddWithValue("@type", car.type);
                cmd.Parameters.AddWithValue("@brand", car.brand);
                cmd.Parameters.AddWithValue("@country", car.country);
                cmd.Parameters.AddWithValue("@city", car.city);
                cmd.Parameters.AddWithValue("@pickup", car.pickup);
                cmd.Parameters.AddWithValue("@returnDate", car.returnDate);

                cmd.Parameters.AddWithValue("@image", car.image);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCar(Car car)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE car SET type = @type, brand = @brand, country = @country, city = @city, pickup = @pickup, returnDate = @returnDate, image = @image WHERE id = @id;";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", car.id);
                cmd.Parameters.AddWithValue("@type", car.type);
                cmd.Parameters.AddWithValue("@brand", car.brand);
                cmd.Parameters.AddWithValue("@country", car.country);
                cmd.Parameters.AddWithValue("@city", car.city);
                cmd.Parameters.AddWithValue("@pickup", car.pickup);
                cmd.Parameters.AddWithValue("@returnDate", car.returnDate);

                cmd.Parameters.AddWithValue("@image", car.image);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCar(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM car WHERE id=@id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }


        public IList<Car> RetrieveCar()
        {
            IList<Car> carList = new List<Car>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM car";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Car car = new Car();
                        car.id = reader.GetInt32("id");
                        car.type = reader.GetString("type");
                        car.brand = reader.GetString("brand");
                        car.country = reader.GetString("country");
                        car.city = reader.GetString("city");
                        car.pickup = reader.GetDateTime("pickup");
                        car.returnDate = reader.GetDateTime("returnDate");
                        car.image = (byte[])reader["image"];

                        carList.Add(car);
                    }
                }
            }

            return carList;
        }


        public Car GetById(int id)
        {
            Car car = new Car();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM car WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(statement, conn);

                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        car.id = reader.GetInt32("id");
                        car.type = reader.GetString("type");
                        car.brand = reader.GetString("brand");
                        car.country = reader.GetString("country");
                        car.city = reader.GetString("city");
                        car.pickup = reader.GetDateTime("pickup");
                        car.returnDate = reader.GetDateTime("returnDate");
                        car.image = (byte[])reader["image"];
                    }
                }
            }

            return car;
        }

    }

}