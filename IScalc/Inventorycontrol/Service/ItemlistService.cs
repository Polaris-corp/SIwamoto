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


        public void RegistrationItemInfo(ItemInfoModel item)
        {
            ExecutionSql(CreateInsertItemInfoSql(item));
        }

        public void UpdateItemInfo(ItemInfoModel item)
        {
            ExecutionSql(CreateUpdateInfoSql(item));
        }

        public void DeleteItemInfo(ItemInfoModel item)
        {
            ExecutionSql(CreateDeleteInfoSql(item));
        }

        public List<string> GetItemName()
        {
            return DataReaderSql(CreateSelectItemNameSql());
        }

        public int GetItemId(ItemInfoModel item)
        {
            return GetIdDataReaderSql(CreateSelectItemIdSql(item));
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
        public List<string> DataReaderSql(MySqlCommand command)
        {
            List<string> items = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionStr))
            {
                command.Connection = connection;

                connection.Open();
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        items.Add(dr["name"].ToString());
                    }
                }
            }
            return items;
        }
        public int GetIdDataReaderSql(MySqlCommand command)
        {
            int id = 0;
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionStr))
            {
                command.Connection = connection;

                connection.Open();
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        id = dr.GetInt32(0);
                    }
                }
            }
            return id;
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

        private MySqlCommand CreateDeleteInfoSql(ItemInfoModel item)
        {
            string query = @"UPDATE 
                                     mitems
                             SET
                                     deleted = true
                             WHERE
                                     id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@id", item.Id);
            return command;
        }

        private MySqlCommand CreateSelectItemNameSql()
        {
            string query = @"SELECT
                                     name
                             FROM
                                     mitems
                             WHERE
                                     deleted = false";
            MySqlCommand command = new MySqlCommand(query);
            return command;
        }

        private MySqlCommand CreateSelectItemIdSql(ItemInfoModel item)
        {
            string query = @"SELECT
                                     id
                             FROM
                                     mitems
                             WHERE
                                     name = @name";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", item.Name);
            return command;
        } 
    }
}
