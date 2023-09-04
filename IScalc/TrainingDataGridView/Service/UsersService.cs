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
        public DataTable ShowUsersData()
        {
            using(MySqlConnection connection = new MySqlConnection(DbConnection.ConnectionString))
            {
                MySqlCommand command = CreateDGVSelectSql();
                command.Connection = connection;
                DataTable dt = new DataTable();
                connection.Open();
                var sda = new MySqlDataAdapter(command);
                sda.Fill(dt);
                return dt;
            }
            
        }

        public void InsertAcInfo(string name, string pwd)
        {
            ExecutionSql(CreateInsertSql(name, pwd));
        }

        public void UpdateAccountInfo(int id, string name, string pwd)
        {
            ExecutionSql(CreateUpdateSql(id, name, pwd));
        }

        private void ExecutionSql(MySqlCommand command)
        {
            using (MySqlConnection connection = new MySqlConnection(DbConnection.ConnectionString))
            {
                command.Connection = connection;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private MySqlCommand CreateDGVSelectSql()
        {
            string query = @"SELECT
                                    * 
                             FROM
                                    users;";

            MySqlCommand command = new MySqlCommand(query);
            return command;
        }

        private MySqlCommand CreateInsertSql(string name, string pwd)
        {
            string query = @"INSERT INTO
                                 users
                             (
                                 Name
                                 ,Pwd
                              ) VALUES (
                                 @Name
                                 ,@Pwd
                              );";


            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Pwd", pwd);

            return command;
        }

       private MySqlCommand CreateUpdateSql(int id, string name, string pwd)
        {
            string query = @"UPDATE 
                                 users 
                             SET
                                 Name = @Name
                                 , Pwd = @Pwd 
                             WHERE
                                 ID = @ID;";

            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@ID", id);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Pwd", pwd);

            return command;
        }
    }
}
