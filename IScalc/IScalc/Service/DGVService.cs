using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;
using IScalc.Common;
using IScalc.Model;

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

        public void InsertAcInfo(UsersModel user)
        {
            ExecutionSql(CreateInsertSql(user));
        }

        public void DeleteAccountInfo(int id)
        {
            ExecutionSql(CreateAccountDeleteSql(id));
        }

        public void UpdateAccountInfo(UsersModel user)
        {
            ExecutionSql(CreateAccountRestorationSql(user));
        }

        private void ExecutionSql(MySqlCommand command)
        {
            using (MySqlConnection connection = new MySqlConnection(DbConnection.ConnectionString))
            {
                command.Connection = connection;

                connection.Open();
                try 
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
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
                                   , deleted
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

        private MySqlCommand CreateInsertSql(UsersModel user)
        {
            string query = @"INSERT INTO
                                 users
                             (
                                 Name
                                 , Pwd
                                 , deleted
                              ) VALUES (
                                 @Name
                                 , @Pwd
                                 , @deleted
                              );";


            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Pwd", user.Pwd);
            command.Parameters.AddWithValue("@deleted", user.Deleted);

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

        private MySqlCommand CreateAccountRestorationSql(UsersModel user)
        {
            string query = @"UPDATE
                                   users
                             SET
                                   Name = @Name
                                   ,Pwd = @Pwd
                                   ,deleted = @deleted
                             WHERE
                                   ID = @ID;";

            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@ID", user.Id);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Pwd", user.Pwd);
            command.Parameters.AddWithValue("@deleted", user.Deleted);
            return command;
        }
    }
}

