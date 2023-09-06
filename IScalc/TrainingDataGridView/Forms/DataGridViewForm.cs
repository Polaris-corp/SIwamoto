using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainingDataGridView.Controller;
using TrainingDataGridView.Common;
using TrainingDataGridView.Model;

namespace TrainingDataGridView.Forms
{
    public partial class DataGridViewForm : Form
    {
        public DataGridViewForm()
        {
            InitializeComponent();
        }

        DGVController dgvController = new DGVController();
        DataTable dt = new DataTable();

        private void Form1_Load(object sender, EventArgs e)
        {
            GetDataTableItem();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            LoadAccountForm(ConstValues.Fresh, new UsersModel());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadAccountForm(ConstValues.Update, GetDgvRowItem());
        }

        private void btnUpdateDB_Click(object sender, EventArgs e)
        {
            GetDataTableItem();
        }

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
