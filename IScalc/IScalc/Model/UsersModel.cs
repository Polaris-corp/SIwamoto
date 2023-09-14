using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IScalc.Model
{
    public class UsersModel
    {
        /// <summary>
        /// ユーザーがデータグリッドビューで選択したIDのID,Name,Pwd,deletedを入れるためのモデル
        /// 新規登録時のIDはデータベース側でPrimaryKeyかつAutoIncrementなので空で問題ない
        /// </summary>
        public UsersModel()
        {
            Id = "";
            Name = "";
            Pwd = "";
            Deleted = false;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        public bool Deleted { get; set; }
    }
}
