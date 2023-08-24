using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IScalc.Common;
using IScalc.Model;

namespace IScalc.Service
{
    public class HistoryService
    {
        /// <summary>
        /// Historyテーブルへのインサートの実行
        /// </summary>
        /// <param name="usersID">UserID</param>
        /// <param name="results">ログイン可否</param>
        public bool InsertLoginHistory(string usersID, bool results)
        {
            using (MySqlConnection connection = new MySqlConnection(DbConnection.connectionString))
            {
                try
                {
                    MySqlCommand command = CreateInsertSql(usersID, results);
                    command.Connection = connection;

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch(Exception ex) 
                {
                    return false;
                    throw;
                }
            }
        }
        /// <summary>
        /// ログインに失敗した直近3件のログイン時間をリストに追加
        /// </summary>
        /// <param name="usersID"></param>
        /// <returns>生成したリスト</returns>
        public List<HistoryModel> CreateDateTimes(string usersID)
        {
            List<HistoryModel> logtimesList = new List<HistoryModel>();
            using (MySqlConnection connection = new MySqlConnection(DbConnection.connectionString))
            {
                try
                {
                    MySqlCommand command = CreateSelectSql(usersID);
                    command.Connection = connection;

                    connection.Open();
                    var reader =  command.ExecuteReader();
                    while (reader.Read())
                    {
                        HistoryModel m = new HistoryModel();
                        m.Logtime = Convert.ToDateTime(reader["logtime"]);
                        m.Results = Convert.ToBoolean(reader["results"]);
                        if(!m.Results)
                        {
                            logtimesList.Add(m);
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw;
                }
                return logtimesList;
            }
        }


       
        /// <summary>
        /// インサートのクエリ作成
        /// </summary>
        /// <param name="usersID">ユーザーが入力したID</param>
        /// <param name="results">ログイン結果</param>
        /// <returns>作成したコマンド</returns>
        private MySqlCommand CreateInsertSql(string usersID, bool results)
        {
            string query = "INSERT INTO loginhistory ("
                      + " usersID"
                      + " ,logtime"
                      + " ,results"
                      + ") VALUES ("
                      + " @usersID"
                      + " ,@logtime"
                      + " ,@results"
                      + " )";

            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@usersID", usersID);
            command.Parameters.AddWithValue("@logtime", DateTime.Now);
            command.Parameters.AddWithValue("@results", results);

            return command;
        }


        /// <summary>
        /// ユーザーが入力したIDのログイン履歴直近3件を指定して取得するクエリ文
        /// に基づくコマンド作成
        /// </summary>
        /// <param name="id">ユーザーが入力したID</param>
        /// <returns>作成したコマンド</returns>
        private MySqlCommand CreateSelectSql(string id)
        {
            string query = "SELECT"
                         + " logtime"
                         + ",results"
                         + " FROM loginhistory"
                         + " WHERE usersID = @usersID"
                         + " ORDER BY logtime DESC"
                         + " LIMIT 3"
                         + " ;";
            
            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@usersID", id);

            return command;
        }
    }
}
