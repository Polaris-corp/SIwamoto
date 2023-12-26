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
        public DataTable ResaultSearchItem(ItemInfoModel item)
        {
            return Itemstable(CreateSelectSql(item));
        }
        public bool RegistrationItemInfo(ItemInfoModel item)
        {
            return ExecutionSql(CreateInsertItemInfoSql(item));
        }
        public bool UpdateItemInfo(ItemInfoModel item)
        {
            return ExecutionSql(CreateUpdateInfoSql(item));
        }
        public List<ItemInfoModel> GetItemInfos()
        {
            return DataReaderItemInfoSql(CreateSelectItemInfoSql());
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
        private bool ExecutionSql(MySqlCommand command)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionStr))
            {
                command.Connection = connection;
                
                connection.Open();
                try
                {
                    return command.ExecuteNonQuery() == 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }
        public List<ItemInfoModel> DataReaderItemInfoSql(MySqlCommand command)
        {
            List<ItemInfoModel> list = new List<ItemInfoModel>();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionStr))
            {
                command.Connection = connection;

                connection.Open();
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ItemInfoModel item = new ItemInfoModel();
                        item.Id = ((int)dr["id"]);
                        item.Name = ((string)dr["name"]);

                        list.Add(item);
                    }
                }
            }
            return list;
        }
        private MySqlCommand CreateSelectSql(ItemInfoModel item)
        {
            string query = @"SELECT
                                     id
                                     ,name
                                     ,deleted
                             FROM
                                     mitems
                             WHERE
                                     deleted = @deleted
                             AND
                                     name
                             LIKE
                                     @name";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", "%" + item.Name + "%");
            command.Parameters.AddWithValue("@deleted", item.Deleted);
            return command;
        }

        private MySqlCommand CreateSelectItemInfoSql()
        {
            string query = @"SELECT
                                     id
                                     ,name
                                     ,deleted
                             FROM
                                     mitems
                             WHERE
                                     deleted = false";
                             
            MySqlCommand command = new MySqlCommand(query);
            return command;
        }
        private MySqlCommand CreateInsertItemInfoSql(ItemInfoModel item)
        {
            string query = @"INSERT INTO 
                                          mitems 
                                          (name)
                                    VALUES
                                          (@name)";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", item.Name);
            return command;
        }

        private MySqlCommand CreateUpdateInfoSql(ItemInfoModel item)
        {
            string query = @"UPDATE
                                     mitems
                             SET
                                     name = @name
                                     ,deleted = @deleted
                             WHERE
                                     id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", item.Name);
            command.Parameters.AddWithValue("@deleted", item.Deleted);
            command.Parameters.AddWithValue("@id", item.Id);
            return command;
        }
    }
}
