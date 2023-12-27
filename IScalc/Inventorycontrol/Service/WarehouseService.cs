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
        public DataTable ResaultSearchWarehouse(WarehouseModel warehouse)
        {
            return Warehousetable(CreateSelectSql(warehouse));
        }

        public DataTable SearchWarehouse(int townshipId)
        {
            return Warehousetable(CreateSelectAreaWarehouseSql(townshipId));
        }

        public bool InsertWarehouseInfo(WarehouseModel warehouse)
        {
           return ExecutionSql(CreateInsertWarehouseInfoSql(warehouse));
        }

        public bool UpdateWarehouse(WarehouseModel warehouse)
        {
            return ExecutionSql(CreateUpdateWarehouseInfoSql(warehouse));
        }

        public void DeleteWarehouse(WarehouseModel warehouse)
        {
            ExecutionSql(CreateDeleteWarehouseSql(warehouse));
        }
        public void UpdateWarehouseActualCap(int cap,int id)
        {
            ExecutionSql(UpdateActualCapSql(cap, id));
        }
        public int GetWarehouseActualCap(int id)
        {
            return GetCapacityDataReaderSql(CreateSelectCapacitySql(id));
        }

        public List<WarehouseModel> GetWarehouseList()
        {
            return GetWarehouseInfoList(CreateSelectWarehouseAllInfoSql());
        }

        public WarehouseModel GetWarehouse(ScheduleModel schedule)
        {
            return GetWarehouseInfo(SelectActualCapacity(schedule));
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

        public List<WarehouseModel> GetWarehouseInfoList(MySqlCommand command)
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

        public WarehouseModel GetWarehouseInfo(MySqlCommand command)
        {
            WarehouseModel warehouse = new WarehouseModel();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionStr))
            {
                command.Connection = connection;

                connection.Open();
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.Read())
                    { 
                        warehouse.Id = (int)dr["id"];
                        warehouse.Name = (string)dr["name"];
                        warehouse.Townshipid = (int)dr["townshipid"];
                        warehouse.Capacity = (int)dr["capacity"];
                        warehouse.ActualCapacity = (int)dr["actualcapacity"];
                        warehouse.Deleted = (bool)dr["deleted"];
                    }
                }
            }
            return warehouse;
        }
        
        private MySqlCommand CreateSelectSql(WarehouseModel warehouse)
        {
            string query = @"SELECT
                                      ware.id
                                      , ware.name
                                      , town.name AS areaname
                                      , ware.capacity
                                      , ware.actualcapacity 
                                      , ware.deleted
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
                                      @name";
                            
            if(warehouse.Townshipid != -1)
            {
                query += " AND ware.townshipid = @townshipid";
            }
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@deleted", warehouse.Deleted);
            command.Parameters.AddWithValue("@name", "%" + warehouse.Name + "%");
            if (warehouse.Townshipid != -1)
            {
                command.Parameters.AddWithValue("@townshipid", warehouse.Townshipid);
            }
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
                                     ,deleted = @deleted
                             WHERE 
                                     id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", warehouse.Name);
            command.Parameters.AddWithValue("@townshipid", warehouse.Townshipid);
            command.Parameters.AddWithValue("@capacity", warehouse.Capacity);
            command.Parameters.AddWithValue("@deleted", warehouse.Deleted);
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
                                     actualcapacity
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
        private MySqlCommand SelectActualCapacity(ScheduleModel schedule)
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
                                     id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@id", schedule.Warehouseid);
            return command;
        }
        private MySqlCommand UpdateActualCapSql(int cap,int id)
        {
            string query = @"UPDATE
                                      mwarehouse
                             SET
                                      actualcapacity = @actualcapacity
                             WHERE
                                      id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@actualcapacity", cap);
            command.Parameters.AddWithValue("@id", id);
            return command;
        }
    }
}
