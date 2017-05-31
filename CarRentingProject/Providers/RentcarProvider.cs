using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRentingProject.Models;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace CarRentingProject.Providers
{
    public class RentcarProvider
    {
        private static string connString;

        public RentcarProvider()
        {
            connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        public IList<Rentcar> RetrieveRentings()
        {
            IList<Rentcar> rentList = new List<Rentcar>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM rentcar";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Rentcar rentcar = new Rentcar();
                        rentcar.idcar = reader.GetInt32("idcar");
                        rentcar.idcustomer = reader.GetInt32("idcustomer");
                        rentcar.isReturned = reader.GetInt32("isReturned");

                        rentList.Add(rentcar);
                    }
                }
            }

            return rentList;
        }

        public void AddRentcar(Rentcar rentcar)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO rentcar(idcustomer, idcar, isReturned) VALUES(@idcustomer, @idcar, @isReturned)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@idcar", rentcar.idcar);
                cmd.Parameters.AddWithValue("@idcustomer", rentcar.idcustomer);
                cmd.Parameters.AddWithValue("@isReturned", rentcar.isReturned);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateRentcar(Rentcar rentcar)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE rentcar SET idcar = @idcar, isReturned = @isReturned WHERE idcustomer = @idcustomer;";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@idcar", rentcar.idcar);
                cmd.Parameters.AddWithValue("@idcustomer", rentcar.idcustomer);
                cmd.Parameters.AddWithValue("@isReturned", rentcar.isReturned);
                cmd.ExecuteNonQuery();
            }
        }

        public Rentcar GetById(int id)
        {
            Rentcar rentcar = new Rentcar();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM rentcar WHERE idcustomer = @id";

                MySqlCommand cmd = new MySqlCommand(statement, conn);

                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rentcar.idcar = reader.GetInt32("idcar");
                        rentcar.idcustomer = reader.GetInt32("idcustomer");
                        rentcar.isReturned = reader.GetInt32("isReturned");
                    }
                }
            }

            return rentcar;
        }

        public void DeleteRentcar(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM rentcar WHERE idcustomer=@id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}