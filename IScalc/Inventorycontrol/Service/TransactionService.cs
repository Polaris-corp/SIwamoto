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
        public void RegistrationInfo(DateTime schedule,int quantity,int warehouseId,int stId,int itemId,string itemName)
        {
            ExecutionSql(CreateInsertInfoSql(schedule, quantity, warehouseId, stId, itemId, itemName));
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

        public MySqlCommand CreateInsertInfoSql(DateTime schedule, int quantity, int warehouseId, int stId, int itemId, string itemName)
        {
            string query = @"INSERT INTO 
                                         ttransaction (
                                                           schedule
                                                          ,itemquantity
                                                          ,warehouseid
                                                          ,statusid
                                                          ,itemid
                                                          ,itemname
                                  ) VALUES (
                                                          @schedule
                                                         ,@itemquantity
                                                         ,@warehouseid
                                                         ,@statusid
                                                         ,@itemid
                                                         ,@itemname)";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@schedule", schedule);
            command.Parameters.AddWithValue("@itemquantity", quantity);
            command.Parameters.AddWithValue("@warehouseid", warehouseId);
            command.Parameters.AddWithValue("@statusid", stId);
            command.Parameters.AddWithValue("@itemid", itemId);
            command.Parameters.AddWithValue("@itemname", itemName);
            return command;
        }
    }
}
