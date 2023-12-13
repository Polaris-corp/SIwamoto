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
    public class TownshipService
    {
        public DataTable ResultSearchTownship(string name,bool deleted)
        {
            return Townshiptable(CreateSelectSql(name,deleted));
        }

        public void RegistrationTownship(string name)
        {
            ExecutionSql(CreateInsertTownshipInfoSql(name));
        }

        public void UpdateTownship(TownshipInfoModel info)
        {
            ExecutionSql(CreateUpdateTownshipInfoSql(info));
        }

        public void DeleteTownship(TownshipInfoModel info)
        {
            ExecutionSql(CreateDeleteInfoSql(info));
        }

        public List<string> GetTownshipName()
        {
            return GetNameDataReaderSql(CreateSelectTownshipNameSql());
        }

        public int GetTownshipId(string tName)
        {
            return GetIdDataReaderSql(CreateSelectTownshipIdSql(tName));
        }
        public DataTable Townshiptable(MySqlCommand command)
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

        public List<string> GetNameDataReaderSql(MySqlCommand command)
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
                    while (dr.Read())
                    {
                        id = (int)dr["id"];
                    }
                }
            }
            return id;
        }

        private MySqlCommand CreateSelectSql(string name,bool deleted)
        {
            string query = @"SELECT
                                       id
                                       ,name
                                       ,deleted
                             FROM 
                                       mtownship 
                             WHERE 
                                       deleted = @deleted 
                             AND 
                                       name LIKE @name";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@deleted", deleted);
            command.Parameters.AddWithValue("@name", "%" + name + "%");
            return command;
        }

        private MySqlCommand CreateInsertTownshipInfoSql(string name)
        {
            string query = @"INSERT INTO
                                         mtownship
                                         (name)
                             VALUES
                                         (@name)";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", name);
            return command;
        }

        private MySqlCommand CreateUpdateTownshipInfoSql(TownshipInfoModel info)
        {
            string query = @"UPDATE
                                     mtownship
                             SET
                                     name = @name
                                     ,deleted = @deleted
                             WHERE
                                     id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", info.Name);
            command.Parameters.AddWithValue("@deleted", info.Deleted);
            command.Parameters.AddWithValue("@id", info.Id);
            return command;
        }

        private MySqlCommand CreateDeleteInfoSql(TownshipInfoModel info)
        {
            string query = @"UPDATE
                                      mtownship
                             SET
                                      deleted = true
                             WHERE
                                      id = @id";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@id", info.Id);
            return command;
        }

        private MySqlCommand CreateSelectTownshipNameSql()
        {
            string query = @"SELECT 
                                      name 
                             FROM 
                                      mtownship 
                             WHERE 
                                      deleted = 0";
            MySqlCommand command = new MySqlCommand(query);
            return command;
        }

        private MySqlCommand CreateSelectTownshipIdSql(string tName)
        {
            string query = @"SELECT
                                     id 
                             FROM 
                                     mtownship 
                             WHERE 
                                     name = @name";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", tName);
            return command;
        }
    }
}
