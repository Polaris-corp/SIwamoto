using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySqlConnector;
using System.Collections.Generic;
using IScalc.Common;
using IScalc.Controller;
using IScalc.Model;

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
                MessageBox.Show(MessageItem.NOT_INPUT);
                return;
            }

            //IDがあるかチェック 
            try
            {
                if (!loginController.CheckUsersID(id))
                {
                    MessageBox.Show(MessageItem.NOT_USER);
                    return;
                }

                //IDとPWの紐づきデータのチェック
                if (!loginController.Check_account(id, pwd))
                {
                    loginController.Insert_Hisotry(id, MessageItem.NG);
                    MessageBox.Show(MessageItem.WRONG_PWD);

                    return;
                }
                
                //そのIDの履歴直近3件取得 
                List<HistoryModel> historyModels = loginController.Check_3_Login_History(id);

                //ログイン履歴のチェック
                if (!loginController.Check_Logtime(historyModels))
                {
                    if (!loginController.Check_Last5Minutes(historyModels))
                    {
                        string t = loginController.GetLockTime(historyModels[2].Logtime);

                        MessageBox.Show(string.Format(MessageItem.REMAINING_TIME, t));
                        return;
                    }
                }

                //ログイン成功
                loginController.Insert_Hisotry(id, MessageItem.OK);
                MessageBox.Show(MessageItem.LOGIN_SUCCES);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
