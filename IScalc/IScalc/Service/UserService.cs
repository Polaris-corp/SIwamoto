using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using IScalc.Common;

namespace IScalc.Service
{
    /// <summary>
    /// usersテーブルに関連する処理クラス
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// ユーザーIDが存在するか確認するメソッド
        /// </summary>
        /// <param name="id">ユーザーが入力したID</param>
        /// <returns>データベース上にIDがあればtrue,なければfalse</returns>
        public bool ExistUsersID(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(DbConnection.ConnectionString))
            {
                    MySqlCommand command = CreateSelectSql(id);
                    command.Connection = connection;
                    
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
            }
            return false;
        }
        /// <summary>
        /// usersIDとPWDが一致するアカウントをチェックして件数を返す
        /// </summary>
        /// <param name="id">ユーザーが入力したID</param>
        /// <param name="pwd">ユーザーが入力したPWD</param>
        /// <returns>IDとPWDが一致する件数は必ず1件になるため、存在したら「1」、無ければ「-1」を返す</returns>
        public int GetUsersAccountCount(int id, string pwd)
        {
            using (MySqlConnection connection = new MySqlConnection(DbConnection.ConnectionString))
            {
                    MySqlCommand command = CreateSelectCountSql(id, pwd);
                    command.Connection = connection;

                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Convert.ToInt32(reader["cnt"]);
                        }
                    }
            }
            return -1;
        }

        




        /// <summary>
        /// usersテーブルに対するSELECT文(クエリ文)(IDが存在するか調べる)を作成するメソッド
        /// </summary>
        /// <param name="id">ユーザーが入力したID</param>
        /// <returns>クエリ文に基づくコマンド</returns>
        private MySqlCommand CreateSelectSql(int id)
        {
            string query = @"SELECT 
                                   ID
                             FROM 
                                   users
                             WHERE
                                   ID = @ID;";

            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@ID", id);
            return command;
        }
        /// <summary>
        /// usersテーブルに対するSELECT文(クエリ文)()
        /// </summary>
        /// <param name="id">ユーザーが入力したID</param>
        /// <param name="pwd">ユーザーが入力したPWD</param>
        /// <returns></returns>
        private MySqlCommand CreateSelectCountSql(int id, string pwd)
        {
            string query = @"SELECT
                                   COUNT(*) AS cnt
                             FROM
                                   users
                             WHERE
                                   ID = @ID
                                   AND Pwd = @Pwd;";

            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@ID", id);
            command.Parameters.AddWithValue("@Pwd", pwd);
            return command;
        }
    }
}
