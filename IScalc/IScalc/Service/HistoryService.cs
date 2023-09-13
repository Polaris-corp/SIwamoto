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
        public void InsertLoginHistory(int usersID, bool results, DateTime tryLoginTime)
        {
            using (MySqlConnection connection = new MySqlConnection(DbConnection.ConnectionString))
            {
                    MySqlCommand command = CreateInsertSql(usersID, results, tryLoginTime);
                    command.Connection = connection;

                    connection.Open();
                    command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 直近3件の中でログインに失敗したログイン時間の最も古い時刻と新しい時刻をHistoryModelのプロパティの値に代入する
        /// </summary>
        /// <param name="usersID"></param>
        /// <returns></returns>
        public HistoryModel CreateDateTimes(int usersID)
        {
            
            using (MySqlConnection connection = new MySqlConnection(DbConnection.ConnectionString))
            {
                HistoryModel historyModel = new HistoryModel();
                MySqlCommand command = CreateSelectSql(usersID);

                command.Connection = connection;
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    historyModel.Count = Convert.ToInt32(reader["cnt"]);
                    historyModel.LatestLogtime = Convert.ToDateTime(reader["maxT"]);
                    historyModel.OldestLogtime = Convert.ToDateTime(reader["minT"]);
                }
                return historyModel;
            }
        }


       
        /// <summary>
        /// インサートのクエリ作成
        /// </summary>
        /// <param name="usersID">ユーザーが入力したID</param>
        /// <param name="results">ログイン結果</param>
        /// <returns>作成したコマンド</returns>
        private MySqlCommand CreateInsertSql(int usersID, bool results, DateTime tryLoginTime)
        {
            string query = @"INSERT INTO 
                                 loginhistory
                             (
                                 usersID
                                 ,logtime
                                 ,results
                              ) VALUES (
                                  @usersID
                                 ,@logtime
                                 ,@results
                              );" ;

            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@usersID", usersID);
            command.Parameters.AddWithValue("@logtime", tryLoginTime);
            command.Parameters.AddWithValue("@results", results);

            return command;
        }


        /// <summary>
        /// ユーザーが入力したIDのログイン履歴直近3件を指定して取得し、
        /// そこから最新のログイン試行時間と最古のログイン試行時間、失敗した回数を取得するクエリ文
        /// に基づくコマンド作成
        /// </summary>
        /// <param name="id">ユーザーが入力したID</param>
        /// <returns>作成したコマンド</returns>
        private MySqlCommand CreateSelectSql(int id)
        {
            string query = @"SELECT
                                    IFNULL(MAX(logtime), CURRENT_TIMESTAMP) AS maxT
                                    , IFNULL(MIN(logtime),CURRENT_TIMESTAMP) AS minT
                                    , COUNT(results) AS cnt 
                             FROM
                                 ( 
                                  SELECT
                                        l.logtime
                                        , l.results
                                  FROM
                                        loginhistory AS l 
                                  WHERE
                                        usersID = @usersID
                                  ORDER BY
                                        logtime DESC 
                                  LIMIT
                                        3
                                 ) AS loghist 
                             WHERE
                                    results = 0;";

            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@usersID", id);

            return command;
        }
    }
}
