using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Inventorycontrol.Common;

namespace Inventorycontrol.Service
{
    public class StatusService
    {
        public void RegistrationStatusInfo(int status)
        {
            ExecutionSql(CreateInsertStatusInfoSql(status));
        }

        public List<int> GetStatusIdList(int count)
        {
            return DataReaderSql(CreateSelectStatusIdSql(count));
        }

        public List<int> DataReaderSql(MySqlCommand command)
        {
            List<int> items = new List<int>();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionStr))
            {
                command.Connection = connection;

                connection.Open();
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        items.Add((int)dr["id"]);
                    }
                }
                connection.Close();
            }
            return items;
        }

        private void ExecutionSql(MySqlCommand command)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionStr))
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
                finally
                {
                    connection.Close();
                }
            }
        }

        private MySqlCommand CreateInsertStatusInfoSql(int status)
        {
            string query = @"INSERT INTO mstatus (status)VALUES (@status)";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@status", status);
            return command;
        }

        private MySqlCommand CreateSelectStatusIdSql(int count)
        {
            string query = @"SELECT id FROM mstatus ORDER BY id DESC LIMIT @count";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@count", count);
            return command;
        }
    }
}
