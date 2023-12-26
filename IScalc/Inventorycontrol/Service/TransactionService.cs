using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Inventorycontrol.Common;
using System.Data;
using Inventorycontrol.Model;

namespace Inventorycontrol.Service
{
    public class TransactionService
    {
        public void RegistrationInfo(ScheduleModel schedules)
        {
            ExecutionSql(CreateInsertInfoSql(schedules));
        }

        public DataTable SearchTranasctionInfo(string name, DateTime start, DateTime end, int townshipId, int warehouseId, int statusId)
        {
            return Transactiontable(CreateSelectInfoSql(name,start,end,townshipId,warehouseId,statusId));
        }

        public DataTable Transactiontable(MySqlCommand command)
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

        public void ExecutionSql(MySqlCommand command)
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

        public MySqlCommand CreateInsertInfoSql(ScheduleModel schedules)
        {
            string query = @"INSERT INTO 
                                         ttransaction (
                                                           schedule
                                                          ,itemquantity
                                                          ,townshipid
                                                          ,warehouseid
                                                          ,statusid
                                                          ,itemid
                                  ) VALUES (
                                                          @schedule
                                                         ,@itemquantity
                                                         ,@townshipid
                                                         ,@warehouseid
                                                         ,@statusid
                                                         ,@itemid)";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@schedule", schedules.Schedule);
            command.Parameters.AddWithValue("@itemquantity", schedules.Itemquantity);
            command.Parameters.AddWithValue("@townshipid", schedules.Townshipid);
            command.Parameters.AddWithValue("@warehouseid", schedules.Warehouseid);
            command.Parameters.AddWithValue("@statusid", schedules.Statusid);
            command.Parameters.AddWithValue("@itemid", schedules.Itemid);
            return command;
        }
        public MySqlCommand CreateUpDateSql(ScheduleModel schedule)
        {
            string query = @"UPDATE 
                                     ttransaction
                             SET 
                                     schedule = @schedule
                                     ,itemquantity = @itemquantity
                                     ,deleted = @deleted
                             WHERE 
                                     id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@schedule", schedule.Schedule);
            command.Parameters.AddWithValue("@itemquantity",schedule.Itemquantity);
            command.Parameters.AddWithValue("@deleted",schedule.Deleted);
            command.Parameters.AddWithValue("@id",schedule.Id);
            return command;
        }
        public MySqlCommand CreateSelectInfoSql(string name, DateTime start, DateTime end, int townshipId, int warehouseId, int statusId)
        {
            string query = @"SELECT 
                                    tran.id
                                    ,tran.schedule
                                    ,tran.itemquantity
                                    ,town.id AS areaid
                                    ,ware.id AS warehouseid
                                    ,status.id AS statusid
                                    ,item.id AS itemid
                                    ,tran.deleted
                             FROM 
                                    ttransaction AS tran 
                             LEFT JOIN 
                                    mtownship AS town 
                             ON 
                                    tran.townshipid = town.id 
                             LEFT JOIN 
                                    mwarehouse AS ware 
                             ON 
                                    tran.warehouseid = ware.id 
                             LEFT JOIN 
                                    mstatus_alternative AS status
                             ON 
                                    tran.statusid = status.id
                             LEFT JOIN 
                                    mitems AS item
                             ON
                                    tran.itemid = item.id
                             WHERE 
                                    schedule
                             BETWEEN 
                                    @start AND @end 
                             AND
                                    tran.deleted = false";
            
            if(0 < townshipId)
            {
                query += " AND town.id = @townshipid ";
            }
            if (0 < warehouseId)
            {
                query += " AND ware.id = @warehouseid ";
            }
            if (0 < statusId)
            {
                query += " AND status.id = @statusid ";
            }
            query += " AND item.name LIKE @name";
            query += " ORDER BY tran.schedule";
            MySqlCommand command = new MySqlCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@start", start);
            command.Parameters.AddWithValue("@end", end);
            if (0 < townshipId)
            {
                command.Parameters.AddWithValue("@townshipid", townshipId);
            }
            if (0 < warehouseId)
            {
                command.Parameters.AddWithValue("@warehouseid", warehouseId);
            }
            if (0 < statusId)
            {
                command.Parameters.AddWithValue("@statusid", statusId);
            }
            command.Parameters.AddWithValue("@name", "%" + name + "%");
            return command;
        }

        
    }
}
