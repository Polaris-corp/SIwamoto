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
                MessageBox.Show(FormMessageItem.NotInput);
                return;
            }
            try
            {
                //IDがあるかチェック
                if (!loginController.CheckUsersID(id))
                {
                    MessageBox.Show(FormMessageItem.NotUser);
                    return;
                }

                //IDとPWの紐づきデータのチェック
                if (!loginController.CheckAccount(id, pwd))
                {
                    loginController.InsertHisotry(id, FormResults.Ng);
                    MessageBox.Show(FormMessageItem.WrongPassword);

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

                        MessageBox.Show(string.Format(FormMessageItem.RemainigTime, t));
                        return;
                    }
                }

                //ログイン成功
                loginController.InsertHisotry(id, FormResults.Ok);
                MessageBox.Show(FormMessageItem.LoginSucces);
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
