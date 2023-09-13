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
       
        public AccountForm(bool update, UsersModel usersInfo)
        {
            InitializeComponent();
            Createflg = update;
            user = usersInfo;

            btnCreate.Text = update ? ConstValues.NewAccount : ConstValues.UpdateAccount;
        }

        AccountController accountController = new AccountController();

        bool Createflg = true;
        UsersModel user;
        
        private void AccountForm_Load_1(object sender, EventArgs e)
        {
            userIDlabel.Text = user.Id;
            userNameTextBox.Text = user.Name;
            userPwdTextBox.Text = user.Pwd;
            if (Createflg)
            {
                btnDelete.Enabled = false;
                btnDelete.Visible = false;
                btnRestorationUser.Enabled = false;
                btnRestorationUser.Visible = false;
            }
            else
            {
                btnDelete.Enabled = true;
                btnDelete.Visible = true;
            }
        }

        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            string Name = userNameTextBox.Text;
            string Pwd = userPwdTextBox.Text;

            if (Createflg)
            {
                if(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Pwd))
                {
                    MessageBox.Show(FormMessageItem.AccountFormWarning);
                    return;
                }
                else
                {
                    accountController.InsertAccountInfo(Name, Pwd);
                }
            }
            else
            {
                accountController.UpdateAccountInfo(Convert.ToInt32(user.Id), Name, Pwd);
                this.Close();
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            accountController.DeleteAccountInfo(Convert.ToInt32(user.Id));
        }

        private void btnRestorationUser_Click(object sender, EventArgs e)
        {
            accountController.RestorationAccountInfo(Convert.ToInt32(user.Id));
        }

    }
}
