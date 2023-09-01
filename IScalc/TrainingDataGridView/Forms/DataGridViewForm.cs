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
        TextModel textModel = new TextModel();
        
        DataTable dt = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt;
            dgvController.IndicateUsersInfo(dt);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textModel.Form2Button = ButtonName.NewAccount;
            AccountForm accountForm = new AccountForm();
            accountForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textModel.Form2Button = ButtonName.ExistingAccount;
            AccountForm accountForm = new AccountForm();
            accountForm.ShowDialog();
        }
    }
}
