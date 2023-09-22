using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IScalc.Common;
using IScalc.Model;
using IScalc.Controller;

namespace IScalc.View
{
    /// <summary>
    /// ユーザー情報の変更、新規登録を行う画面の処理
    /// </summary>
    public partial class AccountForm : Form
    {
       /// <summary>
       /// 新規登録なのかユーザー情報の変更、復旧なのかの判定
       /// 及びそれに必要なユーザー情報の受け取り
       /// </summary>
       /// <param name="Update">新規登録か変更なのか(false , true)</param>
       /// <param name="usersInfo">ユーザー情報(新規ならばdeleted以外空、deletedはfalse)</param>
        public AccountForm(bool Update, UsersModel usersInfo)
        {
            InitializeComponent();
            user = usersInfo;
            panel1.Visible = Update;

        }

        AccountController accountController = new AccountController();

        UsersModel user;
        
        /// <summary>
        /// AccountFormが呼び出されたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountForm_Load_1(object sender, EventArgs e)
        {
            userIDlabel.Text = user.Id;
            userNameTextBox.Text = user.Name;
            userPwdTextBox.Text = user.Pwd;
            chkDeleted.Checked = user.Deleted;
        }

        /// <summary>
        /// 新規登録ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            user.Name = userNameTextBox.Text;
            user.Pwd = userPwdTextBox.Text;
            user.Deleted = chkDeleted.Checked;

            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Pwd))
            {
                MessageBox.Show(FormMessageItem.AccountFormWarning);
                return;
            }

            accountController.InsertAccountInfo(user);
        }

        /// <summary>
        /// ユーザー情報削除ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            accountController.DeleteAccountInfo(Convert.ToInt32(user.Id));
            this.Close();
        }

        /// <summary>
        /// 更新ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            user.Name = userNameTextBox.Text;
            user.Pwd = userPwdTextBox.Text;
            user.Deleted = chkDeleted.Checked;

            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Pwd))
            {
                MessageBox.Show(FormMessageItem.AccountFormWarning);
                return;
            }
            accountController.UpdateAccountInfo(user);
            this.Close();
        }

       
    }
}
