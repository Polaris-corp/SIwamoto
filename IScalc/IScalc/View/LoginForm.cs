using IScalc.Common;
using IScalc.Controller;
using IScalc.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace IScalc.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        LoginController loginController = new LoginController();

        /// <summary>
        /// ログインボタンが押されたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //IDとPWを受け取る　
            string id = textBox1.Text;
            string pwd = textBox2.Text;
            
            //入力チェック　
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show(FormItem.NOT_INPUT);
                return;
            }
            try
            {
                //IDがあるかチェック
                if (!loginController.CheckUsersID(id))
                {
                    MessageBox.Show(FormItem.NOT_USER);
                    return;
                }

                //IDとPWの紐づきデータのチェック
                if (!loginController.CheckAccount(id, pwd))
                {
                    loginController.InsertHisotry(id, FormItem.NG);
                    MessageBox.Show(FormItem.WRONG_PWD);

                    return;
                }

                //そのIDの履歴直近3件取得 
                List<HistoryModel> historyModels = loginController.Check3LoginHistory(id);

                //ログイン履歴のチェック
                if (!loginController.CheckLogtime(historyModels))
                {
                    if (!loginController.CheckLast5Minutes(historyModels))
                    {
                        string t = loginController.GetLockTime(historyModels[0].Logtime);

                        MessageBox.Show(string.Format(FormItem.REMAINING_TIME, t));
                        return;
                    }
                }

                //ログイン成功
                loginController.InsertHisotry(id, FormItem.OK);
                MessageBox.Show(FormItem.LOGIN_SUCCES);
            }
            catch(Exception ex)
            {
                ErrorLog errorLog = new ErrorLog();
                errorLog.WriteStackTraceToTxt(ex);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
