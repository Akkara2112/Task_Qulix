using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Task_Qulix.Models;

namespace Task_Qulix.logic
{
    public class Deletes
    {
        string connectionString = @"Data Source=SQL6002.site4now.net;Initial Catalog=DB_A43234_mydb;User Id=DB_A43234_mydb_admin;Password=3258131s;";
        //метод для удаления строки из базы данных
        public void DelStr(int id, string table)
        {
            string sqlExpression = $"DELETE FROM {table} WHERE id = {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }
            

        }
    }
}