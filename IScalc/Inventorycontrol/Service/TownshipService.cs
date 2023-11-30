using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;
using Inventorycontrol.Common;
using Inventorycontrol.Model;

namespace Inventorycontrol.Service
{
    public class TownshipService
    {
        public DataTable ResultSearchTownship(string name)
        {
            return Townshiptable(CreateSelectSql(name));
        }

        public DataTable ResultSearchDeletedTownship(string name)
        {
            return Townshiptable(CreateSelectDeletedSql(name));
        }

        public void RegistrationTownship(string name)
        {
            ExecutionSql(CreateInsertTownshipInfoSql(name));
        }

        public void UpdateTownship(TownshipInfoModel info)
        {
            ExecutionSql(CreateUpdateTownshipInfoSql(info));
        }

        public void DeleteTownship(TownshipInfoModel info)
        {
            ExecutionSql(CreateDeleteInfoSql(info));
        }
        public DataTable Townshiptable(MySqlCommand command)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionStr))
            {
                command.Connection = connection;
                DataTable dt = new DataTable();
                connection.Open();
                var sda = new MySqlDataAdapter(command);
                sda.Fill(dt);
                return dt;
            }
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
            }
        }

        private MySqlCommand CreateSelectSql(string name)
        {
            string query = @"SELECT id,name FROM mtownship WHERE deleted = 0 AND name LIKE @name";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", "%" + name + "%");
            return command;
        }

        private MySqlCommand CreateInsertTownshipInfoSql(string name)
        {
            string query = @"INSERT INTO mtownship (name)VALUES (@name)";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", name);
            return command;
        }

        private MySqlCommand CreateUpdateTownshipInfoSql(TownshipInfoModel info)
        {
            string query = @"UPDATE mtownship SET name = @name,deleted = false WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", info.Name);
            command.Parameters.AddWithValue("@id", info.Id);
            return command;
        }

        private MySqlCommand CreateDeleteInfoSql(TownshipInfoModel info)
        {
            string query = @"UPDATE mtownship SET deleted = true WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@id", info.Id);
            return command;
        }

        private MySqlCommand CreateSelectDeletedSql(string name)
        {
            string query = @"SELECT id,name FROM mtownship WHERE deleted = 1 AND name LIKE @name";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", "%" + name + "%");
            return command;
        }
    }
}
