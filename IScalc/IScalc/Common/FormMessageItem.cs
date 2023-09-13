using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IScalc.Common
{
    /// <summary>
    /// Formクラスで使用するメッセージの定数
    /// </summary>
    public static class FormMessageItem
    {
        public const string NotUser = "ID,パスワードが違います。";
        public const string NotInput = "ID,パスワードを入力してください。";
        public const string LoginSucces = "ログイン成功";
        public const string WrongPassword = "ID,パスワードが違います。";
        public const string RemainigTime = "あと{0}でログイン可能です。";
        public const string Warning = "IDは数字で入力してください。";
        public const string AccountFormWarning = "名前及びパスワードを設定してください。";
    }
}
