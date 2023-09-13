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
    public partial class AccountForm : Form
    {
       
        public AccountForm(bool Update, UsersModel usersInfo)
        {
            InitializeComponent();
            user = usersInfo;
            panel1.Visible = Update;
        }

        AccountController accountController = new AccountController();

        UsersModel user;
        
        private void AccountForm_Load_1(object sender, EventArgs e)
        {
            userIDlabel.Text = user.Id;
            userNameTextBox.Text = user.Name;
            userPwdTextBox.Text = user.Pwd;
            chkDeleted.Checked = user.Deleted;
        }

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            accountController.DeleteAccountInfo(Convert.ToInt32(user.Id));
        }

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
