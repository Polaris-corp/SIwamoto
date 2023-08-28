using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IScalc.Service;
using IScalc.Model;
using System.Diagnostics;
using System.IO;

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
        public bool InsertHisotry(string id ,bool res)
        {
            return historyService.InsertLoginHistory(id, res);
        }

        /// <summary>
        /// 直近3件ログイン履歴のチェック
        /// </summary>
        /// <param name="id"></param>
        /// <returns>直近3件で連続してログイン失敗した場合の
        /// ログイン試行した時間3件を追加したリスト</returns>
        public List<HistoryModel> Check3LoginHistory(string id)
        {
            return historyService.CreateDateTimes(id);
        }

        /// <summary>
        /// 3回連続で間違えているか、間違えていた場合その間隔が3分以内かの判定
        /// </summary>
        /// <param name="logtimesList">直近3件のログイン失敗した時間のリスト(降順)</param>
        /// <returns>どちらの条件も満たしていたら「false」それ以外は「true」</returns>
        public bool CheckLogtime(List<HistoryModel> logtimesList)
        {
            if(logtimesList.Count != 3)
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
        public bool CheckLast5Minutes(List<HistoryModel> logtimesList)
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

        public void WriteStackTraceToTxt(Exception ex)
        {
            string errFolderPath = @"C:\Users\USER\Source\Repos\SIwamoto\IScalc\IScalc\ErrorLog";

            if (!Directory.Exists(errFolderPath))
            {
                Directory.CreateDirectory(errFolderPath);
            }

            string errorInfo = $"エラーメッセージ: {ex.Message}" +
                               $"\nスタックトレース:\n{ex.StackTrace}";

            string filePath = Path.Combine(errFolderPath, $"error_{DateTime.Now:yyyyMMdd_HHmmss}.txt");


            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("---エラーログ開始---");
                writer.WriteLine(DateTime.Now.ToString());
                writer.WriteLine(errorInfo);
                writer.WriteLine("---エラーログ終了---");
                writer.WriteLine();
            }
        }
    }
}
