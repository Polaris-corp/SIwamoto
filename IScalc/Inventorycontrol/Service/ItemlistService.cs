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

        public void RegistrationItemInfo(string name,int count)
        {
            ExecutionSql(CreateInsertItemInfoSql(name,count));
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
            string query = @"SELECT id,name,count FROM mitems WHERE deleted = 0 AND name LIKE @name";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", "%" + item + "%");
            return command;
        }

        private MySqlCommand CreateInsertItemInfoSql(string name,int count)
        {
            string query = @"INSERT INTO mitems (name,count)VALUES (@name,@count)";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@count", count);
            return command;
        }

        private MySqlCommand CreateUpdateInfoSql(ItemInfoModel item)
        {
            string query = @"UPDATE mitems SET count = @count WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@count", item.Count);
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
