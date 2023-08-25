using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IScalc.Common
{
    /// <summary>
    /// Formクラスで使用する定数
    /// </summary>
    public static class FormItem
    {
        public const string NOT_USER = "ユーザーが存在しません。";
        public const string NOT_INPUT = "ID,パスワードを入力してください。";
        public const string LOGIN_SUCCES = "ログイン成功";
        public const string WRONG_PWD = "パスワードが違います。";
        public const string REMAINING_TIME = "あと{0}でログイン可能です。";

        //ログイン結果
        public const bool OK = true;
        public const bool NG = false;
    }
}
