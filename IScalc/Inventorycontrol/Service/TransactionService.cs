using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Inventorycontrol.Common;
using System.Data;

namespace Inventorycontrol.Service
{
    public class TransactionService
    {
        public void RegistrationInfo(DateTime schedule,int quantity,int townshipId ,int warehouseId,int stId,int itemId,string itemName)
        {
            ExecutionSql(CreateInsertInfoSql(schedule, quantity,townshipId, warehouseId, stId, itemId, itemName));
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

        public MySqlCommand CreateInsertInfoSql(DateTime schedule, int quantity,int townshipId, int warehouseId, int stId, int itemId, string itemName)
        {
            string query = @"INSERT INTO 
                                         ttransaction (
                                                           schedule
                                                          ,itemquantity
                                                          ,townshipid
                                                          ,warehouseid
                                                          ,statusid
                                                          ,itemid
                                                          ,itemname
                                  ) VALUES (
                                                          @schedule
                                                         ,@itemquantity
                                                         ,@townshipid
                                                         ,@warehouseid
                                                         ,@statusid
                                                         ,@itemid
                                                         ,@itemname)";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@schedule", schedule);
            command.Parameters.AddWithValue("@itemquantity", quantity);
            command.Parameters.AddWithValue("@townshipid", townshipId);
            command.Parameters.AddWithValue("@warehouseid", warehouseId);
            command.Parameters.AddWithValue("@statusid", stId);
            command.Parameters.AddWithValue("@itemid", itemId);
            command.Parameters.AddWithValue("@itemname", itemName);
            return command;
        }

        public MySqlCommand CreateSelectInfoSql(string name, DateTime start, DateTime end, int townshipId, int warehouseId, int statusId)
        {
            string query = @"SELECT id
                                    ,schedule
                                    ,itemquantity
                                    ,townshipid
                                    ,warehouseid
                                    ,statusid
                                    ,itemname
                             FROM ttransaction 
                             WHERE 
                                    schedule BETWEEN @start AND @end";
            
            if(0 < townshipId)
            {
                query += " AND townshipid = @townshipid ";
            }
            if (0 < warehouseId)
            {
                query += " AND warehouseid = @warehouseid ";
            }
            if (0 < statusId)
            {
                query += " AND statusid = @statusid ";
            }
            query += " AND itemname LIKE @name";
            MySqlCommand command = new MySqlCommand(query);
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
