using IScalc.Common;
using IScalc.Controller;
using IScalc.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using IScalc.Service;

namespace IScalc.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        LoginController loginController = new LoginController();
        DataGridViewForm dataGridView = new DataGridViewForm();


        /// <summary>
        /// ログインボタンが押されたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Loginbtn_Click(object sender, EventArgs e)
        {
            
            //IDとPWを受け取る　
            string id = textBox1.Text;
            string pwd = textBox2.Text;
            //入力チェック　
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show(FormMessageItem.NotInput);
                return;
            }

            if (!int.TryParse(id,out int userid))
            {
                MessageBox.Show(FormMessageItem.Warning);
                return;
            }
            //現在時刻の取得
            DateTime tryLoginTime = DateTime.Now;

            try
            {
                //IDがあるかチェック
                if (!loginController.CheckUsersID(userid))
                {
                    MessageBox.Show(FormMessageItem.NotUser);
                    return;
                }

                //IDとPWの紐づきデータのチェック
                if (!loginController.CheckAccount(userid, pwd))
                {
                    loginController.InsertHisotry(userid, FormResults.Ng, tryLoginTime);
                    MessageBox.Show(FormMessageItem.WrongPassword);

                    return;
                }

                //そのIDの履歴直近3件の最新のログイン試行時間、最古のログイン試行時間、ログイン失敗数を取得 
                HistoryModel historyModels = loginController.Check3LoginHistory(userid);
                DateTime latestLogTime = historyModels.LatestLogtime;
                DateTime oldestLogTime = historyModels.OldestLogtime;
                int count = historyModels.Count;

                //ログイン履歴のチェック
                if (!loginController.CheckLogtime(latestLogTime, oldestLogTime, count))
                {
                    if (!loginController.CheckLast5Minutes(latestLogTime, tryLoginTime))
                    {
                        string t = loginController.GetLockTime(latestLogTime, tryLoginTime);

                        MessageBox.Show(string.Format(FormMessageItem.RemainigTime, t));
                        return;
                    }
                }

                //ログイン成功
                loginController.InsertHisotry(userid, FormResults.Ok, tryLoginTime);
                MessageBox.Show(FormMessageItem.LoginSucces);
                dataGridView.ShowDialog();
                dataGridView.Dispose();
            }
            catch (Exception ex)
            {
                ErrorLog errorLog = new ErrorLog();
                errorLog.WriteStackTraceToTxt(ex, tryLoginTime);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
           
        }

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            AccountForm accountForm = new AccountForm(true);
            UsersModel user = new UsersModel();
            accountForm.user = user;
            accountForm.ShowDialog();
            accountForm.Dispose();
        }
    }
}
