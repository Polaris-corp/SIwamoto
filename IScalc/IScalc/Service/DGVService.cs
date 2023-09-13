using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;
using IScalc.Common;

namespace IScalc.Service
{
    public class DGVService
    {
        public DataTable ShowUsersData(bool arrive)
        {
            return CreateDT(CreateDGVSelectSql(arrive));
        }

        public DataTable ShowAllUserData()
        {
            return CreateDT(CreateGetAllAccountInfoSql());
        }

        public DataTable ShowDeletedUserData(bool deleted)
        {
            return CreateDT(CreateDGVSelectSql(deleted));
        }

        public void InsertAcInfo(string name, string pwd)
        {
            ExecutionSql(CreateInsertSql(name, pwd));
        }

        public void UpdateAccountInfo(int id, string name, string pwd)
        {
            ExecutionSql(CreateUpdateSql(id, name, pwd));
        }

        public void DeleteAccountInfo(int id)
        {
            ExecutionSql(CreateAccountDeleteSql(id));
        }

        public void RestorationAccountInfo(int id)
        {
            ExecutionSql(CreateAccountRestorationSql(id));
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

        private DataTable CreateDT(MySqlCommand command)
        {
            using (MySqlConnection connection = new MySqlConnection(DbConnection.ConnectionString))
            {
                command.Connection = connection;
                DataTable dt = new DataTable();
                connection.Open();
                var sda = new MySqlDataAdapter(command);
                sda.Fill(dt);
                return dt;
            }
        }

        private MySqlCommand CreateDGVSelectSql(bool deletedFlg)
        {
            string query = @"SELECT 
                                   ID
                                   , Name
                                   , Pwd
                             FROM 
                                   users
                             WHERE 
                                   deleted = @deleted;";

            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@deleted", deletedFlg);
            return command;
        }

       

        private MySqlCommand CreateGetAllAccountInfoSql()
        {
            string query = @"SELECT
                                    ID
                                    , Name
                                    , Pwd
                                    , deleted
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
                                 , Pwd
                              ) VALUES (
                                 @Name
                                 , @Pwd
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

        private MySqlCommand CreateAccountDeleteSql(int id)
        {
            string query = @"UPDATE
                                   users
                             SET
                                   deleted = 1
                             WHERE
                                   ID = @ID;";

            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@ID", id);

            return command;
        }

        private MySqlCommand CreateAccountRestorationSql(int id)
        {
            string query = @"UPDATE
                                   users
                             SET
                                   deleted = 0
                             WHERE
                                   ID = @ID;";

            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@ID", id);

            return command;
        }
    }
}

