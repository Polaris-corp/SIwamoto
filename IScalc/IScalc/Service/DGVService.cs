using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;
using IScalc.Common;
using IScalc.Model;

namespace IScalc.Service
{
    public class DGVService
    {
        /// <summary>
        /// 渡されたboolの値をもとにデータベースからデータを取得
        /// </summary>
        /// <param name="deleted">削除されているかどうか(ここでは削除されていないユーザー)</param>
        /// <returns>削除されていないユーザー情報が入ったデータテーブル</returns>
        public DataTable ShowUsersData(bool deleted)
        {
            return CreateDT(CreateDGVSelectSql(deleted));
        }

        /// <summary>
        /// データベースのユーザー情報を削除フラグにかかわらず取得
        /// </summary>
        /// <returns>全件入ったデータテーブル</returns>
        public DataTable ShowAllUserData()
        {
            return CreateDT(CreateGetAllAccountInfoSql());
        }

        /// <summary>
        /// 渡されたboolの値をもとにデータベースからデータを取得
        /// </summary>
        /// <param name="deleted">削除されているかどうか(ここでは削除済みユーザー)</param>
        /// <returns>削除されたユーザー情報が入ったデータテーブル</returns>
        public DataTable ShowDeletedUserData(bool deleted)
        {
            return CreateDT(CreateDGVSelectSql(deleted));
        }

        /// <summary>
        /// 新規登録時のデータテーブルに対するInsertの実行
        /// </summary>
        /// <param name="user">ユーザーが入力したName,Pwd,deleted</param>
        public void InsertAcInfo(UsersModel user)
        {
            ExecutionSql(CreateInsertSql(user));
        }

        /// <summary>
        /// ユーザー情報更新時の削除を実行したときのデータテーブルに対するUpdateの実行
        /// </summary>
        /// <param name="id">ユーザーがデータグリッドビューで選択したユーザー情報のID</param>
        public void DeleteAccountInfo(int id)
        {
            ExecutionSql(CreateAccountDeleteSql(id));
        }

        /// <summary>
        /// ユーザー情報更新時のデータテーブルに対するUpdateの実行
        /// </summary>
        /// <param name="user">ユーザーが入力したName,Pwd,deleted</param>
        public void UpdateAccountInfo(UsersModel user)
        {
            ExecutionSql(CreateAccountUpdateSql(user));
        }

        /// <summary>
        /// データベースに対するクエリ文の実行メソッド
        /// </summary>
        /// <param name="command">クエリ文に基づくコマンド作成メソッドから返された値</param>
        private void ExecutionSql(MySqlCommand command)
        {
            using (MySqlConnection connection = new MySqlConnection(DbConnection.ConnectionString))
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

        /// <summary>
        /// データベースから指定されたデータをデータテーブルに取得するメソッド
        /// </summary>
        /// <param name="command">クエリ文に基づくコマンド作成メソッドから返された値</param>
        /// <returns></returns>
        private DataTable CreateDT(MySqlCommand command)
        {
            using (MySqlConnection connection = new MySqlConnection(DbConnection.ConnectionString))
            {
                command.Connection = connection;
                DataTable dt = new DataTable();
                connection.Open();
                var sda = new MySqlDataAdapter(command);
                sda.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// 引数に応じて削除済みまたはされていないユーザー情報を取得するクエリ文から
        /// コマンドを作成するメソッド
        /// </summary>
        /// <param name="deletedFlg">削除されているかの真偽値</param>
        /// <returns>クエリ文に基づくコマンド</returns>
        private MySqlCommand CreateDGVSelectSql(bool deletedFlg)
        {
            string query = @"SELECT 
                                   ID
                                   , Name
                                   , Pwd
                                   , deleted
                             FROM 
                                   users
                             WHERE 
                                   deleted = @deleted;";

            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@deleted", deletedFlg);
            return command;
        }

        /// <summary>
        /// ユーザー情報を全件取得するクエリ文からコマンドを作成するメソッド
        /// </summary>
        /// <returns>クエリ文に基づくコマンド</returns>
        private MySqlCommand CreateGetAllAccountInfoSql()
        {
            string query = @"SELECT
                                    ID
                                    , Name
                                    , Pwd
                                    , deleted
                             FROM
                                    users;";

            MySqlCommand command = new MySqlCommand(query);
            return command;
        }

        /// <summary>
        /// 新規登録時に必要なName、Pwd、deletedの値を受け取り
        /// テーブルに追加するコマンド作成メソッド
        /// </summary>
        /// <param name="user">ユーザーが入力したName、Pwd、deleted</param>
        /// <returns>クエリ文に基づくコマンド</returns>
        private MySqlCommand CreateInsertSql(UsersModel user)
        {
            string query = @"INSERT INTO
                                 users
                             (
                                 Name
                                 , Pwd
                                 , deleted
                              ) VALUES (
                                 @Name
                                 , @Pwd
                                 , @deleted
                              );";


            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Pwd", user.Pwd);
            command.Parameters.AddWithValue("@deleted", user.Deleted);

            return command;
        }

        /// <summary>
        /// データテーブルに対してアカウントを削除するための削除フラグを立てるコマンド作成メソッド
        /// </summary>
        /// <param name="id">ユーザーが指定したID</param>
        /// <returns>クエリ文に基づくコマンド</returns>
        private MySqlCommand CreateAccountDeleteSql(int id)
        {
            string query = @"UPDATE
                                   users
                             SET
                                   deleted = 1
                             WHERE
                                   ID = @ID;";

            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@ID", id);

            return command;
        }

        /// <summary>
        /// ユーザー情報更新時の指定されたユーザーのName、Pwd、deletedを更新するコマンド作成メソッド
        /// </summary>
        /// <param name="user">ユーザーが指定したIDに紐づいているName、Pwd、deleted</param>
        /// <returns>クエリ文に基づくコマンド</returns>
        private MySqlCommand CreateAccountUpdateSql(UsersModel user)
        {
            string query = @"UPDATE
                                   users
                             SET
                                   Name = @Name
                                   ,Pwd = @Pwd
                                   ,deleted = @deleted
                             WHERE
                                   ID = @ID;";

            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@ID", user.Id);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Pwd", user.Pwd);
            command.Parameters.AddWithValue("@deleted", user.Deleted);
            return command;
        }
    }
}

