using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data;
using Inventorycontrol.Model;
using Inventorycontrol.Common;

namespace Inventorycontrol.Service
{
    public class WarehouseService
    {
        public DataTable ResaultSearchWarehouse(string name)
        {
            return Warehousetable(CreateSelectSql(name));
        }

        public DataTable ResaultSearchDeletedWarehouse(string name)
        {
            return Warehousetable(CreateSelectdeletedSql(name));
        }

        public void InsertWarehouseInfo(string name,int townshipId,int capacity)
        {
            ExecutionSql(CreateInsertWarehouseInfoSql(name,townshipId,capacity));
        }

        public void UpdateWarehouse(WarehouseModel warehouse)
        {
            ExecutionSql(CreateUpdateWarehouseInfoSql(warehouse));
        }

        public void DeleteWarehouse(WarehouseModel warehouse)
        {
            ExecutionSql(CreateDeleteWarehouseSql(warehouse));
        }

        public List<string> GetWarehouseName(int id)
        {
            return DataReaderSql(CreateSelectWarehouseNameSql(id));
        }

        public int GetWarehouseId(string name)
        {
            return GetIdDataReaderSql(CreateSelectIdSql(name));
        }

        public DataTable Warehousetable(MySqlCommand command)
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
        private MySqlCommand CreateSelectSql(string item)
        {
            string query = @"SELECT id,name,townshipid,capacity FROM mwarehouse WHERE deleted = 0 AND name LIKE @name";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", "%" + item + "%");
            return command;
        }

        private MySqlCommand CreateSelectdeletedSql(string item)
        {
            string query = @"SELECT id,name,townshipid,capacity FROM mwarehouse WHERE deleted = 1 AND name LIKE @name";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", "%" + item + "%");
            return command;
        }

        private MySqlCommand CreateInsertWarehouseInfoSql(string name,int townshipId,int capacity)
        {
            string query = @"INSERT INTO mwarehouse (name,townshipid,capacity)VALUES (@name,@townshipid,@capacity)";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@townshipid", townshipId);
            command.Parameters.AddWithValue("@capacity", capacity);
            return command;
        }

        private MySqlCommand CreateUpdateWarehouseInfoSql(WarehouseModel warehouse)
        {
            string query = @"UPDATE mwarehouse SET name = @name,deleted = false,townshipid = @townshipid,capacity = @capacity WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", warehouse.Name);
            command.Parameters.AddWithValue("@townshipid", warehouse.Townshipid);
            command.Parameters.AddWithValue("@capacity", warehouse.Capacity);
            command.Parameters.AddWithValue("@id", warehouse.Id);
            return command;
        }

        private MySqlCommand CreateDeleteWarehouseSql(WarehouseModel warehouse)
        {
            string query = @"UPDATE mwarehouse SET deleted = true WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@id", warehouse.Id);
            return command;
        }

        private MySqlCommand CreateSelectWarehouseNameSql(int id)
        {
            string query = @"SELECT name FROM mwarehouse WHERE townshipid = @townshipid";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@townshipid", id);
            return command;
        }

        private MySqlCommand CreateSelectIdSql(string name)
        {
            string query = @"SELECT id FROM mwarehouse WHERE name = @name";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", name);
            return command;
        }
    }
}
