using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Inventorycontrol.Common;
using Inventorycontrol.Model;


namespace Inventorycontrol.Service
{
    public class StatusService
    {
        public List<StatusModel> GetStatuses()
        {
            return DataReaderStatusSql(CreateSelectStatusSql());
        }
        public List<StatusModel> DataReaderStatusSql(MySqlCommand command)
        {
            List<StatusModel> list = new List<StatusModel>();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionStr))
            {
                command.Connection = connection;

                connection.Open();
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        StatusModel status = new StatusModel();
                        status.Id = ((int)dr["id"]);
                        status.Status = ((string)dr["status"]);

                        list.Add(status);
                    }
                }
                connection.Close();
            }
            return list;
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
                finally
                {
                    connection.Close();
                }
            }
        }


        private MySqlCommand CreateSelectStatusSql()
        {
            string query = @"SELECT 
                                     id
                                     ,status
                             FROM
                                     mstatus_alternative";
            MySqlCommand command = new MySqlCommand(query);
            return command;
        }
    }
}
