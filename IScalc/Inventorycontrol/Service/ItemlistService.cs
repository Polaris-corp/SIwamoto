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
    class ItemlistService
    {
        public DataTable ResaultSearchItem(string item)
        {
            return Itemstable(CreateSelectSql(item));
        }

        public DataTable ResaultSearchDeletedItem(string item)
        {
            return Itemstable(CreateSelectdeletedSql(item));
        }

        public void RegistrationItemInfo(string name)
        {
            ExecutionSql(CreateInsertItemInfoSql(name));
        }

        public void UpdateItemInfo(ItemInfoModel item)
        {
            ExecutionSql(CreateUpdateInfoSql(item));
        }

        public void DeleteItemInfo(ItemInfoModel item)
        {
            ExecutionSql(CreateDeleteInfoSql(item));
        }
        public DataTable Itemstable(MySqlCommand command)
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

        private MySqlCommand CreateSelectSql(string item)
        {
            string query = @"SELECT id,name FROM mitems WHERE deleted = 0 AND name LIKE @name";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", "%" + item + "%");
            return command;
        }

        private MySqlCommand CreateSelectdeletedSql(string item)
        {
            string query = @"SELECT id,name FROM mitems WHERE deleted = 1 AND name LIKE @name";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", "%" + item + "%");
            return command;
        }
        private MySqlCommand CreateInsertItemInfoSql(string name)
        {
            string query = @"INSERT INTO mitems (name)VALUES (@name)";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", name);
            return command;
        }

        private MySqlCommand CreateUpdateInfoSql(ItemInfoModel item)
        {
            string query = @"UPDATE mitems SET name = @name,deleted = false WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", item.Name);
            command.Parameters.AddWithValue("@id", item.Id);
            return command;
        }

        private MySqlCommand CreateDeleteInfoSql(ItemInfoModel item)
        {
            string query = @"UPDATE mitems SET deleted = true WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@id", item.Id);
            return command;
        }
    }
}
