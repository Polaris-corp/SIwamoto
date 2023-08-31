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
        public bool CheckUsersID(int id)
        {
            return userService.ExistUsersID(id);
        }

        /// <summary>
        /// IDとPWの紐づきデータの確認
        /// </summary>
        /// <param name="id">ユーザーが入力したID</param>
        /// <param name="pwd">ユーザーが入力したPWD</param>
        /// <returns>紐づきデータがあれば「true」無ければ「false」</returns>
        public bool CheckAccount(int id, string pwd)
        {
            return userService.GetUsersAccountCount(id, pwd) == 1;
        }

        /// <summary>
        /// ログイン履歴をデータベースに追加する
        /// </summary>
        /// <param name="id">ユーザーが入力したID</param>
        /// <param name="res">ログイン結果</param>
        /// <returns></returns>
        public void InsertHisotry(int id ,bool res ,DateTime tryLoginTime)
        {
             historyService.InsertLoginHistory(id, res, tryLoginTime);
        }

        /// <summary>
        /// 直近3件ログイン履歴のチェック
        /// </summary>
        /// <param name="id"></param>
        /// <returns>直近3件の履歴の中で最新のログイン試行時間、最古のログイン試行時間、ログイン失敗数を
        /// HistoryModelのプロパティに代入する
        /// </returns>
        public HistoryModel Check3LoginHistory(int id)
        {
            return historyService.CreateDateTimes(id);
        }

        /// <summary>
        /// ログイン失敗数が3回以下か、3回失敗していたらその間が3分経過しているかの判定
        /// </summary>
        /// <param name="latestLogTime">最新のログイン試行時間</param>
        /// <param name="oldestLogTime">最古のログイン試行時間</param>
        /// <param name="count">ログイン失敗数</param>
        /// <returns></returns>
        public bool CheckLogtime(DateTime latestLogTime, DateTime oldestLogTime, int count)
        {
            if(count != VariousNumbers.JudgeNum)
            {
                return true;
            }
          
            return VariousNumbers.JudgeNum < (latestLogTime - oldestLogTime).TotalMinutes;
        }

        /// <summary>
        /// 最後にログインに失敗してアカウントがロックされてから5分経過しているかの判定
        /// </summary>
        /// <param name="logtimesList"></param>
        /// <returns></returns>
        public bool CheckLast5Minutes(DateTime latestLogTime, DateTime tryLoginTime)
        {
            DateTime last = latestLogTime;
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
