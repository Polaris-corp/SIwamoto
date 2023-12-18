using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;


namespace Inventorycontrol.Common
{
    public class CheckWarehouseExists
    {
        public bool CheckIfWarehouseNameExists(string inputName)
        {
            string query = @"SELECT COUNT
                                           (*)
                             FROM
                                           mwarehouse
                             WHERE
                                           name = @name";
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionStr))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", inputName);
                    connection.Open();

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0; // もし1つ以上のレコードが存在すればtrueを返す
                }
            }
        }

        public bool CheckIfTownshipIdExists(int id)
        {
            string query = @"SELECT COUNT
                                           (*)
                             FROM
                                           mtownship
                             WHERE
                                           id = @id";
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionStr))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0; // もし1つ以上のレコードが存在すればtrueを返す
                }
            }
        }
    }
}
