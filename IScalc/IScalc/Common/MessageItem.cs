using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IScalc.Common
{
    /// <summary>
    /// ログイン画面に出力したいメッセージ
    /// </summary>
    public static class MessageItem
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
