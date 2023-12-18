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
        public DataTable ResaultSearchWarehouse(WarehouseModel warehouse,string townshipName)
        {
            return Warehousetable(CreateSelectSql(warehouse,townshipName));
        }

        public DataTable SearchWarehouse(int townshipId)
        {
            return Warehousetable(CreateSelectAreaWarehouseSql(townshipId));
        }

        public void InsertWarehouseInfo(WarehouseModel warehouse)
        {
            ExecutionSql(CreateInsertWarehouseInfoSql(warehouse));
        }

        public void UpdateWarehouse(WarehouseModel warehouse)
        {
            ExecutionSql(CreateUpdateWarehouseInfoSql(warehouse));
        }

        public void DeleteWarehouse(WarehouseModel warehouse)
        {
            ExecutionSql(CreateDeleteWarehouseSql(warehouse));
        }

        public List<string> GetAllWarehouseName()
        {
            return DataReaderSql(CreateSelectWarehouseAllInfoSql());
        }
        public int GetWarehouseId(string name)
        {
            return GetIdDataReaderSql(CreateSelectIdSql(name));
        }

        public int GetWarehouseCapacity(int id)
        {
            return GetCapacityDataReaderSql(CreateSelectCapacitySql(id));
        }

        public List<WarehouseModel> GetWarehouseInfo()
        {
            return GetTownshipToComboBox(CreateSelectWarehouseAllInfoSql());
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

        public int GetCapacityDataReaderSql(MySqlCommand command)
        {
            int capacity = 0;
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionStr))
            {
                command.Connection = connection;

                connection.Open();
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        capacity = dr.GetInt32(0);
                    }
                }
            }
            return capacity;
        }

        public List<WarehouseModel> GetTownshipToComboBox(MySqlCommand command)
        {
            List<WarehouseModel> list = new List<WarehouseModel>();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionStr))
            {
                command.Connection = connection;

                connection.Open();
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        WarehouseModel warehouse = new WarehouseModel();
                        warehouse.Id = (int)dr["id"];
                        warehouse.Name = (string)dr["name"];
                        warehouse.Townshipid = (int)dr["townshipid"];
                        warehouse.Capacity = (int)dr["capacity"];
                        warehouse.ActualCapacity = (int)dr["actualcapacity"];
                        warehouse.Deleted = (bool)dr["deleted"];

                        list.Add(warehouse);
                    }
                }
            }
            return list;
        }
        
        private MySqlCommand CreateSelectSql(WarehouseModel warehouse,string townshipName)
        {
            string query = @"SELECT
                                      ware.id
                                      , ware.name
                                      , town.name AS areaname
                                      , ware.capacity
                                      , ware.actualcapacity 
                             FROM
                                      mwarehouse AS ware 
                             LEFT JOIN
                                      mtownship AS town 
                             ON 
                                      ware.townshipid = town.id
                             WHERE 
                                      ware.deleted = @deleted
                             AND
                                      ware.name
                             LIKE
                                      @name
                             AND 
                                      town.name
                             LIKE
                                      @areaname";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@deleted", warehouse.Deleted);
            command.Parameters.AddWithValue("@name", "%" + warehouse.Name + "%");
            command.Parameters.AddWithValue("@areaname", "%" + townshipName + "%");
            return command;
        }

        private MySqlCommand CreateSelectAreaWarehouseSql(int townshipId)
        {
            string query = @"SELECT
                                      ware.id
                                      , ware.name
                                      , town.name AS areaname
                                      , ware.capacity
                                      , ware.actualcapacity 
                             FROM
                                      mwarehouse AS ware 
                             LEFT JOIN
                                      mtownship AS town 
                             ON 
                                      ware.townshipid = town.id 
                             WHERE 
                                     ware.townshipid = @townshipid 
                             AND 
                                     ware.deleted = false";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@townshipid", townshipId);
            return command;
        }

        private MySqlCommand CreateInsertWarehouseInfoSql(WarehouseModel warehouse)
        {
            string query = @"INSERT INTO 
                                     mwarehouse (
                                     name
                                     ,townshipid
                                     ,capacity
                                     ,actualcapacity
                                     ,deleted
                             )VALUES (
                                     @name
                                     ,@townshipid
                                     ,@capacity
                                     ,@actualcapacity
                                     ,false)";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", warehouse.Name);
            command.Parameters.AddWithValue("@townshipid", warehouse.Townshipid);
            command.Parameters.AddWithValue("@capacity", warehouse.Capacity);
            command.Parameters.AddWithValue("@actualcapacity", warehouse.Capacity);
            return command;
        }

        private MySqlCommand CreateUpdateWarehouseInfoSql(WarehouseModel warehouse)
        {
            string query = @"UPDATE
                                     mwarehouse 
                             SET 
                                     name = @name
                                     ,deleted = false
                                     ,townshipid = @townshipid
                                     ,capacity = @capacity 
                             WHERE 
                                     id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", warehouse.Name);
            command.Parameters.AddWithValue("@townshipid", warehouse.Townshipid);
            command.Parameters.AddWithValue("@capacity", warehouse.Capacity);
            command.Parameters.AddWithValue("@id", warehouse.Id);
            return command;
        }

        private MySqlCommand CreateDeleteWarehouseSql(WarehouseModel warehouse)
        {
            string query = @"UPDATE
                                     mwarehouse 
                             SET 
                                     deleted = true 
                             WHERE 
                                     id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@id", warehouse.Id);
            return command;
        }

        private MySqlCommand CreateSelectWarehouseAllInfoSql()
        {
            string query = @"SELECT 
                                     id
                                     ,name
                                     ,townshipid
                                     ,capacity
                                     ,actualcapacity
                                     ,deleted
                             FROM 
                                     mwarehouse 
                             WHERE 
                                     deleted = false";
            MySqlCommand command = new MySqlCommand(query);
            return command;
        }

        private MySqlCommand CreateSelectAllWarehouseNameSql()
        {
            string query = @"SELECT
                                     name 
                             FROM 
                                     mwarehouse 
                             WHERE 
                                     deleted = false";
            MySqlCommand command = new MySqlCommand(query);
            return command;
        }

        private MySqlCommand CreateSelectIdSql(string name)
        {
            string query = @"SELECT
                                     id
                             FROM
                                     mwarehouse
                             WHERE
                                     name = @name";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", name);
            return command;
        }
        private MySqlCommand CreateSelectCapacitySql(int id)
        {
            string query = @"SELECT
                                     capacity
                             FROM
                                     mwarehouse
                             WHERE
                                     id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@id", id);
            return command;
        }
        public MySqlCommand CreateSelectWarehouseInfoSql()
        {
            string query = @"SELECT 
                                     id
                                     ,name
                                     ,townshipid
                             FROM 
                                     mwarehouse 
                             WHERE 
                                     deleted = false";
            MySqlCommand command = new MySqlCommand(query);
            return command;
        }
    }
}
