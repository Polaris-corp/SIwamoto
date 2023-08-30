using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IScalc.Service;
using IScalc.Model;
using IScalc.Common;


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
        /// <returns>ユーザーIDがあるか(有る: true, 無し: false)</returns>
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
        public bool CheckAccount(string id, string pwd)
        {
            return userService.GetUsersAccountCount(id, pwd) == 1;
        }

        /// <summary>
        /// ログイン履歴をデータベースに追加する
        /// </summary>
        /// <param name="id">ユーザーが入力したID</param>
        /// <param name="res">ログイン結果</param>
        /// <returns></returns>
        public void InsertHisotry(string id ,bool res ,DateTime tryLoginTime)
        {
             historyService.InsertLoginHistory(id, res, tryLoginTime);
        }

        /// <summary>
        /// 直近3件ログイン履歴のチェック
        /// </summary>
        /// <param name="id"></param>
        /// <returns>直近3件でログイン失敗した場合のログイン試行した時間を追加したリスト(0～3件、降順)
        /// </returns>
        public List<HistoryModel> Check3LoginHistory(string id)
        {
            return historyService.CreateDateTimes(id);
        }

        /// <summary>
        /// 3回連続で間違えているか、間違えていた場合その間隔が3分以内かの判定
        /// </summary>
        /// <param name="logtimesList">直近のログイン失敗した時間のリスト(0～3件、降順)</param>
        /// <returns>どちらの条件も満たしていたら「false」それ以外は「true」</returns>
        public bool CheckLogtime(List<HistoryModel> logtimesList)
        {
            if(logtimesList.Count != VariousNumbers.JudgeNum)
            {
                return true;
            }
          
            return VariousNumbers.JudgeNum < (logtimesList[0].Logtime - logtimesList[2].Logtime).TotalMinutes;
        }

        /// <summary>
        /// 最後にログインに失敗してアカウントがロックされてから5分経過しているかの判定
        /// </summary>
        /// <param name="logtimesList"></param>
        /// <returns></returns>
        public bool CheckLast5Minutes(List<HistoryModel> logtimesList, DateTime tryLoginTime)
        {
            DateTime last = logtimesList[0].Logtime;
            return last.AddMinutes(VariousNumbers.AddMin) < tryLoginTime;
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
        /// <param name="time">直近3件の失敗した時間の一番新しい時間</param>
        /// <returns></returns>
        public string GetLockTime(DateTime time, DateTime tryLoginTime)
        {
            return GetMinutesTimeSpanToString(time.AddMinutes(VariousNumbers.AddMin) - tryLoginTime);
        }

        
    }
}
