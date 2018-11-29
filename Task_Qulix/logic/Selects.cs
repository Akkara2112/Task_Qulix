using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Task_Qulix.Models;

namespace Task_Qulix.logic
{
    public class Selects
    {
        string connectionString = @"Data Source=SQL6002.site4now.net;Initial Catalog=DB_A43234_mydb;User Id=DB_A43234_mydb_admin;Password=3258131s;";
        //выборка компаний из базы данных
        public List<Company> SelectCompanies()
        {
            List<Company> newnew = new List<Company>();
            string sqlExpression = "select Company.id, Company.name_of, Company.company_size,Legal_Form.name_of from Company, Legal_Form where Legal_Form.id = Company.legal_form_id; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    newnew.Add(new Company((int)reader.GetValue(0), reader.GetValue(1).ToString(),
                                            reader.GetValue(2).ToString(), reader.GetValue(3).ToString())
                    {
                        id = (int)reader.GetValue(0),
                        name_of = reader.GetValue(1).ToString(),
                        company_size = reader.GetValue(2).ToString(),
                        legal_form_id = reader.GetValue(3).ToString()
                    });
                }
            }
            return newnew;
        }

        //выборка должностей из базы данных
        public List<Position> SelectPositions()
        {
            List<Position> newnew = new List<Position>();
            string sqlExpression = "select id, name_of from Position";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    newnew.Add(new Position((int)reader.GetValue(0),
                                                reader.GetValue(1).ToString())
                    {
                        id = (int)reader.GetValue(0),
                        name_of = reader.GetValue(1).ToString()
                    });
                }
            }
            return newnew;
        }

        //выборка работников из базы данных
        public List<Worker> SelectWorkers()
        {
            List<Worker> newnew = new List<Worker>();
            string sqlExpression = "SELECT Worker.id, Worker.first_name, Worker.last_name, Worker.patronymic,Worker.date_of_registration,Position.name_of, Company.name_of  FROM Worker, Position, Company  where Worker.company_id = Company.id and Worker.position_id = Position.id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    newnew.Add(new Worker((int)reader.GetValue(0),
                                                reader.GetValue(1).ToString(),
                                                reader.GetValue(2).ToString(),
                                                reader.GetValue(3).ToString(),
                                                reader.GetValue(4).ToString(),
                                                reader.GetValue(5).ToString(),
                                                reader.GetValue(6).ToString())
                    {
                        id = (int)reader.GetValue(0),
                        first_name = reader.GetValue(1).ToString(),
                        last_name = reader.GetValue(2).ToString(),
                        patronymic = reader.GetValue(3).ToString(),
                        date_of_registration = reader.GetValue(4).ToString(),
                        position_id = reader.GetValue(5).ToString(),
                        company_id = reader.GetValue(6).ToString()
                    });
                }
            }
            return newnew;
        }

        //выборка ОПФ из базы данных
        public List<Legal_Form> SelectForms()
        {
            List<Legal_Form> newnew = new List<Legal_Form>();
            string sqlExpression = "select id, name_of from Legal_Form";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    newnew.Add(new Legal_Form((int)reader.GetValue(0),
                                                reader.GetValue(1).ToString())
                    {
                        id = (int)reader.GetValue(0),
                        name_of = reader.GetValue(1).ToString()
                    });
                }
            }
            return newnew;
        }


    }
}