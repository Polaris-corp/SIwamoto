using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IScalc.Controller;
using IScalc.Common;
using IScalc.Model;

namespace IScalc.View
{
    public partial class DataGridViewForm : Form
    {
        public DataGridViewForm()
        {
            InitializeComponent();
        }

        DGVController dgvController = new DGVController();
        DataTable dt = new DataTable();

        private UsersModel GetDgvRowItem()
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            UsersModel user = new UsersModel();
            user.Id = selectedRow.Cells["ID"].Value.ToString();
            user.Name = selectedRow.Cells["Name"].Value.ToString();
            user.Pwd = selectedRow.Cells["Pwd"].Value.ToString();
            return user;
        }

        private void GetDataTableItem()
        {
            dt = dgvController.IndicateUsersInfo();
            dataGridView1.DataSource = dt;
        }

        private void LoadAccountForm(bool flg, UsersModel user)
        {
            AccountForm accountForm = new AccountForm(flg);
            accountForm.user = user;
            accountForm.ShowDialog();
            accountForm.Dispose();
        }


        private void GetDeletedDataTableItem()
        {
            dt = dgvController.GetDeletedUserInfo();
            dataGridView1.DataSource = dt;
        }

        private void DataGridViewForm_Load(object sender, EventArgs e)
        {
            GetDataTableItem();
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            LoadAccountForm(ConstValues.Fresh, new UsersModel());
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            LoadAccountForm(ConstValues.Update, GetDgvRowItem());
        }

        private void btnUpdateDB_Click_1(object sender, EventArgs e)
        {
            GetDataTableItem();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowDeletedUserbtn_Click(object sender, EventArgs e)
        {
            GetDeletedDataTableItem();
        }
    }
}
