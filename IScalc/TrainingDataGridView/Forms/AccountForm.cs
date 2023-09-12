using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainingDataGridView.Common;
using TrainingDataGridView.Model;
using TrainingDataGridView.Controller;

namespace TrainingDataGridView.Forms
{
    public partial class AccountForm : Form
    {
        //public AccountForm()
        //{
        //    InitializeComponent();
        //    btnCreateOrUpdate.Text = ConstValues.NewAccount;
        //}

        public AccountForm(bool update)
        {
            InitializeComponent();
            Createflg = update;

            btnCreate.Text = update ? ConstValues.NewAccount : ConstValues.UpdateAccount;
        }

        AccountController accountController = new AccountController();
        DGVController dgvController = new DGVController();

        bool Createflg = true;
        public UsersModel user { get; set; }
        DataTable dt = new DataTable();

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string Name = userNameTextBox.Text;
            string Pwd = userPwdTextBox.Text;

            if (Createflg)
            {
                accountController.InsertAccountInfo(Name, Pwd);
            }
            else
            {
                accountController.UpdateAccountInfo(Convert.ToInt32(user.Id), Name, Pwd);
            }
            this.Close();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            userIDlabel.Text = user.Id;
            userNameTextBox.Text = user.Name;
            userPwdTextBox.Text = user.Pwd;
            GetDataTableItem();
            if (Createflg)
            {
                btnDelete.Enabled = false;
                btnDelete.Visible = false;
            }
            else
            {
                btnDelete.Enabled = true;
                btnDelete.Visible = true;
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            accountController.DeleteAccountInfo(Convert.ToInt32(user.Id));
        }

        private void ShowDeletedAccount_Click(object sender, EventArgs e)
        {
            GetDeletedDataTableItem();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            GetAllDataTableItem();
        }

        private void GetDataTableItem()
        {
            dt = accountController.GetUserInfo();
            dataGridView1.DataSource = dt;
        }

        private void GetAllDataTableItem()
        {
            dt = accountController.GetAllUserInfo();
            dataGridView1.DataSource = dt;
        }

        private void GetDeletedDataTableItem()
        {
            dt = accountController.GetDeletedUserInfo();
            dataGridView1.DataSource = dt;
        }
    }
}
