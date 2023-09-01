using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using TrainingDataGridView.Common;

namespace TrainingDataGridView.Service
{
    public class UsersService
    {
        public DataTable ShowUsersData(DataTable dt)
        {
            using(MySqlConnection connection = new MySqlConnection(DbConnection.ConnectionString))
            {
                MySqlCommand command = CreateSelectSql();
                command.Connection = connection;
                
                connection.Open();
                var sda = new MySqlDataAdapter(command);
                sda.Fill(dt);
                return dt;
            }
            
        }

        private MySqlCommand CreateSelectSql()
        {
            string query = @"SELECT
                                    * 
                             FROM
                                    users;";

            MySqlCommand command = new MySqlCommand(query);
            return command;
        }
    }
}
