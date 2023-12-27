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
        public DataTable ResultSearchTownship(TownshipModel township)
        {
            return Townshiptable(CreateSelectSql(township));
        }

        public bool RegistrationTownship(TownshipModel township)
        {
            return ExecutionSql(CreateInsertTownshipInfoSql(township));
        }

        public bool UpdateTownship(TownshipModel info)
        {
            return ExecutionSql(CreateUpdateTownshipInfoSql(info));
        }
        public int GetTownshipId(string tName)
        {
            return GetIdDataReaderSql(CreateSelectTownshipIdSql(tName));
        }

        public List<TownshipModel> GetTownshipInfo()
        {
            return GetTownshipInfoReader(CreateSelectTownshipInfo());
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

        public List<TownshipModel> GetTownshipInfoReader(MySqlCommand command)
        {
            List<TownshipModel> list = new List<TownshipModel>();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionStr))
            {
                command.Connection = connection;

                connection.Open();
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TownshipModel townshipInfo = new TownshipModel();
                        townshipInfo.Id = (int)dr["id"];
                        townshipInfo.Name = (string)dr["name"];
                        townshipInfo.Deleted = (bool)dr["deleted"];

                        list.Add(townshipInfo);
                    }
                }
            }
            return list;
        }
        private MySqlCommand CreateSelectSql(TownshipModel township)
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
            command.Parameters.AddWithValue("@deleted", township.Deleted);
            command.Parameters.AddWithValue("@name", "%" + township.Name + "%");
            return command;
        }

        private MySqlCommand CreateInsertTownshipInfoSql(TownshipModel township)
        {
            string query = @"INSERT INTO
                                         mtownship
                                         (name)
                             VALUES
                                         (@name)";
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@name", township.Name);
            return command;
        }

        private MySqlCommand CreateUpdateTownshipInfoSql(TownshipModel info)
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

        private MySqlCommand CreateDeleteInfoSql(TownshipModel info)
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

        private MySqlCommand CreateSelectAllTownshipIdSql()
        {
            string query = @"SELECT
                                     id
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

        private MySqlCommand CreateSelectTownshipInfo()
        {
            string query = @"SELECT 
                                     id
                                     ,name
                                     ,deleted
                             FROM
                                     mtownship";
            MySqlCommand command = new MySqlCommand(query);
            return command;
        }
    }
}
