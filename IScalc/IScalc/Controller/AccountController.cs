using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IScalc.Service;
using System.Data;
using IScalc.Model;

namespace IScalc.Controller
{
    public class AccountController
    {
        
        DGVService dgvService = new DGVService();
        
        /// <summary>
        /// 新規ユーザー情報をデータベースに登録する指示
        /// </summary>
        /// <param name="user"></param>
        public void InsertAccountInfo(UsersModel user)
        {
            dgvService.InsertAcInfo(user);
        }

        /// <summary>
        /// 選択されたユーザーの削除フラグを立てる指示
        /// </summary>
        /// <param name="id">ユーザーが選択したユーザーID</param>
        public void DeleteAccountInfo(int id)
        {
            dgvService.DeleteAccountInfo(id);
        }

        /// <summary>
        /// 選択されたユーザーの情報更新の指示
        /// </summary>
        /// <param name="user">ユーザーが入力したName,Pwd,deleted</param>
        public void UpdateAccountInfo(UsersModel user)
        {
            dgvService.UpdateAccountInfo(user);
        }

        /// <summary>
        /// ユーザー情報の全件表示指示
        /// </summary>
        /// <returns>ユーザー情報が全件表示されるデータテーブル</returns>
        public DataTable GetAllUserInfo()
        {
            return dgvService.ShowAllUserData();
        }

        /// <summary>
        /// 削除済みユーザー情報の表示指示
        /// </summary>
        /// <param name="deleted">削除フラグ</param>
        /// <returns>削除フラグが立っているユーザー情報が表示されるデータテーブル</returns>
        public DataTable GetDeletedUserInfo(bool deleted)
        {
            return dgvService.ShowDeletedUserData(deleted);
        }

        /// <summary>
        /// 削除されていないユーザー情報の表示指示
        /// </summary>
        /// <param name="deleted">削除フラグ</param>
        /// <returns>削除フラグが立っていないユーザー情報が表示されるデータテーブル</returns>
        public DataTable GetUserInfo(bool deleted)
        {
            return dgvService.ShowUsersData(deleted);
        }
    }
}
