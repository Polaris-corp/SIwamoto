using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IScalc.Service;
using System.Data;


namespace IScalc.Controller
{
    /// <summary>
    /// DGVFormに対するコントローラー
    /// </summary>
    public class DGVController
    {
        DGVService dgvService = new DGVService();

        /// <summary>
        /// ユーザー情報をデータグリッドビューに表示するための
        /// サービス側のメソッドを呼び出す(削除されているまたは削除されていないユーザー)
        /// </summary>
        /// <param name="deleted">削除フラグが立っているかどうか(true = 削除されている)</param>
        /// <returns></returns>
        public DataTable IndicateUsersInfo(bool deleted)
        {
            return dgvService.ShowUsersData(deleted);
        }

        /// <summary>
        /// ユーザー情報を全件データグリッドビューに表示するための
        /// サービス側のメソッドを呼び出す
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllUserInfo()
        {
            return dgvService.ShowAllUserData();
        }
    }
}
