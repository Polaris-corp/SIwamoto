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
        public DataTable ResultSearchTownship(TownshipInfoModel township)
        {
            return Townshiptable(CreateSelectSql(township));
        }

        public void RegistrationTownship(TownshipInfoModel township)
        {
            ExecutionSql(CreateInsertTownshipInfoSql(township));
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

        public List<int> GetAllTownshipId()
        {
            return GetAllIdDataReaderSql(CreateSelectAllTownshipIdSql());
        }

        public int GetTownshipId(string tName)
        {
            return GetIdDataReaderSql(CreateSelectTownshipIdSql(tName));
        }

        public List<TownshipInfoModel> GetTownshipInfoToCMB()
        {
            return GetTownshipToComboBox(CreateSelectTownshipInfo());
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

        public List<int> GetAllIdDataReaderSql(MySqlCommand command)
        {
            List<int> items = new List<int>();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionStr))
            {
                command.Connection = connection;

                connection.Open();
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        items.Add((int)dr["id"]);
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

        public List<TownshipInfoModel> GetTownshipToComboBox(MySqlCommand command)
        {
            List<TownshipInfoModel> list = new List<TownshipInfoModel>();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionStr))
            {
                command.Connection = connection;

                connection.Open();
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TownshipInfoModel townshipInfo = new TownshipInfoModel();
                        townshipInfo.Id = (int)dr["id"];
                        townshipInfo.Name = (string)dr["name"];

                        list.Add(townshipInfo);
                    }
                }
            }
            return list;
        }
        private MySqlCommand CreateSelectSql(TownshipInfoModel township)
        {
            string query = @"SELECT
                                       id
                                       ,name
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

        private MySqlCommand CreateInsertTownshipInfoSql(TownshipInfoModel township)
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
                             FROM
                                     mtownship
                             WHERE
                                     deleted = false";
            MySqlCommand command = new MySqlCommand(query);
            return command;
        }
    }
}
