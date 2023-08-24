using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IScalc.Service;
using IScalc.Model;

namespace IScalc.Controller
{
    /// <summary>
    /// ログイン画面とUser,Historyサービスを仲介するクラス
    /// </summary>
    public class LoginController
    {
        HistoryService historyService = new HistoryService();
        UserService userService = new UserService();

        /// <summary>
        /// ユーザーIDの確認
        /// </summary>
        /// <param name="id">ユーザーが入力したID</param>
        /// <returns>ユーザーIDがあるか(true, false)</returns>
        public bool CheckUsersID(string id)
        {
            return userService.ExistUsersID(id);
        }

        /// <summary>
        /// IDとPWの紐づきデータの確認
        /// </summary>
        /// <param name="id">ユーザーが入力したID</param>
        /// <param name="pwd">ユーザーが入力したPWD</param>
        /// <returns>紐づきデータがあれば「true」無ければ「false」</returns>
        public bool Check_account(string id, string pwd)
        {
            return userService.GetUsersAccountCount(id, pwd) == 1;
        }

        /// <summary>
        /// ログイン履歴をデータベースに追加する
        /// </summary>
        /// <param name="id">ユーザーが入力したID</param>
        /// <param name="res">ログイン結果</param>
        /// <returns></returns>
        public bool Insert_Hisotry(string id ,bool res)
        {
            return historyService.InsertLoginHistory(id, res);
        }

        /// <summary>
        /// 直近3件ログイン履歴のチェック
        /// </summary>
        /// <param name="id"></param>
        /// <returns>直近3件で連続してログイン失敗した場合の
        /// ログイン試行した時間3件を追加したリスト</returns>
        public List<HistoryModel> Check_3_Login_History(string id)
        {
            return historyService.CreateDateTimes(id);
                
        }

        /// <summary>
        /// 3回連続で間違えているか、間違えていた場合その間隔が3分以内かの判定
        /// </summary>
        /// <param name="logtimesList">直近3件のログイン失敗した時間のリスト(昇順)</param>
        /// <returns>どちらの条件も満たしていたら「false」それ以外は「true」</returns>
        public bool Check_Logtime(List<HistoryModel> logtimesList)
        {
            if(logtimesList.Count != 3)
            {
                return true;
            }
            
            var ok = false;
            foreach (var item in logtimesList)
            {
                ok |= item.Results;
            }
            if (ok)
            {
                return true;
            }

            TimeSpan timeSpan = logtimesList[0].Logtime - logtimesList[2].Logtime;
            if(3 < timeSpan.TotalMinutes)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 最後にログインに失敗してアカウントがロックされてから5分経過しているかの判定
        /// </summary>
        /// <param name="logtimesList"></param>
        /// <returns></returns>
        public bool Check_Last5Minutes(List<HistoryModel> logtimesList)
        {
            DateTime last = logtimesList[0].Logtime;
            return last.AddMinutes(5) < DateTime.Now;
        }

        /// <summary>
        /// TimeSpanの時間(分と秒)を文字列にする
        /// </summary>
        /// <param name="Time"></param>
        /// <returns></returns>
        public string GetMinutesTimeSpanToString(TimeSpan Time)
        {
            return $"{Time.Minutes:D2}:{Time.Seconds:D2}";
        }

        /// <summary>
        /// timeに5分足したものから現在時刻を引く
        /// </summary>
        /// <param name="time">直近3件の失敗した時間の一番古い時間</param>
        /// <returns></returns>
        public string GetLockTime(DateTime time)
        {
            return GetMinutesTimeSpanToString(time.AddMinutes(5) - DateTime.Now);
        }
    }
}
